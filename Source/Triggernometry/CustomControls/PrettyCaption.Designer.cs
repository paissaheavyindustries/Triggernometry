namespace Triggernometry.CustomControls
{
    partial class PrettyCaption
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
            this.lblContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblContent
            // 
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContent.Location = new System.Drawing.Point(0, 0);
            this.lblContent.Name = "lblContent";
            this.lblContent.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblContent.Size = new System.Drawing.Size(536, 59);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = "label1";
            this.lblContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblContent.Click += new System.EventHandler(this.lblContent_Click);
            // 
            // PrettyCaption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblContent);
            this.Name = "PrettyCaption";
            this.Size = new System.Drawing.Size(536, 59);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblContent;
    }
}
