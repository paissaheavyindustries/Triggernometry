namespace Triggernometry.CustomControls
{
    partial class Toast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Toast));
            this.label13 = new System.Windows.Forms.Label();
            this.btnToastYes = new System.Windows.Forms.Button();
            this.btnToastNo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(30, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(299, 28);
            this.label13.TabIndex = 5;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnToastYes
            // 
            this.btnToastYes.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnToastYes.Location = new System.Drawing.Point(329, 5);
            this.btnToastYes.Name = "btnToastYes";
            this.btnToastYes.Size = new System.Drawing.Size(75, 28);
            this.btnToastYes.TabIndex = 4;
            this.btnToastYes.Text = "Yes";
            this.btnToastYes.UseVisualStyleBackColor = true;
            this.btnToastYes.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnToastNo
            // 
            this.btnToastNo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnToastNo.Location = new System.Drawing.Point(404, 5);
            this.btnToastNo.Name = "btnToastNo";
            this.btnToastNo.Size = new System.Drawing.Size(75, 28);
            this.btnToastNo.TabIndex = 3;
            this.btnToastNo.Text = "No";
            this.btnToastNo.UseVisualStyleBackColor = true;
            this.btnToastNo.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 28);
            this.panel1.TabIndex = 6;
            // 
            // Toast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnToastYes);
            this.Controls.Add(this.btnToastNo);
            this.Controls.Add(this.panel1);
            this.Name = "Toast";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(484, 38);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnToastYes;
        private System.Windows.Forms.Button btnToastNo;
        private System.Windows.Forms.Panel panel1;
    }
}
