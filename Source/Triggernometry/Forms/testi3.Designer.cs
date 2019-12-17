namespace Triggernometry.Forms
{
    partial class testi3
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
            this.webView2Control1 = new MtrDev.WebView2.Winforms.WebView2Control();
            this.SuspendLayout();
            // 
            // webView2Control1
            // 
            this.webView2Control1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView2Control1.Location = new System.Drawing.Point(0, 0);
            this.webView2Control1.Name = "webView2Control1";
            this.webView2Control1.Size = new System.Drawing.Size(800, 450);
            this.webView2Control1.TabIndex = 0;
            this.webView2Control1.Url = "www.google.com";
            // 
            // testi3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webView2Control1);
            this.Name = "testi3";
            this.Text = "testi3";
            this.ResumeLayout(false);

        }

        #endregion

        private MtrDev.WebView2.Winforms.WebView2Control webView2Control1;
    }
}