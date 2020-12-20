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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFolderName = new System.Windows.Forms.Label();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpFiltering = new System.Windows.Forms.GroupBox();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtEventFilterRegex = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblEventFilterRegex = new System.Windows.Forms.Label();
            this.chkEventFilter = new System.Windows.Forms.CheckBox();
            this.lblZoneFilterRegex = new System.Windows.Forms.Label();
            this.chkZoneFilter = new System.Windows.Forms.CheckBox();
            this.txtZoneFilterRegex = new Triggernometry.CustomControls.ExpressionTextBox();
            this.btnGetCurZone = new System.Windows.Forms.Button();
            this.tabFFXIV = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetCurFfxivZone = new System.Windows.Forms.Button();
            this.lblFfxivZoneId = new System.Windows.Forms.Label();
            this.chkFfxivZoneFilter = new System.Windows.Forms.CheckBox();
            this.chkFfxivClassFilterEnabled = new System.Windows.Forms.CheckBox();
            this.grpFfxivClassFilter = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkFfxivClassFilter = new System.Windows.Forms.CheckedListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblReadOnly = new System.Windows.Forms.Label();
            this.txtFfxivZoneFilterRegex = new Triggernometry.CustomControls.ExpressionTextBox();
            this.grpGeneral.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.grpFiltering.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabFFXIV.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.grpFfxivClassFilter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGeneral
            // 
            this.grpGeneral.AutoSize = true;
            this.grpGeneral.Controls.Add(this.tableLayoutPanel1);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGeneral.Location = new System.Drawing.Point(10, 10);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(10);
            this.grpGeneral.Size = new System.Drawing.Size(564, 59);
            this.grpGeneral.TabIndex = 13;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = " General settings ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblFolderName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFolderName, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 26);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.txtFolderName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 506);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 10);
            this.panel3.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnOk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 516);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(564, 35);
            this.panel4.TabIndex = 15;
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
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 10);
            this.panel1.TabIndex = 16;
            // 
            // grpFiltering
            // 
            this.grpFiltering.AutoSize = true;
            this.grpFiltering.Controls.Add(this.tbcMain);
            this.grpFiltering.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFiltering.Location = new System.Drawing.Point(10, 130);
            this.grpFiltering.Name = "grpFiltering";
            this.grpFiltering.Padding = new System.Windows.Forms.Padding(10);
            this.grpFiltering.Size = new System.Drawing.Size(564, 376);
            this.grpFiltering.TabIndex = 17;
            this.grpFiltering.TabStop = false;
            this.grpFiltering.Text = " Filtering settings ";
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tabGeneral);
            this.tbcMain.Controls.Add(this.tabFFXIV);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(10, 23);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(544, 343);
            this.tbcMain.TabIndex = 19;
            // 
            // tabGeneral
            // 
            this.tabGeneral.AutoScroll = true;
            this.tabGeneral.Controls.Add(this.tableLayoutPanel2);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(536, 317);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtEventFilterRegex, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblEventFilterRegex, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.chkEventFilter, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblZoneFilterRegex, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkZoneFilter, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtZoneFilterRegex, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnGetCurZone, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(530, 135);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // txtEventFilterRegex
            // 
            this.txtEventFilterRegex.AutoSize = true;
            this.txtEventFilterRegex.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtEventFilterRegex.Enabled = false;
            this.txtEventFilterRegex.Expression = "";
            this.txtEventFilterRegex.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
            this.txtEventFilterRegex.Location = new System.Drawing.Point(158, 112);
            this.txtEventFilterRegex.Name = "txtEventFilterRegex";
            this.txtEventFilterRegex.ReadOnly = false;
            this.txtEventFilterRegex.Size = new System.Drawing.Size(369, 20);
            this.txtEventFilterRegex.TabIndex = 14;
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
            this.lblEventFilterRegex.Text = "Event text regular expression";
            this.lblEventFilterRegex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEventFilter
            // 
            this.chkEventFilter.AutoSize = true;
            this.chkEventFilter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel2.SetColumnSpan(this.chkEventFilter, 2);
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
            // lblZoneFilterRegex
            // 
            this.lblZoneFilterRegex.AutoEllipsis = true;
            this.lblZoneFilterRegex.AutoSize = true;
            this.lblZoneFilterRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZoneFilterRegex.Location = new System.Drawing.Point(3, 27);
            this.lblZoneFilterRegex.Name = "lblZoneFilterRegex";
            this.lblZoneFilterRegex.Size = new System.Drawing.Size(149, 26);
            this.lblZoneFilterRegex.TabIndex = 8;
            this.lblZoneFilterRegex.Text = "Zone name regular expression";
            this.lblZoneFilterRegex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkZoneFilter
            // 
            this.chkZoneFilter.AutoSize = true;
            this.chkZoneFilter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel2.SetColumnSpan(this.chkZoneFilter, 2);
            this.chkZoneFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkZoneFilter.Location = new System.Drawing.Point(3, 5);
            this.chkZoneFilter.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkZoneFilter.Name = "chkZoneFilter";
            this.chkZoneFilter.Size = new System.Drawing.Size(525, 17);
            this.chkZoneFilter.TabIndex = 7;
            this.chkZoneFilter.Text = "Restrict event processing only to events with matching zone name";
            this.chkZoneFilter.UseVisualStyleBackColor = true;
            this.chkZoneFilter.CheckedChanged += new System.EventHandler(this.chkZoneFilter_CheckedChanged);
            // 
            // txtZoneFilterRegex
            // 
            this.txtZoneFilterRegex.AutoSize = true;
            this.txtZoneFilterRegex.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtZoneFilterRegex.Enabled = false;
            this.txtZoneFilterRegex.Expression = "";
            this.txtZoneFilterRegex.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
            this.txtZoneFilterRegex.Location = new System.Drawing.Point(158, 30);
            this.txtZoneFilterRegex.Name = "txtZoneFilterRegex";
            this.txtZoneFilterRegex.ReadOnly = false;
            this.txtZoneFilterRegex.Size = new System.Drawing.Size(369, 20);
            this.txtZoneFilterRegex.TabIndex = 13;
            // 
            // btnGetCurZone
            // 
            this.btnGetCurZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetCurZone.Enabled = false;
            this.btnGetCurZone.Location = new System.Drawing.Point(158, 56);
            this.btnGetCurZone.Name = "btnGetCurZone";
            this.btnGetCurZone.Size = new System.Drawing.Size(369, 23);
            this.btnGetCurZone.TabIndex = 15;
            this.btnGetCurZone.Text = "Retrieve current zone name";
            this.btnGetCurZone.UseVisualStyleBackColor = true;
            this.btnGetCurZone.Click += new System.EventHandler(this.btnGetCurZone_Click);
            // 
            // tabFFXIV
            // 
            this.tabFFXIV.AutoScroll = true;
            this.tabFFXIV.Controls.Add(this.tableLayoutPanel3);
            this.tabFFXIV.Location = new System.Drawing.Point(4, 22);
            this.tabFFXIV.Name = "tabFFXIV";
            this.tabFFXIV.Padding = new System.Windows.Forms.Padding(3);
            this.tabFFXIV.Size = new System.Drawing.Size(536, 317);
            this.tabFFXIV.TabIndex = 1;
            this.tabFFXIV.Text = "Final Fantasy XIV";
            this.tabFFXIV.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.txtFfxivZoneFilterRegex, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnGetCurFfxivZone, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblFfxivZoneId, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.chkFfxivZoneFilter, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkFfxivClassFilterEnabled, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.grpFfxivClassFilter, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(530, 311);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btnGetCurFfxivZone
            // 
            this.btnGetCurFfxivZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetCurFfxivZone.Enabled = false;
            this.btnGetCurFfxivZone.Location = new System.Drawing.Point(103, 56);
            this.btnGetCurFfxivZone.Name = "btnGetCurFfxivZone";
            this.btnGetCurFfxivZone.Size = new System.Drawing.Size(424, 23);
            this.btnGetCurFfxivZone.TabIndex = 16;
            this.btnGetCurFfxivZone.Text = "Retrieve current zone ID";
            this.btnGetCurFfxivZone.UseVisualStyleBackColor = true;
            this.btnGetCurFfxivZone.Click += new System.EventHandler(this.btnGetCurFfxivZone_Click);
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
            // chkFfxivZoneFilter
            // 
            this.chkFfxivZoneFilter.AutoSize = true;
            this.chkFfxivZoneFilter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel3.SetColumnSpan(this.chkFfxivZoneFilter, 2);
            this.chkFfxivZoneFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkFfxivZoneFilter.Location = new System.Drawing.Point(3, 5);
            this.chkFfxivZoneFilter.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkFfxivZoneFilter.Name = "chkFfxivZoneFilter";
            this.chkFfxivZoneFilter.Size = new System.Drawing.Size(525, 17);
            this.chkFfxivZoneFilter.TabIndex = 9;
            this.chkFfxivZoneFilter.Text = "Restrict event processing only to when currently in given zone ID";
            this.chkFfxivZoneFilter.UseVisualStyleBackColor = true;
            this.chkFfxivZoneFilter.CheckedChanged += new System.EventHandler(this.chkFfxivZoneFilter_CheckedChanged);
            // 
            // chkFfxivClassFilterEnabled
            // 
            this.chkFfxivClassFilterEnabled.AutoSize = true;
            this.chkFfxivClassFilterEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel3.SetColumnSpan(this.chkFfxivClassFilterEnabled, 2);
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
            this.tableLayoutPanel3.SetColumnSpan(this.grpFfxivClassFilter, 2);
            this.grpFfxivClassFilter.Controls.Add(this.panel2);
            this.grpFfxivClassFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFfxivClassFilter.Enabled = false;
            this.grpFfxivClassFilter.Location = new System.Drawing.Point(3, 112);
            this.grpFfxivClassFilter.Name = "grpFfxivClassFilter";
            this.grpFfxivClassFilter.Padding = new System.Windows.Forms.Padding(10);
            this.grpFfxivClassFilter.Size = new System.Drawing.Size(524, 196);
            this.grpFfxivClassFilter.TabIndex = 8;
            this.grpFfxivClassFilter.TabStop = false;
            this.grpFfxivClassFilter.Text = " Classes ";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.chkFfxivClassFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 163);
            this.panel2.TabIndex = 16;
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
            this.chkFfxivClassFilter.SelectedIndexChanged += new System.EventHandler(this.chkFfxivClassFilter_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.lblReadOnly);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(10, 79);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel5.Size = new System.Drawing.Size(564, 51);
            this.panel5.TabIndex = 18;
            this.panel5.Visible = false;
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
            // txtFfxivZoneFilterRegex
            // 
            this.txtFfxivZoneFilterRegex.AutoSize = true;
            this.txtFfxivZoneFilterRegex.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFfxivZoneFilterRegex.Enabled = false;
            this.txtFfxivZoneFilterRegex.Expression = "";
            this.txtFfxivZoneFilterRegex.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
            this.txtFfxivZoneFilterRegex.Location = new System.Drawing.Point(103, 30);
            this.txtFfxivZoneFilterRegex.Name = "txtFfxivZoneFilterRegex";
            this.txtFfxivZoneFilterRegex.ReadOnly = false;
            this.txtFfxivZoneFilterRegex.Size = new System.Drawing.Size(424, 20);
            this.txtFfxivZoneFilterRegex.TabIndex = 17;
            // 
            // FolderForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.grpFiltering);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "FolderForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.grpFiltering.ResumeLayout(false);
            this.tbcMain.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabFFXIV.ResumeLayout(false);
            this.tabFFXIV.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.grpFfxivClassFilter.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFolderName;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpFiltering;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CustomControls.ExpressionTextBox txtEventFilterRegex;
        private System.Windows.Forms.Label lblEventFilterRegex;
        private System.Windows.Forms.CheckBox chkEventFilter;
        private System.Windows.Forms.Label lblZoneFilterRegex;
        private System.Windows.Forms.CheckBox chkZoneFilter;
        private CustomControls.ExpressionTextBox txtZoneFilterRegex;
        private System.Windows.Forms.TabPage tabFFXIV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox chkFfxivClassFilterEnabled;
        private System.Windows.Forms.GroupBox grpFfxivClassFilter;
        private System.Windows.Forms.CheckedListBox chkFfxivClassFilter;
        private System.Windows.Forms.Button btnGetCurZone;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblReadOnly;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGetCurFfxivZone;
        private System.Windows.Forms.Label lblFfxivZoneId;
        private System.Windows.Forms.CheckBox chkFfxivZoneFilter;
        private CustomControls.ExpressionTextBox txtFfxivZoneFilterRegex;
    }
}