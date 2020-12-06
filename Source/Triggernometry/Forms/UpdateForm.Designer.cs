namespace Triggernometry.Forms
{
    partial class UpdateForm
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
            this.grpPatchDetails = new System.Windows.Forms.GroupBox();
            this.txtPatchDetails = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.capYourVersion = new Triggernometry.CustomControls.PrettyCaption();
            this.capLatestVersion = new Triggernometry.CustomControls.PrettyCaption();
            this.txtYourVersion = new System.Windows.Forms.TextBox();
            this.txtLatestVersion = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.prgProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpPatchDetails.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPatchDetails
            // 
            this.grpPatchDetails.Controls.Add(this.txtPatchDetails);
            this.grpPatchDetails.Controls.Add(this.statusStrip1);
            this.grpPatchDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPatchDetails.Location = new System.Drawing.Point(10, 253);
            this.grpPatchDetails.Name = "grpPatchDetails";
            this.grpPatchDetails.Padding = new System.Windows.Forms.Padding(10);
            this.grpPatchDetails.Size = new System.Drawing.Size(741, 193);
            this.grpPatchDetails.TabIndex = 24;
            this.grpPatchDetails.TabStop = false;
            this.grpPatchDetails.Text = " Update log ";
            // 
            // txtPatchDetails
            // 
            this.txtPatchDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPatchDetails.Location = new System.Drawing.Point(10, 23);
            this.txtPatchDetails.Multiline = true;
            this.txtPatchDetails.Name = "txtPatchDetails";
            this.txtPatchDetails.ReadOnly = true;
            this.txtPatchDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPatchDetails.Size = new System.Drawing.Size(721, 138);
            this.txtPatchDetails.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 446);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(741, 10);
            this.panel3.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnUpdate);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 456);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(741, 35);
            this.panel4.TabIndex = 23;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(591, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(0, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(150, 35);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtLatestVersion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.capLatestVersion, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.capYourVersion, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtYourVersion, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(741, 73);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // capYourVersion
            // 
            this.capYourVersion.Caption = "Currently installed";
            this.capYourVersion.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capYourVersion.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capYourVersion.Location = new System.Drawing.Point(3, 3);
            this.capYourVersion.Name = "capYourVersion";
            this.capYourVersion.Size = new System.Drawing.Size(364, 30);
            this.capYourVersion.TabIndex = 0;
            // 
            // capLatestVersion
            // 
            this.capLatestVersion.Caption = "Latest version";
            this.capLatestVersion.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capLatestVersion.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capLatestVersion.Location = new System.Drawing.Point(373, 3);
            this.capLatestVersion.Name = "capLatestVersion";
            this.capLatestVersion.Size = new System.Drawing.Size(365, 30);
            this.capLatestVersion.TabIndex = 1;
            // 
            // txtYourVersion
            // 
            this.txtYourVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtYourVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYourVersion.Location = new System.Drawing.Point(3, 39);
            this.txtYourVersion.Name = "txtYourVersion";
            this.txtYourVersion.ReadOnly = true;
            this.txtYourVersion.Size = new System.Drawing.Size(364, 31);
            this.txtYourVersion.TabIndex = 2;
            // 
            // txtLatestVersion
            // 
            this.txtLatestVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLatestVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLatestVersion.Location = new System.Drawing.Point(373, 39);
            this.txtLatestVersion.Name = "txtLatestVersion";
            this.txtLatestVersion.ReadOnly = true;
            this.txtLatestVersion.Size = new System.Drawing.Size(365, 31);
            this.txtLatestVersion.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 10);
            this.panel1.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(741, 150);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Update details ";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(10, 23);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(721, 117);
            this.textBox1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 243);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(741, 10);
            this.panel2.TabIndex = 28;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prgProgress,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(10, 161);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(721, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // prgProgress
            // 
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(74, 17);
            this.lblStatus.Text = "Please wait...";
            // 
            // UpdateForm
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 501);
            this.Controls.Add(this.grpPatchDetails);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "UpdateForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Triggernometry Updater";
            this.TopMost = true;
            this.grpPatchDetails.ResumeLayout(false);
            this.grpPatchDetails.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPatchDetails;
        private System.Windows.Forms.TextBox txtPatchDetails;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControls.PrettyCaption capYourVersion;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox txtLatestVersion;
        private CustomControls.PrettyCaption capLatestVersion;
        private System.Windows.Forms.TextBox txtYourVersion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripProgressBar prgProgress;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}