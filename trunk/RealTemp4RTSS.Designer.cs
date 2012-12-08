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
            this.realTempRefresh = new System.Windows.Forms.Timer(this.components);
            this.notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkStartMinimised = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIconMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.lsvAvailableMetrics.Location = new System.Drawing.Point(12, 58);
            this.lsvAvailableMetrics.MultiSelect = false;
            this.lsvAvailableMetrics.Name = "lsvAvailableMetrics";
            this.lsvAvailableMetrics.Size = new System.Drawing.Size(390, 266);
            this.lsvAvailableMetrics.TabIndex = 1;
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
            // realTempRefresh
            // 
            this.realTempRefresh.Interval = 1000;
            this.realTempRefresh.Tick += new System.EventHandler(this.realTempRefresh_Tick);
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
            this.panel1.Location = new System.Drawing.Point(0, 336);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 46);
            this.panel1.TabIndex = 2;
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
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(414, 51);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select the metrics to include on the OSD below:";
            // 
            // RealTemp4RTSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(414, 382);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lsvAvailableMetrics);
            this.Controls.Add(this.panel2);
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
        private System.Windows.Forms.Label label2;
    }
}

