using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RealTemp4RTSS
{
    public class RTSSController : IDisposable
    {
        private MemoryMappedFile _mmf = null;
        private MemoryMappedViewAccessor _view = null;
        private string _appId = null;
        private HashSet<int> _registeredSlots = null;

        protected internal Interop.RTSS_SHARED_MEMORY Snapshot;
        protected internal List<KeyValuePair<string, string>> OSDSlots = null;

        protected internal const int FIRST_AVAILABLE_SLOT = 1;

        public float RTSSVersion { get; private set; }

        public RTSSController()
            : this(System.Reflection.Assembly.GetEntryAssembly().GetName().Name)
        {
        }

        public RTSSController(string appId)
        {
            _mmf = MemoryMappedFile.OpenExisting("RTSSSharedMemoryV2");
            _view = _mmf.CreateViewAccessor();
            _appId = appId;

            Refresh();

            ValidateUniqueAppId();
        }

        public void Refresh()
        {
            _view.Read<Interop.RTSS_SHARED_MEMORY>(0, out Snapshot);

            if (Snapshot.dwSignature != Interop.VALID_SIGNATURE)
            {
                throw new InvalidOperationException("RTSS is unavailable at this time");
            }
            RTSSVersion = (Snapshot.dwVersion >> 16) + ((float)(Snapshot.dwVersion & 0x0000FFFF) / 10f);

            if (RTSSVersion < 2.0f)
            {
                throw new InvalidOperationException("RTSS version is too old; only version 2.0 and newer are supported");
            }
            var tempSlots = new List<KeyValuePair<string, string>>((int)Snapshot.dwOSDArrSize);

            for (int osdSlot = 0; osdSlot < Snapshot.dwOSDArrSize; osdSlot++)
            {
                Interop.RTSS_SHARED_MEMORY_OSD_ENTRY osdEntry;
                try
                {
                    _view.Read<Interop.RTSS_SHARED_MEMORY_OSD_ENTRY>(Snapshot.dwOSDArrOffset + (Snapshot.dwOSDEntrySize * osdSlot), out osdEntry);
                    tempSlots.Add(new KeyValuePair<string, string>(osdEntry.szOSDOwner.ToString(), osdEntry.szOSD.ToString()));
                }
                catch (Exception ex)
                {
                    // Couldn't get the information for this slot so just put the exception message in it instead so it looks "filled".
                    tempSlots.Add(new KeyValuePair<string, string>("@Exception", ex.Message));
                }
            }
            OSDSlots = tempSlots;
        }

        public int SetOSDValue(string value)
        {
            return SetOSDValue(-1, value);
        }

        public int SetOSDValue(int osdSlot, string value)
        {
            if (osdSlot == -1)
                osdSlot = RegisterSlot();

            if (osdSlot != -1)
            {
                if (!CheckAndSetSlot(osdSlot, _appId, value))
                    osdSlot = -2;
            }
            return osdSlot;
        }

        public bool ClearOSDValue(int osdSlot)
        {
            bool result = false;

            if ((osdSlot >= FIRST_AVAILABLE_SLOT) && (osdSlot <= OSDSlots.Count))
            {
                result = CheckAndSetSlot(osdSlot, null, null);
            }
            return result;
        }

        private void ValidateUniqueAppId()
        {
            if (_appId == null)
                throw new ArgumentNullException("appId", "The Application Id must be initialised to a valid, unique value");

            if (_appId.Length > 255)
                throw new ArgumentException("The Application Id must be 255 characters or less");

            if (OSDSlots.FindIndex(m => m.Key == _appId) != -1)
                throw new ArgumentException("The Application Id specified is already in use");
        }

        protected internal int RegisterSlot()
        {
            Refresh();

            int idx = 0;

            foreach (var slot in OSDSlots)
            {
                if (slot.Key == null)
                {
                    if (_registeredSlots == null)
                        _registeredSlots = new HashSet<int>();

                    _registeredSlots.Add(idx);

                    return idx;
                }
                idx++;
            }
            return -1;
        }

        protected internal bool UnregisterSlots(params int[] slotIndexes)
        {
            bool result = true;

            Refresh();

            foreach (int slotIndex in slotIndexes)
            {
                if ((slotIndex >= FIRST_AVAILABLE_SLOT) && (slotIndex <= OSDSlots.Count) && (OSDSlots[slotIndex].Key == _appId))
                {
                    if (!CheckAndSetSlot(slotIndex, null, null))
                    {
                        result &= false;
                    }
                }
                else
                {
                    result &= false;
                }
            }
            return result;
        }

        protected internal virtual bool CheckAndSetSlot(int slotIndex, string owner, string value)
        {
            bool result = false;

            Interop.RTSS_SHARED_MEMORY_OSD_ENTRY osdEntry;
            _view.Read<Interop.RTSS_SHARED_MEMORY_OSD_ENTRY>(Snapshot.dwOSDArrOffset + (Snapshot.dwOSDEntrySize * slotIndex), out osdEntry);

            if (osdEntry.IsEmpty || osdEntry.szOSDOwner.ToString() == _appId)
            {
                osdEntry.szOSDOwner.SetValue(owner);
                osdEntry.szOSD.SetValue(value);

                _view.Write<Interop.RTSS_SHARED_MEMORY_OSD_ENTRY>(Snapshot.dwOSDArrOffset + (Snapshot.dwOSDEntrySize * slotIndex), ref osdEntry);
                OSDSlots[slotIndex] = new KeyValuePair<string, string>(owner, value);

                result = true;
            }
            return result;
        }

        public void Dispose()
        {
            if (_registeredSlots != null)
            {
                UnregisterSlots(_registeredSlots.ToArray());
            }
            _view.Dispose();
            _mmf.Dispose();
        }

        protected internal class Interop
        {
            public struct RTSS_SHARED_MEMORY
            {
                public UInt32 dwSignature;
                public UInt32 dwVersion;
                public UInt32 dwAppEntrySize;
                public UInt32 dwAppArrOffset;
                public UInt32 dwAppArrSize;
                public UInt32 dwOSDEntrySize;
                public UInt32 dwOSDArrOffset;
                public UInt32 dwOSDArrSize;
                public UInt32 dwOSDFrame;
            }

            [StructLayout(LayoutKind.Sequential, Pack = 0)]
            public struct RTSS_SHARED_MEMORY_OSD_ENTRY
            {
                public OSD_STRING szOSD;
                public OSD_STRING szOSDOwner;

                public bool IsEmpty
                {
                    get { return szOSDOwner.IsNull; }
                }
            }

            [StructLayout(LayoutKind.Sequential, Pack = 0)]
            public unsafe struct OSD_STRING
            {
                public fixed sbyte Data[256];

                public bool IsNull
                {
                    get
                    {
                        fixed (sbyte* b = Data)
                        {
                            return *b == 0;
                        }
                    }
                }

                public override string ToString()
                {
                    fixed (sbyte* b = Data)
                    {
                        int endPoint = 0;
                        while ((endPoint <= 256) && (b[endPoint] != 0))
                            endPoint++;

                        return (endPoint == 0 ? null : new string(b, 0, endPoint));
                    }
                }

                public void SetValue(string str)
                {
                    byte[] strBytes = (str == null ? new byte[0] : Encoding.GetEncoding(1252).GetBytes(str));
                    int strBytesLen = strBytes.Length;

                    fixed (sbyte* b = Data)
                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            if (i < strBytesLen)
                                b[i] = (sbyte)strBytes[i];
                            else
                                b[i] = 0;
                        }
                    }
                }
            }

            public static readonly UInt32 VALID_SIGNATURE = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("RTSS").Reverse().ToArray(), 0);
        }
    }
}
