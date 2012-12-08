using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RealTemp4RTSS
{
    public class RealTemp
    {
        private const int ABSOLUTE_MINIMUM_REFRESH_TIME = 500;
        private const int ABSOLUTE_MAXIMUM_REFRESH_TIME = 60000;

        #region Public Enums / Classes

        public enum TemperatureUnit
        {
            Unknown,
            [Description("°C")]
            Celcius,
            [Description("°F")]
            Faranheit
        }

        public enum FrequencyUnit
        {
            Unknown,
            MHz,
            GHz
        }

        public class Measurement<T>
        {
            public const int DEFAULT_DECIMAL_PLACES = 2;

            public Measurement(decimal value, T unit, int decimalPlaces)
            {
                Value = value;
                Unit = unit;
                DecimalPlaces = decimalPlaces;
            }

            public Measurement(decimal value, T unit)
            {
                Value = value;
                Unit = unit;
                DecimalPlaces = DEFAULT_DECIMAL_PLACES;
            }

            public decimal Value { get; private set; }
            public T Unit { get; private set; }
            public decimal DecimalPlaces { get; private set; }

            public override string ToString()
            {
                string unit = null;
                if (typeof(T).IsEnum)
                {
                    unit = ((Enum)(object)Unit).GetDescription();
                }
                else unit = Unit.ToString();

                return string.Format("{0:F" + DecimalPlaces.ToString() + "} {1}", Value, unit);
            }
        }
        #endregion

        private RealTemp()
        {
            cache = InitialiseCache();
        }

        private static RealTemp instance = null;
        private Dictionary<RealTempControlID, RealTempControl> cache = null;
        private DateTime lastRefresh = DateTime.MinValue;
        private int minRefreshTime = 1000;

        #region Static Interface

        public static RealTemp GetInstance()
        {
            if (instance == null)
                instance = new RealTemp();

            return instance;
        }
        #endregion

        #region Properties

        public int MinimumRefreshTime
        {
            get { return minRefreshTime; }
            set
            {
                if (value < ABSOLUTE_MINIMUM_REFRESH_TIME)
                    throw new ArgumentException("Minimum refresh time cannot be less than " + ABSOLUTE_MINIMUM_REFRESH_TIME + "ms");
                else if (value > ABSOLUTE_MAXIMUM_REFRESH_TIME)
                    throw new ArgumentException("Minimum refresh time cannot be more than " + ABSOLUTE_MAXIMUM_REFRESH_TIME + "ms");

                minRefreshTime = value;
            }
        }

        #endregion

        #region Methods

        #region IsRealTempAvailable

        public bool IsRealTempAvailable()
        {
            Process[] processes = Process.GetProcessesByName("RealTemp");
            return ((processes != null) && (processes.Length > 0));
        }
        #endregion

        #region GetCoreCount

        public int GetCoreCount()
        {
            return InternalGetCoreCount(null);
        }
        #endregion

        #region GetCoreTemperature

        public Measurement<TemperatureUnit> GetCoreTemperature(int core)
        {
            var cache = GetCache();

            return InternalGetCoreTemperature(cache, core);
        }
        #endregion

        #region GetHighestCoreTemperature

        public Measurement<TemperatureUnit> GetHighestCoreTemperature()
        {
            var cache = GetCache();

            return InternalGetHighestCoreTemperature(cache);
        }
        #endregion

        #region GetCoreTJMaxDistance

        public Measurement<TemperatureUnit> GetCoreTJMaxDistance(int core)
        {
            var cache = GetCache();

            return InternalGetCoreTJMaxDistance(cache, core);
        }
        #endregion

        #region GetFrequency

        public Measurement<FrequencyUnit> GetFrequency()
        {
            var cache = GetCache();

            return InternalGetFrequency(cache);
        }
        public Measurement<FrequencyUnit> GetFrequency(FrequencyUnit unit)
        {
            var cache = GetCache();

            return InternalGetFrequency(cache, unit);
        }
        #endregion

        #region GetLoad

        public decimal GetLoad()
        {
            var cache = GetCache();

            return InternalGetLoad(cache);
        }
        #endregion

        #region GetFormattedString

        public string GetFormattedString(string format)
        {
            var cache = GetCache();

            return Regex.Replace(format, "{\\w+}",
                new MatchEvaluator((m) =>
                    {
                        string replacement = m.Value;

                        switch (m.Value.ToLower())
                        {
                            case "{cores}":
                                replacement = InternalGetCoreCount(cache).ToString();
                                break;
                            case "{frequency}":
                                replacement = InternalGetFrequency(cache).ToString();
                                break;
                            case "{frequency_mhz}":
                                replacement = InternalGetFrequency(cache, FrequencyUnit.MHz).ToString();
                                break;
                            case "{frequency_ghz}":
                                replacement = InternalGetFrequency(cache, FrequencyUnit.GHz).ToString();
                                break;
                            case "{coretemp}":
                                replacement = InternalGetHighestCoreTemperature(cache).ToString();
                                break;
                            case "{coretemp0}":
                                replacement = InternalGetCoreTemperature(cache, 0).ToString();
                                break;
                            case "{coretemp1}":
                                replacement = InternalGetCoreTemperature(cache, 1).ToString();
                                break;
                            case "{coretemp2}":
                                replacement = InternalGetCoreTemperature(cache, 2).ToString();
                                break;
                            case "{coretemp3}":
                                replacement = InternalGetCoreTemperature(cache, 3).ToString();
                                break;
                            case "{load}":
                                replacement = InternalGetLoad(cache).ToString();
                                break;
                        }
                        return replacement;
                    }
                )
            );
        }
        #endregion

        #endregion

        #region Internal Methods

        #region InternalGetCoreCount

        private int InternalGetCoreCount(Dictionary<RealTempControlID, RealTempControl> cache)
        {
            if (cache == null)
                cache = GetCache();

            int cores = 0;

            for (int i = 0; i < 4; i++)
            {
                RealTempControlID ctrlId;

                switch (i)
                {
                    case 0:
                        ctrlId = RealTempControlID.CoreZeroTemp;
                        break;
                    case 1:
                        ctrlId = RealTempControlID.CoreOneTemp;
                        break;
                    case 2:
                        ctrlId = RealTempControlID.CoreTwoTemp;
                        break;
                    case 3:
                        ctrlId = RealTempControlID.CoreThreeTemp;
                        break;
                    default:
                        throw new InvalidOperationException("Satisfy Compiler");
                }
                if (!string.IsNullOrEmpty(cache[ctrlId].Value))
                    cores++;
            }
            return cores;
        }
        #endregion

        #region InternalGetCoreTemperature

        private Measurement<TemperatureUnit> InternalGetCoreTemperature(Dictionary<RealTempControlID, RealTempControl> cache, int core)
        {
            if (core < 0 || core >= InternalGetCoreCount(cache))
                throw new ArgumentException("The value specified for the core is invalid");

            int result;
            string value = null;

            switch (core)
            {
                case 0:
                    value = cache[RealTempControlID.CoreZeroTemp].Value;
                    break;
                case 1:
                    value = cache[RealTempControlID.CoreOneTemp].Value;
                    break;
                case 2:
                    value = cache[RealTempControlID.CoreTwoTemp].Value;
                    break;
                case 3:
                    value = cache[RealTempControlID.CoreThreeTemp].Value;
                    break;
            }
            if (int.TryParse(value, out result))
                return new Measurement<TemperatureUnit>(result, InternalGetTemperatureUnit(cache), 0);
            else
                return null;
        }
        #endregion

        #region InternalGetHighestCoreTemperature

        private Measurement<TemperatureUnit> InternalGetHighestCoreTemperature(Dictionary<RealTempControlID, RealTempControl> cache)
        {
            int[] coreTemps = new int[4];

            if (!int.TryParse(cache[RealTempControlID.CoreZeroTemp].Value, out coreTemps[0]))
                coreTemps[0] = 0;
            if (!int.TryParse(cache[RealTempControlID.CoreOneTemp].Value, out coreTemps[1]))
                coreTemps[1] = 0;
            if (!int.TryParse(cache[RealTempControlID.CoreTwoTemp].Value, out coreTemps[2]))
                coreTemps[2] = 0;
            if (!int.TryParse(cache[RealTempControlID.CoreThreeTemp].Value, out coreTemps[3]))
                coreTemps[3] = 0;

            return new Measurement<TemperatureUnit>(coreTemps.Max(), InternalGetTemperatureUnit(cache), 0);
        }
        #endregion

        #region InternalGetCoreTJMaxDistance

        private Measurement<TemperatureUnit> InternalGetCoreTJMaxDistance(Dictionary<RealTempControlID, RealTempControl> cache, int core)
        {
            if (core < 0 || core >= InternalGetCoreCount(cache))
                throw new ArgumentException("The value specified for the core is invalid");

            int result;
            string value = null;

            switch (core)
            {
                case 0:
                    value = cache[RealTempControlID.CoreZeroTJ].Value;
                    break;
                case 1:
                    value = cache[RealTempControlID.CoreOneTJ].Value;
                    break;
                case 2:
                    value = cache[RealTempControlID.CoreTwoTJ].Value;
                    break;
                case 3:
                    value = cache[RealTempControlID.CoreThreeTJ].Value;
                    break;
            }
            if (int.TryParse(value, out result))
                return new Measurement<TemperatureUnit>(result, InternalGetTemperatureUnit(cache), 0);
            else
                return null;
        }
        #endregion

        #region InternalGetFrequency

        private Measurement<FrequencyUnit> InternalGetFrequency(Dictionary<RealTempControlID, RealTempControl> cache, FrequencyUnit forceUnit = FrequencyUnit.Unknown)
        {
            Measurement<FrequencyUnit> frequency = null;

            Match match = Regex.Match(cache[RealTempControlID.Frequency].Value, "(?<speed>\\d+\\.?\\d*){1}\\s*(?<unit>\\w+){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (match.Success)
            {
                decimal speed;
                FrequencyUnit unit;

                if (decimal.TryParse(match.Groups["speed"].Value, out speed) &&
                    Enum.TryParse<FrequencyUnit>(match.Groups["unit"].Value, true, out unit))
                {
                    if (forceUnit != FrequencyUnit.Unknown && (forceUnit != unit))
                    {
                        switch (forceUnit)
                        {
                            case FrequencyUnit.MHz:
                                speed *= 1000m;
                                break;
                            case FrequencyUnit.GHz:
                                speed /= 1000m;
                                break;
                        }
                        unit = forceUnit;
                    }
                    frequency = new Measurement<FrequencyUnit>(speed, unit);
                }
            }
            return frequency;
        }
        #endregion

        #region InternalGetLoad

        private int InternalGetLoad(Dictionary<RealTempControlID, RealTempControl> cache)
        {
            Match match = Regex.Match(cache[RealTempControlID.Load].Value, "\\d+\\.?\\d*", RegexOptions.Compiled);
            decimal load;
            if (match.Success && decimal.TryParse(match.Value, out load))
            {
                return (int)decimal.Round(load, 0, MidpointRounding.AwayFromZero);
            }
            return -1;
        }
        #endregion

        #region InternalGetTemperatureUnit

        private TemperatureUnit InternalGetTemperatureUnit(Dictionary<RealTempControlID, RealTempControl> cache)
        {
            TemperatureUnit unit = TemperatureUnit.Unknown;

            Match match = Regex.Match(cache[RealTempControlID.TemperatureUnit].Value, "°(?<unit>\\w{1})", RegexOptions.Compiled);
            if (match.Success)
            {
                switch (match.Groups["unit"].Value)
                {
                    case "c":
                    case "C":
                        unit = TemperatureUnit.Celcius;
                        break;
                    case "f":
                    case "F":
                        unit = TemperatureUnit.Faranheit;
                        break;
                }
            }
            return unit;
        }
        #endregion

        #endregion

        #region Cache Management

        private Dictionary<RealTempControlID, RealTempControl> InitialiseCache()
        {
            Dictionary<RealTempControlID, RealTempControl> cache = new Dictionary<RealTempControlID, RealTempControl>();
            cache.Add(RealTempControlID.MainDialog, new RealTempControl(RealTempControlID.MainDialog));
            cache.Add(RealTempControlID.CoreZeroTemp, new RealTempControl(RealTempControlID.CoreZeroTemp));
            cache.Add(RealTempControlID.CoreOneTemp, new RealTempControl(RealTempControlID.CoreOneTemp));
            cache.Add(RealTempControlID.CoreTwoTemp, new RealTempControl(RealTempControlID.CoreTwoTemp));
            cache.Add(RealTempControlID.CoreThreeTemp, new RealTempControl(RealTempControlID.CoreThreeTemp));
            cache.Add(RealTempControlID.CoreZeroTJ, new RealTempControl(RealTempControlID.CoreZeroTJ));
            cache.Add(RealTempControlID.CoreOneTJ, new RealTempControl(RealTempControlID.CoreOneTJ));
            cache.Add(RealTempControlID.CoreTwoTJ, new RealTempControl(RealTempControlID.CoreTwoTJ));
            cache.Add(RealTempControlID.CoreThreeTJ, new RealTempControl(RealTempControlID.CoreThreeTJ));
            cache.Add(RealTempControlID.Frequency, new RealTempControl(RealTempControlID.Frequency));
            cache.Add(RealTempControlID.Load, new RealTempControl(RealTempControlID.Load));
            cache.Add(RealTempControlID.TemperatureUnit, new RealTempControl(RealTempControlID.TemperatureUnit));

            return cache;
        }

        private Dictionary<RealTempControlID, RealTempControl> GetCache()
        {
            if (DateTime.Now.Subtract(lastRefresh).TotalMilliseconds > minRefreshTime)
            {
                RefreshCache();
                lastRefresh = DateTime.Now;
            }
            return cache;
        }

        private void RefreshCache()
        {
            bool fullRefresh = (cache[RealTempControlID.MainDialog].Handle == IntPtr.Zero);

            if (!fullRefresh)
            {
                fullRefresh = !IsRealTempMainWindow(cache[RealTempControlID.MainDialog].Handle);
            }
            if (fullRefresh)
            {
                Process[] processes = Process.GetProcessesByName("RealTemp");
                if ((processes != null) && (processes.Length > 0))
                {
                    List<IntPtr> windowHandles = Interop.EnumerateProcessWindowHandles(processes[0].Id);

                    foreach (IntPtr handle in windowHandles)
                    {
                        if (IsRealTempMainWindow(handle))
                        {
                            cache[RealTempControlID.MainDialog].Handle = handle;
                            List<IntPtr> childWindowHandles = Interop.EnumerateChildWindowHandles(handle);
                            foreach (var childHandle in childWindowHandles)
                            {
                                int controlId = Interop.GetWindowControlID(childHandle);
                                if (IsValidControlID(controlId))
                                {
                                    cache[(RealTempControlID)controlId].Handle = childHandle;
                                }
                            }
                        }
                    }
                }
                else
                    throw new InvalidOperationException("RealTemp is not running.");
            }
            foreach (var kvp in cache)
            {
                kvp.Value.Value = Interop.GetWindowText(kvp.Value.Handle);
            }
        }
        #endregion

        #region Helpers

        private bool IsRealTempMainWindow(IntPtr hWnd)
        {
            string windowText = Interop.GetWindowText(hWnd);
            if (windowText == null)
                return false;

            return Regex.IsMatch(windowText, "RealTemp.*|(\\d+°C)+|(\\d+°F)+");
        }

        private bool IsValidControlID(int controlId)
        {
            return Enum.IsDefined(typeof(RealTempControlID), controlId);
        }
        #endregion

        #region Internal Enums / Classes

        internal enum RealTempControlID
        {
            MainDialog = -1,
            CoreZeroTemp = 1001,
            CoreOneTemp = 1002,
            CoreTwoTemp = 1003,
            CoreThreeTemp = 1004,
            CoreZeroTJ = 1005,
            CoreOneTJ = 1006,
            CoreTwoTJ = 1007,
            CoreThreeTJ = 1008,
            Frequency = 1155,
            Load = 1157,
            TemperatureUnit = 1164
        }

        internal class RealTempControl
        {
            public RealTempControl(RealTempControlID controlId)
            {
                ControlID = controlId;
                Handle = IntPtr.Zero;
                Value = null;
            }
            public RealTempControlID ControlID;
            public IntPtr Handle;
            public string Value;
        }
        #endregion

        #region Interop

        private static class Interop
        {
            delegate bool EnumWindowsDelegate(IntPtr hWnd, IntPtr lParam);

            private const uint WM_GETTEXT = 0x000D;
            private const int GWL_ID = -12;

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool EnumThreadWindows(int dwThreadId, EnumWindowsDelegate lpfn, IntPtr lParam);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsDelegate lpEnumFunc, IntPtr lParam);

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            public static List<IntPtr> EnumerateProcessWindowHandles(int processId)
            {
                var handles = new List<IntPtr>();

                foreach (ProcessThread thread in Process.GetProcessById(processId).Threads)
                    EnumThreadWindows(thread.Id, (hWnd, lParam) => { handles.Add(hWnd); return true; }, IntPtr.Zero);

                return handles;
            }

            public static List<IntPtr> EnumerateChildWindowHandles(IntPtr hWndParent)
            {
                var handles = new List<IntPtr>();

                EnumChildWindows(hWndParent, (hWnd, lParam) => { handles.Add(hWnd); return true; }, IntPtr.Zero);

                return handles;
            }

            public static string GetWindowText(IntPtr hWnd)
            {
                if (hWnd == IntPtr.Zero)
                    return null;

                StringBuilder sb = new StringBuilder(256);
                if (SendMessage(hWnd, WM_GETTEXT, sb.Capacity, sb) != IntPtr.Zero)
                    return sb.ToString();
                else
                    return null;
            }

            public static int GetWindowControlID(IntPtr hWnd)
            {
                return GetWindowLong(hWnd, GWL_ID);
            }
        }
        #endregion
    }
}
