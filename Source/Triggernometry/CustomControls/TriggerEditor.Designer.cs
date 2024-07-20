namespace Triggernometry.CustomControls
{
    partial class TriggerEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.capGeneral = new Triggernometry.CustomControls.PrettyCaption();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtUpdateChannelUri = new System.Windows.Forms.TextBox();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.lblUpdateChannelUri = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.splitButton1 = new Triggernometry.CustomControls.SplitButton();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // capGeneral
            // 
            this.capGeneral.Caption = "General settings";
            this.capGeneral.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capGeneral.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capGeneral.Collapsed = false;
            this.capGeneral.Collapsee = null;
            this.capGeneral.Collapsible = false;
            this.capGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.capGeneral.Location = new System.Drawing.Point(0, 0);
            this.capGeneral.Name = "capGeneral";
            this.capGeneral.Size = new System.Drawing.Size(801, 30);
            this.capGeneral.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel1.Size = new System.Drawing.Size(801, 69);
            this.panel1.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtUpdateChannelUri, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbxType, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblUpdateChannelUri, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(801, 53);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // txtUpdateChannelUri
            // 
            this.txtUpdateChannelUri.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUpdateChannelUri.Location = new System.Drawing.Point(159, 3);
            this.txtUpdateChannelUri.Name = "txtUpdateChannelUri";
            this.txtUpdateChannelUri.Size = new System.Drawing.Size(639, 20);
            this.txtUpdateChannelUri.TabIndex = 22;
            // 
            // cbxType
            // 
            this.cbxType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "Built-in Github check (legacy)",
            "Official (recommended)",
            "External third party"});
            this.cbxType.Location = new System.Drawing.Point(159, 29);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(639, 21);
            this.cbxType.TabIndex = 12;
            // 
            // lblUpdateChannelUri
            // 
            this.lblUpdateChannelUri.AutoEllipsis = true;
            this.lblUpdateChannelUri.AutoSize = true;
            this.lblUpdateChannelUri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpdateChannelUri.Location = new System.Drawing.Point(3, 26);
            this.lblUpdateChannelUri.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblUpdateChannelUri.Name = "lblUpdateChannelUri";
            this.lblUpdateChannelUri.Size = new System.Drawing.Size(150, 27);
            this.lblUpdateChannelUri.TabIndex = 11;
            this.lblUpdateChannelUri.Text = "Trigger type";
            this.lblUpdateChannelUri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(150, 26);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(271, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(478, 243);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 150);
            this.comboBox1.TabIndex = 11;
            // 
            // splitButton1
            // 
            this.splitButton1.AutoSize = true;
            this.splitButton1.Location = new System.Drawing.Point(123, 184);
            this.splitButton1.Name = "splitButton1";
            this.splitButton1.Size = new System.Drawing.Size(150, 23);
            this.splitButton1.TabIndex = 12;
            this.splitButton1.Text = "splitButton1";
            this.splitButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButton1.UseVisualStyleBackColor = true;
            // 
            // TriggerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitButton1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.capGeneral);
            this.Name = "TriggerEditor";
            this.Size = new System.Drawing.Size(801, 584);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PrettyCaption capGeneral;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtUpdateChannelUri;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Label lblUpdateChannelUri;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private SplitButton splitButton1;
    }
}
