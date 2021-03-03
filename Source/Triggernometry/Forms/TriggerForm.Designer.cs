namespace Triggernometry.Forms
{
    partial class TriggerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TriggerForm));
            this.dgvActions = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxAddAction = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxEditAction = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxCopyAction = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxPasteAction = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxRemoveAction = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAddAction = new System.Windows.Forms.ToolStripButton();
            this.btnEditAction = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActionUp = new System.Windows.Forms.ToolStripButton();
            this.btnActionDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRemoveAction = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRegexp = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtRegexp = new Triggernometry.CustomControls.ExpressionTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabTriggerActions = new System.Windows.Forms.TabPage();
            this.tabTriggerCondition = new System.Windows.Forms.TabPage();
            this.cndCondition = new Triggernometry.CustomControls.ConditionViewer();
            this.tabScheduling = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.expMutexName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblMutexCapture = new System.Windows.Forms.Label();
            this.cbxSequential = new System.Windows.Forms.CheckBox();
            this.cbxEditAutofire = new System.Windows.Forms.CheckBox();
            this.cbxTriggerSource = new System.Windows.Forms.ComboBox();
            this.lblTriggerSource = new System.Windows.Forms.Label();
            this.cbxRefireWithinPeriod = new System.Windows.Forms.ComboBox();
            this.lblRefireWithinPeriod = new System.Windows.Forms.Label();
            this.cbxRefireOption2 = new System.Windows.Forms.ComboBox();
            this.lblScheduleFrom = new System.Windows.Forms.Label();
            this.lblRefirePeriod = new System.Windows.Forms.Label();
            this.cbxScheduleFrom = new System.Windows.Forms.ComboBox();
            this.cbxRefireOption1 = new System.Windows.Forms.ComboBox();
            this.lblRefireOption1 = new System.Windows.Forms.Label();
            this.expRefirePeriod = new Triggernometry.CustomControls.ExpressionTextBox();
            this.tabDebugging = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxLoggingLevel = new System.Windows.Forms.ComboBox();
            this.lblLoggingLevel = new System.Windows.Forms.Label();
            this.tabDescription = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            this.chkReadmeTrigger = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblReadOnly = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActions)).BeginInit();
            this.ctxAction.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.tabTriggerActions.SuspendLayout();
            this.tabTriggerCondition.SuspendLayout();
            this.tabScheduling.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.tabDebugging.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tabDescription.SuspendLayout();
            this.tableLayoutPanel23.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvActions
            // 
            this.dgvActions.AllowUserToAddRows = false;
            this.dgvActions.AllowUserToDeleteRows = false;
            this.dgvActions.AllowUserToResizeColumns = false;
            this.dgvActions.AllowUserToResizeRows = false;
            this.dgvActions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.colDescription});
            this.dgvActions.ContextMenuStrip = this.ctxAction;
            this.dgvActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvActions.Location = new System.Drawing.Point(3, 28);
            this.dgvActions.Name = "dgvActions";
            this.dgvActions.RowHeadersVisible = false;
            this.dgvActions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActions.ShowCellErrors = false;
            this.dgvActions.ShowEditingIcon = false;
            this.dgvActions.ShowRowErrors = false;
            this.dgvActions.Size = new System.Drawing.Size(650, 293);
            this.dgvActions.TabIndex = 0;
            this.dgvActions.VirtualMode = true;
            this.dgvActions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActions_CellClick);
            this.dgvActions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActions_CellDoubleClick);
            this.dgvActions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvActions_CellFormatting);
            this.dgvActions.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvActions_CellValueNeeded);
            this.dgvActions.SelectionChanged += new System.EventHandler(this.dgvActions_SelectionChanged);
            this.dgvActions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvActions_KeyDown);
            this.dgvActions.Leave += new System.EventHandler(this.dgvActions_Leave);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = " ";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 30;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ctxAction
            // 
            this.ctxAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxAddAction,
            this.ctxEditAction,
            this.toolStripSeparator3,
            this.ctxCopyAction,
            this.ctxPasteAction,
            this.toolStripSeparator10,
            this.ctxMoveUp,
            this.ctxMoveDown,
            this.toolStripSeparator4,
            this.ctxRemoveAction});
            this.ctxAction.Name = "contextMenuStrip1";
            this.ctxAction.Size = new System.Drawing.Size(154, 176);
            this.ctxAction.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ctxAddAction
            // 
            this.ctxAddAction.Image = ((System.Drawing.Image)(resources.GetObject("ctxAddAction.Image")));
            this.ctxAddAction.Name = "ctxAddAction";
            this.ctxAddAction.Size = new System.Drawing.Size(153, 22);
            this.ctxAddAction.Text = "Add action";
            this.ctxAddAction.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // ctxEditAction
            // 
            this.ctxEditAction.Image = ((System.Drawing.Image)(resources.GetObject("ctxEditAction.Image")));
            this.ctxEditAction.Name = "ctxEditAction";
            this.ctxEditAction.Size = new System.Drawing.Size(153, 22);
            this.ctxEditAction.Text = "Edit action";
            this.ctxEditAction.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(150, 6);
            // 
            // ctxCopyAction
            // 
            this.ctxCopyAction.Image = ((System.Drawing.Image)(resources.GetObject("ctxCopyAction.Image")));
            this.ctxCopyAction.Name = "ctxCopyAction";
            this.ctxCopyAction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.ctxCopyAction.Size = new System.Drawing.Size(153, 22);
            this.ctxCopyAction.Text = "Copy";
            this.ctxCopyAction.Click += new System.EventHandler(this.copyActionToolStripMenuItem_Click);
            // 
            // ctxPasteAction
            // 
            this.ctxPasteAction.Image = ((System.Drawing.Image)(resources.GetObject("ctxPasteAction.Image")));
            this.ctxPasteAction.Name = "ctxPasteAction";
            this.ctxPasteAction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.ctxPasteAction.Size = new System.Drawing.Size(153, 22);
            this.ctxPasteAction.Text = "Paste";
            this.ctxPasteAction.Click += new System.EventHandler(this.pasteActionToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(150, 6);
            // 
            // ctxMoveUp
            // 
            this.ctxMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("ctxMoveUp.Image")));
            this.ctxMoveUp.Name = "ctxMoveUp";
            this.ctxMoveUp.Size = new System.Drawing.Size(153, 22);
            this.ctxMoveUp.Text = "Move up";
            this.ctxMoveUp.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // ctxMoveDown
            // 
            this.ctxMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("ctxMoveDown.Image")));
            this.ctxMoveDown.Name = "ctxMoveDown";
            this.ctxMoveDown.Size = new System.Drawing.Size(153, 22);
            this.ctxMoveDown.Text = "Move down";
            this.ctxMoveDown.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(150, 6);
            // 
            // ctxRemoveAction
            // 
            this.ctxRemoveAction.Image = ((System.Drawing.Image)(resources.GetObject("ctxRemoveAction.Image")));
            this.ctxRemoveAction.Name = "ctxRemoveAction";
            this.ctxRemoveAction.Size = new System.Drawing.Size(153, 22);
            this.ctxRemoveAction.Text = "Remove action";
            this.ctxRemoveAction.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddAction,
            this.btnEditAction,
            this.toolStripSeparator2,
            this.btnActionUp,
            this.btnActionDown,
            this.toolStripSeparator1,
            this.btnRemoveAction});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(650, 25);
            this.toolStrip2.TabIndex = 1;
            // 
            // btnAddAction
            // 
            this.btnAddAction.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAction.Image")));
            this.btnAddAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.Size = new System.Drawing.Size(85, 22);
            this.btnAddAction.Text = "Add action";
            this.btnAddAction.Click += new System.EventHandler(this.btnAddAction_Click);
            // 
            // btnEditAction
            // 
            this.btnEditAction.Enabled = false;
            this.btnEditAction.Image = ((System.Drawing.Image)(resources.GetObject("btnEditAction.Image")));
            this.btnEditAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditAction.Name = "btnEditAction";
            this.btnEditAction.Size = new System.Drawing.Size(83, 22);
            this.btnEditAction.Text = "Edit action";
            this.btnEditAction.Click += new System.EventHandler(this.btnEditAction_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnActionUp
            // 
            this.btnActionUp.Enabled = false;
            this.btnActionUp.Image = ((System.Drawing.Image)(resources.GetObject("btnActionUp.Image")));
            this.btnActionUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActionUp.Name = "btnActionUp";
            this.btnActionUp.Size = new System.Drawing.Size(74, 22);
            this.btnActionUp.Text = "Move up";
            this.btnActionUp.Click += new System.EventHandler(this.btnActionUp_Click);
            // 
            // btnActionDown
            // 
            this.btnActionDown.Enabled = false;
            this.btnActionDown.Image = ((System.Drawing.Image)(resources.GetObject("btnActionDown.Image")));
            this.btnActionDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActionDown.Name = "btnActionDown";
            this.btnActionDown.Size = new System.Drawing.Size(90, 22);
            this.btnActionDown.Text = "Move down";
            this.btnActionDown.Click += new System.EventHandler(this.btnActionDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRemoveAction
            // 
            this.btnRemoveAction.Enabled = false;
            this.btnRemoveAction.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveAction.Image")));
            this.btnRemoveAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveAction.Name = "btnRemoveAction";
            this.btnRemoveAction.Size = new System.Drawing.Size(106, 22);
            this.btnRemoveAction.Text = "Remove action";
            this.btnRemoveAction.Click += new System.EventHandler(this.btnRemoveAction_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 10);
            this.panel1.TabIndex = 9;
            // 
            // grpGeneral
            // 
            this.grpGeneral.AutoSize = true;
            this.grpGeneral.Controls.Add(this.tableLayoutPanel1);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGeneral.Location = new System.Drawing.Point(10, 10);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(10);
            this.grpGeneral.Size = new System.Drawing.Size(664, 85);
            this.grpGeneral.TabIndex = 8;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = " General settings ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblRegexp, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtRegexp, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(644, 52);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblRegexp
            // 
            this.lblRegexp.AutoEllipsis = true;
            this.lblRegexp.AutoSize = true;
            this.lblRegexp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRegexp.Location = new System.Drawing.Point(3, 26);
            this.lblRegexp.Name = "lblRegexp";
            this.lblRegexp.Size = new System.Drawing.Size(97, 26);
            this.lblRegexp.TabIndex = 2;
            this.lblRegexp.Text = "Regular expression";
            this.lblRegexp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(97, 26);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Trigger name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(106, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(535, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtRegexp
            // 
            this.txtRegexp.AutoSize = true;
            this.txtRegexp.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRegexp.Expression = "";
            this.txtRegexp.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
            this.txtRegexp.Location = new System.Drawing.Point(106, 29);
            this.txtRegexp.Name = "txtRegexp";
            this.txtRegexp.ReadOnly = false;
            this.txtRegexp.Size = new System.Drawing.Size(535, 20);
            this.txtRegexp.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 506);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(664, 10);
            this.panel3.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnOk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 516);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(664, 35);
            this.panel4.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(514, 0);
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
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tabTriggerActions);
            this.tbcMain.Controls.Add(this.tabTriggerCondition);
            this.tbcMain.Controls.Add(this.tabScheduling);
            this.tbcMain.Controls.Add(this.tabDebugging);
            this.tbcMain.Controls.Add(this.tabDescription);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(10, 156);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(664, 350);
            this.tbcMain.TabIndex = 13;
            // 
            // tabTriggerActions
            // 
            this.tabTriggerActions.Controls.Add(this.dgvActions);
            this.tabTriggerActions.Controls.Add(this.toolStrip2);
            this.tabTriggerActions.Location = new System.Drawing.Point(4, 22);
            this.tabTriggerActions.Name = "tabTriggerActions";
            this.tabTriggerActions.Padding = new System.Windows.Forms.Padding(3);
            this.tabTriggerActions.Size = new System.Drawing.Size(656, 324);
            this.tabTriggerActions.TabIndex = 0;
            this.tabTriggerActions.Text = "Trigger actions";
            this.tabTriggerActions.UseVisualStyleBackColor = true;
            // 
            // tabTriggerCondition
            // 
            this.tabTriggerCondition.Controls.Add(this.cndCondition);
            this.tabTriggerCondition.Location = new System.Drawing.Point(4, 22);
            this.tabTriggerCondition.Name = "tabTriggerCondition";
            this.tabTriggerCondition.Padding = new System.Windows.Forms.Padding(3);
            this.tabTriggerCondition.Size = new System.Drawing.Size(656, 324);
            this.tabTriggerCondition.TabIndex = 5;
            this.tabTriggerCondition.Text = "Trigger condition";
            this.tabTriggerCondition.UseVisualStyleBackColor = true;
            // 
            // cndCondition
            // 
            this.cndCondition.ConditionToEdit = null;
            this.cndCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cndCondition.Location = new System.Drawing.Point(3, 3);
            this.cndCondition.Name = "cndCondition";
            this.cndCondition.Size = new System.Drawing.Size(650, 318);
            this.cndCondition.TabIndex = 4;
            // 
            // tabScheduling
            // 
            this.tabScheduling.Controls.Add(this.tableLayoutPanel15);
            this.tabScheduling.Location = new System.Drawing.Point(4, 22);
            this.tabScheduling.Name = "tabScheduling";
            this.tabScheduling.Padding = new System.Windows.Forms.Padding(7);
            this.tabScheduling.Size = new System.Drawing.Size(656, 324);
            this.tabScheduling.TabIndex = 2;
            this.tabScheduling.Text = "Scheduling";
            this.tabScheduling.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.AutoSize = true;
            this.tableLayoutPanel15.ColumnCount = 3;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel15.Controls.Add(this.expMutexName, 1, 6);
            this.tableLayoutPanel15.Controls.Add(this.lblMutexCapture, 0, 6);
            this.tableLayoutPanel15.Controls.Add(this.cbxSequential, 0, 8);
            this.tableLayoutPanel15.Controls.Add(this.cbxEditAutofire, 0, 7);
            this.tableLayoutPanel15.Controls.Add(this.cbxTriggerSource, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.lblTriggerSource, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.cbxRefireWithinPeriod, 1, 4);
            this.tableLayoutPanel15.Controls.Add(this.lblRefireWithinPeriod, 0, 4);
            this.tableLayoutPanel15.Controls.Add(this.cbxRefireOption2, 1, 2);
            this.tableLayoutPanel15.Controls.Add(this.lblScheduleFrom, 0, 3);
            this.tableLayoutPanel15.Controls.Add(this.lblRefirePeriod, 0, 5);
            this.tableLayoutPanel15.Controls.Add(this.cbxScheduleFrom, 1, 3);
            this.tableLayoutPanel15.Controls.Add(this.cbxRefireOption1, 1, 1);
            this.tableLayoutPanel15.Controls.Add(this.lblRefireOption1, 0, 1);
            this.tableLayoutPanel15.Controls.Add(this.expRefirePeriod, 1, 5);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 9;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.Size = new System.Drawing.Size(642, 233);
            this.tableLayoutPanel15.TabIndex = 6;
            // 
            // expMutexName
            // 
            this.expMutexName.AutoSize = true;
            this.tableLayoutPanel15.SetColumnSpan(this.expMutexName, 2);
            this.expMutexName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expMutexName.Expression = "";
            this.expMutexName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expMutexName.Location = new System.Drawing.Point(282, 164);
            this.expMutexName.Name = "expMutexName";
            this.expMutexName.ReadOnly = false;
            this.expMutexName.Size = new System.Drawing.Size(357, 20);
            this.expMutexName.TabIndex = 18;
            // 
            // lblMutexCapture
            // 
            this.lblMutexCapture.AutoSize = true;
            this.lblMutexCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMutexCapture.Location = new System.Drawing.Point(3, 161);
            this.lblMutexCapture.Name = "lblMutexCapture";
            this.lblMutexCapture.Size = new System.Drawing.Size(273, 26);
            this.lblMutexCapture.TabIndex = 17;
            this.lblMutexCapture.Text = "Mutex to capture on fire";
            this.lblMutexCapture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxSequential
            // 
            this.cbxSequential.AutoSize = true;
            this.cbxSequential.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel15.SetColumnSpan(this.cbxSequential, 3);
            this.cbxSequential.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxSequential.Location = new System.Drawing.Point(3, 213);
            this.cbxSequential.Name = "cbxSequential";
            this.cbxSequential.Size = new System.Drawing.Size(636, 17);
            this.cbxSequential.TabIndex = 16;
            this.cbxSequential.Text = "Sequential execution";
            this.cbxSequential.UseVisualStyleBackColor = true;
            // 
            // cbxEditAutofire
            // 
            this.cbxEditAutofire.AutoSize = true;
            this.cbxEditAutofire.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel15.SetColumnSpan(this.cbxEditAutofire, 3);
            this.cbxEditAutofire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxEditAutofire.Location = new System.Drawing.Point(3, 190);
            this.cbxEditAutofire.Name = "cbxEditAutofire";
            this.cbxEditAutofire.Size = new System.Drawing.Size(636, 17);
            this.cbxEditAutofire.TabIndex = 15;
            this.cbxEditAutofire.Text = "Autofire trigger after it has been edited";
            this.cbxEditAutofire.UseVisualStyleBackColor = true;
            // 
            // cbxTriggerSource
            // 
            this.tableLayoutPanel15.SetColumnSpan(this.cbxTriggerSource, 2);
            this.cbxTriggerSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxTriggerSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTriggerSource.FormattingEnabled = true;
            this.cbxTriggerSource.Items.AddRange(new object[] {
            "Normal log lines",
            "FFXIV network events",
            "None"});
            this.cbxTriggerSource.Location = new System.Drawing.Point(282, 3);
            this.cbxTriggerSource.Name = "cbxTriggerSource";
            this.cbxTriggerSource.Size = new System.Drawing.Size(357, 21);
            this.cbxTriggerSource.TabIndex = 14;
            // 
            // lblTriggerSource
            // 
            this.lblTriggerSource.AutoSize = true;
            this.lblTriggerSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTriggerSource.Location = new System.Drawing.Point(3, 0);
            this.lblTriggerSource.Name = "lblTriggerSource";
            this.lblTriggerSource.Size = new System.Drawing.Size(273, 27);
            this.lblTriggerSource.TabIndex = 13;
            this.lblTriggerSource.Text = "Trigger event source";
            this.lblTriggerSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxRefireWithinPeriod
            // 
            this.tableLayoutPanel15.SetColumnSpan(this.cbxRefireWithinPeriod, 2);
            this.cbxRefireWithinPeriod.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxRefireWithinPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRefireWithinPeriod.FormattingEnabled = true;
            this.cbxRefireWithinPeriod.Items.AddRange(new object[] {
            "Allow the trigger to fire again",
            "Do not allow the trigger to fire again"});
            this.cbxRefireWithinPeriod.Location = new System.Drawing.Point(282, 111);
            this.cbxRefireWithinPeriod.Name = "cbxRefireWithinPeriod";
            this.cbxRefireWithinPeriod.Size = new System.Drawing.Size(357, 21);
            this.cbxRefireWithinPeriod.TabIndex = 12;
            // 
            // lblRefireWithinPeriod
            // 
            this.lblRefireWithinPeriod.AutoSize = true;
            this.lblRefireWithinPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRefireWithinPeriod.Location = new System.Drawing.Point(3, 108);
            this.lblRefireWithinPeriod.Name = "lblRefireWithinPeriod";
            this.lblRefireWithinPeriod.Size = new System.Drawing.Size(273, 27);
            this.lblRefireWithinPeriod.TabIndex = 11;
            this.lblRefireWithinPeriod.Text = "If the trigger fires within the refire period";
            this.lblRefireWithinPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxRefireOption2
            // 
            this.tableLayoutPanel15.SetColumnSpan(this.cbxRefireOption2, 2);
            this.cbxRefireOption2.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxRefireOption2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRefireOption2.FormattingEnabled = true;
            this.cbxRefireOption2.Items.AddRange(new object[] {
            "...and allow the trigger to fire again",
            "...and do not allow the trigger to fire again"});
            this.cbxRefireOption2.Location = new System.Drawing.Point(282, 57);
            this.cbxRefireOption2.Name = "cbxRefireOption2";
            this.cbxRefireOption2.Size = new System.Drawing.Size(357, 21);
            this.cbxRefireOption2.TabIndex = 10;
            // 
            // lblScheduleFrom
            // 
            this.lblScheduleFrom.AutoSize = true;
            this.lblScheduleFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScheduleFrom.Location = new System.Drawing.Point(3, 81);
            this.lblScheduleFrom.Name = "lblScheduleFrom";
            this.lblScheduleFrom.Size = new System.Drawing.Size(273, 27);
            this.lblScheduleFrom.TabIndex = 9;
            this.lblScheduleFrom.Text = "Schedule trigger actions starting from";
            this.lblScheduleFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRefirePeriod
            // 
            this.lblRefirePeriod.AutoSize = true;
            this.lblRefirePeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRefirePeriod.Location = new System.Drawing.Point(3, 135);
            this.lblRefirePeriod.Name = "lblRefirePeriod";
            this.lblRefirePeriod.Size = new System.Drawing.Size(273, 26);
            this.lblRefirePeriod.TabIndex = 6;
            this.lblRefirePeriod.Text = "Trigger refire period";
            this.lblRefirePeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxScheduleFrom
            // 
            this.tableLayoutPanel15.SetColumnSpan(this.cbxScheduleFrom, 2);
            this.cbxScheduleFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxScheduleFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxScheduleFrom.FormattingEnabled = true;
            this.cbxScheduleFrom.Items.AddRange(new object[] {
            "The firing time",
            "The last queued action from this trigger",
            "The end of the trigger refire period"});
            this.cbxScheduleFrom.Location = new System.Drawing.Point(282, 84);
            this.cbxScheduleFrom.Name = "cbxScheduleFrom";
            this.cbxScheduleFrom.Size = new System.Drawing.Size(357, 21);
            this.cbxScheduleFrom.TabIndex = 4;
            // 
            // cbxRefireOption1
            // 
            this.tableLayoutPanel15.SetColumnSpan(this.cbxRefireOption1, 2);
            this.cbxRefireOption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxRefireOption1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRefireOption1.FormattingEnabled = true;
            this.cbxRefireOption1.Items.AddRange(new object[] {
            "Interrupt all actions previously queued from this trigger...",
            "Keep all actions previously queued from this trigger..."});
            this.cbxRefireOption1.Location = new System.Drawing.Point(282, 30);
            this.cbxRefireOption1.Name = "cbxRefireOption1";
            this.cbxRefireOption1.Size = new System.Drawing.Size(357, 21);
            this.cbxRefireOption1.TabIndex = 3;
            // 
            // lblRefireOption1
            // 
            this.lblRefireOption1.AutoSize = true;
            this.lblRefireOption1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRefireOption1.Location = new System.Drawing.Point(3, 27);
            this.lblRefireOption1.Name = "lblRefireOption1";
            this.lblRefireOption1.Size = new System.Drawing.Size(273, 27);
            this.lblRefireOption1.TabIndex = 2;
            this.lblRefireOption1.Text = "If the trigger fires while any of its actions are still in queue";
            this.lblRefireOption1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expRefirePeriod
            // 
            this.expRefirePeriod.AutoSize = true;
            this.tableLayoutPanel15.SetColumnSpan(this.expRefirePeriod, 2);
            this.expRefirePeriod.Dock = System.Windows.Forms.DockStyle.Top;
            this.expRefirePeriod.Expression = "";
            this.expRefirePeriod.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expRefirePeriod.Location = new System.Drawing.Point(282, 138);
            this.expRefirePeriod.Name = "expRefirePeriod";
            this.expRefirePeriod.ReadOnly = false;
            this.expRefirePeriod.Size = new System.Drawing.Size(357, 20);
            this.expRefirePeriod.TabIndex = 7;
            // 
            // tabDebugging
            // 
            this.tabDebugging.Controls.Add(this.tableLayoutPanel16);
            this.tabDebugging.Location = new System.Drawing.Point(4, 22);
            this.tabDebugging.Name = "tabDebugging";
            this.tabDebugging.Padding = new System.Windows.Forms.Padding(7);
            this.tabDebugging.Size = new System.Drawing.Size(656, 324);
            this.tabDebugging.TabIndex = 3;
            this.tabDebugging.Text = "Debugging";
            this.tabDebugging.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.AutoSize = true;
            this.tableLayoutPanel16.ColumnCount = 2;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Controls.Add(this.cbxLoggingLevel, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.lblLoggingLevel, 0, 0);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 1;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(642, 27);
            this.tableLayoutPanel16.TabIndex = 3;
            // 
            // cbxLoggingLevel
            // 
            this.cbxLoggingLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxLoggingLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLoggingLevel.FormattingEnabled = true;
            this.cbxLoggingLevel.Items.AddRange(new object[] {
            "Nothing",
            "Errors only",
            "Errors and warnings",
            "All informational messages",
            "Verbose debug",
            "(inherit from configuration)"});
            this.cbxLoggingLevel.Location = new System.Drawing.Point(115, 3);
            this.cbxLoggingLevel.Name = "cbxLoggingLevel";
            this.cbxLoggingLevel.Size = new System.Drawing.Size(524, 21);
            this.cbxLoggingLevel.TabIndex = 3;
            // 
            // lblLoggingLevel
            // 
            this.lblLoggingLevel.AutoSize = true;
            this.lblLoggingLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoggingLevel.Location = new System.Drawing.Point(3, 0);
            this.lblLoggingLevel.Name = "lblLoggingLevel";
            this.lblLoggingLevel.Size = new System.Drawing.Size(106, 27);
            this.lblLoggingLevel.TabIndex = 2;
            this.lblLoggingLevel.Text = "Logging filtering level";
            this.lblLoggingLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabDescription
            // 
            this.tabDescription.Controls.Add(this.tableLayoutPanel23);
            this.tabDescription.Location = new System.Drawing.Point(4, 22);
            this.tabDescription.Name = "tabDescription";
            this.tabDescription.Padding = new System.Windows.Forms.Padding(7);
            this.tabDescription.Size = new System.Drawing.Size(656, 324);
            this.tabDescription.TabIndex = 4;
            this.tabDescription.Text = "Description";
            this.tabDescription.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel23
            // 
            this.tableLayoutPanel23.AutoSize = true;
            this.tableLayoutPanel23.ColumnCount = 1;
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel23.Controls.Add(this.chkReadmeTrigger, 0, 1);
            this.tableLayoutPanel23.Controls.Add(this.txtDescription, 0, 0);
            this.tableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel23.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanel23.Name = "tableLayoutPanel23";
            this.tableLayoutPanel23.RowCount = 2;
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel23.Size = new System.Drawing.Size(642, 310);
            this.tableLayoutPanel23.TabIndex = 3;
            // 
            // chkReadmeTrigger
            // 
            this.chkReadmeTrigger.AutoSize = true;
            this.chkReadmeTrigger.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkReadmeTrigger.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkReadmeTrigger.Location = new System.Drawing.Point(3, 288);
            this.chkReadmeTrigger.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkReadmeTrigger.Name = "chkReadmeTrigger";
            this.chkReadmeTrigger.Size = new System.Drawing.Size(637, 17);
            this.chkReadmeTrigger.TabIndex = 8;
            this.chkReadmeTrigger.Text = "Specify trigger as readme for repositories";
            this.chkReadmeTrigger.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.AcceptsReturn = true;
            this.txtDescription.AcceptsTab = true;
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(3, 3);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(636, 277);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.WordWrap = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.lblReadOnly);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(10, 105);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel5.Size = new System.Drawing.Size(664, 51);
            this.panel5.TabIndex = 14;
            this.panel5.Visible = false;
            // 
            // lblReadOnly
            // 
            this.lblReadOnly.AutoEllipsis = true;
            this.lblReadOnly.BackColor = System.Drawing.SystemColors.Info;
            this.lblReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReadOnly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReadOnly.Location = new System.Drawing.Point(0, 0);
            this.lblReadOnly.Name = "lblReadOnly";
            this.lblReadOnly.Size = new System.Drawing.Size(664, 41);
            this.lblReadOnly.TabIndex = 0;
            this.lblReadOnly.Text = "You are in read-only mode, as the configuration of remote triggers can\'t be edite" +
    "d locally. If you wish to edit the trigger, you will need to make a local copy o" +
    "f it.";
            this.lblReadOnly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TriggerForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "TriggerForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.TriggerForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActions)).EndInit();
            this.ctxAction.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tbcMain.ResumeLayout(false);
            this.tabTriggerActions.ResumeLayout(false);
            this.tabTriggerActions.PerformLayout();
            this.tabTriggerCondition.ResumeLayout(false);
            this.tabScheduling.ResumeLayout(false);
            this.tabScheduling.PerformLayout();
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.tabDebugging.ResumeLayout(false);
            this.tabDebugging.PerformLayout();
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.tabDescription.ResumeLayout(false);
            this.tabDescription.PerformLayout();
            this.tableLayoutPanel23.ResumeLayout(false);
            this.tableLayoutPanel23.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvActions;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAddAction;
        private System.Windows.Forms.ToolStripButton btnRemoveAction;
        private System.Windows.Forms.ToolStripButton btnEditAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnActionUp;
        private System.Windows.Forms.ToolStripButton btnActionDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblRegexp;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip ctxAction;
        private System.Windows.Forms.ToolStripMenuItem ctxAddAction;
        private System.Windows.Forms.ToolStripMenuItem ctxEditAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ctxMoveUp;
        private System.Windows.Forms.ToolStripMenuItem ctxMoveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ctxRemoveAction;
        private CustomControls.ExpressionTextBox txtRegexp;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabTriggerActions;
        private System.Windows.Forms.ToolStripMenuItem ctxCopyAction;
        private System.Windows.Forms.ToolStripMenuItem ctxPasteAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.TabPage tabScheduling;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Label lblRefirePeriod;
        private System.Windows.Forms.ComboBox cbxScheduleFrom;
        private System.Windows.Forms.ComboBox cbxRefireOption1;
        private System.Windows.Forms.Label lblRefireOption1;
        private CustomControls.ExpressionTextBox expRefirePeriod;
        private System.Windows.Forms.Label lblScheduleFrom;
        private System.Windows.Forms.ComboBox cbxRefireOption2;
        private System.Windows.Forms.ComboBox cbxRefireWithinPeriod;
        private System.Windows.Forms.Label lblRefireWithinPeriod;
        private System.Windows.Forms.TabPage tabDebugging;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.ComboBox cbxLoggingLevel;
        private System.Windows.Forms.Label lblLoggingLevel;
        private System.Windows.Forms.TabPage tabDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TabPage tabTriggerCondition;
        private CustomControls.ConditionViewer cndCondition;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.ComboBox cbxTriggerSource;
        private System.Windows.Forms.Label lblTriggerSource;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblReadOnly;
        private System.Windows.Forms.CheckBox cbxEditAutofire;
        private System.Windows.Forms.CheckBox cbxSequential;
        private CustomControls.ExpressionTextBox expMutexName;
        private System.Windows.Forms.Label lblMutexCapture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel23;
        private System.Windows.Forms.CheckBox chkReadmeTrigger;
    }
}