namespace Triggernometry.Forms
{
    partial class RepositoryListForm
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
            this.trvRepositories = new Triggernometry.CustomControls.TreeViewEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grpAvailRepos = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.prgProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpRepoDetails = new System.Windows.Forms.GroupBox();
            this.txtRepoDetails = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            this.grpAvailRepos.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpRepoDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvRepositories
            // 
            this.trvRepositories.CheckBoxes = true;
            this.trvRepositories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvRepositories.Enabled = false;
            this.trvRepositories.Location = new System.Drawing.Point(10, 23);
            this.trvRepositories.Name = "trvRepositories";
            this.trvRepositories.Size = new System.Drawing.Size(544, 258);
            this.trvRepositories.TabIndex = 0;
            this.trvRepositories.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvRepositories_AfterCheck);
            this.trvRepositories.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvRepositories_BeforeSelect);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 406);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 10);
            this.panel3.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnOk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 416);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(564, 35);
            this.panel4.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(414, 0);
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
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(0, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 35);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Add selected";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // grpAvailRepos
            // 
            this.grpAvailRepos.Controls.Add(this.trvRepositories);
            this.grpAvailRepos.Controls.Add(this.statusStrip1);
            this.grpAvailRepos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAvailRepos.Location = new System.Drawing.Point(10, 10);
            this.grpAvailRepos.Name = "grpAvailRepos";
            this.grpAvailRepos.Padding = new System.Windows.Forms.Padding(10);
            this.grpAvailRepos.Size = new System.Drawing.Size(564, 291);
            this.grpAvailRepos.TabIndex = 20;
            this.grpAvailRepos.TabStop = false;
            this.grpAvailRepos.Text = " Available repositories ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prgProgress,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(10, 259);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(544, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // prgProgress
            // 
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(100, 16);
            this.prgProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(74, 17);
            this.lblStatus.Text = "Please wait...";
            // 
            // grpRepoDetails
            // 
            this.grpRepoDetails.Controls.Add(this.txtRepoDetails);
            this.grpRepoDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpRepoDetails.Location = new System.Drawing.Point(10, 311);
            this.grpRepoDetails.Name = "grpRepoDetails";
            this.grpRepoDetails.Padding = new System.Windows.Forms.Padding(10);
            this.grpRepoDetails.Size = new System.Drawing.Size(564, 95);
            this.grpRepoDetails.TabIndex = 21;
            this.grpRepoDetails.TabStop = false;
            this.grpRepoDetails.Text = " Repository details ";
            // 
            // txtRepoDetails
            // 
            this.txtRepoDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRepoDetails.Location = new System.Drawing.Point(10, 23);
            this.txtRepoDetails.Multiline = true;
            this.txtRepoDetails.Name = "txtRepoDetails";
            this.txtRepoDetails.ReadOnly = true;
            this.txtRepoDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRepoDetails.Size = new System.Drawing.Size(544, 62);
            this.txtRepoDetails.TabIndex = 0;
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(10, 301);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(564, 10);
            this.panel11.TabIndex = 29;
            // 
            // RepositoryListForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.grpAvailRepos);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.grpRepoDetails);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "RepositoryListForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel4.ResumeLayout(false);
            this.grpAvailRepos.ResumeLayout(false);
            this.grpAvailRepos.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpRepoDetails.ResumeLayout(false);
            this.grpRepoDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Triggernometry.CustomControls.TreeViewEx trvRepositories;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grpAvailRepos;
        private System.Windows.Forms.GroupBox grpRepoDetails;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox txtRepoDetails;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar prgProgress;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}