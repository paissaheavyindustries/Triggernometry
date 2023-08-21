
using System.Windows.Forms;

namespace Triggernometry.CustomControls
{
    partial class ActionViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionViewer));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAddAction = new System.Windows.Forms.ToolStripButton();
            this.btnEditAction = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActionUp = new System.Windows.Forms.ToolStripButton();
            this.btnActionDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRemoveAction = new System.Windows.Forms.ToolStripButton();
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
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActions)).BeginInit();
            this.ctxAction.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(814, 25);
            this.toolStrip2.TabIndex = 2;
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
            this.dgvActions.Location = new System.Drawing.Point(0, 25);
            this.dgvActions.Name = "dgvActions";
            this.dgvActions.RowHeadersVisible = false;
            this.dgvActions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActions.ShowCellErrors = false;
            this.dgvActions.ShowEditingIcon = false;
            this.dgvActions.ShowRowErrors = false;
            this.dgvActions.Size = new System.Drawing.Size(814, 394);
            this.dgvActions.TabIndex = 3;
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
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.Width = Screen.PrimaryScreen.Bounds.Width / 50;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.ctxAction.Size = new System.Drawing.Size(181, 198);
            this.ctxAction.Opening += new System.ComponentModel.CancelEventHandler(this.ctxAction_Opening);
            // 
            // ctxAddAction
            // 
            this.ctxAddAction.Image = ((System.Drawing.Image)(resources.GetObject("ctxAddAction.Image")));
            this.ctxAddAction.Name = "ctxAddAction";
            this.ctxAddAction.Size = new System.Drawing.Size(180, 22);
            this.ctxAddAction.Text = "Add action";
            this.ctxAddAction.Click += new System.EventHandler(this.ctxAddAction_Click);
            // 
            // ctxEditAction
            // 
            this.ctxEditAction.Image = ((System.Drawing.Image)(resources.GetObject("ctxEditAction.Image")));
            this.ctxEditAction.Name = "ctxEditAction";
            this.ctxEditAction.Size = new System.Drawing.Size(180, 22);
            this.ctxEditAction.Text = "Edit action";
            this.ctxEditAction.Click += new System.EventHandler(this.ctxEditAction_Click);
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
            this.ctxCopyAction.Size = new System.Drawing.Size(180, 22);
            this.ctxCopyAction.Text = "Copy";
            this.ctxCopyAction.Click += new System.EventHandler(this.ctxCopyAction_Click);
            // 
            // ctxPasteAction
            // 
            this.ctxPasteAction.Image = ((System.Drawing.Image)(resources.GetObject("ctxPasteAction.Image")));
            this.ctxPasteAction.Name = "ctxPasteAction";
            this.ctxPasteAction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.ctxPasteAction.Size = new System.Drawing.Size(180, 22);
            this.ctxPasteAction.Text = "Paste";
            this.ctxPasteAction.Click += new System.EventHandler(this.ctxPasteAction_Click);
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
            this.ctxMoveUp.Size = new System.Drawing.Size(180, 22);
            this.ctxMoveUp.Text = "Move up";
            this.ctxMoveUp.Click += new System.EventHandler(this.ctxMoveUp_Click);
            // 
            // ctxMoveDown
            // 
            this.ctxMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("ctxMoveDown.Image")));
            this.ctxMoveDown.Name = "ctxMoveDown";
            this.ctxMoveDown.Size = new System.Drawing.Size(180, 22);
            this.ctxMoveDown.Text = "Move down";
            this.ctxMoveDown.Click += new System.EventHandler(this.ctxMoveDown_Click);
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
            this.ctxRemoveAction.Size = new System.Drawing.Size(180, 22);
            this.ctxRemoveAction.Text = "Remove action";
            this.ctxRemoveAction.Click += new System.EventHandler(this.ctxRemoveAction_Click);
            // 
            // ActionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvActions);
            this.Controls.Add(this.toolStrip2);
            this.Name = "ActionViewer";
            this.Size = new System.Drawing.Size(814, 419);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActions)).EndInit();
            this.ctxAction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAddAction;
        private System.Windows.Forms.ToolStripButton btnEditAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnActionUp;
        private System.Windows.Forms.ToolStripButton btnActionDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRemoveAction;
        private System.Windows.Forms.DataGridView dgvActions;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.ContextMenuStrip ctxAction;
        private System.Windows.Forms.ToolStripMenuItem ctxAddAction;
        private System.Windows.Forms.ToolStripMenuItem ctxEditAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ctxCopyAction;
        private System.Windows.Forms.ToolStripMenuItem ctxPasteAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem ctxMoveUp;
        private System.Windows.Forms.ToolStripMenuItem ctxMoveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ctxRemoveAction;
    }
}
