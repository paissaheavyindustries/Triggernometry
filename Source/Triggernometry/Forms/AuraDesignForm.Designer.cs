namespace Triggernometry.Forms
{
    partial class AuraDesignForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuraDesignForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxImage = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxWidthToImageWidth = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxHeightToImageHeight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxDisplayMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDisplayNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDisplayStretch = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDisplayCentered = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDisplayZoomed = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxText = new System.Windows.Forms.ToolStripMenuItem();
            this.alignmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.middleLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.middleCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.middleRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxSaveChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDiscardChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.clickthroughPictureBox1 = new Triggernometry.CustomControls.ClickthroughPictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clickthroughPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxImage,
            this.ctxText,
            this.toolStripSeparator1,
            this.ctxSaveChanges,
            this.ctxDiscardChanges});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 98);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ctxImage
            // 
            this.ctxImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxWidthToImageWidth,
            this.ctxHeightToImageHeight,
            this.toolStripSeparator2,
            this.ctxDisplayMethod});
            this.ctxImage.Image = ((System.Drawing.Image)(resources.GetObject("ctxImage.Image")));
            this.ctxImage.Name = "ctxImage";
            this.ctxImage.Size = new System.Drawing.Size(160, 22);
            this.ctxImage.Text = "Image ";
            // 
            // ctxWidthToImageWidth
            // 
            this.ctxWidthToImageWidth.Name = "ctxWidthToImageWidth";
            this.ctxWidthToImageWidth.Size = new System.Drawing.Size(214, 22);
            this.ctxWidthToImageWidth.Text = "Set width to image width";
            this.ctxWidthToImageWidth.Click += new System.EventHandler(this.setWidthToImageWidthToolStripMenuItem_Click);
            // 
            // ctxHeightToImageHeight
            // 
            this.ctxHeightToImageHeight.Name = "ctxHeightToImageHeight";
            this.ctxHeightToImageHeight.Size = new System.Drawing.Size(214, 22);
            this.ctxHeightToImageHeight.Text = "Set height to image height";
            this.ctxHeightToImageHeight.Click += new System.EventHandler(this.setHeightToImageHeightToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // ctxDisplayMethod
            // 
            this.ctxDisplayMethod.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxDisplayNormal,
            this.ctxDisplayStretch,
            this.ctxDisplayCentered,
            this.ctxDisplayZoomed});
            this.ctxDisplayMethod.Name = "ctxDisplayMethod";
            this.ctxDisplayMethod.Size = new System.Drawing.Size(214, 22);
            this.ctxDisplayMethod.Text = "Display method";
            // 
            // ctxDisplayNormal
            // 
            this.ctxDisplayNormal.CheckOnClick = true;
            this.ctxDisplayNormal.Name = "ctxDisplayNormal";
            this.ctxDisplayNormal.Size = new System.Drawing.Size(276, 22);
            this.ctxDisplayNormal.Text = "Normal";
            this.ctxDisplayNormal.CheckedChanged += new System.EventHandler(this.onceToolStripMenuItem_CheckedChanged);
            this.ctxDisplayNormal.Click += new System.EventHandler(this.onceToolStripMenuItem_Click);
            // 
            // ctxDisplayStretch
            // 
            this.ctxDisplayStretch.CheckOnClick = true;
            this.ctxDisplayStretch.Name = "ctxDisplayStretch";
            this.ctxDisplayStretch.Size = new System.Drawing.Size(276, 22);
            this.ctxDisplayStretch.Text = "Stretched to fill";
            this.ctxDisplayStretch.Click += new System.EventHandler(this.stretchedToolStripMenuItem_Click);
            // 
            // ctxDisplayCentered
            // 
            this.ctxDisplayCentered.CheckOnClick = true;
            this.ctxDisplayCentered.Name = "ctxDisplayCentered";
            this.ctxDisplayCentered.Size = new System.Drawing.Size(276, 22);
            this.ctxDisplayCentered.Text = "Centered";
            this.ctxDisplayCentered.Click += new System.EventHandler(this.centeredToolStripMenuItem_Click);
            // 
            // ctxDisplayZoomed
            // 
            this.ctxDisplayZoomed.CheckOnClick = true;
            this.ctxDisplayZoomed.Name = "ctxDisplayZoomed";
            this.ctxDisplayZoomed.Size = new System.Drawing.Size(276, 22);
            this.ctxDisplayZoomed.Text = "Zoomed to fill respecting Aspect Ratio";
            this.ctxDisplayZoomed.Click += new System.EventHandler(this.stretchedWithAspectRatioToolStripMenuItem_Click);
            // 
            // ctxText
            // 
            this.ctxText.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alignmentToolStripMenuItem});
            this.ctxText.Image = ((System.Drawing.Image)(resources.GetObject("ctxText.Image")));
            this.ctxText.Name = "ctxText";
            this.ctxText.Size = new System.Drawing.Size(160, 22);
            this.ctxText.Text = "Text";
            this.ctxText.DropDownOpening += new System.EventHandler(this.textToolStripMenuItem_DropDownOpening);
            // 
            // alignmentToolStripMenuItem
            // 
            this.alignmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topLeftToolStripMenuItem,
            this.topCenterToolStripMenuItem,
            this.topRightToolStripMenuItem,
            this.middleLeftToolStripMenuItem,
            this.middleCenterToolStripMenuItem,
            this.middleRightToolStripMenuItem,
            this.bottomLeftToolStripMenuItem,
            this.bottomCenterToolStripMenuItem,
            this.bottomRightToolStripMenuItem});
            this.alignmentToolStripMenuItem.Name = "alignmentToolStripMenuItem";
            this.alignmentToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.alignmentToolStripMenuItem.Text = "Alignment";
            // 
            // topLeftToolStripMenuItem
            // 
            this.topLeftToolStripMenuItem.CheckOnClick = true;
            this.topLeftToolStripMenuItem.Name = "topLeftToolStripMenuItem";
            this.topLeftToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.topLeftToolStripMenuItem.Text = "Top left";
            this.topLeftToolStripMenuItem.Click += new System.EventHandler(this.topLeftToolStripMenuItem_Click);
            // 
            // topCenterToolStripMenuItem
            // 
            this.topCenterToolStripMenuItem.CheckOnClick = true;
            this.topCenterToolStripMenuItem.Name = "topCenterToolStripMenuItem";
            this.topCenterToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.topCenterToolStripMenuItem.Text = "Top center";
            this.topCenterToolStripMenuItem.Click += new System.EventHandler(this.topCenterToolStripMenuItem_Click);
            // 
            // topRightToolStripMenuItem
            // 
            this.topRightToolStripMenuItem.CheckOnClick = true;
            this.topRightToolStripMenuItem.Name = "topRightToolStripMenuItem";
            this.topRightToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.topRightToolStripMenuItem.Text = "Top right";
            this.topRightToolStripMenuItem.Click += new System.EventHandler(this.topRightToolStripMenuItem_Click);
            // 
            // middleLeftToolStripMenuItem
            // 
            this.middleLeftToolStripMenuItem.CheckOnClick = true;
            this.middleLeftToolStripMenuItem.Name = "middleLeftToolStripMenuItem";
            this.middleLeftToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.middleLeftToolStripMenuItem.Text = "Middle left";
            this.middleLeftToolStripMenuItem.Click += new System.EventHandler(this.middleLeftToolStripMenuItem_Click);
            // 
            // middleCenterToolStripMenuItem
            // 
            this.middleCenterToolStripMenuItem.CheckOnClick = true;
            this.middleCenterToolStripMenuItem.Name = "middleCenterToolStripMenuItem";
            this.middleCenterToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.middleCenterToolStripMenuItem.Text = "Middle center";
            this.middleCenterToolStripMenuItem.Click += new System.EventHandler(this.middleCenterToolStripMenuItem_Click);
            // 
            // middleRightToolStripMenuItem
            // 
            this.middleRightToolStripMenuItem.CheckOnClick = true;
            this.middleRightToolStripMenuItem.Name = "middleRightToolStripMenuItem";
            this.middleRightToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.middleRightToolStripMenuItem.Text = "Middle right";
            this.middleRightToolStripMenuItem.Click += new System.EventHandler(this.middleRightToolStripMenuItem_Click);
            // 
            // bottomLeftToolStripMenuItem
            // 
            this.bottomLeftToolStripMenuItem.CheckOnClick = true;
            this.bottomLeftToolStripMenuItem.Name = "bottomLeftToolStripMenuItem";
            this.bottomLeftToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.bottomLeftToolStripMenuItem.Text = "Bottom left";
            this.bottomLeftToolStripMenuItem.Click += new System.EventHandler(this.bottomLeftToolStripMenuItem_Click);
            // 
            // bottomCenterToolStripMenuItem
            // 
            this.bottomCenterToolStripMenuItem.CheckOnClick = true;
            this.bottomCenterToolStripMenuItem.Name = "bottomCenterToolStripMenuItem";
            this.bottomCenterToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.bottomCenterToolStripMenuItem.Text = "Bottom center";
            this.bottomCenterToolStripMenuItem.Click += new System.EventHandler(this.bottomCenterToolStripMenuItem_Click);
            // 
            // bottomRightToolStripMenuItem
            // 
            this.bottomRightToolStripMenuItem.CheckOnClick = true;
            this.bottomRightToolStripMenuItem.Name = "bottomRightToolStripMenuItem";
            this.bottomRightToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.bottomRightToolStripMenuItem.Text = "Bottom right";
            this.bottomRightToolStripMenuItem.Click += new System.EventHandler(this.bottomRightToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // ctxSaveChanges
            // 
            this.ctxSaveChanges.Image = ((System.Drawing.Image)(resources.GetObject("ctxSaveChanges.Image")));
            this.ctxSaveChanges.Name = "ctxSaveChanges";
            this.ctxSaveChanges.Size = new System.Drawing.Size(160, 22);
            this.ctxSaveChanges.Text = "Save changes";
            this.ctxSaveChanges.Click += new System.EventHandler(this.applyToolStripMenuItem_Click);
            // 
            // ctxDiscardChanges
            // 
            this.ctxDiscardChanges.Image = ((System.Drawing.Image)(resources.GetObject("ctxDiscardChanges.Image")));
            this.ctxDiscardChanges.Name = "ctxDiscardChanges";
            this.ctxDiscardChanges.Size = new System.Drawing.Size(160, 22);
            this.ctxDiscardChanges.Text = "Discard changes";
            this.ctxDiscardChanges.Click += new System.EventHandler(this.discardChangesToolStripMenuItem_Click);
            // 
            // clickthroughPictureBox1
            // 
            this.clickthroughPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.clickthroughPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.clickthroughPictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.clickthroughPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clickthroughPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.clickthroughPictureBox1.Name = "clickthroughPictureBox1";
            this.clickthroughPictureBox1.Size = new System.Drawing.Size(270, 91);
            this.clickthroughPictureBox1.TabIndex = 0;
            this.clickthroughPictureBox1.TabStop = false;
            // 
            // AuraDesignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.ClientSize = new System.Drawing.Size(270, 91);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.clickthroughPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(30, 30);
            this.Name = "AuraDesignForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clickthroughPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private CustomControls.ClickthroughPictureBox clickthroughPictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctxImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ctxSaveChanges;
        private System.Windows.Forms.ToolStripMenuItem ctxWidthToImageWidth;
        private System.Windows.Forms.ToolStripMenuItem ctxHeightToImageHeight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ctxDiscardChanges;
        private System.Windows.Forms.ToolStripMenuItem ctxDisplayMethod;
        private System.Windows.Forms.ToolStripMenuItem ctxDisplayNormal;
        private System.Windows.Forms.ToolStripMenuItem ctxDisplayCentered;
        private System.Windows.Forms.ToolStripMenuItem ctxDisplayStretch;
        private System.Windows.Forms.ToolStripMenuItem ctxDisplayZoomed;
        private System.Windows.Forms.ToolStripMenuItem ctxText;
        private System.Windows.Forms.ToolStripMenuItem alignmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topCenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem middleLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem middleCenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem middleRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bottomLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bottomCenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bottomRightToolStripMenuItem;
    }
}