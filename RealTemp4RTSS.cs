using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealTemp4RTSS
{
    public partial class RealTemp4RTSS : Form
    {
        private const int MAX_RTSS_COMMUNICATION_ERRORS = 10;

        private RealTemp realTemp = null;
        private RTSSController rtssController = null;
        private int osdSlot = -1;
        private bool isClosing = false;
        private bool isChangingSettings = true;
        private int rtssCommunicationErrors = 0;

        public RealTemp4RTSS()
        {
            InitializeComponent();
            
            realTemp = RealTemp.GetInstance();
            PopulateMetrics();

            lblRealTempStatus.Text = "Initialising...";
            lblOSDStatus.Text = "Initialising...";

            lsvAvailableMetrics.EnableDoubleBuffer();
            try
            {
                rtssController = new RTSSController();
                lblOSDStatus.Text = "OK";
            }
            catch
            {
                // RTSS is currently unavailable or uncommunicative; don't stop as if it becomes responsive later
                // we can re-establish communication then...
                lblOSDStatus.Text = "Unavailable";
            }
            LoadSettings();
            realTempRefresh.Enabled = true;
        }

        private void PopulateMetrics()
        {
            lsvAvailableMetrics.BeginUpdate();
            try
            {
                ListViewItem lvi;

                lvi = lsvAvailableMetrics.Items.Add("coretemp0", "Core 0 Temperature", -1);
                lvi.Group = lsvAvailableMetrics.Groups["lvgTemps"];
                lvi.SubItems.Add("...");
                lvi.Tag = RealTemp.RealTempControlID.CoreZeroTemp;

                lvi = lsvAvailableMetrics.Items.Add("coretemp1", "Core 1 Temperature", -1);
                lvi.Group = lsvAvailableMetrics.Groups["lvgTemps"];
                lvi.SubItems.Add("...");
                lvi.Tag = RealTemp.RealTempControlID.CoreOneTemp;

                lvi = lsvAvailableMetrics.Items.Add("coretemp2", "Core 2 Temperature", -1);
                lvi.Group = lsvAvailableMetrics.Groups["lvgTemps"];
                lvi.SubItems.Add("...");
                lvi.Tag = RealTemp.RealTempControlID.CoreTwoTemp;

                lvi = lsvAvailableMetrics.Items.Add("coretemp3", "Core 3 Temperature", -1);
                lvi.Group = lsvAvailableMetrics.Groups["lvgTemps"];
                lvi.SubItems.Add("...");
                lvi.Tag = RealTemp.RealTempControlID.CoreThreeTemp;

                lvi = lsvAvailableMetrics.Items.Add("coretemp", "Highest Core Temperature", -1);
                lvi.Group = lsvAvailableMetrics.Groups["lvgTemps"];
                lvi.SubItems.Add("...");
                lvi.Tag = RealTemp.RealTempControlID.TemperatureUnit;

                lvi = lsvAvailableMetrics.Items.Add("load", "Total Load", -1);
                lvi.Group = lsvAvailableMetrics.Groups["lvgOther"];
                lvi.SubItems.Add("...");
                lvi.Tag = RealTemp.RealTempControlID.Load;

                lvi = lsvAvailableMetrics.Items.Add("frequency_mhz", "Processor Frequency (MHz)", -1);
                lvi.Group = lsvAvailableMetrics.Groups["lvgOther"];
                lvi.SubItems.Add("...");
                lvi.Tag = RealTemp.RealTempControlID.Frequency;

                lvi = lsvAvailableMetrics.Items.Add("frequency_ghz", "Processor Frequency (GHz)", -1);
                lvi.Group = lsvAvailableMetrics.Groups["lvgOther"];
                lvi.SubItems.Add("...");
                lvi.Tag = RealTemp.RealTempControlID.Frequency;

                lvi = lsvAvailableMetrics.Items.Add("time", "Current Time", -1);
                lvi.Group = lsvAvailableMetrics.Groups["lvgOther"];
                lvi.SubItems.Add("...");
            }
            finally
            {
                lsvAvailableMetrics.EndUpdate();
            }
        }

        public void StartMinimised()
        {
            Visible = false;
            WindowState = FormWindowState.Minimized;
            notifyIcon.Visible = true;
        }

        public void LoadSettings()
        {
            isChangingSettings = true;
            try
            {
                foreach (ListViewItem lvi in lsvAvailableMetrics.Items)
                {
                    if (Properties.Settings.Default.EnabledMetrics != null)
                    {
                        lvi.Checked = Properties.Settings.Default.EnabledMetrics.Contains(lvi.Name);
                    }
                    else
                        lvi.Checked = false;
                }
                chkStartMinimised.Checked = Properties.Settings.Default.StartMinimised;
            }
            finally
            {
                isChangingSettings = false;
            }
        }

        public void SaveSettings()
        {
            if (Properties.Settings.Default.EnabledMetrics == null)
            {
                Properties.Settings.Default.EnabledMetrics = new System.Collections.Specialized.StringCollection();
            }
            else
                Properties.Settings.Default.EnabledMetrics.Clear();

            foreach (ListViewItem lvi in lsvAvailableMetrics.Items)
            {
                if (lvi.Checked)
                {
                    Properties.Settings.Default.EnabledMetrics.Add(lvi.Name);
                }
            }
            Properties.Settings.Default.StartMinimised = chkStartMinimised.Checked;

            Properties.Settings.Default.Save();
        }

        private void AllowClose(ref bool allow)
        {
            if (!isClosing)
            {
                if (allow || MessageBox.Show(this, "Are you sure you want to exit?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    isClosing = true;
                    allow = true;

                    if (rtssController != null)
                        rtssController.Dispose();

                    Application.Exit();
                }
            }
        }

        private void realTempRefresh_Tick(object sender, EventArgs e)
        {
            StringBuilder rtssString = new StringBuilder();

            foreach (ListViewItem lvi in lsvAvailableMetrics.Items)
            {
                if (realTemp.IsRealTempAvailable())
                {
                    lblRealTempStatus.Text = "Polling...";

                    if (lvi.Tag != null)
                    {
                        if (Visible)
                        {
                            int coreCount = realTemp.GetCoreCount();
                            if (coreCount > 0)
                            {
                                switch ((RealTemp.RealTempControlID)lvi.Tag)
                                {
                                    case RealTemp.RealTempControlID.CoreZeroTemp:
                                        lvi.SubItems[1].Text = realTemp.GetCoreTemperature(0).ToString();
                                        break;
                                    case RealTemp.RealTempControlID.CoreOneTemp:
                                        if (coreCount > 1)
                                            lvi.SubItems[1].Text = realTemp.GetCoreTemperature(1).ToString();
                                        else
                                            lvi.SubItems[1].Text = "N/A";
                                        break;
                                    case RealTemp.RealTempControlID.CoreTwoTemp:
                                        if (coreCount > 2)
                                            lvi.SubItems[1].Text = realTemp.GetCoreTemperature(2).ToString();
                                        else
                                            lvi.SubItems[1].Text = "N/A";
                                        break;
                                    case RealTemp.RealTempControlID.CoreThreeTemp:
                                        if (coreCount > 3)
                                            lvi.SubItems[1].Text = realTemp.GetCoreTemperature(3).ToString();
                                        else
                                            lvi.SubItems[1].Text = "N/A";
                                        break;
                                    case RealTemp.RealTempControlID.TemperatureUnit:
                                        lvi.SubItems[1].Text = realTemp.GetHighestCoreTemperature().ToString();
                                        break;
                                    case RealTemp.RealTempControlID.Load:
                                        lvi.SubItems[1].Text = realTemp.GetLoad() + "%";
                                        break;
                                    case RealTemp.RealTempControlID.Frequency:
                                        if (lvi.Name.EndsWith("mhz"))
                                            lvi.SubItems[1].Text = realTemp.GetFrequency(RealTemp.FrequencyUnit.MHz).ToString();
                                        else if (lvi.Name.EndsWith("ghz"))
                                            lvi.SubItems[1].Text = realTemp.GetFrequency(RealTemp.FrequencyUnit.GHz).ToString();
                                        else
                                            lvi.SubItems[1].Text = realTemp.GetFrequency().ToString();
                                        break;
                                }
                            }
                            else
                            {
                                lvi.SubItems[1].Text = "N/A";
                            }
                        }
                        if (lvi.Checked)
                        {
                            if (rtssString.Length > 0)
                                rtssString.Append(", ");
                            rtssString.Append("{" + lvi.Name + "}");
                            if ((RealTemp.RealTempControlID)lvi.Tag == RealTemp.RealTempControlID.Load)
                                rtssString.Append(" %");
                        }
                    }
                    else
                    {
                        switch (lvi.Name)
                        {
                            case "time":
                                if (Visible)
                                    lvi.SubItems[1].Text = DateTime.Now.ToShortTimeString();
                                if (lvi.Checked)
                                {
                                    if (rtssString.Length > 0)
                                        rtssString.Append("\r\n");
                                    rtssString.Append("TIME \t: " + DateTime.Now.ToShortTimeString());
                                }
                                break;
                        }
                    }
                }
                else
                {
                    lvi.SubItems[1].Text = "N/A";
                    lblRealTempStatus.Text = "Unavailable";
                }
            }
            if (rtssController == null)
            {
                try
                {
                    rtssController = new RTSSController();
                    lblOSDStatus.Text = "OK";
                }
                catch
                {
                    // RTSS is still unavailable or uncommunacative; ignore - we'll try next time.
                    lblOSDStatus.Text = "Unavailable";
                }
            }
            if (rtssController != null)
            {
                try
                {
                    rtssCommunicationErrors = 0;

                    if (rtssString.Length > 0)
                    {
                        osdSlot = rtssController.SetOSDValue(osdSlot, "CPU \t: " + realTemp.GetFormattedString(rtssString.ToString()));
                        lblOSDStatus.Text = "OK";
                    }
                    else if (osdSlot != -1)
                    {
                        rtssController.ClearOSDValue(osdSlot);
                        osdSlot = -1;
                        lblOSDStatus.Text = "OK";
                    }
                    else
                    {
                        lblOSDStatus.Text = rtssController.GetStatus().GetDescription();
                    }
                }
                catch
                {
                    lblOSDStatus.Text = "Unavailable";

                    // Something went wrong when communicating with RTSS...
                    rtssCommunicationErrors++;
                    // This may actually cause more trouble as if it manages to reconnect to the existing
                    // RTSS instance its shared memory will still be intact and hence our AppId will be
                    // in-use... so we won't be allowed to do anything.  I'm not sure whether it's
                    // RivaTuner (Afterburner, etc.) that maintain it or RTSS itself... lets hope the later!
                    if (rtssCommunicationErrors >= MAX_RTSS_COMMUNICATION_ERRORS)
                        rtssController = null;
                }
            }
        }

        private void RealTemp4RTSS_Move(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
            else if (!Visible)
            {
                Show();
                notifyIcon.Visible = false;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void RealTemp4RTSS_Load(object sender, EventArgs e)
        {
            
        }

        private void RealTemp4RTSS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                bool allow = false;

                if (e.CloseReason == CloseReason.TaskManagerClosing || e.CloseReason == CloseReason.WindowsShutDown)
                    allow = true;

                AllowClose(ref allow);

                e.Cancel = !allow;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            btnCancel.Enabled = false;

            LoadSettings();
        }

        private void chkStartMinimised_CheckedChanged(object sender, EventArgs e)
        {
            if (!isChangingSettings)
            {
                btnOK.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        private void lsvAvailableMetrics_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!isChangingSettings)
            {
                btnOK.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            btnCancel.Enabled = false;

            SaveSettings();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            bool allow = false;

            AllowClose(ref allow);
        }
    }
}
