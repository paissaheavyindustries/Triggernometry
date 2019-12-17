namespace Triggernometry.Forms
{
    partial class SubstitutionForm
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
            this.grpSubstitution = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.clbScope = new System.Windows.Forms.CheckedListBox();
            this.lblScope = new System.Windows.Forms.Label();
            this.txtReplaceWith = new System.Windows.Forms.TextBox();
            this.lblReplaceWith = new System.Windows.Forms.Label();
            this.lblSearchFor = new System.Windows.Forms.Label();
            this.txtSearchFor = new System.Windows.Forms.TextBox();
            this.panel4.SuspendLayout();
            this.grpSubstitution.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 206);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 10);
            this.panel3.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnOk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 216);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(564, 35);
            this.panel4.TabIndex = 22;
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
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // grpSubstitution
            // 
            this.grpSubstitution.AutoSize = true;
            this.grpSubstitution.Controls.Add(this.tableLayoutPanel1);
            this.grpSubstitution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSubstitution.Location = new System.Drawing.Point(10, 10);
            this.grpSubstitution.Name = "grpSubstitution";
            this.grpSubstitution.Padding = new System.Windows.Forms.Padding(10);
            this.grpSubstitution.Size = new System.Drawing.Size(564, 196);
            this.grpSubstitution.TabIndex = 23;
            this.grpSubstitution.TabStop = false;
            this.grpSubstitution.Text = " Substitution settings ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.clbScope, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblScope, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtReplaceWith, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblReplaceWith, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSearchFor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchFor, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 163);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // clbScope
            // 
            this.clbScope.CheckOnClick = true;
            this.clbScope.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbScope.FormattingEnabled = true;
            this.clbScope.IntegralHeight = false;
            this.clbScope.Items.AddRange(new object[] {
            "Regular expression capture group results",
            "All numeric expressions",
            "All string expressions",
            "Text to speech messages"});
            this.clbScope.Location = new System.Drawing.Point(78, 55);
            this.clbScope.Name = "clbScope";
            this.tableLayoutPanel1.SetRowSpan(this.clbScope, 2);
            this.clbScope.Size = new System.Drawing.Size(463, 105);
            this.clbScope.TabIndex = 5;
            // 
            // lblScope
            // 
            this.lblScope.AutoEllipsis = true;
            this.lblScope.AutoSize = true;
            this.lblScope.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScope.Location = new System.Drawing.Point(3, 52);
            this.lblScope.Name = "lblScope";
            this.lblScope.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblScope.Size = new System.Drawing.Size(69, 17);
            this.lblScope.TabIndex = 4;
            this.lblScope.Text = "Scope";
            this.lblScope.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReplaceWith
            // 
            this.txtReplaceWith.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReplaceWith.Location = new System.Drawing.Point(78, 29);
            this.txtReplaceWith.Name = "txtReplaceWith";
            this.txtReplaceWith.Size = new System.Drawing.Size(463, 20);
            this.txtReplaceWith.TabIndex = 3;
            // 
            // lblReplaceWith
            // 
            this.lblReplaceWith.AutoEllipsis = true;
            this.lblReplaceWith.AutoSize = true;
            this.lblReplaceWith.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReplaceWith.Location = new System.Drawing.Point(3, 26);
            this.lblReplaceWith.Name = "lblReplaceWith";
            this.lblReplaceWith.Size = new System.Drawing.Size(69, 26);
            this.lblReplaceWith.TabIndex = 2;
            this.lblReplaceWith.Text = "Replace with";
            this.lblReplaceWith.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSearchFor
            // 
            this.lblSearchFor.AutoEllipsis = true;
            this.lblSearchFor.AutoSize = true;
            this.lblSearchFor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearchFor.Location = new System.Drawing.Point(3, 0);
            this.lblSearchFor.Name = "lblSearchFor";
            this.lblSearchFor.Size = new System.Drawing.Size(69, 26);
            this.lblSearchFor.TabIndex = 0;
            this.lblSearchFor.Text = "Search for";
            this.lblSearchFor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearchFor
            // 
            this.txtSearchFor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchFor.Location = new System.Drawing.Point(78, 3);
            this.txtSearchFor.Name = "txtSearchFor";
            this.txtSearchFor.Size = new System.Drawing.Size(463, 20);
            this.txtSearchFor.TabIndex = 1;
            this.txtSearchFor.TextChanged += new System.EventHandler(this.txtSearchFor_TextChanged);
            // 
            // SubstitutionForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.grpSubstitution);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "SubstitutionForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SubstitutionForm";
            this.panel4.ResumeLayout(false);
            this.grpSubstitution.ResumeLayout(false);
            this.grpSubstitution.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grpSubstitution;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblSearchFor;
        private System.Windows.Forms.TextBox txtSearchFor;
        private System.Windows.Forms.Label lblScope;
        private System.Windows.Forms.TextBox txtReplaceWith;
        private System.Windows.Forms.Label lblReplaceWith;
        private System.Windows.Forms.CheckedListBox clbScope;
    }
}