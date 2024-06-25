namespace Triggernometry.Forms
{
    partial class StateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StateForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvCellStyleDict = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvCellStylePeDict = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlsScalar = new System.Windows.Forms.ToolStrip();
            this.btnScalarAdd = new System.Windows.Forms.ToolStripButton();
            this.btnScalarEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnScalarRemove = new System.Windows.Forms.ToolStripButton();
            this.btnScalarRefresh = new System.Windows.Forms.ToolStripSplitButton();
            this.btnScalarRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tbcScalar = new System.Windows.Forms.TabControl();
            this.tabScalarSession = new System.Windows.Forms.TabPage();
            this.tabScalarPersistent = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvPeScalarVariables = new Triggernometry.CustomControls.DataGridViewEx();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnPeScalarAdd = new System.Windows.Forms.ToolStripButton();
            this.btnPeScalarEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPeScalarRemove = new System.Windows.Forms.ToolStripButton();
            this.btnPeScalarRefresh = new System.Windows.Forms.ToolStripSplitButton();
            this.btnPeScalarRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabList = new System.Windows.Forms.TabPage();
            this.tbcList = new System.Windows.Forms.TabControl();
            this.tabListSession = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvListVariables = new Triggernometry.CustomControls.DataGridViewEx();
            this.colListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListLastChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListChangedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsList = new System.Windows.Forms.ToolStrip();
            this.btnListAdd = new System.Windows.Forms.ToolStripButton();
            this.btnListEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnListRemove = new System.Windows.Forms.ToolStripButton();
            this.btnListRefresh = new System.Windows.Forms.ToolStripSplitButton();
            this.btnListRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tabListPersistent = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvPeListVariables = new Triggernometry.CustomControls.DataGridViewEx();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnPeListAdd = new System.Windows.Forms.ToolStripButton();
            this.btnPeListEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPeListRemove = new System.Windows.Forms.ToolStripButton();
            this.btnPeListRefresh = new System.Windows.Forms.ToolStripSplitButton();
            this.btnPeListRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.tbcTable = new System.Windows.Forms.TabControl();
            this.tabTableSession = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvTableVariables = new Triggernometry.CustomControls.DataGridViewEx();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsTable = new System.Windows.Forms.ToolStrip();
            this.btnTableAdd = new System.Windows.Forms.ToolStripButton();
            this.btnTableEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTableRemove = new System.Windows.Forms.ToolStripButton();
            this.btnTableRefresh = new System.Windows.Forms.ToolStripSplitButton();
            this.btnTableRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tabTablePersistent = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvPeTableVariables = new Triggernometry.CustomControls.DataGridViewEx();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.btnPeTableAdd = new System.Windows.Forms.ToolStripButton();
            this.btnPeTableEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPeTableRemove = new System.Windows.Forms.ToolStripButton();
            this.btnPeTableRefresh = new System.Windows.Forms.ToolStripSplitButton();
            this.btnPeTableRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tabDict = new System.Windows.Forms.TabPage();
            this.tbcDict = new System.Windows.Forms.TabControl();
            this.tabDictSession = new System.Windows.Forms.TabPage();
            this.panelDict = new System.Windows.Forms.Panel();
            this.dgvDictVariables = new Triggernometry.CustomControls.DataGridViewEx();
            this.colDictName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDictSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDictValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDictLastChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDictChangedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsDict = new System.Windows.Forms.ToolStrip();
            this.btnDictAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDictEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorDict = new System.Windows.Forms.ToolStripSeparator();
            this.btnDictRemove = new System.Windows.Forms.ToolStripButton();
            this.btnDictRefresh = new System.Windows.Forms.ToolStripSplitButton();
            this.btnDictRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tabDictPersistent = new System.Windows.Forms.TabPage();
            this.panelPeDict = new System.Windows.Forms.Panel();
            this.dgvPeDictVariables = new Triggernometry.CustomControls.DataGridViewEx();
            this.colPeDictName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeDictSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeDictValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeDictLastChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeDictChangedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsPeDict = new System.Windows.Forms.ToolStrip();
            this.btnPeDictAdd = new System.Windows.Forms.ToolStripButton();
            this.btnPeDictEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorPeDict = new System.Windows.Forms.ToolStripSeparator();
            this.btnPeDictRemove = new System.Windows.Forms.ToolStripButton();
            this.btnPeDictRefresh = new System.Windows.Forms.ToolStripSplitButton();
            this.btnPeDictRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMutexes = new System.Windows.Forms.TabPage();
            this.dgvMutexes = new Triggernometry.CustomControls.DataGridViewEx();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsMutex = new System.Windows.Forms.ToolStrip();
            this.btnMutexRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnMutexForce = new System.Windows.Forms.ToolStripButton();
            this.tabImageAura = new System.Windows.Forms.TabPage();
            this.dgvImage = new Triggernometry.CustomControls.DataGridViewEx();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsImageAura = new System.Windows.Forms.ToolStrip();
            this.btnImageRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnImageForce = new System.Windows.Forms.ToolStripButton();
            this.tabTextAura = new System.Windows.Forms.TabPage();
            this.dgvText = new Triggernometry.CustomControls.DataGridViewEx();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsTextAura = new System.Windows.Forms.ToolStrip();
            this.btnTextRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnTextForce = new System.Windows.Forms.ToolStripButton();
            this.tabNamedCallbacks = new System.Windows.Forms.TabPage();
            this.dgvCallback = new Triggernometry.CustomControls.DataGridViewEx();
            this.colCallbackId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCallbackName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCallbackRegistrant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCallbackRegistrationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCallbackLastInvoked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCallbackRefresh = new System.Windows.Forms.ToolStripButton();
            this.tlsScalar.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScalarVariables)).BeginInit();
            this.tbcMain.SuspendLayout();
            this.tabScalar.SuspendLayout();
            this.tbcScalar.SuspendLayout();
            this.tabScalarSession.SuspendLayout();
            this.tabScalarPersistent.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeScalarVariables)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tabList.SuspendLayout();
            this.tbcList.SuspendLayout();
            this.tabListSession.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListVariables)).BeginInit();
            this.tlsList.SuspendLayout();
            this.tabListPersistent.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeListVariables)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.tbcTable.SuspendLayout();
            this.tabTableSession.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableVariables)).BeginInit();
            this.tlsTable.SuspendLayout();
            this.tabTablePersistent.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeTableVariables)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.tbcDict.SuspendLayout();
            this.tabDictSession.SuspendLayout();
            this.panelDict.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDictVariables)).BeginInit();
            this.tlsDict.SuspendLayout();
            this.tabDictPersistent.SuspendLayout();
            this.panelPeDict.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeDictVariables)).BeginInit();
            this.tlsPeDict.SuspendLayout();
            this.tabMutexes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMutexes)).BeginInit();
            this.tlsMutex.SuspendLayout();
            this.tabImageAura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImage)).BeginInit();
            this.tlsImageAura.SuspendLayout();
            this.tabTextAura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvText)).BeginInit();
            this.tlsTextAura.SuspendLayout();
            this.tabNamedCallbacks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCallback)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 456);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(714, 10);
            this.panel3.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.Location = new System.Drawing.Point(10, 466);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(714, 35);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // tlsScalar
            // 
            this.tlsScalar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsScalar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnScalarAdd,
            this.btnScalarEdit,
            this.toolStripSeparator1,
            this.btnScalarRemove,
            this.btnScalarRefresh});
            this.tlsScalar.Location = new System.Drawing.Point(0, 0);
            this.tlsScalar.Name = "tlsScalar";
            this.tlsScalar.Size = new System.Drawing.Size(672, 25);
            this.tlsScalar.TabIndex = 20;
            // 
            // btnScalarAdd
            // 
            this.btnScalarAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnScalarAdd.Image")));
            this.btnScalarAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScalarAdd.Name = "btnScalarAdd";
            this.btnScalarAdd.Size = new System.Drawing.Size(93, 22);
            this.btnScalarAdd.Text = "Add variable";
            this.btnScalarAdd.Click += new System.EventHandler(this.btnScalarAdd_Click);
            // 
            // btnScalarEdit
            // 
            this.btnScalarEdit.Enabled = false;
            this.btnScalarEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnScalarEdit.Image")));
            this.btnScalarEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScalarEdit.Name = "btnScalarEdit";
            this.btnScalarEdit.Size = new System.Drawing.Size(91, 22);
            this.btnScalarEdit.Text = "Edit variable";
            this.btnScalarEdit.Click += new System.EventHandler(this.btnScalarEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnScalarRemove
            // 
            this.btnScalarRemove.Enabled = false;
            this.btnScalarRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnScalarRemove.Image")));
            this.btnScalarRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScalarRemove.Name = "btnScalarRemove";
            this.btnScalarRemove.Size = new System.Drawing.Size(114, 22);
            this.btnScalarRemove.Text = "Remove variable";
            this.btnScalarRemove.Click += new System.EventHandler(this.btnScalarRemove_Click);
            // 
            // btnScalarRefresh
            // 
            this.btnScalarRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnScalarRefresh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnScalarRemoveAll});
            this.btnScalarRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnScalarRefresh.Image")));
            this.btnScalarRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScalarRefresh.Name = "btnScalarRefresh";
            this.btnScalarRefresh.Size = new System.Drawing.Size(78, 22);
            this.btnScalarRefresh.Text = "Refresh";
            this.btnScalarRefresh.ButtonClick += new System.EventHandler(this.btnRefreshScalar_ButtonClick);
            // 
            // btnScalarRemoveAll
            // 
            this.btnScalarRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnScalarRemoveAll.Image")));
            this.btnScalarRemoveAll.Name = "btnScalarRemoveAll";
            this.btnScalarRemoveAll.Size = new System.Drawing.Size(181, 22);
            this.btnScalarRemoveAll.Text = "Remove all variables";
            this.btnScalarRemoveAll.Click += new System.EventHandler(this.btnRemoveAllScalar_Click);
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
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvScalarVariables);
            this.panel1.Controls.Add(this.tlsScalar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(672, 366);
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
            this.dgvScalarVariables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvScalarVariables.Location = new System.Drawing.Point(0, 25);
            this.dgvScalarVariables.Name = "dgvScalarVariables";
            this.dgvScalarVariables.RowHeadersVisible = false;
            this.dgvScalarVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScalarVariables.ShowCellErrors = false;
            this.dgvScalarVariables.ShowEditingIcon = false;
            this.dgvScalarVariables.ShowRowErrors = false;
            this.dgvScalarVariables.Size = new System.Drawing.Size(672, 341);
            this.dgvScalarVariables.TabIndex = 21;
            this.dgvScalarVariables.VirtualMode = true;
            this.dgvScalarVariables.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScalarVariables_CellDoubleClick);
            this.dgvScalarVariables.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvScalarVariables_CellValueNeeded);
            this.dgvScalarVariables.SelectionChanged += new System.EventHandler(this.dgvScalarVariables_SelectionChanged);
            this.dgvScalarVariables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvScalarVariables_KeyDown);
            this.dgvScalarVariables.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCommon_ColumnHeaderMouseClick);
            // 
            // colScalarName
            // 
            this.colScalarName.Frozen = true;
            this.colScalarName.HeaderText = "Name";
            this.colScalarName.Name = "colScalarName";
            this.colScalarName.ReadOnly = true;
            this.colScalarName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colScalarName.Width = 160;
            // 
            // colScalarValue
            // 
            this.colScalarValue.HeaderText = "Value";
            this.colScalarValue.Name = "colScalarValue";
            this.colScalarValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colScalarValue.Width = 160;
            // 
            // colScalarLastChanged
            // 
            this.colScalarLastChanged.HeaderText = "Last changed";
            this.colScalarLastChanged.Name = "colScalarLastChanged";
            this.colScalarLastChanged.ReadOnly = true;
            this.colScalarLastChanged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colScalarLastChanged.Width = 125;
            // 
            // colScalarChangedBy
            // 
            this.colScalarChangedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colScalarChangedBy.HeaderText = "Changed by";
            this.colScalarChangedBy.Name = "colScalarChangedBy";
            this.colScalarChangedBy.ReadOnly = true;
            this.colScalarChangedBy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tabScalar);
            this.tbcMain.Controls.Add(this.tabList);
            this.tbcMain.Controls.Add(this.tabTable);
            this.tbcMain.Controls.Add(this.tabDict);
            this.tbcMain.Controls.Add(this.tabMutexes);
            this.tbcMain.Controls.Add(this.tabImageAura);
            this.tbcMain.Controls.Add(this.tabTextAura);
            this.tbcMain.Controls.Add(this.tabNamedCallbacks);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.ImageList = this.imageList1;
            this.tbcMain.Location = new System.Drawing.Point(10, 10);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(714, 446);
            this.tbcMain.TabIndex = 23;
            this.tbcMain.SelectedIndexChanged += new System.EventHandler(this.tbcMain_SelectedIndexChanged);
            // 
            // tabScalar
            // 
            this.tabScalar.Controls.Add(this.tbcScalar);
            this.tabScalar.ImageKey = "var_scalar.png";
            this.tabScalar.Location = new System.Drawing.Point(4, 23);
            this.tabScalar.Name = "tabScalar";
            this.tabScalar.Padding = new System.Windows.Forms.Padding(10);
            this.tabScalar.Size = new System.Drawing.Size(706, 419);
            this.tabScalar.TabIndex = 0;
            this.tabScalar.Text = "Scalar variables";
            this.tabScalar.UseVisualStyleBackColor = true;
            // 
            // tbcScalar
            // 
            this.tbcScalar.Controls.Add(this.tabScalarSession);
            this.tbcScalar.Controls.Add(this.tabScalarPersistent);
            this.tbcScalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcScalar.ImageList = this.imageList1;
            this.tbcScalar.Location = new System.Drawing.Point(10, 10);
            this.tbcScalar.Name = "tbcScalar";
            this.tbcScalar.SelectedIndex = 0;
            this.tbcScalar.Size = new System.Drawing.Size(686, 399);
            this.tbcScalar.TabIndex = 23;
            this.tbcScalar.SelectedIndexChanged += new System.EventHandler(this.tbcScalar_SelectedIndexChanged);
            // 
            // tabScalarSession
            // 
            this.tabScalarSession.Controls.Add(this.panel1);
            this.tabScalarSession.ImageKey = "appointment-new.png";
            this.tabScalarSession.Location = new System.Drawing.Point(4, 23);
            this.tabScalarSession.Name = "tabScalarSession";
            this.tabScalarSession.Padding = new System.Windows.Forms.Padding(3);
            this.tabScalarSession.Size = new System.Drawing.Size(678, 372);
            this.tabScalarSession.TabIndex = 0;
            this.tabScalarSession.Text = "Session";
            this.tabScalarSession.UseVisualStyleBackColor = true;
            // 
            // tabScalarPersistent
            // 
            this.tabScalarPersistent.Controls.Add(this.panel5);
            this.tabScalarPersistent.ImageKey = "media-floppy.png";
            this.tabScalarPersistent.Location = new System.Drawing.Point(4, 23);
            this.tabScalarPersistent.Name = "tabScalarPersistent";
            this.tabScalarPersistent.Padding = new System.Windows.Forms.Padding(3);
            this.tabScalarPersistent.Size = new System.Drawing.Size(678, 372);
            this.tabScalarPersistent.TabIndex = 1;
            this.tabScalarPersistent.Text = "Persistent";
            this.tabScalarPersistent.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvPeScalarVariables);
            this.panel5.Controls.Add(this.toolStrip2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(672, 366);
            this.panel5.TabIndex = 23;
            // 
            // dgvPeScalarVariables
            // 
            this.dgvPeScalarVariables.AllowUserToAddRows = false;
            this.dgvPeScalarVariables.AllowUserToDeleteRows = false;
            this.dgvPeScalarVariables.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPeScalarVariables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPeScalarVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeScalarVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
            this.dgvPeScalarVariables.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPeScalarVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeScalarVariables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPeScalarVariables.Location = new System.Drawing.Point(0, 25);
            this.dgvPeScalarVariables.Name = "dgvPeScalarVariables";
            this.dgvPeScalarVariables.RowHeadersVisible = false;
            this.dgvPeScalarVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeScalarVariables.ShowCellErrors = false;
            this.dgvPeScalarVariables.ShowEditingIcon = false;
            this.dgvPeScalarVariables.ShowRowErrors = false;
            this.dgvPeScalarVariables.Size = new System.Drawing.Size(672, 341);
            this.dgvPeScalarVariables.TabIndex = 21;
            this.dgvPeScalarVariables.VirtualMode = true;
            this.dgvPeScalarVariables.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeScalarVariables_CellDoubleClick);
            this.dgvPeScalarVariables.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvPeScalarVariables_CellValueNeeded);
            this.dgvPeScalarVariables.SelectionChanged += new System.EventHandler(this.dgvPeScalarVariables_SelectionChanged);
            this.dgvPeScalarVariables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPeScalarVariables_KeyDown);
            this.dgvPeScalarVariables.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCommon_ColumnHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.Frozen = true;
            this.dataGridViewTextBoxColumn10.HeaderText = "Name";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn10.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn10.Width = 240;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Value";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn11.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn11.Width = 240;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Last changed";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn12.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn12.Width = 100;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn13.HeaderText = "Changed by";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn13.MinimumWidth = 50;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPeScalarAdd,
            this.btnPeScalarEdit,
            this.toolStripSeparator4,
            this.btnPeScalarRemove,
            this.btnPeScalarRefresh});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(672, 25);
            this.toolStrip2.TabIndex = 20;
            // 
            // btnPeScalarAdd
            // 
            this.btnPeScalarAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnPeScalarAdd.Image")));
            this.btnPeScalarAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeScalarAdd.Name = "btnPeScalarAdd";
            this.btnPeScalarAdd.Size = new System.Drawing.Size(93, 22);
            this.btnPeScalarAdd.Text = "Add variable";
            this.btnPeScalarAdd.Click += new System.EventHandler(this.btnPeScalarAdd_Click);
            // 
            // btnPeScalarEdit
            // 
            this.btnPeScalarEdit.Enabled = false;
            this.btnPeScalarEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnPeScalarEdit.Image")));
            this.btnPeScalarEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeScalarEdit.Name = "btnPeScalarEdit";
            this.btnPeScalarEdit.Size = new System.Drawing.Size(91, 22);
            this.btnPeScalarEdit.Text = "Edit variable";
            this.btnPeScalarEdit.Click += new System.EventHandler(this.btnPeScalarEdit_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPeScalarRemove
            // 
            this.btnPeScalarRemove.Enabled = false;
            this.btnPeScalarRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnPeScalarRemove.Image")));
            this.btnPeScalarRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeScalarRemove.Name = "btnPeScalarRemove";
            this.btnPeScalarRemove.Size = new System.Drawing.Size(114, 22);
            this.btnPeScalarRemove.Text = "Remove variable";
            this.btnPeScalarRemove.Click += new System.EventHandler(this.btnPeScalarRemove_Click);
            // 
            // btnPeScalarRefresh
            // 
            this.btnPeScalarRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPeScalarRefresh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPeScalarRemoveAll});
            this.btnPeScalarRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnPeScalarRefresh.Image")));
            this.btnPeScalarRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeScalarRefresh.Name = "btnPeScalarRefresh";
            this.btnPeScalarRefresh.Size = new System.Drawing.Size(78, 22);
            this.btnPeScalarRefresh.Text = "Refresh";
            this.btnPeScalarRefresh.ButtonClick += new System.EventHandler(this.btnPeScalarRefresh_ButtonClick);
            // 
            // btnPeScalarRemoveAll
            // 
            this.btnPeScalarRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnPeScalarRemoveAll.Image")));
            this.btnPeScalarRemoveAll.Name = "btnPeScalarRemoveAll";
            this.btnPeScalarRemoveAll.Size = new System.Drawing.Size(181, 22);
            this.btnPeScalarRemoveAll.Text = "Remove all variables";
            this.btnPeScalarRemoveAll.Click += new System.EventHandler(this.btnPeScalarRemoveAll_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "var_scalar.png");
            this.imageList1.Images.SetKeyName(1, "var_list.png");
            this.imageList1.Images.SetKeyName(2, "var_table.png");
            this.imageList1.Images.SetKeyName(3, "mutex.png");
            this.imageList1.Images.SetKeyName(4, "imageaura.png");
            this.imageList1.Images.SetKeyName(5, "textaura.png");
            this.imageList1.Images.SetKeyName(6, "callback.png");
            this.imageList1.Images.SetKeyName(7, "appointment-new.png");
            this.imageList1.Images.SetKeyName(8, "media-floppy.png");
            this.imageList1.Images.SetKeyName(9, "var_dict.png");
            // 
            // tabList
            // 
            this.tabList.Controls.Add(this.tbcList);
            this.tabList.ImageKey = "var_list.png";
            this.tabList.Location = new System.Drawing.Point(4, 23);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(10);
            this.tabList.Size = new System.Drawing.Size(706, 419);
            this.tabList.TabIndex = 1;
            this.tabList.Text = "List variables";
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // tbcList
            // 
            this.tbcList.Controls.Add(this.tabListSession);
            this.tbcList.Controls.Add(this.tabListPersistent);
            this.tbcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcList.ImageList = this.imageList1;
            this.tbcList.Location = new System.Drawing.Point(10, 10);
            this.tbcList.Name = "tbcList";
            this.tbcList.SelectedIndex = 0;
            this.tbcList.Size = new System.Drawing.Size(686, 399);
            this.tbcList.TabIndex = 24;
            this.tbcList.SelectedIndexChanged += new System.EventHandler(this.tbcList_SelectedIndexChanged);
            // 
            // tabListSession
            // 
            this.tabListSession.Controls.Add(this.panel2);
            this.tabListSession.ImageKey = "appointment-new.png";
            this.tabListSession.Location = new System.Drawing.Point(4, 23);
            this.tabListSession.Name = "tabListSession";
            this.tabListSession.Padding = new System.Windows.Forms.Padding(3);
            this.tabListSession.Size = new System.Drawing.Size(678, 372);
            this.tabListSession.TabIndex = 0;
            this.tabListSession.Text = "Session";
            this.tabListSession.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvListVariables);
            this.panel2.Controls.Add(this.tlsList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(672, 366);
            this.panel2.TabIndex = 23;
            // 
            // dgvListVariables
            // 
            this.dgvListVariables.AllowUserToAddRows = false;
            this.dgvListVariables.AllowUserToDeleteRows = false;
            this.dgvListVariables.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvListVariables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
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
            this.dgvListVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListVariables.ShowCellErrors = false;
            this.dgvListVariables.ShowEditingIcon = false;
            this.dgvListVariables.ShowRowErrors = false;
            this.dgvListVariables.Size = new System.Drawing.Size(672, 341);
            this.dgvListVariables.TabIndex = 21;
            this.dgvListVariables.VirtualMode = true;
            this.dgvListVariables.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListVariables_CellDoubleClick);
            this.dgvListVariables.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvListVariables_CellValueNeeded);
            this.dgvListVariables.SelectionChanged += new System.EventHandler(this.dgvListVariables_SelectionChanged);
            this.dgvListVariables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListVariables_KeyDown);
            this.dgvListVariables.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCommon_ColumnHeaderMouseClick);
            // 
            // colListName
            // 
            this.colListName.Frozen = true;
            this.colListName.HeaderText = "Name";
            this.colListName.Name = "colListName";
            this.colListName.ReadOnly = true;
            this.colListName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colListName.Width = 200;
            // 
            // colListSize
            // 
            this.colListSize.HeaderText = "Size";
            this.colListSize.Name = "colListSize";
            this.colListSize.ReadOnly = true;
            this.colListSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colListSize.Width = 50;
            // 
            // colListValue
            // 
            this.colListValue.HeaderText = "Value";
            this.colListValue.Name = "colListValue";
            this.colListValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colListValue.Width = 240;
            // 
            // colListLastChanged
            // 
            this.colListLastChanged.HeaderText = "Last changed";
            this.colListLastChanged.Name = "colListLastChanged";
            this.colListLastChanged.ReadOnly = true;
            this.colListLastChanged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colListLastChanged.Width = 100;
            // 
            // colListChangedBy
            // 
            this.colListChangedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colListChangedBy.HeaderText = "Changed by";
            this.colListChangedBy.Name = "colListChangedBy";
            this.colListChangedBy.ReadOnly = true;
            this.colListChangedBy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tlsList
            // 
            this.tlsList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnListAdd,
            this.btnListEdit,
            this.toolStripSeparator2,
            this.btnListRemove,
            this.btnListRefresh});
            this.tlsList.Location = new System.Drawing.Point(0, 0);
            this.tlsList.Name = "tlsList";
            this.tlsList.Size = new System.Drawing.Size(672, 25);
            this.tlsList.TabIndex = 22;
            // 
            // btnListAdd
            // 
            this.btnListAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnListAdd.Image")));
            this.btnListAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListAdd.Name = "btnListAdd";
            this.btnListAdd.Size = new System.Drawing.Size(93, 22);
            this.btnListAdd.Text = "Add variable";
            this.btnListAdd.Click += new System.EventHandler(this.btnListAdd_Click);
            // 
            // btnListEdit
            // 
            this.btnListEdit.Enabled = false;
            this.btnListEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnListEdit.Image")));
            this.btnListEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListEdit.Name = "btnListEdit";
            this.btnListEdit.Size = new System.Drawing.Size(91, 22);
            this.btnListEdit.Text = "Edit variable";
            this.btnListEdit.Click += new System.EventHandler(this.btnListEdit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnListRemove
            // 
            this.btnListRemove.Enabled = false;
            this.btnListRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnListRemove.Image")));
            this.btnListRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListRemove.Name = "btnListRemove";
            this.btnListRemove.Size = new System.Drawing.Size(114, 22);
            this.btnListRemove.Text = "Remove variable";
            this.btnListRemove.Click += new System.EventHandler(this.btnListRemove_Click);
            // 
            // btnListRefresh
            // 
            this.btnListRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnListRefresh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnListRemoveAll});
            this.btnListRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnListRefresh.Image")));
            this.btnListRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListRefresh.Name = "btnListRefresh";
            this.btnListRefresh.Size = new System.Drawing.Size(78, 22);
            this.btnListRefresh.Text = "Refresh";
            this.btnListRefresh.ButtonClick += new System.EventHandler(this.btnListRefresh_ButtonClick);
            // 
            // btnListRemoveAll
            // 
            this.btnListRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnListRemoveAll.Image")));
            this.btnListRemoveAll.Name = "btnListRemoveAll";
            this.btnListRemoveAll.Size = new System.Drawing.Size(181, 22);
            this.btnListRemoveAll.Text = "Remove all variables";
            this.btnListRemoveAll.Click += new System.EventHandler(this.btnListRemoveAll_Click);
            // 
            // tabListPersistent
            // 
            this.tabListPersistent.Controls.Add(this.panel6);
            this.tabListPersistent.ImageKey = "media-floppy.png";
            this.tabListPersistent.Location = new System.Drawing.Point(4, 23);
            this.tabListPersistent.Name = "tabListPersistent";
            this.tabListPersistent.Padding = new System.Windows.Forms.Padding(3);
            this.tabListPersistent.Size = new System.Drawing.Size(678, 372);
            this.tabListPersistent.TabIndex = 1;
            this.tabListPersistent.Text = "Persistent";
            this.tabListPersistent.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvPeListVariables);
            this.panel6.Controls.Add(this.toolStrip3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(672, 366);
            this.panel6.TabIndex = 24;
            // 
            // dgvPeListVariables
            // 
            this.dgvPeListVariables.AllowUserToAddRows = false;
            this.dgvPeListVariables.AllowUserToDeleteRows = false;
            this.dgvPeListVariables.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPeListVariables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPeListVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeListVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18});
            this.dgvPeListVariables.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPeListVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeListVariables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPeListVariables.Location = new System.Drawing.Point(0, 25);
            this.dgvPeListVariables.Name = "dgvPeListVariables";
            this.dgvPeListVariables.RowHeadersVisible = false;
            this.dgvPeListVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeListVariables.ShowCellErrors = false;
            this.dgvPeListVariables.ShowEditingIcon = false;
            this.dgvPeListVariables.ShowRowErrors = false;
            this.dgvPeListVariables.Size = new System.Drawing.Size(672, 341);
            this.dgvPeListVariables.TabIndex = 21;
            this.dgvPeListVariables.VirtualMode = true;
            this.dgvPeListVariables.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeListVariables_CellDoubleClick);
            this.dgvPeListVariables.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvPeListVariables_CellValueNeeded);
            this.dgvPeListVariables.SelectionChanged += new System.EventHandler(this.dgvPeListVariables_SelectionChanged);
            this.dgvPeListVariables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPeListVariables_KeyDown);
            this.dgvPeListVariables.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCommon_ColumnHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.Frozen = true;
            this.dataGridViewTextBoxColumn14.HeaderText = "Name";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn14.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn14.Width = 200;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Size";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn15.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn15.Width = 50;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "Value";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn16.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn16.Width = 240;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "Last changed";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn17.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn17.Width = 100;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn18.HeaderText = "Changed by";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn18.MinimumWidth = 50;
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPeListAdd,
            this.btnPeListEdit,
            this.toolStripSeparator5,
            this.btnPeListRemove,
            this.btnPeListRefresh});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(672, 25);
            this.toolStrip3.TabIndex = 22;
            // 
            // btnPeListAdd
            // 
            this.btnPeListAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnPeListAdd.Image")));
            this.btnPeListAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeListAdd.Name = "btnPeListAdd";
            this.btnPeListAdd.Size = new System.Drawing.Size(93, 22);
            this.btnPeListAdd.Text = "Add variable";
            this.btnPeListAdd.Click += new System.EventHandler(this.btnPeListAdd_Click);
            // 
            // btnPeListEdit
            // 
            this.btnPeListEdit.Enabled = false;
            this.btnPeListEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnPeListEdit.Image")));
            this.btnPeListEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeListEdit.Name = "btnPeListEdit";
            this.btnPeListEdit.Size = new System.Drawing.Size(91, 22);
            this.btnPeListEdit.Text = "Edit variable";
            this.btnPeListEdit.Click += new System.EventHandler(this.btnPeListEdit_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPeListRemove
            // 
            this.btnPeListRemove.Enabled = false;
            this.btnPeListRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnPeListRemove.Image")));
            this.btnPeListRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeListRemove.Name = "btnPeListRemove";
            this.btnPeListRemove.Size = new System.Drawing.Size(114, 22);
            this.btnPeListRemove.Text = "Remove variable";
            this.btnPeListRemove.Click += new System.EventHandler(this.btnPeListRemove_Click);
            // 
            // btnPeListRefresh
            // 
            this.btnPeListRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPeListRefresh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPeListRemoveAll});
            this.btnPeListRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnPeListRefresh.Image")));
            this.btnPeListRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeListRefresh.Name = "btnPeListRefresh";
            this.btnPeListRefresh.Size = new System.Drawing.Size(78, 22);
            this.btnPeListRefresh.Text = "Refresh";
            this.btnPeListRefresh.ButtonClick += new System.EventHandler(this.btnPeListRefresh_ButtonClick);
            // 
            // btnPeListRemoveAll
            // 
            this.btnPeListRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnPeListRemoveAll.Image")));
            this.btnPeListRemoveAll.Name = "btnPeListRemoveAll";
            this.btnPeListRemoveAll.Size = new System.Drawing.Size(181, 22);
            this.btnPeListRemoveAll.Text = "Remove all variables";
            this.btnPeListRemoveAll.Click += new System.EventHandler(this.btnPeListRemoveAll_Click);
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.tbcTable);
            this.tabTable.ImageKey = "var_table.png";
            this.tabTable.Location = new System.Drawing.Point(4, 23);
            this.tabTable.Name = "tabTable";
            this.tabTable.Padding = new System.Windows.Forms.Padding(10);
            this.tabTable.Size = new System.Drawing.Size(706, 419);
            this.tabTable.TabIndex = 2;
            this.tabTable.Text = "Table variables";
            this.tabTable.UseVisualStyleBackColor = true;
            // 
            // tbcTable
            // 
            this.tbcTable.Controls.Add(this.tabTableSession);
            this.tbcTable.Controls.Add(this.tabTablePersistent);
            this.tbcTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcTable.ImageList = this.imageList1;
            this.tbcTable.Location = new System.Drawing.Point(10, 10);
            this.tbcTable.Name = "tbcTable";
            this.tbcTable.SelectedIndex = 0;
            this.tbcTable.Size = new System.Drawing.Size(686, 399);
            this.tbcTable.TabIndex = 25;
            this.tbcTable.SelectedIndexChanged += new System.EventHandler(this.tbcTable_SelectedIndexChanged);
            // 
            // tabTableSession
            // 
            this.tabTableSession.Controls.Add(this.panel4);
            this.tabTableSession.ImageKey = "appointment-new.png";
            this.tabTableSession.Location = new System.Drawing.Point(4, 23);
            this.tabTableSession.Name = "tabTableSession";
            this.tabTableSession.Padding = new System.Windows.Forms.Padding(3);
            this.tabTableSession.Size = new System.Drawing.Size(678, 372);
            this.tabTableSession.TabIndex = 0;
            this.tabTableSession.Text = "Session";
            this.tabTableSession.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvTableVariables);
            this.panel4.Controls.Add(this.tlsTable);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(672, 366);
            this.panel4.TabIndex = 24;
            // 
            // dgvTableVariables
            // 
            this.dgvTableVariables.AllowUserToAddRows = false;
            this.dgvTableVariables.AllowUserToDeleteRows = false;
            this.dgvTableVariables.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTableVariables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
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
            this.dgvTableVariables.Location = new System.Drawing.Point(0, 25);
            this.dgvTableVariables.Name = "dgvTableVariables";
            this.dgvTableVariables.RowHeadersVisible = false;
            this.dgvTableVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTableVariables.ShowCellErrors = false;
            this.dgvTableVariables.ShowEditingIcon = false;
            this.dgvTableVariables.ShowRowErrors = false;
            this.dgvTableVariables.Size = new System.Drawing.Size(672, 341);
            this.dgvTableVariables.TabIndex = 22;
            this.dgvTableVariables.VirtualMode = true;
            this.dgvTableVariables.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTableVariables_CellDoubleClick);
            this.dgvTableVariables.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvTableVariables_CellValueNeeded);
            this.dgvTableVariables.SelectionChanged += new System.EventHandler(this.dgvTableVariables_SelectionChanged);
            this.dgvTableVariables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTableVariables_KeyDown);
            this.dgvTableVariables.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCommon_ColumnHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn1.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn1.Width = 240;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Width";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn2.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Height";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column1.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Last changed";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn4.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Changed by";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn5.MinimumWidth = 50;
            // 
            // tlsTable
            // 
            this.tlsTable.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTableAdd,
            this.btnTableEdit,
            this.toolStripSeparator3,
            this.btnTableRemove,
            this.btnTableRefresh});
            this.tlsTable.Location = new System.Drawing.Point(0, 0);
            this.tlsTable.Name = "tlsTable";
            this.tlsTable.Size = new System.Drawing.Size(672, 25);
            this.tlsTable.TabIndex = 23;
            // 
            // btnTableAdd
            // 
            this.btnTableAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnTableAdd.Image")));
            this.btnTableAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTableAdd.Name = "btnTableAdd";
            this.btnTableAdd.Size = new System.Drawing.Size(93, 22);
            this.btnTableAdd.Text = "Add variable";
            this.btnTableAdd.Click += new System.EventHandler(this.btnTableAdd_Click);
            // 
            // btnTableEdit
            // 
            this.btnTableEdit.Enabled = false;
            this.btnTableEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnTableEdit.Image")));
            this.btnTableEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTableEdit.Name = "btnTableEdit";
            this.btnTableEdit.Size = new System.Drawing.Size(91, 22);
            this.btnTableEdit.Text = "Edit variable";
            this.btnTableEdit.Click += new System.EventHandler(this.btnTableEdit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnTableRemove
            // 
            this.btnTableRemove.Enabled = false;
            this.btnTableRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnTableRemove.Image")));
            this.btnTableRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTableRemove.Name = "btnTableRemove";
            this.btnTableRemove.Size = new System.Drawing.Size(114, 22);
            this.btnTableRemove.Text = "Remove variable";
            this.btnTableRemove.Click += new System.EventHandler(this.btnTableRemove_Click);
            // 
            // btnTableRefresh
            // 
            this.btnTableRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnTableRefresh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTableRemoveAll});
            this.btnTableRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnTableRefresh.Image")));
            this.btnTableRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTableRefresh.Name = "btnTableRefresh";
            this.btnTableRefresh.Size = new System.Drawing.Size(78, 22);
            this.btnTableRefresh.Text = "Refresh";
            this.btnTableRefresh.ButtonClick += new System.EventHandler(this.btnTableRefresh_ButtonClick);
            // 
            // btnTableRemoveAll
            // 
            this.btnTableRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnTableRemoveAll.Image")));
            this.btnTableRemoveAll.Name = "btnTableRemoveAll";
            this.btnTableRemoveAll.Size = new System.Drawing.Size(181, 22);
            this.btnTableRemoveAll.Text = "Remove all variables";
            this.btnTableRemoveAll.Click += new System.EventHandler(this.btnTableRemoveAll_Click);
            // 
            // tabTablePersistent
            // 
            this.tabTablePersistent.Controls.Add(this.panel7);
            this.tabTablePersistent.ImageKey = "media-floppy.png";
            this.tabTablePersistent.Location = new System.Drawing.Point(4, 23);
            this.tabTablePersistent.Name = "tabTablePersistent";
            this.tabTablePersistent.Padding = new System.Windows.Forms.Padding(3);
            this.tabTablePersistent.Size = new System.Drawing.Size(678, 372);
            this.tabTablePersistent.TabIndex = 1;
            this.tabTablePersistent.Text = "Persistent";
            this.tabTablePersistent.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dgvPeTableVariables);
            this.panel7.Controls.Add(this.toolStrip4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(672, 366);
            this.panel7.TabIndex = 25;
            // 
            // dgvPeTableVariables
            // 
            this.dgvPeTableVariables.AllowUserToAddRows = false;
            this.dgvPeTableVariables.AllowUserToDeleteRows = false;
            this.dgvPeTableVariables.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPeTableVariables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPeTableVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeTableVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23});
            this.dgvPeTableVariables.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPeTableVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeTableVariables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPeTableVariables.Location = new System.Drawing.Point(0, 25);
            this.dgvPeTableVariables.Name = "dgvPeTableVariables";
            this.dgvPeTableVariables.RowHeadersVisible = false;
            this.dgvPeTableVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeTableVariables.ShowCellErrors = false;
            this.dgvPeTableVariables.ShowEditingIcon = false;
            this.dgvPeTableVariables.ShowRowErrors = false;
            this.dgvPeTableVariables.Size = new System.Drawing.Size(672, 341);
            this.dgvPeTableVariables.TabIndex = 22;
            this.dgvPeTableVariables.VirtualMode = true;
            this.dgvPeTableVariables.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeTableVariables_CellDoubleClick);
            this.dgvPeTableVariables.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvPeTableVariables_CellValueNeeded);
            this.dgvPeTableVariables.SelectionChanged += new System.EventHandler(this.dgvPeTableVariables_SelectionChanged);
            this.dgvPeTableVariables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPeTableVariables_KeyDown);
            this.dgvPeTableVariables.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCommon_ColumnHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "Name";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn19.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn19.Width = 240;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "Width";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn20.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn20.Width = 70;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.HeaderText = "Height";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn21.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn21.Width = 70;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.HeaderText = "Last changed";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn22.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn22.Width = 160;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn23.HeaderText = "Changed by";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn23.MinimumWidth = 50;
            // 
            // toolStrip4
            // 
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPeTableAdd,
            this.btnPeTableEdit,
            this.toolStripSeparator6,
            this.btnPeTableRemove,
            this.btnPeTableRefresh});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(672, 25);
            this.toolStrip4.TabIndex = 23;
            // 
            // btnPeTableAdd
            // 
            this.btnPeTableAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnPeTableAdd.Image")));
            this.btnPeTableAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeTableAdd.Name = "btnPeTableAdd";
            this.btnPeTableAdd.Size = new System.Drawing.Size(93, 22);
            this.btnPeTableAdd.Text = "Add variable";
            this.btnPeTableAdd.Click += new System.EventHandler(this.btnPeTableAdd_Click);
            // 
            // btnPeTableEdit
            // 
            this.btnPeTableEdit.Enabled = false;
            this.btnPeTableEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnPeTableEdit.Image")));
            this.btnPeTableEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeTableEdit.Name = "btnPeTableEdit";
            this.btnPeTableEdit.Size = new System.Drawing.Size(91, 22);
            this.btnPeTableEdit.Text = "Edit variable";
            this.btnPeTableEdit.Click += new System.EventHandler(this.btnPeTableEdit_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPeTableRemove
            // 
            this.btnPeTableRemove.Enabled = false;
            this.btnPeTableRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnPeTableRemove.Image")));
            this.btnPeTableRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeTableRemove.Name = "btnPeTableRemove";
            this.btnPeTableRemove.Size = new System.Drawing.Size(114, 22);
            this.btnPeTableRemove.Text = "Remove variable";
            this.btnPeTableRemove.Click += new System.EventHandler(this.btnPeTableRemove_Click);
            // 
            // btnPeTableRefresh
            // 
            this.btnPeTableRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPeTableRefresh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPeTableRemoveAll});
            this.btnPeTableRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnPeTableRefresh.Image")));
            this.btnPeTableRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeTableRefresh.Name = "btnPeTableRefresh";
            this.btnPeTableRefresh.Size = new System.Drawing.Size(78, 22);
            this.btnPeTableRefresh.Text = "Refresh";
            this.btnPeTableRefresh.ButtonClick += new System.EventHandler(this.btnPeTableRefresh_ButtonClick);
            // 
            // btnPeTableRemoveAll
            // 
            this.btnPeTableRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnPeTableRemoveAll.Image")));
            this.btnPeTableRemoveAll.Name = "btnPeTableRemoveAll";
            this.btnPeTableRemoveAll.Size = new System.Drawing.Size(181, 22);
            this.btnPeTableRemoveAll.Text = "Remove all variables";
            this.btnPeTableRemoveAll.Click += new System.EventHandler(this.btnPeTableRemoveAll_Click);
            // 
            // tabDict
            // 
            this.tabDict.Controls.Add(this.tbcDict);
            this.tabDict.ImageKey = "var_dict.png";
            this.tabDict.Location = new System.Drawing.Point(4, 23);
            this.tabDict.Name = "tabDict";
            this.tabDict.Padding = new System.Windows.Forms.Padding(10);
            this.tabDict.Size = new System.Drawing.Size(706, 419);
            this.tabDict.TabIndex = 1;
            this.tabDict.Text = "Dict variables";
            this.tabDict.UseVisualStyleBackColor = true;
            // 
            // tbcDict
            // 
            this.tbcDict.Controls.Add(this.tabDictSession);
            this.tbcDict.Controls.Add(this.tabDictPersistent);
            this.tbcDict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcDict.ImageList = this.imageList1;
            this.tbcDict.Location = new System.Drawing.Point(10, 10);
            this.tbcDict.Name = "tbcDict";
            this.tbcDict.SelectedIndex = 0;
            this.tbcDict.Size = new System.Drawing.Size(686, 399);
            this.tbcDict.TabIndex = 24;
            this.tbcDict.SelectedIndexChanged += new System.EventHandler(this.tbcDict_SelectedIndexChanged);
            // 
            // tabDictSession
            // 
            this.tabDictSession.Controls.Add(this.panelDict);
            this.tabDictSession.ImageKey = "appointment-new.png";
            this.tabDictSession.Location = new System.Drawing.Point(4, 23);
            this.tabDictSession.Name = "tabDictSession";
            this.tabDictSession.Padding = new System.Windows.Forms.Padding(3);
            this.tabDictSession.Size = new System.Drawing.Size(678, 372);
            this.tabDictSession.TabIndex = 0;
            this.tabDictSession.Text = "Session";
            this.tabDictSession.UseVisualStyleBackColor = true;
            // 
            // panelDict
            // 
            this.panelDict.Controls.Add(this.dgvDictVariables);
            this.panelDict.Controls.Add(this.tlsDict);
            this.panelDict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDict.Location = new System.Drawing.Point(3, 3);
            this.panelDict.Name = "panelDict";
            this.panelDict.Size = new System.Drawing.Size(672, 366);
            this.panelDict.TabIndex = 23;
            // 
            // dgvDictVariables
            // 
            this.dgvDictVariables.AllowUserToAddRows = false;
            this.dgvDictVariables.AllowUserToDeleteRows = false;
            this.dgvDictVariables.AllowUserToResizeRows = false;
            dgvCellStyleDict.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDictVariables.AlternatingRowsDefaultCellStyle = dgvCellStyleDict;
            this.dgvDictVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDictVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDictName,
            this.colDictSize,
            this.colDictValue,
            this.colDictLastChanged,
            this.colDictChangedBy});
            this.dgvDictVariables.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDictVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDictVariables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDictVariables.Location = new System.Drawing.Point(0, 25);
            this.dgvDictVariables.Name = "dgvDictVariables";
            this.dgvDictVariables.RowHeadersVisible = false;
            this.dgvDictVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDictVariables.ShowCellErrors = false;
            this.dgvDictVariables.ShowEditingIcon = false;
            this.dgvDictVariables.ShowRowErrors = false;
            this.dgvDictVariables.Size = new System.Drawing.Size(672, 341);
            this.dgvDictVariables.TabIndex = 21;
            this.dgvDictVariables.VirtualMode = true;
            this.dgvDictVariables.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDictVariables_CellDoubleClick);
            this.dgvDictVariables.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvDictVariables_CellValueNeeded);
            this.dgvDictVariables.SelectionChanged += new System.EventHandler(this.dgvDictVariables_SelectionChanged);
            this.dgvDictVariables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDictVariables_KeyDown);
            this.dgvDictVariables.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCommon_ColumnHeaderMouseClick);
            // 
            // colDictName
            // 
            this.colDictName.Frozen = true;
            this.colDictName.HeaderText = "Name";
            this.colDictName.Name = "colDictName";
            this.colDictName.ReadOnly = true;
            this.colDictName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colDictName.Width = 200;
            // 
            // colDictSize
            // 
            this.colDictSize.HeaderText = "Size";
            this.colDictSize.Name = "colDictSize";
            this.colDictSize.ReadOnly = true;
            this.colDictSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colDictSize.Width = 50;
            // 
            // colDictValue
            // 
            this.colDictValue.HeaderText = "Value";
            this.colDictValue.Name = "colDictValue";
            this.colDictValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colDictValue.Width = 240;
            // 
            // colDictLastChanged
            // 
            this.colDictLastChanged.HeaderText = "Last changed";
            this.colDictLastChanged.Name = "colDictLastChanged";
            this.colDictLastChanged.ReadOnly = true;
            this.colDictLastChanged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colDictLastChanged.Width = 100;
            // 
            // colDictChangedBy
            // 
            this.colDictChangedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDictChangedBy.HeaderText = "Changed by";
            this.colDictChangedBy.Name = "colDictChangedBy";
            this.colDictChangedBy.ReadOnly = true;
            this.colDictChangedBy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tlsDict
            // 
            this.tlsDict.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsDict.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDictAdd,
            this.btnDictEdit,
            this.toolStripSeparatorDict,
            this.btnDictRemove,
            this.btnDictRefresh});
            this.tlsDict.Location = new System.Drawing.Point(0, 0);
            this.tlsDict.Name = "tlsDict";
            this.tlsDict.Size = new System.Drawing.Size(672, 25);
            this.tlsDict.TabIndex = 22;
            // 
            // btnDictAdd
            // 
            this.btnDictAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnDictAdd.Image")));
            this.btnDictAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDictAdd.Name = "btnDictAdd";
            this.btnDictAdd.Size = new System.Drawing.Size(93, 22);
            this.btnDictAdd.Text = "Add variable";
            this.btnDictAdd.Click += new System.EventHandler(this.btnDictAdd_Click);
            // 
            // btnDictEdit
            // 
            this.btnDictEdit.Enabled = false;
            this.btnDictEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnDictEdit.Image")));
            this.btnDictEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDictEdit.Name = "btnDictEdit";
            this.btnDictEdit.Size = new System.Drawing.Size(91, 22);
            this.btnDictEdit.Text = "Edit variable";
            this.btnDictEdit.Click += new System.EventHandler(this.btnDictEdit_Click);
            // 
            // toolStripSeparatorDict
            // 
            this.toolStripSeparatorDict.Name = "toolStripSeparatorDict";
            this.toolStripSeparatorDict.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDictRemove
            // 
            this.btnDictRemove.Enabled = false;
            this.btnDictRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnDictRemove.Image")));
            this.btnDictRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDictRemove.Name = "btnDictRemove";
            this.btnDictRemove.Size = new System.Drawing.Size(114, 22);
            this.btnDictRemove.Text = "Remove variable";
            this.btnDictRemove.Click += new System.EventHandler(this.btnDictRemove_Click);
            // 
            // btnDictRefresh
            // 
            this.btnDictRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDictRefresh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDictRemoveAll});
            this.btnDictRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnDictRefresh.Image")));
            this.btnDictRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDictRefresh.Name = "btnDictRefresh";
            this.btnDictRefresh.Size = new System.Drawing.Size(78, 22);
            this.btnDictRefresh.Text = "Refresh";
            this.btnDictRefresh.ButtonClick += new System.EventHandler(this.btnDictRefresh_ButtonClick);
            // 
            // btnDictRemoveAll
            // 
            this.btnDictRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnDictRemoveAll.Image")));
            this.btnDictRemoveAll.Name = "btnDictRemoveAll";
            this.btnDictRemoveAll.Size = new System.Drawing.Size(181, 22);
            this.btnDictRemoveAll.Text = "Remove all variables";
            this.btnDictRemoveAll.Click += new System.EventHandler(this.btnDictRemoveAll_Click);
            // 
            // tabDictPersistent
            // 
            this.tabDictPersistent.Controls.Add(this.panelPeDict);
            this.tabDictPersistent.ImageKey = "media-floppy.png";
            this.tabDictPersistent.Location = new System.Drawing.Point(4, 23);
            this.tabDictPersistent.Name = "tabDictPersistent";
            this.tabDictPersistent.Padding = new System.Windows.Forms.Padding(3);
            this.tabDictPersistent.Size = new System.Drawing.Size(678, 372);
            this.tabDictPersistent.TabIndex = 1;
            this.tabDictPersistent.Text = "Persistent";
            this.tabDictPersistent.UseVisualStyleBackColor = true;
            // 
            // panelPeDict
            // 
            this.panelPeDict.Controls.Add(this.dgvPeDictVariables);
            this.panelPeDict.Controls.Add(this.tlsPeDict);
            this.panelPeDict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPeDict.Location = new System.Drawing.Point(3, 3);
            this.panelPeDict.Name = "panelPeDict";
            this.panelPeDict.Size = new System.Drawing.Size(672, 366);
            this.panelPeDict.TabIndex = 24;
            // 
            // dgvPeDictVariables
            // 
            this.dgvPeDictVariables.AllowUserToAddRows = false;
            this.dgvPeDictVariables.AllowUserToDeleteRows = false;
            this.dgvPeDictVariables.AllowUserToResizeRows = false;
            dgvCellStylePeDict.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPeDictVariables.AlternatingRowsDefaultCellStyle = dgvCellStylePeDict;
            this.dgvPeDictVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeDictVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPeDictName,
            this.colPeDictSize,
            this.colPeDictValue,
            this.colPeDictLastChanged,
            this.colPeDictChangedBy});
            this.dgvPeDictVariables.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPeDictVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeDictVariables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPeDictVariables.Location = new System.Drawing.Point(0, 25);
            this.dgvPeDictVariables.Name = "dgvPeDictVariables";
            this.dgvPeDictVariables.RowHeadersVisible = false;
            this.dgvPeDictVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeDictVariables.ShowCellErrors = false;
            this.dgvPeDictVariables.ShowEditingIcon = false;
            this.dgvPeDictVariables.ShowRowErrors = false;
            this.dgvPeDictVariables.Size = new System.Drawing.Size(672, 341);
            this.dgvPeDictVariables.TabIndex = 21;
            this.dgvPeDictVariables.VirtualMode = true;
            this.dgvPeDictVariables.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeDictVariables_CellDoubleClick);
            this.dgvPeDictVariables.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvPeDictVariables_CellValueNeeded);
            this.dgvPeDictVariables.SelectionChanged += new System.EventHandler(this.dgvPeDictVariables_SelectionChanged);
            this.dgvPeDictVariables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPeDictVariables_KeyDown);
            this.dgvPeDictVariables.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCommon_ColumnHeaderMouseClick);
            // 
            // colPeDictName
            // 
            this.colPeDictName.Frozen = true;
            this.colPeDictName.HeaderText = "Name";
            this.colPeDictName.Name = "colPeDictName";
            this.colPeDictName.ReadOnly = true;
            this.colPeDictName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colPeDictName.Width = 200;
            // 
            // colPeDictSize
            // 
            this.colPeDictSize.HeaderText = "Size";
            this.colPeDictSize.Name = "colPeDictSize";
            this.colPeDictSize.ReadOnly = true;
            this.colPeDictSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colPeDictSize.Width = 50;
            // 
            // colPeDictValue
            // 
            this.colPeDictValue.HeaderText = "Value";
            this.colPeDictValue.Name = "colPeDictValue";
            this.colPeDictValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colPeDictValue.Width = 240;
            // 
            // colPeDictLastChanged
            // 
            this.colPeDictLastChanged.HeaderText = "Last changed";
            this.colPeDictLastChanged.Name = "colPeDictLastChanged";
            this.colPeDictLastChanged.ReadOnly = true;
            this.colPeDictLastChanged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colPeDictLastChanged.Width = 100;
            // 
            // colPeDictChangedBy
            // 
            this.colPeDictChangedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPeDictChangedBy.HeaderText = "Changed by";
            this.colPeDictChangedBy.Name = "colPeDictChangedBy";
            this.colPeDictChangedBy.ReadOnly = true;
            this.colPeDictChangedBy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tlsPeDict
            // 
            this.tlsPeDict.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsPeDict.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPeDictAdd,
            this.btnPeDictEdit,
            this.toolStripSeparatorPeDict,
            this.btnPeDictRemove,
            this.btnPeDictRefresh});
            this.tlsPeDict.Location = new System.Drawing.Point(0, 0);
            this.tlsPeDict.Name = "tlsPeDict";
            this.tlsPeDict.Size = new System.Drawing.Size(672, 25);
            this.tlsPeDict.TabIndex = 22;
            // 
            // btnPeDictAdd
            // 
            this.btnPeDictAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnPeDictAdd.Image")));
            this.btnPeDictAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeDictAdd.Name = "btnPeDictAdd";
            this.btnPeDictAdd.Size = new System.Drawing.Size(93, 22);
            this.btnPeDictAdd.Text = "Add variable";
            this.btnPeDictAdd.Click += new System.EventHandler(this.btnPeDictAdd_Click);
            // 
            // btnPeDictEdit
            // 
            this.btnPeDictEdit.Enabled = false;
            this.btnPeDictEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnPeDictEdit.Image")));
            this.btnPeDictEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeDictEdit.Name = "btnPeDictEdit";
            this.btnPeDictEdit.Size = new System.Drawing.Size(91, 22);
            this.btnPeDictEdit.Text = "Edit variable";
            this.btnPeDictEdit.Click += new System.EventHandler(this.btnPeDictEdit_Click);
            // 
            // toolStripSeparatorPeDict
            // 
            this.toolStripSeparatorPeDict.Name = "toolStripSeparatorPeDict";
            this.toolStripSeparatorPeDict.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPeDictRemove
            // 
            this.btnPeDictRemove.Enabled = false;
            this.btnPeDictRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnPeDictRemove.Image")));
            this.btnPeDictRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeDictRemove.Name = "btnPeDictRemove";
            this.btnPeDictRemove.Size = new System.Drawing.Size(114, 22);
            this.btnPeDictRemove.Text = "Remove variable";
            this.btnPeDictRemove.Click += new System.EventHandler(this.btnPeDictRemove_Click);
            // 
            // btnPeDictRefresh
            // 
            this.btnPeDictRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPeDictRefresh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPeDictRemoveAll});
            this.btnPeDictRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnPeDictRefresh.Image")));
            this.btnPeDictRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeDictRefresh.Name = "btnPeDictRefresh";
            this.btnPeDictRefresh.Size = new System.Drawing.Size(78, 22);
            this.btnPeDictRefresh.Text = "Refresh";
            this.btnPeDictRefresh.ButtonClick += new System.EventHandler(this.btnPeDictRefresh_ButtonClick);
            // 
            // btnPeDictRemoveAll
            // 
            this.btnPeDictRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnPeDictRemoveAll.Image")));
            this.btnPeDictRemoveAll.Name = "btnPeDictRemoveAll";
            this.btnPeDictRemoveAll.Size = new System.Drawing.Size(181, 22);
            this.btnPeDictRemoveAll.Text = "Remove all variables";
            this.btnPeDictRemoveAll.Click += new System.EventHandler(this.btnPeDictRemoveAll_Click);
            // 
            // tabMutexes
            // 
            this.tabMutexes.Controls.Add(this.dgvMutexes);
            this.tabMutexes.Controls.Add(this.tlsMutex);
            this.tabMutexes.ImageKey = "mutex.png";
            this.tabMutexes.Location = new System.Drawing.Point(4, 23);
            this.tabMutexes.Name = "tabMutexes";
            this.tabMutexes.Padding = new System.Windows.Forms.Padding(3);
            this.tabMutexes.Size = new System.Drawing.Size(706, 419);
            this.tabMutexes.TabIndex = 3;
            this.tabMutexes.Text = "Mutexes";
            this.tabMutexes.UseVisualStyleBackColor = true;
            // 
            // dgvMutexes
            // 
            this.dgvMutexes.AllowUserToAddRows = false;
            this.dgvMutexes.AllowUserToDeleteRows = false;
            this.dgvMutexes.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMutexes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMutexes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMutexes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.Column2,
            this.Column4,
            this.Column3});
            this.dgvMutexes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvMutexes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMutexes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMutexes.Location = new System.Drawing.Point(3, 28);
            this.dgvMutexes.Name = "dgvMutexes";
            this.dgvMutexes.RowHeadersVisible = false;
            this.dgvMutexes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMutexes.ShowCellErrors = false;
            this.dgvMutexes.ShowEditingIcon = false;
            this.dgvMutexes.ShowRowErrors = false;
            this.dgvMutexes.Size = new System.Drawing.Size(700, 388);
            this.dgvMutexes.TabIndex = 24;
            this.dgvMutexes.VirtualMode = true;
            this.dgvMutexes.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvMutexes_CellValueNeeded);
            this.dgvMutexes.SelectionChanged += new System.EventHandler(this.dgvMutexes_SelectionChanged);
            this.dgvMutexes.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCommon_ColumnHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Current owner";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Refcount";
            this.Column4.Name = "Column4";
            this.Column4.Width = 75;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Acquisition queue";
            this.Column3.Name = "Column3";
            // 
            // tlsMutex
            // 
            this.tlsMutex.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsMutex.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMutexRefresh,
            this.btnMutexForce});
            this.tlsMutex.Location = new System.Drawing.Point(3, 3);
            this.tlsMutex.Name = "tlsMutex";
            this.tlsMutex.Size = new System.Drawing.Size(700, 25);
            this.tlsMutex.TabIndex = 25;
            // 
            // btnMutexRefresh
            // 
            this.btnMutexRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnMutexRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnMutexRefresh.Image")));
            this.btnMutexRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMutexRefresh.Name = "btnMutexRefresh";
            this.btnMutexRefresh.Size = new System.Drawing.Size(66, 22);
            this.btnMutexRefresh.Text = "Refresh";
            this.btnMutexRefresh.Click += new System.EventHandler(this.btnMutexRefresh_Click);
            // 
            // btnMutexForce
            // 
            this.btnMutexForce.Enabled = false;
            this.btnMutexForce.Image = ((System.Drawing.Image)(resources.GetObject("btnMutexForce.Image")));
            this.btnMutexForce.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMutexForce.Name = "btnMutexForce";
            this.btnMutexForce.Size = new System.Drawing.Size(95, 22);
            this.btnMutexForce.Text = "Force release";
            this.btnMutexForce.Click += new System.EventHandler(this.btnMutexForce_Click);
            // 
            // tabImageAura
            // 
            this.tabImageAura.Controls.Add(this.dgvImage);
            this.tabImageAura.Controls.Add(this.tlsImageAura);
            this.tabImageAura.ImageKey = "imageaura.png";
            this.tabImageAura.Location = new System.Drawing.Point(4, 23);
            this.tabImageAura.Name = "tabImageAura";
            this.tabImageAura.Padding = new System.Windows.Forms.Padding(3);
            this.tabImageAura.Size = new System.Drawing.Size(706, 419);
            this.tabImageAura.TabIndex = 4;
            this.tabImageAura.Text = "Image auras";
            this.tabImageAura.UseVisualStyleBackColor = true;
            // 
            // dgvImage
            // 
            this.dgvImage.AllowUserToAddRows = false;
            this.dgvImage.AllowUserToDeleteRows = false;
            this.dgvImage.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvImage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvImage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dgvImage.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImage.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvImage.Location = new System.Drawing.Point(3, 28);
            this.dgvImage.Name = "dgvImage";
            this.dgvImage.RowHeadersVisible = false;
            this.dgvImage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImage.ShowCellErrors = false;
            this.dgvImage.ShowEditingIcon = false;
            this.dgvImage.ShowRowErrors = false;
            this.dgvImage.Size = new System.Drawing.Size(700, 388);
            this.dgvImage.TabIndex = 26;
            this.dgvImage.VirtualMode = true;
            this.dgvImage.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvImage_CellValueNeeded);
            this.dgvImage.SelectionChanged += new System.EventHandler(this.dgvImage_SelectionChanged);
            this.dgvImage.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCommon_ColumnHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Name";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.HeaderText = "Created by";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tlsImageAura
            // 
            this.tlsImageAura.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsImageAura.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImageRefresh,
            this.btnImageForce});
            this.tlsImageAura.Location = new System.Drawing.Point(3, 3);
            this.tlsImageAura.Name = "tlsImageAura";
            this.tlsImageAura.Size = new System.Drawing.Size(700, 25);
            this.tlsImageAura.TabIndex = 27;
            // 
            // btnImageRefresh
            // 
            this.btnImageRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnImageRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnImageRefresh.Image")));
            this.btnImageRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImageRefresh.Name = "btnImageRefresh";
            this.btnImageRefresh.Size = new System.Drawing.Size(66, 22);
            this.btnImageRefresh.Text = "Refresh";
            this.btnImageRefresh.Click += new System.EventHandler(this.btnImageRefresh_Click);
            // 
            // btnImageForce
            // 
            this.btnImageForce.Enabled = false;
            this.btnImageForce.Image = ((System.Drawing.Image)(resources.GetObject("btnImageForce.Image")));
            this.btnImageForce.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImageForce.Name = "btnImageForce";
            this.btnImageForce.Size = new System.Drawing.Size(113, 22);
            this.btnImageForce.Text = "Force deactivate";
            this.btnImageForce.Click += new System.EventHandler(this.btnImageForce_Click);
            // 
            // tabTextAura
            // 
            this.tabTextAura.Controls.Add(this.dgvText);
            this.tabTextAura.Controls.Add(this.tlsTextAura);
            this.tabTextAura.ImageKey = "textaura.png";
            this.tabTextAura.Location = new System.Drawing.Point(4, 23);
            this.tabTextAura.Name = "tabTextAura";
            this.tabTextAura.Padding = new System.Windows.Forms.Padding(3);
            this.tabTextAura.Size = new System.Drawing.Size(706, 419);
            this.tabTextAura.TabIndex = 5;
            this.tabTextAura.Text = "Text auras";
            this.tabTextAura.UseVisualStyleBackColor = true;
            // 
            // dgvText
            // 
            this.dgvText.AllowUserToAddRows = false;
            this.dgvText.AllowUserToDeleteRows = false;
            this.dgvText.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvText.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvText.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvText.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dgvText.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvText.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvText.Location = new System.Drawing.Point(3, 28);
            this.dgvText.Name = "dgvText";
            this.dgvText.RowHeadersVisible = false;
            this.dgvText.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvText.ShowCellErrors = false;
            this.dgvText.ShowEditingIcon = false;
            this.dgvText.ShowRowErrors = false;
            this.dgvText.Size = new System.Drawing.Size(700, 388);
            this.dgvText.TabIndex = 28;
            this.dgvText.VirtualMode = true;
            this.dgvText.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvText_CellValueNeeded);
            this.dgvText.SelectionChanged += new System.EventHandler(this.dgvText_SelectionChanged);
            this.dgvText.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCommon_ColumnHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Name";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn8.Width = 200;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.HeaderText = "Created by";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tlsTextAura
            // 
            this.tlsTextAura.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsTextAura.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTextRefresh,
            this.btnTextForce});
            this.tlsTextAura.Location = new System.Drawing.Point(3, 3);
            this.tlsTextAura.Name = "tlsTextAura";
            this.tlsTextAura.Size = new System.Drawing.Size(700, 25);
            this.tlsTextAura.TabIndex = 27;
            // 
            // btnTextRefresh
            // 
            this.btnTextRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnTextRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnTextRefresh.Image")));
            this.btnTextRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTextRefresh.Name = "btnTextRefresh";
            this.btnTextRefresh.Size = new System.Drawing.Size(66, 22);
            this.btnTextRefresh.Text = "Refresh";
            this.btnTextRefresh.Click += new System.EventHandler(this.btnTextRefresh_Click);
            // 
            // btnTextForce
            // 
            this.btnTextForce.Enabled = false;
            this.btnTextForce.Image = ((System.Drawing.Image)(resources.GetObject("btnTextForce.Image")));
            this.btnTextForce.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTextForce.Name = "btnTextForce";
            this.btnTextForce.Size = new System.Drawing.Size(113, 22);
            this.btnTextForce.Text = "Force deactivate";
            this.btnTextForce.Click += new System.EventHandler(this.btnTextForce_Click);
            // 
            // tabNamedCallbacks
            // 
            this.tabNamedCallbacks.Controls.Add(this.dgvCallback);
            this.tabNamedCallbacks.Controls.Add(this.toolStrip1);
            this.tabNamedCallbacks.ImageKey = "callback.png";
            this.tabNamedCallbacks.Location = new System.Drawing.Point(4, 23);
            this.tabNamedCallbacks.Name = "tabNamedCallbacks";
            this.tabNamedCallbacks.Padding = new System.Windows.Forms.Padding(3);
            this.tabNamedCallbacks.Size = new System.Drawing.Size(706, 419);
            this.tabNamedCallbacks.TabIndex = 6;
            this.tabNamedCallbacks.Text = "Named callbacks";
            this.tabNamedCallbacks.UseVisualStyleBackColor = true;
            // 
            // dgvCallback
            // 
            this.dgvCallback.AllowUserToAddRows = false;
            this.dgvCallback.AllowUserToDeleteRows = false;
            this.dgvCallback.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCallback.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvCallback.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCallback.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCallbackId,
            this.colCallbackName,
            this.colCallbackRegistrant,
            this.colCallbackRegistrationTime,
            this.colCallbackLastInvoked});
            this.dgvCallback.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCallback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCallback.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCallback.Location = new System.Drawing.Point(3, 28);
            this.dgvCallback.Name = "dgvCallback";
            this.dgvCallback.RowHeadersVisible = false;
            this.dgvCallback.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCallback.ShowCellErrors = false;
            this.dgvCallback.ShowEditingIcon = false;
            this.dgvCallback.ShowRowErrors = false;
            this.dgvCallback.Size = new System.Drawing.Size(700, 388);
            this.dgvCallback.TabIndex = 29;
            this.dgvCallback.VirtualMode = true;
            this.dgvCallback.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvCallback_CellValueNeeded);
            this.dgvCallback.SelectionChanged += new System.EventHandler(this.dgvCallback_SelectionChanged);
            this.dgvCallback.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCommon_ColumnHeaderMouseClick);
            // 
            // colCallbackId
            // 
            this.colCallbackId.HeaderText = "Id";
            this.colCallbackId.Name = "colCallbackId";
            this.colCallbackId.ReadOnly = true;
            this.colCallbackId.Width = 50;
            // 
            // colCallbackName
            // 
            this.colCallbackName.HeaderText = "Name";
            this.colCallbackName.Name = "colCallbackName";
            this.colCallbackName.ReadOnly = true;
            this.colCallbackName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colCallbackName.Width = 240;
            // 
            // colCallbackRegistrant
            // 
            this.colCallbackRegistrant.HeaderText = "Registrant";
            this.colCallbackRegistrant.Name = "colCallbackRegistrant";
            this.colCallbackRegistrant.ReadOnly = true;
            this.colCallbackRegistrant.Width = 240;
            // 
            // colCallbackRegistrationTime
            // 
            this.colCallbackRegistrationTime.HeaderText = "Registration Time";
            this.colCallbackRegistrationTime.Name = "colCallbackRegistrationTime";
            this.colCallbackRegistrationTime.ReadOnly = true;
            this.colCallbackRegistrationTime.Width = 120;
            // 
            // colCallbackLastInvoked
            // 
            this.colCallbackLastInvoked.HeaderText = "Last Invoked";
            this.colCallbackLastInvoked.Name = "colCallbackLastInvoked";
            this.colCallbackLastInvoked.ReadOnly = true;
            this.colCallbackLastInvoked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCallbackRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(700, 25);
            this.toolStrip1.TabIndex = 28;
            // 
            // btnCallbackRefresh
            // 
            this.btnCallbackRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCallbackRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnCallbackRefresh.Image")));
            this.btnCallbackRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCallbackRefresh.Name = "btnCallbackRefresh";
            this.btnCallbackRefresh.Size = new System.Drawing.Size(66, 22);
            this.btnCallbackRefresh.Text = "Refresh";
            this.btnCallbackRefresh.Click += new System.EventHandler(this.btnCallbackRefresh_Click);
            // 
            // StateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "StateForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Triggernometry state";
            this.tlsScalar.ResumeLayout(false);
            this.tlsScalar.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScalarVariables)).EndInit();
            this.tbcMain.ResumeLayout(false);
            this.tabScalar.ResumeLayout(false);
            this.tbcScalar.ResumeLayout(false);
            this.tabScalarSession.ResumeLayout(false);
            this.tabScalarPersistent.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeScalarVariables)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabList.ResumeLayout(false);
            this.tbcList.ResumeLayout(false);
            this.tabListSession.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListVariables)).EndInit();
            this.tlsList.ResumeLayout(false);
            this.tlsList.PerformLayout();
            this.tabListPersistent.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeListVariables)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabTable.ResumeLayout(false);
            this.tbcTable.ResumeLayout(false);
            this.tabTableSession.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableVariables)).EndInit();
            this.tlsTable.ResumeLayout(false);
            this.tlsTable.PerformLayout();
            this.tabTablePersistent.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeTableVariables)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.tabDict.ResumeLayout(false);
            this.tbcDict.ResumeLayout(false);
            this.tabDictSession.ResumeLayout(false);
            this.panelDict.ResumeLayout(false);
            this.panelDict.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDictVariables)).EndInit();
            this.tlsDict.ResumeLayout(false);
            this.tlsDict.PerformLayout();
            this.tabDictPersistent.ResumeLayout(false);
            this.panelPeDict.ResumeLayout(false);
            this.panelPeDict.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeDictVariables)).EndInit();
            this.tlsPeDict.ResumeLayout(false);
            this.tlsPeDict.PerformLayout();
            this.tabMutexes.ResumeLayout(false);
            this.tabMutexes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMutexes)).EndInit();
            this.tlsMutex.ResumeLayout(false);
            this.tlsMutex.PerformLayout();
            this.tabImageAura.ResumeLayout(false);
            this.tabImageAura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImage)).EndInit();
            this.tlsImageAura.ResumeLayout(false);
            this.tlsImageAura.PerformLayout();
            this.tabTextAura.ResumeLayout(false);
            this.tabTextAura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvText)).EndInit();
            this.tlsTextAura.ResumeLayout(false);
            this.tlsTextAura.PerformLayout();
            this.tabNamedCallbacks.ResumeLayout(false);
            this.tabNamedCallbacks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCallback)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStrip tlsScalar;
        private CustomControls.DataGridViewEx dgvScalarVariables;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabScalar;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.Panel panel2;
        private CustomControls.DataGridViewEx dgvListVariables;
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
        private System.Windows.Forms.ToolStripButton btnScalarAdd;
        private System.Windows.Forms.ToolStripButton btnScalarEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnScalarRemove;
        private System.Windows.Forms.ToolStripSplitButton btnScalarRefresh;
        private System.Windows.Forms.ToolStripMenuItem btnScalarRemoveAll;
        private System.Windows.Forms.ToolStrip tlsList;
        private System.Windows.Forms.ToolStripButton btnListAdd;
        private System.Windows.Forms.ToolStripButton btnListEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnListRemove;
        private System.Windows.Forms.ToolStripSplitButton btnListRefresh;
        private System.Windows.Forms.ToolStripMenuItem btnListRemoveAll;
        private System.Windows.Forms.ToolStrip tlsTable;
        private System.Windows.Forms.ToolStripButton btnTableAdd;
        private System.Windows.Forms.ToolStripButton btnTableEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnTableRemove;
        private System.Windows.Forms.ToolStripSplitButton btnTableRefresh;
        private System.Windows.Forms.ToolStripMenuItem btnTableRemoveAll;
        private System.Windows.Forms.TabPage tabMutexes;
        private CustomControls.DataGridViewEx dgvMutexes;
        private System.Windows.Forms.ToolStrip tlsMutex;
        private System.Windows.Forms.ToolStripButton btnMutexRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStripButton btnMutexForce;
        private System.Windows.Forms.TabPage tabImageAura;
        private System.Windows.Forms.TabPage tabTextAura;
        private CustomControls.DataGridViewEx dgvImage;
        private System.Windows.Forms.ToolStrip tlsImageAura;
        private System.Windows.Forms.ToolStripButton btnImageRefresh;
        private System.Windows.Forms.ToolStripButton btnImageForce;
        private System.Windows.Forms.ToolStrip tlsTextAura;
        private System.Windows.Forms.ToolStripButton btnTextRefresh;
        private System.Windows.Forms.ToolStripButton btnTextForce;
        private CustomControls.DataGridViewEx dgvText;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.TabPage tabNamedCallbacks;
        private CustomControls.DataGridViewEx dgvCallback;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCallbackId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCallbackName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCallbackRegistrant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCallbackRegistrationTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCallbackLastInvoked;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCallbackRefresh;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tbcScalar;
        private System.Windows.Forms.TabPage tabScalarSession;
        private System.Windows.Forms.TabPage tabScalarPersistent;
        private System.Windows.Forms.TabControl tbcList;
        private System.Windows.Forms.TabPage tabListSession;
        private System.Windows.Forms.TabPage tabListPersistent;
        private System.Windows.Forms.TabControl tbcTable;
        private System.Windows.Forms.TabPage tabTableSession;
        private System.Windows.Forms.TabPage tabTablePersistent;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private CustomControls.DataGridViewEx dgvPeScalarVariables;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnPeScalarAdd;
        private System.Windows.Forms.ToolStripButton btnPeScalarEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnPeScalarRemove;
        private System.Windows.Forms.ToolStripSplitButton btnPeScalarRefresh;
        private System.Windows.Forms.ToolStripMenuItem btnPeScalarRemoveAll;
        private System.Windows.Forms.Panel panel6;
        private CustomControls.DataGridViewEx dgvPeListVariables;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnPeListAdd;
        private System.Windows.Forms.ToolStripButton btnPeListEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnPeListRemove;
        private System.Windows.Forms.ToolStripSplitButton btnPeListRefresh;
        private System.Windows.Forms.ToolStripMenuItem btnPeListRemoveAll;
        private System.Windows.Forms.Panel panel7;
        private CustomControls.DataGridViewEx dgvPeTableVariables;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton btnPeTableAdd;
        private System.Windows.Forms.ToolStripButton btnPeTableEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnPeTableRemove;
        private System.Windows.Forms.ToolStripSplitButton btnPeTableRefresh;
        private System.Windows.Forms.ToolStripMenuItem btnPeTableRemoveAll;
        private System.Windows.Forms.TabPage tabDict;
        private System.Windows.Forms.TabControl tbcDict;
        private System.Windows.Forms.TabPage tabDictSession;
        private System.Windows.Forms.Panel panelDict;
        private CustomControls.DataGridViewEx dgvDictVariables;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDictName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDictSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDictValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDictLastChanged;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDictChangedBy;
        private System.Windows.Forms.ToolStrip tlsDict;
        private System.Windows.Forms.ToolStripButton btnDictAdd;
        private System.Windows.Forms.ToolStripButton btnDictEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorDict;
        private System.Windows.Forms.ToolStripButton btnDictRemove;
        private System.Windows.Forms.ToolStripSplitButton btnDictRefresh;
        private System.Windows.Forms.ToolStripMenuItem btnDictRemoveAll;
        private System.Windows.Forms.TabPage tabDictPersistent;
        private System.Windows.Forms.Panel panelPeDict;
        private CustomControls.DataGridViewEx dgvPeDictVariables;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeDictName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeDictSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeDictValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeDictLastChanged;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeDictChangedBy;
        private System.Windows.Forms.ToolStrip tlsPeDict;
        private System.Windows.Forms.ToolStripButton btnPeDictAdd;
        private System.Windows.Forms.ToolStripButton btnPeDictEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorPeDict;
        private System.Windows.Forms.ToolStripButton btnPeDictRemove;
        private System.Windows.Forms.ToolStripSplitButton btnPeDictRefresh;
        private System.Windows.Forms.ToolStripMenuItem btnPeDictRemoveAll;
    }
}