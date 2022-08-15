namespace Triggernometry.Forms
{
    partial class RepositoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepositoryForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.grpUpdateSettings = new System.Windows.Forms.GroupBox();
            this.tbcGeneral = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkAllowDisk = new System.Windows.Forms.CheckBox();
            this.cbxAudioOverride = new System.Windows.Forms.ComboBox();
            this.lblAudioOverride = new System.Windows.Forms.Label();
            this.chkAllowObs = new System.Windows.Forms.CheckBox();
            this.chkAllowWmsg = new System.Windows.Forms.CheckBox();
            this.chkKeepLocal = new System.Windows.Forms.CheckBox();
            this.chkAllowScript = new System.Windows.Forms.CheckBox();
            this.chkAllowProcess = new System.Windows.Forms.CheckBox();
            this.tabUpdates = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.nudUpdateMinutes = new System.Windows.Forms.NumericUpDown();
            this.lblUpdateInterval = new System.Windows.Forms.Label();
            this.cbxUpdateAuto = new System.Windows.Forms.CheckBox();
            this.lblDefaultBehavior = new System.Windows.Forms.Label();
            this.cbxNewBehavior = new System.Windows.Forms.ComboBox();
            this.cbxUpdatePolicy = new System.Windows.Forms.ComboBox();
            this.lblUpdatePolicy = new System.Windows.Forms.Label();
            this.tabUpdateLog = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxSelectionToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxEverythingToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.btnCopy = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnSelectionToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEverythingToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.lblCacheFilename = new System.Windows.Forms.Label();
            this.txtCacheFilename = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContentSize = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.txtLastUpdated = new System.Windows.Forms.TextBox();
            this.capDetails = new Triggernometry.CustomControls.PrettyCaption();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLastChecked = new System.Windows.Forms.Label();
            this.txtLastChecked = new System.Windows.Forms.TextBox();
            this.panel4.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpUpdateSettings.SuspendLayout();
            this.tbcGeneral.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabUpdates.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateMinutes)).BeginInit();
            this.tabUpdateLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tlsMain.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 456);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 10);
            this.panel3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnOk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 466);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(564, 35);
            this.panel4.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(414, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(0, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 35);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // grpGeneral
            // 
            this.grpGeneral.AutoSize = true;
            this.grpGeneral.Controls.Add(this.tableLayoutPanel1);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGeneral.Location = new System.Drawing.Point(10, 10);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(10);
            this.grpGeneral.Size = new System.Drawing.Size(564, 85);
            this.grpGeneral.TabIndex = 18;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = " General settings ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtAddress, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAddress, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 52);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtAddress
            // 
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Location = new System.Drawing.Point(95, 29);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(446, 20);
            this.txtAddress.TabIndex = 4;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoEllipsis = true;
            this.lblAddress.AutoSize = true;
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddress.Location = new System.Drawing.Point(3, 26);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(86, 26);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(86, 26);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Repository name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(95, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(446, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // grpUpdateSettings
            // 
            this.grpUpdateSettings.AutoSize = true;
            this.grpUpdateSettings.Controls.Add(this.tbcGeneral);
            this.grpUpdateSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUpdateSettings.Location = new System.Drawing.Point(10, 105);
            this.grpUpdateSettings.Name = "grpUpdateSettings";
            this.grpUpdateSettings.Padding = new System.Windows.Forms.Padding(10);
            this.grpUpdateSettings.Size = new System.Drawing.Size(564, 351);
            this.grpUpdateSettings.TabIndex = 19;
            this.grpUpdateSettings.TabStop = false;
            this.grpUpdateSettings.Text = " Updates and permissions ";
            // 
            // tbcGeneral
            // 
            this.tbcGeneral.Controls.Add(this.tabGeneral);
            this.tbcGeneral.Controls.Add(this.tabUpdates);
            this.tbcGeneral.Controls.Add(this.tabUpdateLog);
            this.tbcGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcGeneral.Location = new System.Drawing.Point(10, 23);
            this.tbcGeneral.Name = "tbcGeneral";
            this.tbcGeneral.SelectedIndex = 0;
            this.tbcGeneral.Size = new System.Drawing.Size(544, 318);
            this.tbcGeneral.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tableLayoutPanel2);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(536, 292);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "Settings";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.chkAllowDisk, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.cbxAudioOverride, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblAudioOverride, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkAllowObs, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.chkAllowWmsg, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.chkKeepLocal, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.chkAllowScript, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkAllowProcess, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(530, 286);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // chkAllowDisk
            // 
            this.chkAllowDisk.AutoSize = true;
            this.chkAllowDisk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel2.SetColumnSpan(this.chkAllowDisk, 2);
            this.chkAllowDisk.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkAllowDisk.Location = new System.Drawing.Point(3, 140);
            this.chkAllowDisk.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkAllowDisk.Name = "chkAllowDisk";
            this.chkAllowDisk.Size = new System.Drawing.Size(525, 17);
            this.chkAllowDisk.TabIndex = 36;
            this.chkAllowDisk.Text = "Allow triggers to perform file operations";
            this.chkAllowDisk.UseVisualStyleBackColor = true;
            this.chkAllowDisk.CheckedChanged += new System.EventHandler(this.chkAllowDisk_CheckedChanged);
            // 
            // cbxAudioOverride
            // 
            this.cbxAudioOverride.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxAudioOverride.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAudioOverride.FormattingEnabled = true;
            this.cbxAudioOverride.Items.AddRange(new object[] {
            "As defined in repository",
            "Audio override setting always on",
            "Audio override setting always off"});
            this.cbxAudioOverride.Location = new System.Drawing.Point(268, 3);
            this.cbxAudioOverride.Name = "cbxAudioOverride";
            this.cbxAudioOverride.Size = new System.Drawing.Size(259, 21);
            this.cbxAudioOverride.TabIndex = 35;
            // 
            // lblAudioOverride
            // 
            this.lblAudioOverride.AutoEllipsis = true;
            this.lblAudioOverride.AutoSize = true;
            this.lblAudioOverride.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAudioOverride.Location = new System.Drawing.Point(3, 0);
            this.lblAudioOverride.Name = "lblAudioOverride";
            this.lblAudioOverride.Size = new System.Drawing.Size(259, 27);
            this.lblAudioOverride.TabIndex = 34;
            this.lblAudioOverride.Text = "Audio output setting override";
            this.lblAudioOverride.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkAllowObs
            // 
            this.chkAllowObs.AutoSize = true;
            this.chkAllowObs.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel2.SetColumnSpan(this.chkAllowObs, 2);
            this.chkAllowObs.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkAllowObs.Location = new System.Drawing.Point(3, 113);
            this.chkAllowObs.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkAllowObs.Name = "chkAllowObs";
            this.chkAllowObs.Size = new System.Drawing.Size(525, 17);
            this.chkAllowObs.TabIndex = 33;
            this.chkAllowObs.Text = "Allow triggers to control OBS";
            this.chkAllowObs.UseVisualStyleBackColor = true;
            this.chkAllowObs.CheckedChanged += new System.EventHandler(this.chkAllowObs_CheckedChanged);
            // 
            // chkAllowWmsg
            // 
            this.chkAllowWmsg.AutoSize = true;
            this.chkAllowWmsg.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel2.SetColumnSpan(this.chkAllowWmsg, 2);
            this.chkAllowWmsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkAllowWmsg.Location = new System.Drawing.Point(3, 86);
            this.chkAllowWmsg.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkAllowWmsg.Name = "chkAllowWmsg";
            this.chkAllowWmsg.Size = new System.Drawing.Size(525, 17);
            this.chkAllowWmsg.TabIndex = 32;
            this.chkAllowWmsg.Text = "Allow triggers to send window messages";
            this.chkAllowWmsg.UseVisualStyleBackColor = true;
            this.chkAllowWmsg.CheckedChanged += new System.EventHandler(this.chkAllowWmsg_CheckedChanged);
            // 
            // chkKeepLocal
            // 
            this.chkKeepLocal.AutoSize = true;
            this.chkKeepLocal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel2.SetColumnSpan(this.chkKeepLocal, 2);
            this.chkKeepLocal.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkKeepLocal.Location = new System.Drawing.Point(3, 167);
            this.chkKeepLocal.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkKeepLocal.Name = "chkKeepLocal";
            this.chkKeepLocal.Size = new System.Drawing.Size(525, 17);
            this.chkKeepLocal.TabIndex = 29;
            this.chkKeepLocal.Text = "Maintain a local backup for outages";
            this.chkKeepLocal.UseVisualStyleBackColor = true;
            // 
            // chkAllowScript
            // 
            this.chkAllowScript.AutoSize = true;
            this.chkAllowScript.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel2.SetColumnSpan(this.chkAllowScript, 2);
            this.chkAllowScript.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkAllowScript.Location = new System.Drawing.Point(3, 59);
            this.chkAllowScript.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkAllowScript.Name = "chkAllowScript";
            this.chkAllowScript.Size = new System.Drawing.Size(525, 17);
            this.chkAllowScript.TabIndex = 28;
            this.chkAllowScript.Text = "Allow triggers to execute scripts";
            this.chkAllowScript.UseVisualStyleBackColor = true;
            this.chkAllowScript.CheckedChanged += new System.EventHandler(this.chkAllowScript_CheckedChanged);
            // 
            // chkAllowProcess
            // 
            this.chkAllowProcess.AutoSize = true;
            this.chkAllowProcess.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel2.SetColumnSpan(this.chkAllowProcess, 2);
            this.chkAllowProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkAllowProcess.Location = new System.Drawing.Point(3, 32);
            this.chkAllowProcess.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkAllowProcess.Name = "chkAllowProcess";
            this.chkAllowProcess.Size = new System.Drawing.Size(525, 17);
            this.chkAllowProcess.TabIndex = 27;
            this.chkAllowProcess.Text = "Allow triggers to launch processes";
            this.chkAllowProcess.UseVisualStyleBackColor = true;
            this.chkAllowProcess.CheckedChanged += new System.EventHandler(this.chkAllowProcess_CheckedChanged);
            // 
            // tabUpdates
            // 
            this.tabUpdates.Controls.Add(this.tableLayoutPanel6);
            this.tabUpdates.Location = new System.Drawing.Point(4, 22);
            this.tabUpdates.Name = "tabUpdates";
            this.tabUpdates.Padding = new System.Windows.Forms.Padding(3);
            this.tabUpdates.Size = new System.Drawing.Size(536, 292);
            this.tabUpdates.TabIndex = 2;
            this.tabUpdates.Text = "Updates";
            this.tabUpdates.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.nudUpdateMinutes, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.lblUpdateInterval, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.cbxUpdateAuto, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.lblDefaultBehavior, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbxNewBehavior, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbxUpdatePolicy, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.lblUpdatePolicy, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 5;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(530, 286);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // nudUpdateMinutes
            // 
            this.nudUpdateMinutes.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudUpdateMinutes.Location = new System.Drawing.Point(268, 84);
            this.nudUpdateMinutes.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudUpdateMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUpdateMinutes.Name = "nudUpdateMinutes";
            this.nudUpdateMinutes.Size = new System.Drawing.Size(259, 20);
            this.nudUpdateMinutes.TabIndex = 34;
            this.nudUpdateMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudUpdateMinutes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblUpdateInterval
            // 
            this.lblUpdateInterval.AutoEllipsis = true;
            this.lblUpdateInterval.AutoSize = true;
            this.lblUpdateInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpdateInterval.Location = new System.Drawing.Point(3, 81);
            this.lblUpdateInterval.Name = "lblUpdateInterval";
            this.lblUpdateInterval.Size = new System.Drawing.Size(259, 26);
            this.lblUpdateInterval.TabIndex = 33;
            this.lblUpdateInterval.Text = "Update interval in minutes";
            this.lblUpdateInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxUpdateAuto
            // 
            this.cbxUpdateAuto.AutoSize = true;
            this.cbxUpdateAuto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel6.SetColumnSpan(this.cbxUpdateAuto, 2);
            this.cbxUpdateAuto.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxUpdateAuto.Location = new System.Drawing.Point(3, 59);
            this.cbxUpdateAuto.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.cbxUpdateAuto.Name = "cbxUpdateAuto";
            this.cbxUpdateAuto.Size = new System.Drawing.Size(525, 17);
            this.cbxUpdateAuto.TabIndex = 32;
            this.cbxUpdateAuto.Text = "Enable repository auto-update";
            this.cbxUpdateAuto.UseVisualStyleBackColor = true;
            this.cbxUpdateAuto.CheckedChanged += new System.EventHandler(this.cbxUpdateAuto_CheckedChanged);
            // 
            // lblDefaultBehavior
            // 
            this.lblDefaultBehavior.AutoEllipsis = true;
            this.lblDefaultBehavior.AutoSize = true;
            this.lblDefaultBehavior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefaultBehavior.Location = new System.Drawing.Point(3, 0);
            this.lblDefaultBehavior.Name = "lblDefaultBehavior";
            this.lblDefaultBehavior.Size = new System.Drawing.Size(259, 27);
            this.lblDefaultBehavior.TabIndex = 0;
            this.lblDefaultBehavior.Text = "Default behaviour for newly added triggers";
            this.lblDefaultBehavior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxNewBehavior
            // 
            this.cbxNewBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNewBehavior.FormattingEnabled = true;
            this.cbxNewBehavior.Items.AddRange(new object[] {
            "Enabled or disabled as specified in repository",
            "Enable everything new by default",
            "Disable everything new by default"});
            this.cbxNewBehavior.Location = new System.Drawing.Point(268, 3);
            this.cbxNewBehavior.Name = "cbxNewBehavior";
            this.cbxNewBehavior.Size = new System.Drawing.Size(259, 21);
            this.cbxNewBehavior.TabIndex = 26;
            // 
            // cbxUpdatePolicy
            // 
            this.cbxUpdatePolicy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUpdatePolicy.FormattingEnabled = true;
            this.cbxUpdatePolicy.Items.AddRange(new object[] {
            "Update automatically on startup",
            "Update only manually"});
            this.cbxUpdatePolicy.Location = new System.Drawing.Point(268, 30);
            this.cbxUpdatePolicy.Name = "cbxUpdatePolicy";
            this.cbxUpdatePolicy.Size = new System.Drawing.Size(259, 21);
            this.cbxUpdatePolicy.TabIndex = 31;
            // 
            // lblUpdatePolicy
            // 
            this.lblUpdatePolicy.AutoEllipsis = true;
            this.lblUpdatePolicy.AutoSize = true;
            this.lblUpdatePolicy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpdatePolicy.Location = new System.Drawing.Point(3, 27);
            this.lblUpdatePolicy.Name = "lblUpdatePolicy";
            this.lblUpdatePolicy.Size = new System.Drawing.Size(259, 27);
            this.lblUpdatePolicy.TabIndex = 30;
            this.lblUpdatePolicy.Text = "Update policy";
            this.lblUpdatePolicy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabUpdateLog
            // 
            this.tabUpdateLog.Controls.Add(this.splitContainer1);
            this.tabUpdateLog.Location = new System.Drawing.Point(4, 22);
            this.tabUpdateLog.Name = "tabUpdateLog";
            this.tabUpdateLog.Padding = new System.Windows.Forms.Padding(6);
            this.tabUpdateLog.Size = new System.Drawing.Size(536, 292);
            this.tabUpdateLog.TabIndex = 1;
            this.tabUpdateLog.Text = "Update log";
            this.tabUpdateLog.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(6, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel5);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel4);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel7);
            this.splitContainer1.Panel2.Controls.Add(this.capDetails);
            this.splitContainer1.Size = new System.Drawing.Size(524, 280);
            this.splitContainer1.SplitterDistance = 327;
            this.splitContainer1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtLog);
            this.panel2.Controls.Add(this.tlsMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 280);
            this.panel2.TabIndex = 6;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.ContextMenuStrip = this.contextMenuStrip1;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(0, 25);
            this.txtLog.MaxLength = 2147483647;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(327, 255);
            this.txtLog.TabIndex = 4;
            this.txtLog.WordWrap = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxSelectionToClipboard,
            this.ctxEverythingToClipboard});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(198, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ctxSelectionToClipboard
            // 
            this.ctxSelectionToClipboard.Name = "ctxSelectionToClipboard";
            this.ctxSelectionToClipboard.Size = new System.Drawing.Size(197, 22);
            this.ctxSelectionToClipboard.Text = "Selection to clipboard";
            this.ctxSelectionToClipboard.Click += new System.EventHandler(this.selectionToClipboardToolStripMenuItem_Click);
            // 
            // ctxEverythingToClipboard
            // 
            this.ctxEverythingToClipboard.Name = "ctxEverythingToClipboard";
            this.ctxEverythingToClipboard.Size = new System.Drawing.Size(197, 22);
            this.ctxEverythingToClipboard.Text = "Everything to clipboard";
            this.ctxEverythingToClipboard.Click += new System.EventHandler(this.everythingToClipboardToolStripMenuItem_Click);
            // 
            // tlsMain
            // 
            this.tlsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopy});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(327, 25);
            this.tlsMain.TabIndex = 5;
            // 
            // btnCopy
            // 
            this.btnCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSelectionToClipboard,
            this.btnEverythingToClipboard});
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(64, 22);
            this.btnCopy.Text = "Copy";
            this.btnCopy.DropDownOpening += new System.EventHandler(this.btnCopy_DropDownOpening);
            // 
            // btnSelectionToClipboard
            // 
            this.btnSelectionToClipboard.Enabled = false;
            this.btnSelectionToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectionToClipboard.Image")));
            this.btnSelectionToClipboard.Name = "btnSelectionToClipboard";
            this.btnSelectionToClipboard.Size = new System.Drawing.Size(197, 22);
            this.btnSelectionToClipboard.Text = "Selection to clipboard";
            this.btnSelectionToClipboard.Click += new System.EventHandler(this.btnSelectionToClipboard_Click);
            // 
            // btnEverythingToClipboard
            // 
            this.btnEverythingToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btnEverythingToClipboard.Image")));
            this.btnEverythingToClipboard.Name = "btnEverythingToClipboard";
            this.btnEverythingToClipboard.Size = new System.Drawing.Size(197, 22);
            this.btnEverythingToClipboard.Text = "Everything to clipboard";
            this.btnEverythingToClipboard.Click += new System.EventHandler(this.btnEverythingToClipboard_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.Controls.Add(this.button3, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblCacheFilename, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtCacheFilename, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 195);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(193, 55);
            this.tableLayoutPanel5.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Enabled = false;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(153, 29);
            this.button3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 26);
            this.button3.TabIndex = 14;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblCacheFilename
            // 
            this.lblCacheFilename.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.lblCacheFilename, 2);
            this.lblCacheFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheFilename.Location = new System.Drawing.Point(3, 0);
            this.lblCacheFilename.Name = "lblCacheFilename";
            this.lblCacheFilename.Padding = new System.Windows.Forms.Padding(0, 15, 0, 1);
            this.lblCacheFilename.Size = new System.Drawing.Size(187, 29);
            this.lblCacheFilename.TabIndex = 1;
            this.lblCacheFilename.Text = "Cache filename";
            // 
            // txtCacheFilename
            // 
            this.txtCacheFilename.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCacheFilename.Location = new System.Drawing.Point(3, 32);
            this.txtCacheFilename.Name = "txtCacheFilename";
            this.txtCacheFilename.ReadOnly = true;
            this.txtCacheFilename.Size = new System.Drawing.Size(147, 20);
            this.txtCacheFilename.TabIndex = 2;
            this.txtCacheFilename.TextChanged += new System.EventHandler(this.txtCacheFilename_TextChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtContentSize, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 140);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(193, 55);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 15, 0, 1);
            this.label2.Size = new System.Drawing.Size(187, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Content size";
            // 
            // txtContentSize
            // 
            this.txtContentSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtContentSize.Location = new System.Drawing.Point(3, 32);
            this.txtContentSize.Name = "txtContentSize";
            this.txtContentSize.ReadOnly = true;
            this.txtContentSize.Size = new System.Drawing.Size(187, 20);
            this.txtContentSize.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.lblLastUpdated, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtLastUpdated, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 85);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(193, 55);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.AutoSize = true;
            this.lblLastUpdated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastUpdated.Location = new System.Drawing.Point(3, 0);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Padding = new System.Windows.Forms.Padding(0, 15, 0, 1);
            this.lblLastUpdated.Size = new System.Drawing.Size(187, 29);
            this.lblLastUpdated.TabIndex = 1;
            this.lblLastUpdated.Text = "Last updated";
            // 
            // txtLastUpdated
            // 
            this.txtLastUpdated.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLastUpdated.Location = new System.Drawing.Point(3, 32);
            this.txtLastUpdated.Name = "txtLastUpdated";
            this.txtLastUpdated.ReadOnly = true;
            this.txtLastUpdated.Size = new System.Drawing.Size(187, 20);
            this.txtLastUpdated.TabIndex = 2;
            // 
            // capDetails
            // 
            this.capDetails.Caption = "Details";
            this.capDetails.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capDetails.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.capDetails.Location = new System.Drawing.Point(0, 0);
            this.capDetails.Name = "capDetails";
            this.capDetails.Size = new System.Drawing.Size(193, 30);
            this.capDetails.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 10);
            this.panel1.TabIndex = 20;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.lblLastChecked, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.txtLastChecked, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(193, 55);
            this.tableLayoutPanel7.TabIndex = 10;
            // 
            // lblLastChecked
            // 
            this.lblLastChecked.AutoSize = true;
            this.lblLastChecked.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastChecked.Location = new System.Drawing.Point(3, 0);
            this.lblLastChecked.Name = "lblLastChecked";
            this.lblLastChecked.Padding = new System.Windows.Forms.Padding(0, 15, 0, 1);
            this.lblLastChecked.Size = new System.Drawing.Size(187, 29);
            this.lblLastChecked.TabIndex = 1;
            this.lblLastChecked.Text = "Last checked";
            // 
            // txtLastChecked
            // 
            this.txtLastChecked.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLastChecked.Location = new System.Drawing.Point(3, 32);
            this.txtLastChecked.Name = "txtLastChecked";
            this.txtLastChecked.ReadOnly = true;
            this.txtLastChecked.Size = new System.Drawing.Size(187, 20);
            this.txtLastChecked.TabIndex = 2;
            // 
            // RepositoryForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 511);
            this.Controls.Add(this.grpUpdateSettings);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 550);
            this.Name = "RepositoryForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.RepositoryForm_Shown);
            this.panel4.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grpUpdateSettings.ResumeLayout(false);
            this.tbcGeneral.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabUpdates.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateMinutes)).EndInit();
            this.tabUpdateLog.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox grpUpdateSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblDefaultBehavior;
        private System.Windows.Forms.ComboBox cbxNewBehavior;
        private System.Windows.Forms.CheckBox chkAllowScript;
        private System.Windows.Forms.CheckBox chkAllowProcess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxUpdatePolicy;
        private System.Windows.Forms.Label lblUpdatePolicy;
        private System.Windows.Forms.CheckBox chkKeepLocal;
        private System.Windows.Forms.TabControl tbcGeneral;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabUpdateLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripDropDownButton btnCopy;
        private System.Windows.Forms.ToolStripMenuItem btnSelectionToClipboard;
        private System.Windows.Forms.ToolStripMenuItem btnEverythingToClipboard;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private CustomControls.PrettyCaption capDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.TextBox txtLastUpdated;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContentSize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblCacheFilename;
        private System.Windows.Forms.TextBox txtCacheFilename;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctxSelectionToClipboard;
        private System.Windows.Forms.ToolStripMenuItem ctxEverythingToClipboard;
        private System.Windows.Forms.CheckBox chkAllowWmsg;
        private System.Windows.Forms.CheckBox chkAllowObs;
        private System.Windows.Forms.Label lblAudioOverride;
        private System.Windows.Forms.ComboBox cbxAudioOverride;
        private System.Windows.Forms.CheckBox chkAllowDisk;
        private System.Windows.Forms.TabPage tabUpdates;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.CheckBox cbxUpdateAuto;
        private System.Windows.Forms.Label lblUpdateInterval;
        private System.Windows.Forms.NumericUpDown nudUpdateMinutes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label lblLastChecked;
        private System.Windows.Forms.TextBox txtLastChecked;
    }
}