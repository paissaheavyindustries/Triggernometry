namespace Triggernometry.Forms
{
    partial class TestInputForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCopyDebugTrigger = new System.Windows.Forms.Button();
            this.grpEventDetails = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.cbxZoneType = new System.Windows.Forms.ComboBox();
            this.lblZoneType = new System.Windows.Forms.Label();
            this.cbxEventDestination = new System.Windows.Forms.ComboBox();
            this.lblEventDestination = new System.Windows.Forms.Label();
            this.btnGetCurZone = new System.Windows.Forms.Button();
            this.txtEvent = new System.Windows.Forms.TextBox();
            this.lblEvent = new System.Windows.Forms.Label();
            this.lblZoneName = new System.Windows.Forms.Label();
            this.txtZoneName = new System.Windows.Forms.TextBox();
            this.panel4.SuspendLayout();
            this.grpEventDetails.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 356);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(514, 10);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.tableLayoutPanelBottom);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 366);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(514, 35);
            this.panel4.TabIndex = 18;
            // 
            // tableLayoutPanelBottom
            // 
            this.tableLayoutPanelBottom.AutoSize = true;
            this.tableLayoutPanelBottom.ColumnCount = 3;
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelBottom.Controls.Add(this.btnOk, 0, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.btnCopyDebugTrigger, 1, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 1;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.None;
            this.btnOk.Location = new System.Drawing.Point(0, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 35);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCopyDebugTrigger
            // 
            this.btnCopyDebugTrigger.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCopyDebugTrigger.Dock = System.Windows.Forms.DockStyle.None;
            this.btnCopyDebugTrigger.Location = new System.Drawing.Point(182, 0);
            this.btnCopyDebugTrigger.Name = "btnCopyDebugTrigger";
            this.btnCopyDebugTrigger.Size = new System.Drawing.Size(150, 35);
            this.btnCopyDebugTrigger.TabIndex = 1;
            this.btnCopyDebugTrigger.Text = "Copy Debug Trigger";
            this.btnCopyDebugTrigger.UseVisualStyleBackColor = true;
            this.btnCopyDebugTrigger.Click += new System.EventHandler(this.btnCopyDebugTrigger_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.None;
            this.btnCancel.Location = new System.Drawing.Point(364, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // grpEventDetails
            // 
            this.grpEventDetails.AutoSize = true;
            this.grpEventDetails.Controls.Add(this.tableLayoutPanel3);
            this.grpEventDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEventDetails.Location = new System.Drawing.Point(10, 10);
            this.grpEventDetails.Name = "grpEventDetails";
            this.grpEventDetails.Padding = new System.Windows.Forms.Padding(10);
            this.grpEventDetails.Size = new System.Drawing.Size(514, 346);
            this.grpEventDetails.TabIndex = 19;
            this.grpEventDetails.TabStop = false;
            this.grpEventDetails.Text = " Event details ";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.Controls.Add(this.cbxZoneType, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblZoneType, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.cbxEventDestination, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblEventDestination, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnGetCurZone, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtEvent, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblEvent, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblZoneName, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtZoneName, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(494, 313);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // cbxZoneType
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.cbxZoneType, 2);
            this.cbxZoneType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxZoneType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxZoneType.FormattingEnabled = true;
            this.cbxZoneType.Items.AddRange(new object[] {
            "Zone name",
            "FFXIV zone ID"});
            this.cbxZoneType.Location = new System.Drawing.Point(70, 30);
            this.cbxZoneType.Name = "cbxZoneType";
            this.cbxZoneType.Size = new System.Drawing.Size(421, 21);
            this.cbxZoneType.TabIndex = 20;
            this.cbxZoneType.SelectedIndexChanged += new System.EventHandler(this.cbxZoneType_SelectedIndexChanged);
            // 
            // lblZoneType
            // 
            this.lblZoneType.AutoEllipsis = true;
            this.lblZoneType.AutoSize = true;
            this.lblZoneType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZoneType.Location = new System.Drawing.Point(3, 27);
            this.lblZoneType.Name = "lblZoneType";
            this.lblZoneType.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblZoneType.Size = new System.Drawing.Size(61, 27);
            this.lblZoneType.TabIndex = 19;
            this.lblZoneType.Text = "Zone type";
            // 
            // cbxEventDestination
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.cbxEventDestination, 2);
            this.cbxEventDestination.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxEventDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEventDestination.FormattingEnabled = true;
            this.cbxEventDestination.Items.AddRange(new object[] {
            "Normal log line",
            "FFXIV network event",
            "ACT event",
            "Endpoint"});
            this.cbxEventDestination.Location = new System.Drawing.Point(70, 3);
            this.cbxEventDestination.Name = "cbxEventDestination";
            this.cbxEventDestination.Size = new System.Drawing.Size(421, 21);
            this.cbxEventDestination.TabIndex = 18;
            // 
            // lblEventDestination
            // 
            this.lblEventDestination.AutoEllipsis = true;
            this.lblEventDestination.AutoSize = true;
            this.lblEventDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEventDestination.Location = new System.Drawing.Point(3, 0);
            this.lblEventDestination.Name = "lblEventDestination";
            this.lblEventDestination.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblEventDestination.Size = new System.Drawing.Size(61, 27);
            this.lblEventDestination.TabIndex = 17;
            this.lblEventDestination.Text = "Destination";
            // 
            // btnGetCurZone
            // 
            this.btnGetCurZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetCurZone.Location = new System.Drawing.Point(347, 57);
            this.btnGetCurZone.Name = "btnGetCurZone";
            this.btnGetCurZone.Size = new System.Drawing.Size(144, 23);
            this.btnGetCurZone.TabIndex = 16;
            this.btnGetCurZone.Text = "Retrieve current";
            this.btnGetCurZone.UseVisualStyleBackColor = true;
            this.btnGetCurZone.Click += new System.EventHandler(this.btnGetCurZone_Click);
            // 
            // txtEvent
            // 
            this.txtEvent.AcceptsReturn = true;
            this.txtEvent.AcceptsTab = true;
            this.tableLayoutPanel3.SetColumnSpan(this.txtEvent, 2);
            this.txtEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEvent.Location = new System.Drawing.Point(70, 86);
            this.txtEvent.Multiline = true;
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEvent.Size = new System.Drawing.Size(421, 224);
            this.txtEvent.TabIndex = 9;
            this.txtEvent.WordWrap = false;
            this.txtEvent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEvent_KeyDown);
            // 
            // lblEvent
            // 
            this.lblEvent.AutoEllipsis = true;
            this.lblEvent.AutoSize = true;
            this.lblEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEvent.Location = new System.Drawing.Point(3, 83);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblEvent.Size = new System.Drawing.Size(61, 230);
            this.lblEvent.TabIndex = 8;
            this.lblEvent.Text = "Event text";
            // 
            // lblZoneName
            // 
            this.lblZoneName.AutoEllipsis = true;
            this.lblZoneName.AutoSize = true;
            this.lblZoneName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZoneName.Location = new System.Drawing.Point(3, 54);
            this.lblZoneName.Name = "lblZoneName";
            this.lblZoneName.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblZoneName.Size = new System.Drawing.Size(61, 29);
            this.lblZoneName.TabIndex = 6;
            this.lblZoneName.Text = "Zone name";
            // 
            // txtZoneName
            // 
            this.txtZoneName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtZoneName.Location = new System.Drawing.Point(70, 57);
            this.txtZoneName.Name = "txtZoneName";
            this.txtZoneName.Size = new System.Drawing.Size(271, 20);
            this.txtZoneName.TabIndex = 7;
            // 
            // TestInputForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(534, 411);
            this.Controls.Add(this.grpEventDetails);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(550, 400);
            this.Name = "TestInputForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test input";
            this.panel4.ResumeLayout(false);
            this.grpEventDetails.ResumeLayout(false);
            this.grpEventDetails.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanelBottom.ResumeLayout(false);
            this.tableLayoutPanelBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCopyDebugTrigger;
        private System.Windows.Forms.GroupBox grpEventDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBottom;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.Label lblZoneName;
        private System.Windows.Forms.Button btnGetCurZone;
        internal System.Windows.Forms.TextBox txtEvent;
        internal System.Windows.Forms.TextBox txtZoneName;
        private System.Windows.Forms.Label lblEventDestination;
        internal System.Windows.Forms.ComboBox cbxEventDestination;
        internal System.Windows.Forms.ComboBox cbxZoneType;
        private System.Windows.Forms.Label lblZoneType;
    }
}