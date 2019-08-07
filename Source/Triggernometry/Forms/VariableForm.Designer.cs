namespace Triggernometry.Forms
{
    partial class VariableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VariableForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlsScalar = new System.Windows.Forms.ToolStrip();
            this.btnRefreshScalar = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveAllScalar = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabScalar = new System.Windows.Forms.TabPage();
            this.tabList = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tlsList = new System.Windows.Forms.ToolStrip();
            this.btnRefreshList = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveAllList = new System.Windows.Forms.ToolStripButton();
            this.dgvScalarVariables = new Triggernometry.CustomControls.DataGridViewEx();
            this.colScalarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScalarValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScalarLastChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScalarChangedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvListVariables = new Triggernometry.CustomControls.DataGridViewEx();
            this.colListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListLastChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListChangedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsScalar.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.tabScalar.SuspendLayout();
            this.tabList.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tlsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScalarVariables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListVariables)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 406);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 10);
            this.panel3.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.Location = new System.Drawing.Point(10, 416);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(564, 35);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // tlsScalar
            // 
            this.tlsScalar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsScalar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshScalar,
            this.btnRemoveAllScalar});
            this.tlsScalar.Location = new System.Drawing.Point(0, 0);
            this.tlsScalar.Name = "tlsScalar";
            this.tlsScalar.Size = new System.Drawing.Size(550, 25);
            this.tlsScalar.TabIndex = 20;
            // 
            // btnRefreshScalar
            // 
            this.btnRefreshScalar.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshScalar.Image")));
            this.btnRefreshScalar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshScalar.Name = "btnRefreshScalar";
            this.btnRefreshScalar.Size = new System.Drawing.Size(66, 22);
            this.btnRefreshScalar.Text = "Refresh";
            this.btnRefreshScalar.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnRemoveAllScalar
            // 
            this.btnRemoveAllScalar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRemoveAllScalar.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveAllScalar.Image")));
            this.btnRemoveAllScalar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveAllScalar.Name = "btnRemoveAllScalar";
            this.btnRemoveAllScalar.Size = new System.Drawing.Size(85, 22);
            this.btnRemoveAllScalar.Text = "Remove all";
            this.btnRemoveAllScalar.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvScalarVariables);
            this.panel1.Controls.Add(this.tlsScalar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 364);
            this.panel1.TabIndex = 22;
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tabScalar);
            this.tbcMain.Controls.Add(this.tabList);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(10, 10);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(564, 396);
            this.tbcMain.TabIndex = 23;
            // 
            // tabScalar
            // 
            this.tabScalar.Controls.Add(this.panel1);
            this.tabScalar.Location = new System.Drawing.Point(4, 22);
            this.tabScalar.Name = "tabScalar";
            this.tabScalar.Padding = new System.Windows.Forms.Padding(3);
            this.tabScalar.Size = new System.Drawing.Size(556, 370);
            this.tabScalar.TabIndex = 0;
            this.tabScalar.Text = "Scalar variables";
            this.tabScalar.UseVisualStyleBackColor = true;
            // 
            // tabList
            // 
            this.tabList.Controls.Add(this.panel2);
            this.tabList.Location = new System.Drawing.Point(4, 22);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(456, 170);
            this.tabList.TabIndex = 1;
            this.tabList.Text = "List variables";
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvListVariables);
            this.panel2.Controls.Add(this.tlsList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 164);
            this.panel2.TabIndex = 23;
            // 
            // tlsList
            // 
            this.tlsList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshList,
            this.btnRemoveAllList});
            this.tlsList.Location = new System.Drawing.Point(0, 0);
            this.tlsList.Name = "tlsList";
            this.tlsList.Size = new System.Drawing.Size(450, 25);
            this.tlsList.TabIndex = 20;
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshList.Image")));
            this.btnRefreshList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(66, 22);
            this.btnRefreshList.Text = "Refresh";
            this.btnRefreshList.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // btnRemoveAllList
            // 
            this.btnRemoveAllList.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRemoveAllList.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveAllList.Image")));
            this.btnRemoveAllList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveAllList.Name = "btnRemoveAllList";
            this.btnRemoveAllList.Size = new System.Drawing.Size(85, 22);
            this.btnRemoveAllList.Text = "Remove all";
            this.btnRemoveAllList.Click += new System.EventHandler(this.btnRemoveAllList_Click);
            // 
            // dgvScalarVariables
            // 
            this.dgvScalarVariables.AllowUserToAddRows = false;
            this.dgvScalarVariables.AllowUserToDeleteRows = false;
            this.dgvScalarVariables.AllowUserToResizeColumns = false;
            this.dgvScalarVariables.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvScalarVariables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScalarVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScalarVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colScalarName,
            this.colScalarValue,
            this.colScalarLastChanged,
            this.colScalarChangedBy});
            this.dgvScalarVariables.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvScalarVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScalarVariables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvScalarVariables.Location = new System.Drawing.Point(0, 25);
            this.dgvScalarVariables.Name = "dgvScalarVariables";
            this.dgvScalarVariables.RowHeadersVisible = false;
            this.dgvScalarVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvScalarVariables.ShowCellErrors = false;
            this.dgvScalarVariables.ShowEditingIcon = false;
            this.dgvScalarVariables.ShowRowErrors = false;
            this.dgvScalarVariables.Size = new System.Drawing.Size(550, 339);
            this.dgvScalarVariables.TabIndex = 21;
            this.dgvScalarVariables.VirtualMode = true;
            this.dgvScalarVariables.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGridView1_CellValueNeeded);
            this.dgvScalarVariables.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGridView1_CellValuePushed);
            this.dgvScalarVariables.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // colScalarName
            // 
            this.colScalarName.Frozen = true;
            this.colScalarName.HeaderText = "Name";
            this.colScalarName.Name = "colScalarName";
            this.colScalarName.ReadOnly = true;
            this.colScalarName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colScalarValue
            // 
            this.colScalarValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colScalarValue.HeaderText = "Value";
            this.colScalarValue.Name = "colScalarValue";
            this.colScalarValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colScalarLastChanged
            // 
            this.colScalarLastChanged.HeaderText = "Last changed";
            this.colScalarLastChanged.Name = "colScalarLastChanged";
            this.colScalarLastChanged.ReadOnly = true;
            this.colScalarLastChanged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colScalarLastChanged.Width = 120;
            // 
            // colScalarChangedBy
            // 
            this.colScalarChangedBy.HeaderText = "Changed by";
            this.colScalarChangedBy.Name = "colScalarChangedBy";
            this.colScalarChangedBy.ReadOnly = true;
            this.colScalarChangedBy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvListVariables
            // 
            this.dgvListVariables.AllowUserToAddRows = false;
            this.dgvListVariables.AllowUserToDeleteRows = false;
            this.dgvListVariables.AllowUserToResizeColumns = false;
            this.dgvListVariables.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvListVariables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colListName,
            this.colListSize,
            this.colListValue,
            this.colListLastChanged,
            this.colListChangedBy});
            this.dgvListVariables.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvListVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListVariables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListVariables.Location = new System.Drawing.Point(0, 25);
            this.dgvListVariables.Name = "dgvListVariables";
            this.dgvListVariables.RowHeadersVisible = false;
            this.dgvListVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListVariables.ShowCellErrors = false;
            this.dgvListVariables.ShowEditingIcon = false;
            this.dgvListVariables.ShowRowErrors = false;
            this.dgvListVariables.Size = new System.Drawing.Size(450, 139);
            this.dgvListVariables.TabIndex = 21;
            this.dgvListVariables.VirtualMode = true;
            this.dgvListVariables.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvListVariables_CellValueNeeded);
            this.dgvListVariables.SelectionChanged += new System.EventHandler(this.dgvListVariables_SelectionChanged);
            // 
            // colListName
            // 
            this.colListName.Frozen = true;
            this.colListName.HeaderText = "Name";
            this.colListName.Name = "colListName";
            this.colListName.ReadOnly = true;
            this.colListName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colListSize
            // 
            this.colListSize.HeaderText = "Size";
            this.colListSize.Name = "colListSize";
            this.colListSize.ReadOnly = true;
            this.colListSize.Width = 40;
            // 
            // colListValue
            // 
            this.colListValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colListValue.HeaderText = "Value";
            this.colListValue.Name = "colListValue";
            this.colListValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colListLastChanged
            // 
            this.colListLastChanged.HeaderText = "Last changed";
            this.colListLastChanged.Name = "colListLastChanged";
            this.colListLastChanged.ReadOnly = true;
            this.colListLastChanged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colListLastChanged.Width = 120;
            // 
            // colListChangedBy
            // 
            this.colListChangedBy.HeaderText = "Changed by";
            this.colListChangedBy.Name = "colListChangedBy";
            this.colListChangedBy.ReadOnly = true;
            this.colListChangedBy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // VariableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "VariableForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Triggernometry variables";
            this.tlsScalar.ResumeLayout(false);
            this.tlsScalar.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tbcMain.ResumeLayout(false);
            this.tabScalar.ResumeLayout(false);
            this.tabList.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tlsList.ResumeLayout(false);
            this.tlsList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScalarVariables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListVariables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStrip tlsScalar;
        private System.Windows.Forms.ToolStripButton btnRefreshScalar;
        private CustomControls.DataGridViewEx dgvScalarVariables;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabScalar;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.Panel panel2;
        private CustomControls.DataGridViewEx dgvListVariables;
        private System.Windows.Forms.ToolStrip tlsList;
        private System.Windows.Forms.ToolStripButton btnRefreshList;
        private System.Windows.Forms.ToolStripButton btnRemoveAllScalar;
        private System.Windows.Forms.ToolStripButton btnRemoveAllList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScalarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScalarValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScalarLastChanged;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScalarChangedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListLastChanged;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListChangedBy;
    }
}