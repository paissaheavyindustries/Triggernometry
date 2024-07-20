namespace Triggernometry.CustomControls
{
    partial class ActionEditor
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
            this.capGeneral.Size = new System.Drawing.Size(836, 30);
            this.capGeneral.TabIndex = 9;
            // 
            // ActionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.capGeneral);
            this.Name = "ActionEditor";
            this.Size = new System.Drawing.Size(836, 514);
            this.ResumeLayout(false);

        }

        #endregion

        private PrettyCaption capGeneral;
    }
}
