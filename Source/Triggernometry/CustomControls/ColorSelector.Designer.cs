namespace Triggernometry.CustomControls
{
    partial class ColorSelector
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorSelector));
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxSetTextColor = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSetTextOutline = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSetBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxSetBackgroundTransparent = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.ContextMenuStrip = this.contextMenuStrip1;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(178, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 33);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxSetTextColor,
            this.ctxSetTextOutline,
            this.ctxSetBackground,
            this.toolStripSeparator1,
            this.ctxSetBackgroundTransparent});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(235, 120);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ctxSetTextColor
            // 
            this.ctxSetTextColor.Name = "ctxSetTextColor";
            this.ctxSetTextColor.Size = new System.Drawing.Size(234, 22);
            this.ctxSetTextColor.Text = "Set text color";
            this.ctxSetTextColor.Click += new System.EventHandler(this.setTextColorToolStripMenuItem_Click);
            // 
            // ctxSetTextOutline
            // 
            this.ctxSetTextOutline.Name = "ctxSetTextOutline";
            this.ctxSetTextOutline.Size = new System.Drawing.Size(234, 22);
            this.ctxSetTextOutline.Text = "Set text outline color";
            this.ctxSetTextOutline.Click += new System.EventHandler(this.setTextOutlineColorToolStripMenuItem_Click);
            // 
            // ctxSetBackground
            // 
            this.ctxSetBackground.Name = "ctxSetBackground";
            this.ctxSetBackground.Size = new System.Drawing.Size(234, 22);
            this.ctxSetBackground.Text = "Set background color";
            this.ctxSetBackground.Click += new System.EventHandler(this.setBackgroundColorToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(231, 6);
            // 
            // ctxSetBackgroundTransparent
            // 
            this.ctxSetBackgroundTransparent.Name = "ctxSetBackgroundTransparent";
            this.ctxSetBackgroundTransparent.Size = new System.Drawing.Size(234, 22);
            this.ctxSetBackgroundTransparent.Text = "Set background as transparent";
            this.ctxSetBackgroundTransparent.Click += new System.EventHandler(this.setBackgroundAsTransparentToolStripMenuItem_Click);
            // 
            // ColorSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.button1);
            this.Name = "ColorSelector";
            this.Size = new System.Drawing.Size(207, 33);
            this.Click += new System.EventHandler(this.button1_Click);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctxSetTextColor;
        private System.Windows.Forms.ToolStripMenuItem ctxSetTextOutline;
        private System.Windows.Forms.ToolStripMenuItem ctxSetBackground;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ctxSetBackgroundTransparent;
    }
}
