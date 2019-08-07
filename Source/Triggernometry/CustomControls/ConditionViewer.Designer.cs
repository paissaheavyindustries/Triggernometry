namespace Triggernometry.CustomControls
{
    partial class ConditionViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConditionViewer));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAddGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnProperties = new System.Windows.Forms.ToolStripButton();
            this.pnlEditorSingle = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.expRight = new Triggernometry.CustomControls.ExpressionTextBox();
            this.cbxExpRType = new System.Windows.Forms.ComboBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.lblLeftExpression = new System.Windows.Forms.Label();
            this.cbxExpLType = new System.Windows.Forms.ComboBox();
            this.expLeft = new Triggernometry.CustomControls.ExpressionTextBox();
            this.cbxOpType = new System.Windows.Forms.ComboBox();
            this.lblRightExpression = new System.Windows.Forms.Label();
            this.pnlEditorGroup = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxGroupingType = new System.Windows.Forms.ComboBox();
            this.lblGroupingType = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvNodes = new Triggernometry.CustomControls.TreeViewEx();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxAddGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxAddCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxPasteOver = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.capProperties = new Triggernometry.CustomControls.PrettyCaption();
            this.toolStrip1.SuspendLayout();
            this.pnlEditorSingle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlEditorGroup.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "function");
            this.imageList1.Images.SetKeyName(1, "group_and");
            this.imageList1.Images.SetKeyName(2, "group_or");
            this.imageList1.Images.SetKeyName(3, "group_not");
            this.imageList1.Images.SetKeyName(4, "group_xor");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.toolStripSeparator1,
            this.btnDelete,
            this.btnProperties});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(839, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddGroup,
            this.btnAddCondition});
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 22);
            this.btnAdd.Text = "Add";
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGroup.Image")));
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(162, 22);
            this.btnAddGroup.Text = "Condition group";
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnAddCondition
            // 
            this.btnAddCondition.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCondition.Image")));
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(162, 22);
            this.btnAddCondition.Text = "Condition";
            this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 22);
            this.btnDelete.Text = "Remove";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnProperties
            // 
            this.btnProperties.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnProperties.Checked = true;
            this.btnProperties.CheckOnClick = true;
            this.btnProperties.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnProperties.Image = ((System.Drawing.Image)(resources.GetObject("btnProperties.Image")));
            this.btnProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(112, 22);
            this.btnProperties.Text = "Show properties";
            this.btnProperties.CheckedChanged += new System.EventHandler(this.btnProperties_CheckedChanged);
            // 
            // pnlEditorSingle
            // 
            this.pnlEditorSingle.AutoSize = true;
            this.pnlEditorSingle.Controls.Add(this.tableLayoutPanel1);
            this.pnlEditorSingle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEditorSingle.Location = new System.Drawing.Point(0, 56);
            this.pnlEditorSingle.Name = "pnlEditorSingle";
            this.pnlEditorSingle.Size = new System.Drawing.Size(200, 220);
            this.pnlEditorSingle.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.expRight, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.cbxExpRType, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblOperator, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblLeftExpression, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxExpLType, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.expLeft, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxOpType, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblRightExpression, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 220);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // expRight
            // 
            this.expRight.AutoSize = true;
            this.expRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.expRight.Expression = "";
            this.expRight.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expRight.Location = new System.Drawing.Point(3, 197);
            this.expRight.Name = "expRight";
            this.expRight.Size = new System.Drawing.Size(194, 20);
            this.expRight.TabIndex = 7;
            // 
            // cbxExpRType
            // 
            this.cbxExpRType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxExpRType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxExpRType.FormattingEnabled = true;
            this.cbxExpRType.Items.AddRange(new object[] {
            "String",
            "Numeric"});
            this.cbxExpRType.Location = new System.Drawing.Point(3, 170);
            this.cbxExpRType.Name = "cbxExpRType";
            this.cbxExpRType.Size = new System.Drawing.Size(194, 21);
            this.cbxExpRType.TabIndex = 6;
            this.cbxExpRType.SelectedIndexChanged += new System.EventHandler(this.cbxExpRType_SelectedIndexChanged);
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOperator.Location = new System.Drawing.Point(3, 82);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Padding = new System.Windows.Forms.Padding(0, 15, 0, 1);
            this.lblOperator.Size = new System.Drawing.Size(194, 29);
            this.lblOperator.TabIndex = 1;
            this.lblOperator.Text = "Operator";
            // 
            // lblLeftExpression
            // 
            this.lblLeftExpression.AutoSize = true;
            this.lblLeftExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLeftExpression.Location = new System.Drawing.Point(3, 0);
            this.lblLeftExpression.Name = "lblLeftExpression";
            this.lblLeftExpression.Padding = new System.Windows.Forms.Padding(0, 15, 0, 1);
            this.lblLeftExpression.Size = new System.Drawing.Size(194, 29);
            this.lblLeftExpression.TabIndex = 0;
            this.lblLeftExpression.Text = "Left expression";
            // 
            // cbxExpLType
            // 
            this.cbxExpLType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxExpLType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxExpLType.FormattingEnabled = true;
            this.cbxExpLType.Items.AddRange(new object[] {
            "String",
            "Numeric"});
            this.cbxExpLType.Location = new System.Drawing.Point(3, 32);
            this.cbxExpLType.Name = "cbxExpLType";
            this.cbxExpLType.Size = new System.Drawing.Size(194, 21);
            this.cbxExpLType.TabIndex = 3;
            this.cbxExpLType.SelectedIndexChanged += new System.EventHandler(this.cbxExpLType_SelectedIndexChanged);
            // 
            // expLeft
            // 
            this.expLeft.AutoSize = true;
            this.expLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLeft.Expression = "";
            this.expLeft.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expLeft.Location = new System.Drawing.Point(3, 59);
            this.expLeft.Name = "expLeft";
            this.expLeft.Size = new System.Drawing.Size(194, 20);
            this.expLeft.TabIndex = 4;
            // 
            // cbxOpType
            // 
            this.cbxOpType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxOpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOpType.FormattingEnabled = true;
            this.cbxOpType.Items.AddRange(new object[] {
            "Expressions must be numerically equal (X = Y)",
            "Expressions must not be numerically equal (X ≠ Y)",
            "Left side must be numerically greater than (X > Y)",
            "Left side must be numerically greater or equal to (X ≥ Y)",
            "Left side must be numerically less than (X < Y)",
            "Left side must be numerically less or equal to (X ≤ Y)",
            "Left side must pass case-sensitive string comparison with the right side",
            "Left side must pass case-insensitive string comparison with the right side",
            "Left side must not pass case-sensitive string comparison with the right side",
            "Left side must not pass case-insensitive string comparison with the right side",
            "Left side must match the regular expression on the right side",
            "Left side must not match the regular expression on the right side",
            "List variable specified on the left side must contain the value on the right side" +
                "",
            "List variable specified on the left side must not contain the value on the right " +
                "side"});
            this.cbxOpType.Location = new System.Drawing.Point(3, 114);
            this.cbxOpType.Name = "cbxOpType";
            this.cbxOpType.Size = new System.Drawing.Size(194, 21);
            this.cbxOpType.TabIndex = 5;
            this.cbxOpType.SelectedIndexChanged += new System.EventHandler(this.cbxOpType_SelectedIndexChanged);
            // 
            // lblRightExpression
            // 
            this.lblRightExpression.AutoSize = true;
            this.lblRightExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRightExpression.Location = new System.Drawing.Point(3, 138);
            this.lblRightExpression.Name = "lblRightExpression";
            this.lblRightExpression.Padding = new System.Windows.Forms.Padding(0, 15, 0, 1);
            this.lblRightExpression.Size = new System.Drawing.Size(194, 29);
            this.lblRightExpression.TabIndex = 2;
            this.lblRightExpression.Text = "Right expression";
            // 
            // pnlEditorGroup
            // 
            this.pnlEditorGroup.AutoSize = true;
            this.pnlEditorGroup.Controls.Add(this.tableLayoutPanel2);
            this.pnlEditorGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEditorGroup.Location = new System.Drawing.Point(0, 0);
            this.pnlEditorGroup.Name = "pnlEditorGroup";
            this.pnlEditorGroup.Size = new System.Drawing.Size(200, 56);
            this.pnlEditorGroup.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.cbxGroupingType, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblGroupingType, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 56);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // cbxGroupingType
            // 
            this.cbxGroupingType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxGroupingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGroupingType.FormattingEnabled = true;
            this.cbxGroupingType.Items.AddRange(new object[] {
            "All conditions must be true (AND)",
            "At least one condition must be true (OR)",
            "Only one condition must be true (XOR)",
            "None of the conditions may be true (NOT)"});
            this.cbxGroupingType.Location = new System.Drawing.Point(3, 32);
            this.cbxGroupingType.Name = "cbxGroupingType";
            this.cbxGroupingType.Size = new System.Drawing.Size(194, 21);
            this.cbxGroupingType.TabIndex = 4;
            this.cbxGroupingType.SelectedIndexChanged += new System.EventHandler(this.cbxGroupingType_SelectedIndexChanged);
            // 
            // lblGroupingType
            // 
            this.lblGroupingType.AutoSize = true;
            this.lblGroupingType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGroupingType.Location = new System.Drawing.Point(3, 0);
            this.lblGroupingType.Name = "lblGroupingType";
            this.lblGroupingType.Padding = new System.Windows.Forms.Padding(0, 15, 0, 1);
            this.lblGroupingType.Size = new System.Drawing.Size(194, 29);
            this.lblGroupingType.TabIndex = 1;
            this.lblGroupingType.Text = "Grouping type";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvNodes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.capProperties);
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(839, 576);
            this.splitContainer1.SplitterDistance = 635;
            this.splitContainer1.TabIndex = 3;
            // 
            // trvNodes
            // 
            this.trvNodes.AllowDrop = true;
            this.trvNodes.CheckBoxes = true;
            this.trvNodes.ContextMenuStrip = this.contextMenuStrip1;
            this.trvNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvNodes.HideSelection = false;
            this.trvNodes.ImageIndex = 0;
            this.trvNodes.ImageList = this.imageList1;
            this.trvNodes.Location = new System.Drawing.Point(0, 0);
            this.trvNodes.Name = "trvNodes";
            this.trvNodes.SelectedImageIndex = 0;
            this.trvNodes.Size = new System.Drawing.Size(635, 576);
            this.trvNodes.TabIndex = 0;
            this.trvNodes.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvNodes_AfterCheck);
            this.trvNodes.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trvNodes_ItemDrag);
            this.trvNodes.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvNodes_BeforeSelect);
            this.trvNodes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvNodes_AfterSelect);
            this.trvNodes.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvNodes_NodeMouseClick);
            this.trvNodes.DragDrop += new System.Windows.Forms.DragEventHandler(this.trvNodes_DragDrop);
            this.trvNodes.DragEnter += new System.Windows.Forms.DragEventHandler(this.trvNodes_DragEnter);
            this.trvNodes.DragOver += new System.Windows.Forms.DragEventHandler(this.trvNodes_DragOver);
            this.trvNodes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trvNodes_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxAdd,
            this.toolStripSeparator7,
            this.ctxCopy,
            this.ctxPaste,
            this.ctxPasteOver,
            this.toolStripSeparator2,
            this.ctxRemove});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(202, 126);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ctxAdd
            // 
            this.ctxAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxAddGroup,
            this.ctxAddCondition});
            this.ctxAdd.Image = ((System.Drawing.Image)(resources.GetObject("ctxAdd.Image")));
            this.ctxAdd.Name = "ctxAdd";
            this.ctxAdd.Size = new System.Drawing.Size(201, 22);
            this.ctxAdd.Text = "Add";
            // 
            // ctxAddGroup
            // 
            this.ctxAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("ctxAddGroup.Image")));
            this.ctxAddGroup.Name = "ctxAddGroup";
            this.ctxAddGroup.Size = new System.Drawing.Size(162, 22);
            this.ctxAddGroup.Text = "Condition group";
            this.ctxAddGroup.Click += new System.EventHandler(this.ctxBtnConditionGroup_Click);
            // 
            // ctxAddCondition
            // 
            this.ctxAddCondition.Image = ((System.Drawing.Image)(resources.GetObject("ctxAddCondition.Image")));
            this.ctxAddCondition.Name = "ctxAddCondition";
            this.ctxAddCondition.Size = new System.Drawing.Size(162, 22);
            this.ctxAddCondition.Text = "Condition";
            this.ctxAddCondition.Click += new System.EventHandler(this.ctxBtnCondition_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(198, 6);
            // 
            // ctxCopy
            // 
            this.ctxCopy.Image = ((System.Drawing.Image)(resources.GetObject("ctxCopy.Image")));
            this.ctxCopy.Name = "ctxCopy";
            this.ctxCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.ctxCopy.Size = new System.Drawing.Size(201, 22);
            this.ctxCopy.Text = "Copy";
            this.ctxCopy.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // ctxPaste
            // 
            this.ctxPaste.Image = ((System.Drawing.Image)(resources.GetObject("ctxPaste.Image")));
            this.ctxPaste.Name = "ctxPaste";
            this.ctxPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.ctxPaste.Size = new System.Drawing.Size(201, 22);
            this.ctxPaste.Text = "Paste";
            this.ctxPaste.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // ctxPasteOver
            // 
            this.ctxPasteOver.Image = ((System.Drawing.Image)(resources.GetObject("ctxPasteOver.Image")));
            this.ctxPasteOver.Name = "ctxPasteOver";
            this.ctxPasteOver.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.V)));
            this.ctxPasteOver.Size = new System.Drawing.Size(201, 22);
            this.ctxPasteOver.Text = "Paste over";
            this.ctxPasteOver.Click += new System.EventHandler(this.pasteOverToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(198, 6);
            // 
            // ctxRemove
            // 
            this.ctxRemove.Image = ((System.Drawing.Image)(resources.GetObject("ctxRemove.Image")));
            this.ctxRemove.Name = "ctxRemove";
            this.ctxRemove.Size = new System.Drawing.Size(201, 22);
            this.ctxRemove.Text = "Remove";
            this.ctxRemove.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.pnlEditorSingle);
            this.panel3.Controls.Add(this.pnlEditorGroup);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 546);
            this.panel3.TabIndex = 5;
            // 
            // capProperties
            // 
            this.capProperties.Caption = "Properties";
            this.capProperties.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capProperties.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.capProperties.Location = new System.Drawing.Point(0, 0);
            this.capProperties.Name = "capProperties";
            this.capProperties.Size = new System.Drawing.Size(200, 30);
            this.capProperties.TabIndex = 4;
            // 
            // ConditionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ConditionViewer";
            this.Size = new System.Drawing.Size(839, 601);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlEditorSingle.ResumeLayout(false);
            this.pnlEditorSingle.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlEditorGroup.ResumeLayout(false);
            this.pnlEditorGroup.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeViewEx trvNodes;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton btnAdd;
        private System.Windows.Forms.ToolStripMenuItem btnAddCondition;
        private System.Windows.Forms.ToolStripMenuItem btnAddGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Panel pnlEditorSingle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblRightExpression;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label lblLeftExpression;
        private System.Windows.Forms.ComboBox cbxExpLType;
        private ExpressionTextBox expLeft;
        private System.Windows.Forms.ComboBox cbxOpType;
        private ExpressionTextBox expRight;
        private System.Windows.Forms.ComboBox cbxExpRType;
        private System.Windows.Forms.Panel pnlEditorGroup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cbxGroupingType;
        private System.Windows.Forms.Label lblGroupingType;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctxAdd;
        private System.Windows.Forms.ToolStripMenuItem ctxAddGroup;
        private System.Windows.Forms.ToolStripMenuItem ctxAddCondition;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem ctxCopy;
        private System.Windows.Forms.ToolStripMenuItem ctxPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ctxRemove;
        private System.Windows.Forms.Panel panel3;
        private PrettyCaption capProperties;
        private System.Windows.Forms.ToolStripMenuItem ctxPasteOver;
        private System.Windows.Forms.ToolStripButton btnProperties;
    }
}
