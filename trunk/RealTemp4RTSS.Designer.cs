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
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.realTempRefresh = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkStartMinimised = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpMetrics = new System.Windows.Forms.GroupBox();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblOSDStatus = new System.Windows.Forms.Label();
            this.lblOSD = new System.Windows.Forms.Label();
            this.lblRealTempStatus = new System.Windows.Forms.Label();
            this.lblRealTemp = new System.Windows.Forms.Label();
            this.notifyIconMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpMetrics.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.mnuExit});
            this.notifyIconMenu.Name = "notifyIconMenu";
            this.notifyIconMenu.Size = new System.Drawing.Size(93, 26);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(92, 22);
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
            this.panel1.Controls.Add(this.chkStartMinimised);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 379);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 46);
            this.panel1.TabIndex = 3;
            // 
            // chkStartMinimised
            // 
            this.chkStartMinimised.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkStartMinimised.AutoSize = true;
            this.chkStartMinimised.Location = new System.Drawing.Point(12, 15);
            this.chkStartMinimised.Name = "chkStartMinimised";
            this.chkStartMinimised.Size = new System.Drawing.Size(109, 19);
            this.chkStartMinimised.TabIndex = 0;
            this.chkStartMinimised.Text = "Start Minimised";
            this.chkStartMinimised.UseVisualStyleBackColor = true;
            this.chkStartMinimised.Click += new System.EventHandler(this.chkStartMinimised_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(327, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(246, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            // RealTemp4RTSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(414, 425);
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
            this.Load += new System.EventHandler(this.RealTemp4RTSS_Load);
            this.Move += new System.EventHandler(this.RealTemp4RTSS_Move);
            this.notifyIconMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grpMetrics.ResumeLayout(false);
            this.grpStatus.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
    }
}

