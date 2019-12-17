namespace Triggernometry.Forms
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblRegExp = new System.Windows.Forms.Label();
            this.expSearchTerm = new Triggernometry.CustomControls.ExpressionTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvResults = new Triggernometry.CustomControls.DataGridViewEx();
            this.hdrMatchedTrigger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdrMatchType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblResultInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.clbMisc = new System.Windows.Forms.CheckedListBox();
            this.lblMisc = new System.Windows.Forms.Label();
            this.clbScope = new System.Windows.Forms.CheckedListBox();
            this.lblScope = new System.Windows.Forms.Label();
            this.clbRepos = new System.Windows.Forms.CheckedListBox();
            this.lblRepos = new System.Windows.Forms.Label();
            this.clbActions = new System.Windows.Forms.CheckedListBox();
            this.lblActions = new System.Windows.Forms.Label();
            this.lblTriggers = new System.Windows.Forms.Label();
            this.clbTriggers = new System.Windows.Forms.CheckedListBox();
            this.tlsModify = new System.Windows.Forms.ToolStrip();
            this.btnModifySelection = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUncheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.capSearchScope = new Triggernometry.CustomControls.PrettyCaption();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlsModify.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 556);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(764, 10);
            this.panel3.TabIndex = 21;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.Location = new System.Drawing.Point(10, 566);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(764, 35);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRegExp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.expSearchTerm, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(551, 26);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(448, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 20);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblRegExp
            // 
            this.lblRegExp.AutoSize = true;
            this.lblRegExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRegExp.Location = new System.Drawing.Point(3, 0);
            this.lblRegExp.Name = "lblRegExp";
            this.lblRegExp.Size = new System.Drawing.Size(97, 26);
            this.lblRegExp.TabIndex = 0;
            this.lblRegExp.Text = "Regular expression";
            this.lblRegExp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expSearchTerm
            // 
            this.expSearchTerm.AutoSize = true;
            this.expSearchTerm.Dock = System.Windows.Forms.DockStyle.Top;
            this.expSearchTerm.Expression = "";
            this.expSearchTerm.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
            this.expSearchTerm.Location = new System.Drawing.Point(106, 3);
            this.expSearchTerm.Name = "expSearchTerm";
            this.expSearchTerm.ReadOnly = false;
            this.expSearchTerm.Size = new System.Drawing.Size(336, 20);
            this.expSearchTerm.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvResults);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(551, 498);
            this.panel1.TabIndex = 24;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeColumns = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hdrMatchedTrigger,
            this.hdrMatchType});
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvResults.Location = new System.Drawing.Point(0, 5);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.ShowCellErrors = false;
            this.dgvResults.ShowEditingIcon = false;
            this.dgvResults.ShowRowErrors = false;
            this.dgvResults.Size = new System.Drawing.Size(551, 493);
            this.dgvResults.TabIndex = 23;
            this.dgvResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellDoubleClick);
            // 
            // hdrMatchedTrigger
            // 
            this.hdrMatchedTrigger.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hdrMatchedTrigger.HeaderText = "Matched item";
            this.hdrMatchedTrigger.Name = "hdrMatchedTrigger";
            this.hdrMatchedTrigger.ReadOnly = true;
            // 
            // hdrMatchType
            // 
            this.hdrMatchType.HeaderText = "Match type";
            this.hdrMatchType.Name = "hdrMatchType";
            this.hdrMatchType.ReadOnly = true;
            this.hdrMatchType.Width = 200;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblResultInfo});
            this.statusStrip1.Location = new System.Drawing.Point(10, 534);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(764, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 26;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblResultInfo
            // 
            this.lblResultInfo.Name = "lblResultInfo";
            this.lblResultInfo.Size = new System.Drawing.Size(60, 17);
            this.lblResultInfo.Text = "No results";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(10, 10);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.tlsModify);
            this.splitContainer1.Panel2.Controls.Add(this.capSearchScope);
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(764, 524);
            this.splitContainer1.SplitterDistance = 551;
            this.splitContainer1.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 469);
            this.panel2.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.clbMisc, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.lblMisc, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.clbScope, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.lblScope, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.clbRepos, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblRepos, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.clbActions, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblActions, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblTriggers, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.clbTriggers, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(209, 420);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // clbMisc
            // 
            this.clbMisc.CheckOnClick = true;
            this.clbMisc.Dock = System.Windows.Forms.DockStyle.Top;
            this.clbMisc.FormattingEnabled = true;
            this.clbMisc.Items.AddRange(new object[] {
            "Include folders",
            "Include disabled"});
            this.clbMisc.Location = new System.Drawing.Point(3, 383);
            this.clbMisc.Name = "clbMisc";
            this.clbMisc.Size = new System.Drawing.Size(203, 34);
            this.clbMisc.TabIndex = 10;
            this.clbMisc.SelectedIndexChanged += new System.EventHandler(this.clbTriggers_SelectedIndexChanged);
            // 
            // lblMisc
            // 
            this.lblMisc.AutoSize = true;
            this.lblMisc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMisc.Location = new System.Drawing.Point(3, 351);
            this.lblMisc.Name = "lblMisc";
            this.lblMisc.Padding = new System.Windows.Forms.Padding(0, 15, 0, 1);
            this.lblMisc.Size = new System.Drawing.Size(203, 29);
            this.lblMisc.TabIndex = 9;
            this.lblMisc.Text = "Miscellaneous";
            // 
            // clbScope
            // 
            this.clbScope.CheckOnClick = true;
            this.clbScope.Dock = System.Windows.Forms.DockStyle.Top;
            this.clbScope.FormattingEnabled = true;
            this.clbScope.Items.AddRange(new object[] {
            "Local",
            "Remote"});
            this.clbScope.Location = new System.Drawing.Point(3, 314);
            this.clbScope.Name = "clbScope";
            this.clbScope.Size = new System.Drawing.Size(203, 34);
            this.clbScope.TabIndex = 8;
            this.clbScope.SelectedIndexChanged += new System.EventHandler(this.clbTriggers_SelectedIndexChanged);
            // 
            // lblScope
            // 
            this.lblScope.AutoSize = true;
            this.lblScope.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScope.Location = new System.Drawing.Point(3, 282);
            this.lblScope.Name = "lblScope";
            this.lblScope.Padding = new System.Windows.Forms.Padding(0, 15, 0, 1);
            this.lblScope.Size = new System.Drawing.Size(203, 29);
            this.lblScope.TabIndex = 7;
            this.lblScope.Text = "Object scope";
            // 
            // clbRepos
            // 
            this.clbRepos.CheckOnClick = true;
            this.clbRepos.Dock = System.Windows.Forms.DockStyle.Top;
            this.clbRepos.FormattingEnabled = true;
            this.clbRepos.Items.AddRange(new object[] {
            "Name",
            "Address"});
            this.clbRepos.Location = new System.Drawing.Point(3, 245);
            this.clbRepos.Name = "clbRepos";
            this.clbRepos.Size = new System.Drawing.Size(203, 34);
            this.clbRepos.TabIndex = 6;
            this.clbRepos.SelectedIndexChanged += new System.EventHandler(this.clbTriggers_SelectedIndexChanged);
            // 
            // lblRepos
            // 
            this.lblRepos.AutoSize = true;
            this.lblRepos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepos.Location = new System.Drawing.Point(3, 213);
            this.lblRepos.Name = "lblRepos";
            this.lblRepos.Padding = new System.Windows.Forms.Padding(0, 15, 0, 1);
            this.lblRepos.Size = new System.Drawing.Size(203, 29);
            this.lblRepos.TabIndex = 5;
            this.lblRepos.Text = "Repositories";
            // 
            // clbActions
            // 
            this.clbActions.CheckOnClick = true;
            this.clbActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.clbActions.FormattingEnabled = true;
            this.clbActions.Items.AddRange(new object[] {
            "Description",
            "Condition",
            "Action-specific properties"});
            this.clbActions.Location = new System.Drawing.Point(3, 161);
            this.clbActions.Name = "clbActions";
            this.clbActions.Size = new System.Drawing.Size(203, 49);
            this.clbActions.TabIndex = 4;
            this.clbActions.SelectedIndexChanged += new System.EventHandler(this.clbTriggers_SelectedIndexChanged);
            // 
            // lblActions
            // 
            this.lblActions.AutoSize = true;
            this.lblActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActions.Location = new System.Drawing.Point(3, 129);
            this.lblActions.Name = "lblActions";
            this.lblActions.Padding = new System.Windows.Forms.Padding(0, 15, 0, 1);
            this.lblActions.Size = new System.Drawing.Size(203, 29);
            this.lblActions.TabIndex = 3;
            this.lblActions.Text = "Actions";
            // 
            // lblTriggers
            // 
            this.lblTriggers.AutoSize = true;
            this.lblTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTriggers.Location = new System.Drawing.Point(3, 0);
            this.lblTriggers.Name = "lblTriggers";
            this.lblTriggers.Padding = new System.Windows.Forms.Padding(0, 15, 0, 1);
            this.lblTriggers.Size = new System.Drawing.Size(203, 29);
            this.lblTriggers.TabIndex = 1;
            this.lblTriggers.Text = "Triggers";
            // 
            // clbTriggers
            // 
            this.clbTriggers.CheckOnClick = true;
            this.clbTriggers.Dock = System.Windows.Forms.DockStyle.Top;
            this.clbTriggers.FormattingEnabled = true;
            this.clbTriggers.Items.AddRange(new object[] {
            "ID",
            "Name",
            "Description",
            "Condition",
            "Full path",
            "Regular expression"});
            this.clbTriggers.Location = new System.Drawing.Point(3, 32);
            this.clbTriggers.Name = "clbTriggers";
            this.clbTriggers.Size = new System.Drawing.Size(203, 94);
            this.clbTriggers.TabIndex = 2;
            this.clbTriggers.SelectedIndexChanged += new System.EventHandler(this.clbTriggers_SelectedIndexChanged);
            // 
            // tlsModify
            // 
            this.tlsModify.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsModify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnModifySelection});
            this.tlsModify.Location = new System.Drawing.Point(0, 30);
            this.tlsModify.Name = "tlsModify";
            this.tlsModify.Size = new System.Drawing.Size(209, 25);
            this.tlsModify.TabIndex = 9;
            this.tlsModify.Text = "toolStrip1";
            // 
            // btnModifySelection
            // 
            this.btnModifySelection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCheckAll,
            this.btnUncheckAll});
            this.btnModifySelection.Image = ((System.Drawing.Image)(resources.GetObject("btnModifySelection.Image")));
            this.btnModifySelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifySelection.Name = "btnModifySelection";
            this.btnModifySelection.Size = new System.Drawing.Size(124, 22);
            this.btnModifySelection.Text = "Modify selection";
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(135, 22);
            this.btnCheckAll.Text = "Check all";
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(135, 22);
            this.btnUncheckAll.Text = "Uncheck all";
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // capSearchScope
            // 
            this.capSearchScope.Caption = "Search scope";
            this.capSearchScope.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capSearchScope.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capSearchScope.Dock = System.Windows.Forms.DockStyle.Top;
            this.capSearchScope.Location = new System.Drawing.Point(0, 0);
            this.capSearchScope.Name = "capSearchScope";
            this.capSearchScope.Size = new System.Drawing.Size(209, 30);
            this.capSearchScope.TabIndex = 6;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(784, 611);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "SearchForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tlsModify.ResumeLayout(false);
            this.tlsModify.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblRegExp;
        private CustomControls.ExpressionTextBox expSearchTerm;
        private System.Windows.Forms.Button btnSearch;
        private CustomControls.DataGridViewEx dgvResults;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrMatchedTrigger;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrMatchType;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblResultInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CustomControls.PrettyCaption capSearchScope;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblTriggers;
        private System.Windows.Forms.CheckedListBox clbRepos;
        private System.Windows.Forms.Label lblRepos;
        private System.Windows.Forms.CheckedListBox clbActions;
        private System.Windows.Forms.Label lblActions;
        private System.Windows.Forms.CheckedListBox clbTriggers;
        private System.Windows.Forms.Label lblMisc;
        private System.Windows.Forms.CheckedListBox clbScope;
        private System.Windows.Forms.Label lblScope;
        private System.Windows.Forms.ToolStrip tlsModify;
        private System.Windows.Forms.ToolStripDropDownButton btnModifySelection;
        private System.Windows.Forms.ToolStripMenuItem btnCheckAll;
        private System.Windows.Forms.ToolStripMenuItem btnUncheckAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckedListBox clbMisc;
    }
}