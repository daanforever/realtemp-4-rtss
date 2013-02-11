namespace RealTemp4RTSS
{
    partial class RealTemp4RTSS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Temperatures", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Other", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealTemp4RTSS));
            this.lsvAvailableMetrics = new System.Windows.Forms.ListView();
            this.colMetric = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.realTempRefresh = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkStartMinimised = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpMetrics = new System.Windows.Forms.GroupBox();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblOSDStatus = new System.Windows.Forms.Label();
            this.lblRealTemp = new System.Windows.Forms.Label();
            this.lblOSD = new System.Windows.Forms.Label();
            this.lblRealTempStatus = new System.Windows.Forms.Label();
            this.grpAdvancedOptions = new System.Windows.Forms.GroupBox();
            this.btnUpdateCheck = new System.Windows.Forms.Button();
            this.chkNotifyUpdates = new System.Windows.Forms.CheckBox();
            this.pnlStartupOptions = new System.Windows.Forms.Panel();
            this.radStartForAllUsers = new System.Windows.Forms.RadioButton();
            this.radStartForCurrentUser = new System.Windows.Forms.RadioButton();
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            this.notifyIconMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpMetrics.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpAdvancedOptions.SuspendLayout();
            this.pnlStartupOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvAvailableMetrics
            // 
            this.lsvAvailableMetrics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvAvailableMetrics.CheckBoxes = true;
            this.lsvAvailableMetrics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMetric,
            this.colValue});
            this.lsvAvailableMetrics.FullRowSelect = true;
            listViewGroup1.Header = "Temperatures";
            listViewGroup1.Name = "lvgTemps";
            listViewGroup2.Header = "Other";
            listViewGroup2.Name = "lvgOther";
            this.lsvAvailableMetrics.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lsvAvailableMetrics.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvAvailableMetrics.HideSelection = false;
            this.lsvAvailableMetrics.Location = new System.Drawing.Point(6, 22);
            this.lsvAvailableMetrics.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lsvAvailableMetrics.MinimumSize = new System.Drawing.Size(4, 260);
            this.lsvAvailableMetrics.MultiSelect = false;
            this.lsvAvailableMetrics.Name = "lsvAvailableMetrics";
            this.lsvAvailableMetrics.Size = new System.Drawing.Size(387, 260);
            this.lsvAvailableMetrics.TabIndex = 0;
            this.lsvAvailableMetrics.UseCompatibleStateImageBehavior = false;
            this.lsvAvailableMetrics.View = System.Windows.Forms.View.Details;
            this.lsvAvailableMetrics.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lsvAvailableMetrics_ItemChecked);
            // 
            // colMetric
            // 
            this.colMetric.Text = "Metric";
            this.colMetric.Width = 200;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 100;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "RealTemp4RTSS";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // notifyIconMenu
            // 
            this.notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShow,
            this.mnuExit});
            this.notifyIconMenu.Name = "notifyIconMenu";
            this.notifyIconMenu.Size = new System.Drawing.Size(104, 48);
            // 
            // mnuShow
            // 
            this.mnuShow.Name = "mnuShow";
            this.mnuShow.Size = new System.Drawing.Size(103, 22);
            this.mnuShow.Text = "Show";
            this.mnuShow.Click += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(103, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // realTempRefresh
            // 
            this.realTempRefresh.Interval = 1000;
            this.realTempRefresh.Tick += new System.EventHandler(this.realTempRefresh_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "RealTemp data on your MSI Afterburner or EVGA Precision OSD";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnAdvanced);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 379);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 46);
            this.panel1.TabIndex = 3;
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.Location = new System.Drawing.Point(12, 10);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(75, 25);
            this.btnAdvanced.TabIndex = 3;
            this.btnAdvanced.Text = "Advanced";
            this.btnAdvanced.UseVisualStyleBackColor = true;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(327, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(246, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkStartMinimised
            // 
            this.chkStartMinimised.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkStartMinimised.AutoSize = true;
            this.chkStartMinimised.Location = new System.Drawing.Point(14, 114);
            this.chkStartMinimised.Name = "chkStartMinimised";
            this.chkStartMinimised.Size = new System.Drawing.Size(109, 19);
            this.chkStartMinimised.TabIndex = 2;
            this.chkStartMinimised.Text = "Start minimised";
            this.chkStartMinimised.UseVisualStyleBackColor = true;
            this.chkStartMinimised.CheckedChanged += new System.EventHandler(this.chkStartMinimised_CheckedChanged);
            this.chkStartMinimised.Click += new System.EventHandler(this.chkStartMinimised_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(414, 33);
            this.panel2.TabIndex = 0;
            // 
            // grpMetrics
            // 
            this.grpMetrics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMetrics.Controls.Add(this.lsvAvailableMetrics);
            this.grpMetrics.Location = new System.Drawing.Point(8, 36);
            this.grpMetrics.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.grpMetrics.MinimumSize = new System.Drawing.Size(0, 292);
            this.grpMetrics.Name = "grpMetrics";
            this.grpMetrics.Size = new System.Drawing.Size(399, 292);
            this.grpMetrics.TabIndex = 1;
            this.grpMetrics.TabStop = false;
            this.grpMetrics.Text = "Select the metrics to include on the OSD below:";
            // 
            // grpStatus
            // 
            this.grpStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStatus.Controls.Add(this.tableLayoutPanel1);
            this.grpStatus.Location = new System.Drawing.Point(8, 328);
            this.grpStatus.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Padding = new System.Windows.Forms.Padding(10, 1, 10, 10);
            this.grpStatus.Size = new System.Drawing.Size(399, 45);
            this.grpStatus.TabIndex = 2;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Status";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.lblOSDStatus, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRealTemp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOSD, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRealTempStatus, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(379, 18);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lblOSDStatus
            // 
            this.lblOSDStatus.AutoSize = true;
            this.lblOSDStatus.Location = new System.Drawing.Point(267, 1);
            this.lblOSDStatus.Name = "lblOSDStatus";
            this.lblOSDStatus.Size = new System.Drawing.Size(23, 15);
            this.lblOSDStatus.TabIndex = 7;
            this.lblOSDStatus.Text = "OK";
            // 
            // lblRealTemp
            // 
            this.lblRealTemp.BackColor = System.Drawing.SystemColors.Control;
            this.lblRealTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRealTemp.Location = new System.Drawing.Point(1, 1);
            this.lblRealTemp.Margin = new System.Windows.Forms.Padding(0);
            this.lblRealTemp.Name = "lblRealTemp";
            this.lblRealTemp.Size = new System.Drawing.Size(74, 16);
            this.lblRealTemp.TabIndex = 4;
            this.lblRealTemp.Text = "RealTemp:";
            this.lblRealTemp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblOSD
            // 
            this.lblOSD.BackColor = System.Drawing.SystemColors.Control;
            this.lblOSD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOSD.Location = new System.Drawing.Point(189, 1);
            this.lblOSD.Margin = new System.Windows.Forms.Padding(0);
            this.lblOSD.Name = "lblOSD";
            this.lblOSD.Size = new System.Drawing.Size(74, 16);
            this.lblOSD.TabIndex = 6;
            this.lblOSD.Text = "OSD:";
            this.lblOSD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRealTempStatus
            // 
            this.lblRealTempStatus.AutoSize = true;
            this.lblRealTempStatus.Location = new System.Drawing.Point(79, 1);
            this.lblRealTempStatus.Name = "lblRealTempStatus";
            this.lblRealTempStatus.Size = new System.Drawing.Size(53, 15);
            this.lblRealTempStatus.TabIndex = 5;
            this.lblRealTempStatus.Text = "Polling...";
            // 
            // grpAdvancedOptions
            // 
            this.grpAdvancedOptions.Controls.Add(this.btnUpdateCheck);
            this.grpAdvancedOptions.Controls.Add(this.chkNotifyUpdates);
            this.grpAdvancedOptions.Controls.Add(this.pnlStartupOptions);
            this.grpAdvancedOptions.Controls.Add(this.chkStartWithWindows);
            this.grpAdvancedOptions.Controls.Add(this.chkStartMinimised);
            this.grpAdvancedOptions.Location = new System.Drawing.Point(8, 36);
            this.grpAdvancedOptions.Name = "grpAdvancedOptions";
            this.grpAdvancedOptions.Size = new System.Drawing.Size(399, 292);
            this.grpAdvancedOptions.TabIndex = 4;
            this.grpAdvancedOptions.TabStop = false;
            this.grpAdvancedOptions.Text = "Advanced Options";
            this.grpAdvancedOptions.Visible = false;
            // 
            // btnUpdateCheck
            // 
            this.btnUpdateCheck.Location = new System.Drawing.Point(280, 144);
            this.btnUpdateCheck.Name = "btnUpdateCheck";
            this.btnUpdateCheck.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateCheck.TabIndex = 4;
            this.btnUpdateCheck.Text = "Check";
            this.btnUpdateCheck.UseVisualStyleBackColor = true;
            this.btnUpdateCheck.Click += new System.EventHandler(this.btnUpdateCheck_Click);
            // 
            // chkNotifyUpdates
            // 
            this.chkNotifyUpdates.AutoSize = true;
            this.chkNotifyUpdates.Location = new System.Drawing.Point(14, 147);
            this.chkNotifyUpdates.Name = "chkNotifyUpdates";
            this.chkNotifyUpdates.Size = new System.Drawing.Size(237, 19);
            this.chkNotifyUpdates.TabIndex = 3;
            this.chkNotifyUpdates.Text = "Notify when there is an update available";
            this.chkNotifyUpdates.UseVisualStyleBackColor = true;
            this.chkNotifyUpdates.CheckedChanged += new System.EventHandler(this.chkNotifyUpdates_CheckedChanged);
            // 
            // pnlStartupOptions
            // 
            this.pnlStartupOptions.Controls.Add(this.radStartForAllUsers);
            this.pnlStartupOptions.Controls.Add(this.radStartForCurrentUser);
            this.pnlStartupOptions.Location = new System.Drawing.Point(27, 52);
            this.pnlStartupOptions.Name = "pnlStartupOptions";
            this.pnlStartupOptions.Size = new System.Drawing.Size(362, 50);
            this.pnlStartupOptions.TabIndex = 1;
            // 
            // radStartForAllUsers
            // 
            this.radStartForAllUsers.AutoSize = true;
            this.radStartForAllUsers.Location = new System.Drawing.Point(3, 28);
            this.radStartForAllUsers.Name = "radStartForAllUsers";
            this.radStartForAllUsers.Size = new System.Drawing.Size(72, 19);
            this.radStartForAllUsers.TabIndex = 1;
            this.radStartForAllUsers.TabStop = true;
            this.radStartForAllUsers.Text = "Any User";
            this.radStartForAllUsers.UseVisualStyleBackColor = true;
            this.radStartForAllUsers.CheckedChanged += new System.EventHandler(this.radStartForAllUsers_CheckedChanged);
            // 
            // radStartForCurrentUser
            // 
            this.radStartForCurrentUser.AutoSize = true;
            this.radStartForCurrentUser.Location = new System.Drawing.Point(3, 3);
            this.radStartForCurrentUser.Name = "radStartForCurrentUser";
            this.radStartForCurrentUser.Size = new System.Drawing.Size(99, 19);
            this.radStartForCurrentUser.TabIndex = 0;
            this.radStartForCurrentUser.TabStop = true;
            this.radStartForCurrentUser.Text = "[Current User]";
            this.radStartForCurrentUser.UseVisualStyleBackColor = true;
            this.radStartForCurrentUser.CheckedChanged += new System.EventHandler(this.radStartForCurrentUser_CheckedChanged);
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Location = new System.Drawing.Point(14, 30);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(225, 19);
            this.chkStartWithWindows.TabIndex = 0;
            this.chkStartWithWindows.Text = "Start when the following user logs on:";
            this.chkStartWithWindows.UseVisualStyleBackColor = true;
            this.chkStartWithWindows.CheckedChanged += new System.EventHandler(this.chkStartWithWindows_CheckedChanged);
            // 
            // RealTemp4RTSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(414, 425);
            this.Controls.Add(this.grpAdvancedOptions);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.grpMetrics);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RealTemp4RTSS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RealTemp4RTSS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RealTemp4RTSS_FormClosing);
            this.Move += new System.EventHandler(this.RealTemp4RTSS_Move);
            this.notifyIconMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grpMetrics.ResumeLayout(false);
            this.grpStatus.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grpAdvancedOptions.ResumeLayout(false);
            this.grpAdvancedOptions.PerformLayout();
            this.pnlStartupOptions.ResumeLayout(false);
            this.pnlStartupOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvAvailableMetrics;
        private System.Windows.Forms.ColumnHeader colMetric;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer realTempRefresh;
        private System.Windows.Forms.ContextMenuStrip notifyIconMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkStartMinimised;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grpMetrics;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblOSDStatus;
        private System.Windows.Forms.Label lblRealTemp;
        private System.Windows.Forms.Label lblOSD;
        private System.Windows.Forms.Label lblRealTempStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuShow;
        private System.Windows.Forms.Button btnAdvanced;
        private System.Windows.Forms.GroupBox grpAdvancedOptions;
        private System.Windows.Forms.Panel pnlStartupOptions;
        private System.Windows.Forms.RadioButton radStartForAllUsers;
        private System.Windows.Forms.RadioButton radStartForCurrentUser;
        private System.Windows.Forms.CheckBox chkStartWithWindows;
        private System.Windows.Forms.CheckBox chkNotifyUpdates;
        private System.Windows.Forms.Button btnUpdateCheck;
    }
}

