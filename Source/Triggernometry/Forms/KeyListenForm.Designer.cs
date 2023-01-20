namespace Triggernometry.Forms
{
    partial class KeyListenForm
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblKeypressInfo = new System.Windows.Forms.Label();
            this.lblKeypress = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnOk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 175);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(464, 35);
            this.panel4.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(314, 0);
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
            this.btnOk.Location = new System.Drawing.Point(0, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 35);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 165);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(464, 10);
            this.panel3.TabIndex = 14;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.Controls.Add(this.lblKeypressInfo);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(10, 10);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel8.Size = new System.Drawing.Size(464, 51);
            this.panel8.TabIndex = 18;
            // 
            // lblKeypressInfo
            // 
            this.lblKeypressInfo.AutoEllipsis = true;
            this.lblKeypressInfo.BackColor = System.Drawing.SystemColors.Info;
            this.lblKeypressInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeypressInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeypressInfo.Location = new System.Drawing.Point(0, 0);
            this.lblKeypressInfo.Name = "lblKeypressInfo";
            this.lblKeypressInfo.Size = new System.Drawing.Size(464, 41);
            this.lblKeypressInfo.TabIndex = 0;
            this.lblKeypressInfo.Text = "Press a key or a combination of keys, and press OK when you are satisfied with th" +
    "e result.";
            this.lblKeypressInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKeypress
            // 
            this.lblKeypress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblKeypress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeypress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeypress.Location = new System.Drawing.Point(10, 61);
            this.lblKeypress.Name = "lblKeypress";
            this.lblKeypress.Size = new System.Drawing.Size(464, 104);
            this.lblKeypress.TabIndex = 19;
            this.lblKeypress.Text = "(no keypress recorded)";
            this.lblKeypress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KeyListenForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(484, 220);
            this.Controls.Add(this.lblKeypress);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KeyListenForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listening to keypresses";
            this.panel4.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblKeypressInfo;
        private System.Windows.Forms.Label lblKeypress;
    }
}