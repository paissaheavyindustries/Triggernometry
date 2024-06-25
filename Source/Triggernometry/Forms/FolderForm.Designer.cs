namespace Triggernometry.Forms
{
    partial class FolderForm
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
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.lblFolderName = new System.Windows.Forms.Label();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpSetting = new System.Windows.Forms.GroupBox();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabFilter = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelFilter = new System.Windows.Forms.TableLayoutPanel();
            this.expEventFilterRegex = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblEventFilterRegex = new System.Windows.Forms.Label();
            this.chkEventFilter = new System.Windows.Forms.CheckBox();
            this.lblZoneFilterRegex = new System.Windows.Forms.Label();
            this.chkZoneFilter = new System.Windows.Forms.CheckBox();
            this.expZoneFilterRegex = new Triggernometry.CustomControls.ExpressionTextBox();
            this.btnGetCurZone = new System.Windows.Forms.Button();
            this.tabEnvironment = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelEnvironment = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetCurFfxivZone = new System.Windows.Forms.Button();
            this.lblFfxivZoneId = new System.Windows.Forms.Label();
            this.chkFfxivZoneFilter = new System.Windows.Forms.CheckBox();
            this.chkFfxivClassFilterEnabled = new System.Windows.Forms.CheckBox();
            this.grpFfxivClassFilter = new System.Windows.Forms.GroupBox();
            this.panelFfxivClassFilter = new System.Windows.Forms.Panel();
            this.chkFfxivClassFilter = new System.Windows.Forms.CheckedListBox();
            this.panelReadOnly = new System.Windows.Forms.Panel();
            this.lblReadOnly = new System.Windows.Forms.Label();
            this.expFfxivZoneFilterRegex = new Triggernometry.CustomControls.ExpressionTextBox();
            this.txtEnvironment = new Triggernometry.CustomControls.ExpressionTextBox.TextBox();
            this.grpGeneral.SuspendLayout();
            this.tableLayoutPanelGeneral.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.grpSetting.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.tabFilter.SuspendLayout();
            this.tableLayoutPanelFilter.SuspendLayout();
            this.tabEnvironment.SuspendLayout();
            this.tableLayoutPanelEnvironment.SuspendLayout();
            this.grpFfxivClassFilter.SuspendLayout();
            this.panelFfxivClassFilter.SuspendLayout();
            this.panelReadOnly.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGeneral
            // 
            this.grpGeneral.AutoSize = true;
            this.grpGeneral.Controls.Add(this.tableLayoutPanelGeneral);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGeneral.Location = new System.Drawing.Point(10, 10);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(10);
            this.grpGeneral.Size = new System.Drawing.Size(564, 59);
            this.grpGeneral.TabIndex = 13;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = " General ";
            // 
            // tableLayoutPanelGeneral
            // 
            this.tableLayoutPanelGeneral.AutoSize = true;
            this.tableLayoutPanelGeneral.ColumnCount = 2;
            this.tableLayoutPanelGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGeneral.Controls.Add(this.lblFolderName, 0, 0);
            this.tableLayoutPanelGeneral.Controls.Add(this.txtFolderName, 1, 0);
            this.tableLayoutPanelGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelGeneral.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanelGeneral.Name = "tableLayoutPanelGeneral";
            this.tableLayoutPanelGeneral.RowCount = 1;
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelGeneral.Size = new System.Drawing.Size(544, 26);
            this.tableLayoutPanelGeneral.TabIndex = 0;
            // 
            // lblFolderName
            // 
            this.lblFolderName.AutoEllipsis = true;
            this.lblFolderName.AutoSize = true;
            this.lblFolderName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFolderName.Location = new System.Drawing.Point(3, 0);
            this.lblFolderName.Name = "lblFolderName";
            this.lblFolderName.Size = new System.Drawing.Size(65, 26);
            this.lblFolderName.TabIndex = 0;
            this.lblFolderName.Text = "Folder name";
            this.lblFolderName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFolderName
            // 
            this.txtFolderName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFolderName.Location = new System.Drawing.Point(74, 3);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(467, 20);
            this.txtFolderName.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 506);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 10);
            this.panel3.TabIndex = 14;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnOk);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(10, 516);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(564, 35);
            this.panelBottom.TabIndex = 15;
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
            this.btnOk.Enabled = true;
            this.btnOk.Location = new System.Drawing.Point(0, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 35);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 10);
            this.panel1.TabIndex = 16;
            // 
            // grpSetting
            // 
            this.grpSetting.AutoSize = true;
            this.grpSetting.Controls.Add(this.tbcMain);
            this.grpSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSetting.Location = new System.Drawing.Point(10, 130);
            this.grpSetting.Name = "grpSetting";
            this.grpSetting.Padding = new System.Windows.Forms.Padding(10);
            this.grpSetting.Size = new System.Drawing.Size(564, 376);
            this.grpSetting.TabIndex = 17;
            this.grpSetting.TabStop = false;
            this.grpSetting.Text = " Settings ";
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tabFilter);
            this.tbcMain.Controls.Add(this.tabEnvironment);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(10, 23);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(544, 343);
            this.tbcMain.TabIndex = 19;
            // 
            // tabFilter
            // 
            this.tabFilter.AutoScroll = true;
            this.tabFilter.Controls.Add(this.tableLayoutPanelFilter);
            this.tabFilter.Location = new System.Drawing.Point(4, 22);
            this.tabFilter.Name = "tabFilter";
            this.tabFilter.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilter.Size = new System.Drawing.Size(536, 317);
            this.tabFilter.TabIndex = 0;
            this.tabFilter.Text = "Filter";
            this.tabFilter.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelFilter
            // 
            this.tableLayoutPanelFilter.AutoSize = true;
            this.tableLayoutPanelFilter.ColumnCount = 3;
            this.tableLayoutPanelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutPanelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelFilter.Controls.Add(this.chkZoneFilter, 0, 0);
            this.tableLayoutPanelFilter.Controls.Add(this.lblZoneFilterRegex, 0, 1);
            this.tableLayoutPanelFilter.Controls.Add(this.expZoneFilterRegex, 1, 1);
            this.tableLayoutPanelFilter.Controls.Add(this.btnGetCurZone, 2, 1);
            this.tableLayoutPanelFilter.Controls.Add(this.chkFfxivZoneFilter, 0, 2);
            this.tableLayoutPanelFilter.Controls.Add(this.lblFfxivZoneId, 0, 3);
            this.tableLayoutPanelFilter.Controls.Add(this.expFfxivZoneFilterRegex, 1, 3);
            this.tableLayoutPanelFilter.Controls.Add(this.btnGetCurFfxivZone, 2, 3);
            this.tableLayoutPanelFilter.Controls.Add(this.chkEventFilter, 0, 4);
            this.tableLayoutPanelFilter.Controls.Add(this.lblEventFilterRegex, 0, 5);
            this.tableLayoutPanelFilter.Controls.Add(this.expEventFilterRegex, 1, 5);
            this.tableLayoutPanelFilter.Controls.Add(this.chkFfxivClassFilterEnabled, 0, 6);
            this.tableLayoutPanelFilter.Controls.Add(this.grpFfxivClassFilter, 0, 7);
            this.tableLayoutPanelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelFilter.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelFilter.Name = "tableLayoutPanelFilter";
            this.tableLayoutPanelFilter.RowCount = 8;
            this.tableLayoutPanelFilter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFilter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFilter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFilter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFilter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFilter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFilter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFilter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFilter.Size = new System.Drawing.Size(530, 135);
            this.tableLayoutPanelFilter.TabIndex = 1;
            // 
            // chkZoneFilter
            // 
            this.chkZoneFilter.AutoSize = true;
            this.chkZoneFilter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanelFilter.SetColumnSpan(this.chkZoneFilter, 3);
            this.chkZoneFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkZoneFilter.Location = new System.Drawing.Point(3, 5);
            this.chkZoneFilter.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkZoneFilter.Name = "chkZoneFilter";
            this.chkZoneFilter.Size = new System.Drawing.Size(525, 17);
            this.chkZoneFilter.TabIndex = 7;
            this.chkZoneFilter.Text = "Restrict event processing only to events with matching zone name (regex)";
            this.chkZoneFilter.UseVisualStyleBackColor = true;
            this.chkZoneFilter.CheckedChanged += new System.EventHandler(this.chkZoneFilter_CheckedChanged);
            // 
            // lblZoneFilterRegex
            // 
            this.lblZoneFilterRegex.AutoEllipsis = true;
            this.lblZoneFilterRegex.AutoSize = true;
            this.lblZoneFilterRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZoneFilterRegex.Location = new System.Drawing.Point(3, 27);
            this.lblZoneFilterRegex.Name = "lblZoneFilterRegex";
            this.lblZoneFilterRegex.Size = new System.Drawing.Size(149, 26);
            this.lblZoneFilterRegex.TabIndex = 8;
            this.lblZoneFilterRegex.Text = "Zone name";
            this.lblZoneFilterRegex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expZoneFilterRegex
            // 
            this.expZoneFilterRegex.AutoSize = true;
            this.expZoneFilterRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expZoneFilterRegex.Enabled = false;
            this.expZoneFilterRegex.Expression = "";
            this.expZoneFilterRegex.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
            this.expZoneFilterRegex.Location = new System.Drawing.Point(158, 30);
            this.expZoneFilterRegex.Name = "expZoneFilterRegex";
            this.expZoneFilterRegex.ReadOnly = false;
            this.expZoneFilterRegex.Size = new System.Drawing.Size(369, 20);
            this.expZoneFilterRegex.TabIndex = 13;
            // 
            // btnGetCurZone
            // 
            this.btnGetCurZone.AutoSize = true;
            this.btnGetCurZone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGetCurZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetCurZone.Enabled = false;
            this.btnGetCurZone.Name = "btnGetCurZone";
            this.btnGetCurZone.TabIndex = 15;
            this.btnGetCurZone.Text = "Retrieve";
            this.btnGetCurZone.UseVisualStyleBackColor = true;
            this.btnGetCurZone.Click += new System.EventHandler(this.btnGetCurZone_Click);
            // 
            // chkFfxivZoneFilter
            // 
            this.chkFfxivZoneFilter.AutoSize = true;
            this.chkFfxivZoneFilter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanelFilter.SetColumnSpan(this.chkFfxivZoneFilter, 3);
            this.chkFfxivZoneFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkFfxivZoneFilter.Location = new System.Drawing.Point(3, 5);
            this.chkFfxivZoneFilter.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkFfxivZoneFilter.Name = "chkFfxivZoneFilter";
            this.chkFfxivZoneFilter.Size = new System.Drawing.Size(525, 17);
            this.chkFfxivZoneFilter.TabIndex = 9;
            this.chkFfxivZoneFilter.Text = "Restrict event processing only to when currently in given zone ID (regex)";
            this.chkFfxivZoneFilter.UseVisualStyleBackColor = true;
            this.chkFfxivZoneFilter.CheckedChanged += new System.EventHandler(this.chkFfxivZoneFilter_CheckedChanged);
            // 
            // lblFfxivZoneId
            // 
            this.lblFfxivZoneId.AutoEllipsis = true;
            this.lblFfxivZoneId.AutoSize = true;
            this.lblFfxivZoneId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFfxivZoneId.Location = new System.Drawing.Point(3, 27);
            this.lblFfxivZoneId.Name = "lblFfxivZoneId";
            this.lblFfxivZoneId.Size = new System.Drawing.Size(94, 26);
            this.lblFfxivZoneId.TabIndex = 10;
            this.lblFfxivZoneId.Text = "Zone ID";
            this.lblFfxivZoneId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expFfxivZoneFilterRegex
            // 
            this.expFfxivZoneFilterRegex.AutoSize = true;
            this.expFfxivZoneFilterRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expFfxivZoneFilterRegex.Enabled = false;
            this.expFfxivZoneFilterRegex.Expression = "";
            this.expFfxivZoneFilterRegex.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
            this.expFfxivZoneFilterRegex.Location = new System.Drawing.Point(103, 30);
            this.expFfxivZoneFilterRegex.Name = "expFfxivZoneFilterRegex";
            this.expFfxivZoneFilterRegex.ReadOnly = false;
            this.expFfxivZoneFilterRegex.Size = new System.Drawing.Size(424, 20);
            this.expFfxivZoneFilterRegex.TabIndex = 17;
            // 
            // btnGetCurFfxivZone
            // 
            this.btnGetCurFfxivZone.AutoSize = true;
            this.btnGetCurFfxivZone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGetCurFfxivZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetCurFfxivZone.Enabled = false;
            this.btnGetCurFfxivZone.Name = "btnGetCurFfxivZone";
            this.btnGetCurFfxivZone.TabIndex = 16;
            this.btnGetCurFfxivZone.Text = "Retrieve";
            this.btnGetCurFfxivZone.UseVisualStyleBackColor = true;
            this.btnGetCurFfxivZone.Click += new System.EventHandler(this.btnGetCurFfxivZone_Click);
            // 
            // chkEventFilter
            // 
            this.chkEventFilter.AutoSize = true;
            this.chkEventFilter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanelFilter.SetColumnSpan(this.chkEventFilter, 3);
            this.chkEventFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkEventFilter.Location = new System.Drawing.Point(3, 87);
            this.chkEventFilter.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkEventFilter.Name = "chkEventFilter";
            this.chkEventFilter.Size = new System.Drawing.Size(525, 17);
            this.chkEventFilter.TabIndex = 10;
            this.chkEventFilter.Text = "Restrict event processing only to events with matching event text";
            this.chkEventFilter.UseVisualStyleBackColor = true;
            this.chkEventFilter.CheckedChanged += new System.EventHandler(this.chkEventFilter_CheckedChanged);
            // 
            // lblEventFilterRegex
            // 
            this.lblEventFilterRegex.AutoEllipsis = true;
            this.lblEventFilterRegex.AutoSize = true;
            this.lblEventFilterRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEventFilterRegex.Location = new System.Drawing.Point(3, 109);
            this.lblEventFilterRegex.Name = "lblEventFilterRegex";
            this.lblEventFilterRegex.Size = new System.Drawing.Size(149, 26);
            this.lblEventFilterRegex.TabIndex = 11;
            this.lblEventFilterRegex.Text = "Text regex";
            this.lblEventFilterRegex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expEventFilterRegex
            // 
            this.expEventFilterRegex.AutoSize = true;
            this.tableLayoutPanelFilter.SetColumnSpan(this.expEventFilterRegex, 2);
            this.expEventFilterRegex.Dock = System.Windows.Forms.DockStyle.Top;
            this.expEventFilterRegex.Enabled = false;
            this.expEventFilterRegex.Expression = "";
            this.expEventFilterRegex.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
            this.expEventFilterRegex.Location = new System.Drawing.Point(158, 112);
            this.expEventFilterRegex.Name = "expEventFilterRegex";
            this.expEventFilterRegex.ReadOnly = false;
            this.expEventFilterRegex.Size = new System.Drawing.Size(369, 20);
            this.expEventFilterRegex.TabIndex = 14;
            // 
            // chkFfxivClassFilterEnabled
            // 
            this.chkFfxivClassFilterEnabled.AutoSize = true;
            this.chkFfxivClassFilterEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanelEnvironment.SetColumnSpan(this.chkFfxivClassFilterEnabled, 3);
            this.chkFfxivClassFilterEnabled.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkFfxivClassFilterEnabled.Location = new System.Drawing.Point(3, 87);
            this.chkFfxivClassFilterEnabled.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkFfxivClassFilterEnabled.Name = "chkFfxivClassFilterEnabled";
            this.chkFfxivClassFilterEnabled.Size = new System.Drawing.Size(525, 17);
            this.chkFfxivClassFilterEnabled.TabIndex = 7;
            this.chkFfxivClassFilterEnabled.Text = "Process events only if currently on one of the specified classes";
            this.chkFfxivClassFilterEnabled.UseVisualStyleBackColor = true;
            this.chkFfxivClassFilterEnabled.CheckedChanged += new System.EventHandler(this.chkFfxivClassFilterEnabled_CheckedChanged);
            // 
            // grpFfxivClassFilter
            // 
            this.tableLayoutPanelEnvironment.SetColumnSpan(this.grpFfxivClassFilter, 3);
            this.grpFfxivClassFilter.Controls.Add(this.panelFfxivClassFilter);
            this.grpFfxivClassFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFfxivClassFilter.Enabled = true;
            this.grpFfxivClassFilter.Location = new System.Drawing.Point(3, 112);
            this.grpFfxivClassFilter.Name = "grpFfxivClassFilter";
            this.grpFfxivClassFilter.Padding = new System.Windows.Forms.Padding(10);
            this.grpFfxivClassFilter.Size = new System.Drawing.Size(524, 196);
            this.grpFfxivClassFilter.TabIndex = 8;
            this.grpFfxivClassFilter.TabStop = false;
            this.grpFfxivClassFilter.Text = " Classes ";
            // 
            // panelFfxivClassFilter
            // 
            this.panelFfxivClassFilter.AutoScroll = true;
            this.panelFfxivClassFilter.Controls.Add(this.chkFfxivClassFilter);
            this.panelFfxivClassFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFfxivClassFilter.Location = new System.Drawing.Point(10, 23);
            this.panelFfxivClassFilter.Name = "panelFfxivClassFilter";
            this.panelFfxivClassFilter.Size = new System.Drawing.Size(504, 163);
            this.panelFfxivClassFilter.TabIndex = 16;
            // 
            // chkFfxivClassFilter
            // 
            this.chkFfxivClassFilter.CheckOnClick = true;
            this.chkFfxivClassFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFfxivClassFilter.FormattingEnabled = true;
            this.chkFfxivClassFilter.IntegralHeight = false;
            this.chkFfxivClassFilter.Location = new System.Drawing.Point(0, 0);
            this.chkFfxivClassFilter.Name = "chkFfxivClassFilter";
            this.chkFfxivClassFilter.ScrollAlwaysVisible = true;
            this.chkFfxivClassFilter.Size = new System.Drawing.Size(504, 163);
            this.chkFfxivClassFilter.TabIndex = 15;
            this.chkFfxivClassFilter.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.chkFfxivClassFilter.SelectedIndexChanged += new System.EventHandler(this.chkFfxivClassFilter_SelectedIndexChanged);
            // 
            // tabEnvironment
            // 
            this.tabEnvironment.AutoScroll = true;
            this.tabEnvironment.Controls.Add(this.tableLayoutPanelEnvironment);
            this.tabEnvironment.Location = new System.Drawing.Point(4, 22);
            this.tabEnvironment.Name = "tabEnvironment";
            this.tabEnvironment.Padding = new System.Windows.Forms.Padding(3);
            this.tabEnvironment.Size = new System.Drawing.Size(536, 317);
            this.tabEnvironment.TabIndex = 1;
            this.tabEnvironment.Text = "Environment";
            this.tabEnvironment.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelEnvironment
            // 
            this.tableLayoutPanelEnvironment.AutoSize = true;
            this.tableLayoutPanelEnvironment.ColumnCount = 2;
            this.tableLayoutPanelEnvironment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEnvironment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanelEnvironment.Controls.Add(this.txtEnvironment, 0, 0);
            this.tableLayoutPanelEnvironment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelEnvironment.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelEnvironment.Name = "tableLayoutPanelEnvironment";
            this.tableLayoutPanelEnvironment.RowCount = 1;
            this.tableLayoutPanelEnvironment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutPanelEnvironment.TabIndex = 2;
            // 
            // txtEnvironment
            // 
            this.txtEnvironment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEnvironment.Multiline = true;
            this.txtEnvironment.Name = "txtEnvironment";
            this.txtEnvironment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEnvironment.TabIndex = 15;
            // 
            // panelReadOnly
            // 
            this.panelReadOnly.BackColor = System.Drawing.SystemColors.Control;
            this.panelReadOnly.Controls.Add(this.lblReadOnly);
            this.panelReadOnly.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelReadOnly.Location = new System.Drawing.Point(10, 79);
            this.panelReadOnly.Name = "panelReadOnly";
            this.panelReadOnly.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panelReadOnly.Size = new System.Drawing.Size(564, 51);
            this.panelReadOnly.TabIndex = 18;
            this.panelReadOnly.Visible = false;
            // 
            // lblReadOnly
            // 
            this.lblReadOnly.AutoEllipsis = true;
            this.lblReadOnly.BackColor = System.Drawing.SystemColors.Info;
            this.lblReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReadOnly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReadOnly.Location = new System.Drawing.Point(0, 0);
            this.lblReadOnly.Name = "lblReadOnly";
            this.lblReadOnly.Size = new System.Drawing.Size(564, 41);
            this.lblReadOnly.TabIndex = 0;
            this.lblReadOnly.Text = "You are in read-only mode, as the configuration of remote folders can\'t be edited" +
    " locally. If you wish to edit the folder, you will need to make a local copy of " +
    "it.";
            this.lblReadOnly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FolderForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.grpSetting);
            this.Controls.Add(this.panelReadOnly);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(650, 700);
            this.Name = "FolderForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.tableLayoutPanelGeneral.ResumeLayout(false);
            this.tableLayoutPanelGeneral.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.grpSetting.ResumeLayout(false);
            this.tbcMain.ResumeLayout(false);
            this.tabFilter.ResumeLayout(false);
            this.tabFilter.PerformLayout();
            this.tableLayoutPanelFilter.ResumeLayout(false);
            this.tableLayoutPanelFilter.PerformLayout();
            this.tabEnvironment.ResumeLayout(false);
            this.tabEnvironment.PerformLayout();
            this.tableLayoutPanelEnvironment.ResumeLayout(false);
            this.tableLayoutPanelEnvironment.PerformLayout();
            this.grpFfxivClassFilter.ResumeLayout(false);
            this.panelFfxivClassFilter.ResumeLayout(false);
            this.panelReadOnly.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGeneral;
        private System.Windows.Forms.Label lblFolderName;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpSetting;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFilter;
        private CustomControls.ExpressionTextBox expEventFilterRegex;
        private System.Windows.Forms.Label lblEventFilterRegex;
        private System.Windows.Forms.CheckBox chkEventFilter;
        private System.Windows.Forms.Label lblZoneFilterRegex;
        private System.Windows.Forms.CheckBox chkZoneFilter;
        private CustomControls.ExpressionTextBox expZoneFilterRegex;
        private System.Windows.Forms.TabPage tabEnvironment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEnvironment;
        private System.Windows.Forms.CheckBox chkFfxivClassFilterEnabled;
        private System.Windows.Forms.GroupBox grpFfxivClassFilter;
        private System.Windows.Forms.CheckedListBox chkFfxivClassFilter;
        private System.Windows.Forms.Button btnGetCurZone;
        private System.Windows.Forms.Panel panelReadOnly;
        private System.Windows.Forms.Label lblReadOnly;
        private System.Windows.Forms.Panel panelFfxivClassFilter;
        private System.Windows.Forms.Button btnGetCurFfxivZone;
        private System.Windows.Forms.Label lblFfxivZoneId;
        private System.Windows.Forms.CheckBox chkFfxivZoneFilter;
        private CustomControls.ExpressionTextBox expFfxivZoneFilterRegex;
        private System.Windows.Forms.TextBox txtEnvironment;
    }
}