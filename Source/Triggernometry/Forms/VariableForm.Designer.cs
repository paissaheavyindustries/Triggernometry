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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlsScalar = new System.Windows.Forms.ToolStrip();
            this.btnRefreshScalar = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveAllScalar = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvScalarVariables = new Triggernometry.CustomControls.DataGridViewEx();
            this.colScalarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScalarValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScalarLastChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScalarChangedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabScalar = new System.Windows.Forms.TabPage();
            this.tabList = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvListVariables = new Triggernometry.CustomControls.DataGridViewEx();
            this.colListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListLastChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListChangedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsList = new System.Windows.Forms.ToolStrip();
            this.btnRefreshList = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveAllList = new System.Windows.Forms.ToolStripButton();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.dgvTableVariables = new Triggernometry.CustomControls.DataGridViewEx();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefreshTable = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveAllTable = new System.Windows.Forms.ToolStripButton();
            this.tlsScalar.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScalarVariables)).BeginInit();
            this.tbcMain.SuspendLayout();
            this.tabScalar.SuspendLayout();
            this.tabList.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListVariables)).BeginInit();
            this.tlsList.SuspendLayout();
            this.tabTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableVariables)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            // dgvScalarVariables
            // 
            this.dgvScalarVariables.AllowUserToAddRows = false;
            this.dgvScalarVariables.AllowUserToDeleteRows = false;
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
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tabScalar);
            this.tbcMain.Controls.Add(this.tabList);
            this.tbcMain.Controls.Add(this.tabTable);
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
            this.tabList.Size = new System.Drawing.Size(556, 370);
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
            this.panel2.Size = new System.Drawing.Size(550, 364);
            this.panel2.TabIndex = 23;
            // 
            // dgvListVariables
            // 
            this.dgvListVariables.AllowUserToAddRows = false;
            this.dgvListVariables.AllowUserToDeleteRows = false;
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
            this.dgvListVariables.Size = new System.Drawing.Size(550, 339);
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
            this.colListSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // tlsList
            // 
            this.tlsList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshList,
            this.btnRemoveAllList});
            this.tlsList.Location = new System.Drawing.Point(0, 0);
            this.tlsList.Name = "tlsList";
            this.tlsList.Size = new System.Drawing.Size(550, 25);
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
            // tabTable
            // 
            this.tabTable.Controls.Add(this.dgvTableVariables);
            this.tabTable.Controls.Add(this.toolStrip1);
            this.tabTable.Location = new System.Drawing.Point(4, 22);
            this.tabTable.Name = "tabTable";
            this.tabTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabTable.Size = new System.Drawing.Size(556, 370);
            this.tabTable.TabIndex = 2;
            this.tabTable.Text = "Table variables";
            this.tabTable.UseVisualStyleBackColor = true;
            // 
            // dgvTableVariables
            // 
            this.dgvTableVariables.AllowUserToAddRows = false;
            this.dgvTableVariables.AllowUserToDeleteRows = false;
            this.dgvTableVariables.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTableVariables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTableVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column1,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvTableVariables.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvTableVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableVariables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTableVariables.Location = new System.Drawing.Point(3, 28);
            this.dgvTableVariables.Name = "dgvTableVariables";
            this.dgvTableVariables.RowHeadersVisible = false;
            this.dgvTableVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTableVariables.ShowCellErrors = false;
            this.dgvTableVariables.ShowEditingIcon = false;
            this.dgvTableVariables.ShowRowErrors = false;
            this.dgvTableVariables.Size = new System.Drawing.Size(550, 339);
            this.dgvTableVariables.TabIndex = 22;
            this.dgvTableVariables.VirtualMode = true;
            this.dgvTableVariables.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvTableVariables_CellValueNeeded);
            this.dgvTableVariables.SelectionChanged += new System.EventHandler(this.dgvTableVariables_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Width";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Height";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Last changed";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Changed by";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshTable,
            this.btnRemoveAllTable});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(550, 25);
            this.toolStrip1.TabIndex = 21;
            // 
            // btnRefreshTable
            // 
            this.btnRefreshTable.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshTable.Image")));
            this.btnRefreshTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshTable.Name = "btnRefreshTable";
            this.btnRefreshTable.Size = new System.Drawing.Size(66, 22);
            this.btnRefreshTable.Text = "Refresh";
            this.btnRefreshTable.Click += new System.EventHandler(this.btnRefreshTable_Click);
            // 
            // btnRemoveAllTable
            // 
            this.btnRemoveAllTable.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRemoveAllTable.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveAllTable.Image")));
            this.btnRemoveAllTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveAllTable.Name = "btnRemoveAllTable";
            this.btnRemoveAllTable.Size = new System.Drawing.Size(85, 22);
            this.btnRemoveAllTable.Text = "Remove all";
            this.btnRemoveAllTable.Click += new System.EventHandler(this.btnRemoveAllTable_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvScalarVariables)).EndInit();
            this.tbcMain.ResumeLayout(false);
            this.tabScalar.ResumeLayout(false);
            this.tabList.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListVariables)).EndInit();
            this.tlsList.ResumeLayout(false);
            this.tlsList.PerformLayout();
            this.tabTable.ResumeLayout(false);
            this.tabTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableVariables)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListLastChanged;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListChangedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScalarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScalarValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScalarLastChanged;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScalarChangedBy;
        private System.Windows.Forms.TabPage tabTable;
        private CustomControls.DataGridViewEx dgvTableVariables;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefreshTable;
        private System.Windows.Forms.ToolStripButton btnRemoveAllTable;
    }
}