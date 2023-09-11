using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using static Triggernometry.ConditionGroup;

namespace Triggernometry.CustomControls
{

    public partial class ConditionViewer : UserControl
    {

        private Dictionary<ConditionComponent, TreeNode> ReverseNodeLookup = new Dictionary<ConditionComponent, TreeNode>();
        private bool Changing { get; set; } = false;
        private Color disabledNodeColor;
        internal RealPlugin plug;

        private bool _PanelStateFromOption;
        private bool PanelStateFromOption
        {
            get
            {
                return _PanelStateFromOption;
            }
            set
            {
                _PanelStateFromOption = value;
                splitContainer1.Panel2Collapsed = (_PanelStateFromSelection == false || _PanelStateFromOption == false);
            }
        }

        private bool _PanelStateFromSelection;
        private bool PanelStateFromSelection
        {
            get
            {
                return _PanelStateFromSelection;
            }
            set
            {
                _PanelStateFromSelection = value;
                splitContainer1.Panel2Collapsed = (_PanelStateFromSelection == false || _PanelStateFromOption == false);
            }
        }

        private ConditionGroup _ConditionToEdit = null;
        public ConditionGroup ConditionToEdit
        {
            get
            {
                return _ConditionToEdit;
            }
            set
            {
                if (_ConditionToEdit != value)
                {
                    ClearReverseLookup();
                    trvNodes.Nodes.Clear();
                }
                _ConditionToEdit = value;
                if (_ConditionToEdit != null)
                {
                    UpdateEditorToCondition(_ConditionToEdit);
                }
            }
        }

        private void ClearReverseLookup()
        {
            ReverseNodeLookup.Clear();
            //System.Diagnostics.Debug.WriteLine("CV: Reverse look cleared");
        }

        private void RemoveReverseLookup(ConditionComponent cc)
        {
            if (ReverseNodeLookup.ContainsKey(cc) == true)
            {
                ReverseNodeLookup.Remove(cc);
                //System.Diagnostics.Debug.WriteLine("CV: ConditionComponent " + cc.Id + " unregistered");
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("CV: ConditionComponent " + cc.Id + " not registered");
            }
        }

        private void SetReverseLookup(ConditionComponent cc, TreeNode tn)
        {
            //System.Diagnostics.Debug.WriteLine("CV: ConditionComponent " + cc.Id + " registered");
            ReverseNodeLookup[cc] = tn;
        }

        private TreeNode GetReverseLookup(ConditionComponent cc)
        {
            if (ReverseNodeLookup.ContainsKey(cc) == true)
            {
                return ReverseNodeLookup[cc];
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("CV: ConditionComponent " + cc.Id + " not found");
            }
            return null;
        }

        public ConditionViewer()
        {
            InitializeComponent();
            // todo resize doesn't follow i18n when it's done here
            ResizeCombobox(cbxExpLType);
            ResizeCombobox(cbxExpRType);
            ResizeCombobox(cbxGroupingType);
            ResizeCombobox(cbxOpType);
            DoubleBuffered = true;
            disabledNodeColor = Color.Red;
            trvNodes.TreeViewNodeSorter = new NodeSorter();
            trvNodes.ItemDrag += trvNodes_ItemDrag;
            trvNodes.DragDrop += trvNodes_DragDrop;
            trvNodes.DragEnter += trvNodes_DragEnter;
            trvNodes.DragOver += trvNodes_DragOver;
            pnlEditorGroup.Visible = false;
            pnlEditorSingle.Visible = false;            
            PanelStateFromSelection = false;
            expLeft.textBox1.TextChanged += expLeft_TextChanged;
            expRight.textBox1.TextChanged += expRight_TextChanged;
            _PanelStateFromOption = btnProperties.Checked;
        }

        internal event EventHandler ConditionsUpdated;

        internal void OnConditionsUpdated()
        {
            ConditionsUpdated?.Invoke(this, EventArgs.Empty);
        }
        private void expLeft_TextChanged(object sender, EventArgs e)
        {
            TreeNode tn = trvNodes.SelectedNode;
            ConditionSingle re = (ConditionSingle)tn.Tag;
            re.ExpressionL = expLeft.Expression;
            TreeSort();

        }

        private void expRight_TextChanged(object sender, EventArgs e)
        {
            TreeNode tn = trvNodes.SelectedNode;
            ConditionSingle re = (ConditionSingle)tn.Tag;
            re.ExpressionR = expRight.Expression;
            TreeSort();
        }

        private void expLeft_LostFocus(object sender, EventArgs e)
        {
            OnConditionsUpdated();
        }

        private void expRight_LostFocus(object sender, EventArgs e)
        {
            OnConditionsUpdated();
        }

        private void ResizeCombobox(ComboBox cbx)
        {
            int mw = cbx.DropDownWidth;
            using (Graphics gr = toolStrip1.CreateGraphics())
            {
                foreach (string s in cbx.Items)
                {
                    int nw = (int)Math.Ceiling(gr.MeasureString(s, cbx.Font).Width);
                    if (nw > mw)
                    {
                        mw = nw;
                    }
                }
            }
            cbx.DropDownWidth = mw;
        }

        // Create a node sorter that implements the IComparer interface.
        public class NodeSorter : IComparer
        {
            // Compare the length of the strings, or the strings
            // themselves, if they are the same length.
            public int Compare(object x, object y)
            {
                TreeNode tx = x as TreeNode;
                TreeNode ty = y as TreeNode;
                if (tx.Tag is ConditionGroup && ty.Tag is ConditionSingle)
                {
                    return -1;
                }
                if (ty.Tag is ConditionGroup && tx.Tag is ConditionSingle)
                {
                    return 1;
                }                // If they are the same length, call Compare.
                int ex = string.Compare(tx.Text, ty.Text);
                if (ex != 0)
                {
                    return ex;
                }
                return ((ConditionComponent)tx.Tag).Id.CompareTo(((ConditionComponent)ty.Tag).Id);
            }
        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;
            return ContainsNode(node1, node2.Parent);
        }

        internal void trvNodes_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = trvNodes.PointToClient(new Point(e.X, e.Y));
            TreeNode tn = trvNodes.GetNodeAt(targetPoint);
            if (tn != null)
            {
                trvNodes.SelectedNode = tn;
            }
            if (tn != null && tn.Tag is ConditionGroup)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        internal void trvNodes_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
            OnConditionsUpdated();
        }

        internal void FocusTree()
        {
            trvNodes.Focus();
        }

        internal void trvNodes_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = trvNodes.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = trvNodes.GetNodeAt(targetPoint);
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode) && !(targetNode.Tag is ConditionSingle))
            {
                if (e.Effect == DragDropEffects.Move)
                {
                    ConditionGroup te = (ConditionGroup)targetNode.Tag;
                    ConditionComponent de = (ConditionComponent)draggedNode.Tag;
                    de.Parent.Children.Remove(de);
                    de.Parent = te;
                    te.Children.Add(de);
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                    trvNodes.SelectedNode = draggedNode;
                    RecolorStartingFromNode(targetNode, targetNode.Checked);
                }
                targetNode.Expand();
            }
            OnConditionsUpdated();
        }

        internal void trvNodes_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Item != trvNodes.Nodes[0])
                {
                    DoDragDrop(e.Item, DragDropEffects.Move);
                }
            }
        }

        private void TreeSort()
        {
            if (Changing == false)
            {
                TreeNode tn = trvNodes.SelectedNode;
                trvNodes.Sort();
                trvNodes.SelectedNode = tn;
            }
        }

        private void UpdateNodeIcon(TreeNode tn)
        {
            ConditionComponent re = (ConditionComponent)tn.Tag;
            if (re is ConditionSingle)
            {
                tn.ImageKey = "function";
                tn.SelectedImageKey = "function";
            }
            if (re is ConditionGroup)
            {
                switch (((ConditionGroup)re).Grouping)
                {
                    case ConditionGroup.CndGroupingEnum.And:
                        tn.ImageKey = "group_and";
                        tn.SelectedImageKey = "group_and";
                        break;
                    case ConditionGroup.CndGroupingEnum.Or:
                        tn.ImageKey = "group_or";
                        tn.SelectedImageKey = "group_or";
                        break;
                    case ConditionGroup.CndGroupingEnum.Xor:
                        tn.ImageKey = "group_xor";
                        tn.SelectedImageKey = "group_xor";
                        break;
                    case ConditionGroup.CndGroupingEnum.Not:
                        tn.ImageKey = "group_not";
                        tn.SelectedImageKey = "group_not";
                        break;
                }
            }
        }

        private void AttachConditionComponentToNode(TreeNode tn, ConditionComponent re)
        {
            tn.Tag = re;
            tn.Text = re.ToString();
            tn.Checked = re.Enabled;
            if (re != null)
            {
                SetReverseLookup(re, tn);
            }
            re.OnPropertyChange += Re_OnPropertyChange;
            UpdateNodeIcon(tn);
        }

        private void Re_OnPropertyChange(ConditionComponent re)
        {
            TreeNode tn = GetReverseLookup(re);
            UpdateNodeIcon(tn);
            tn.Text = re.ToString();
        }

        private void UpdateEditorToCondition(ConditionGroup r)
        {
            BuildTreeFromCondition(r);
            TreeSort();
            trvNodes.SelectedNode = trvNodes.Nodes[0];
            trvNodes.Nodes[0].Expand();
        }

        private void UpdateEditorToConditionComponent(ConditionComponent re)
        {
            if (re is ConditionSingle)
            {
                pnlEditorGroup.Visible = false;
                PanelStateFromSelection = true;                
                ConditionSingle r = (ConditionSingle)re;
                expLeft.Expression = r.ExpressionL;
                expRight.Expression = r.ExpressionR;
                switch (r.ExpressionTypeL)
                {
                    case ConditionSingle.ExprTypeEnum.String:
                        cbxExpLType.SelectedIndex = 0;
                        break;
                    case ConditionSingle.ExprTypeEnum.Numeric:
                        cbxExpLType.SelectedIndex = 1;
                        break;
                }
                switch (r.ExpressionTypeR)
                {
                    case ConditionSingle.ExprTypeEnum.String:
                        cbxExpRType.SelectedIndex = 0;
                        break;
                    case ConditionSingle.ExprTypeEnum.Numeric:
                        cbxExpRType.SelectedIndex = 1;
                        break;
                }
                cbxOpType.SelectedIndex = (int)r.ConditionType;
                capProperties.Caption = I18n.Translate("internal/ConditionViewer/condprops", "Condition properties");
                pnlEditorSingle.Visible = true;
            }
            else if (re is ConditionGroup)
            {
                pnlEditorSingle.Visible = false;
                PanelStateFromSelection = true;                
                ConditionGroup r = (ConditionGroup)re;
                switch (r.Grouping)
                {
                    case ConditionGroup.CndGroupingEnum.And:
                        cbxGroupingType.SelectedIndex = 0;
                        break;
                    case ConditionGroup.CndGroupingEnum.Or:
                        cbxGroupingType.SelectedIndex = 1;
                        break;
                    case ConditionGroup.CndGroupingEnum.Xor:
                        cbxGroupingType.SelectedIndex = 2;
                        break;
                    case ConditionGroup.CndGroupingEnum.Not:
                        cbxGroupingType.SelectedIndex = 3;
                        break;
                }
                capProperties.Caption = I18n.Translate("internal/ConditionViewer/groupprops", "Group properties");
                pnlEditorGroup.Visible = true;
            }
            else
            {
                pnlEditorSingle.Visible = false;
                pnlEditorGroup.Visible = false;
                PanelStateFromSelection = false;                
            }
            btnAddGroup.Enabled = true;
            btnAddCondition.Enabled = true;
            btnDelete.Enabled = (re.Parent != null);
        }

        private void trvNodes_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            Changing = true;
        }

        private void trvNodes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ConfirmComponentSelection((ConditionComponent)e.Node.Tag);
        }

        private void ConfirmComponentSelection(ConditionComponent cc)
        {
            UpdateEditorToConditionComponent(cc);
            Changing = false;
        }

        private void BuildTreeFromCondition(ConditionGroup r)
        {
            BuildTreeFromConditionItem(null, r);
        }

        private TreeNode BuildTreeFromConditionItem(TreeNode parent, ConditionComponent r)
        {
            TreeNode tn = new TreeNode();
            if (parent == null)
            {
                trvNodes.Nodes.Add(tn);
            }
            else
            {
                parent.Nodes.Add(tn);
            }
            AttachConditionComponentToNode(tn, r);
            if (r is ConditionGroup)
            {
                ConditionGroup gr = (ConditionGroup)r;
                foreach (ConditionComponent cr in gr.Children)
                {
                    BuildTreeFromConditionItem(tn, cr);
                }
            }
            return tn;
        }

        internal int CountRootConditions()
        {   // Count the enabled conditions under root folder.
            // -1 if contains enabled subfolder.
            TreeNodeCollection nodes = trvNodes.Nodes;
            TreeNode rootNode = nodes[0];
            if (rootNode.Tag is ConditionGroup rootGroup)
            {
                if (!rootGroup.Enabled) { return 0; }

                int conditionCount = 0;
                foreach (TreeNode node in rootNode.Nodes)
                {
                    if (node.Tag is ConditionGroup group && group.Enabled)
                    {
                        return -1;
                    }
                    else if (node.Tag is ConditionSingle condition && condition.Enabled)
                    {
                        conditionCount++;
                    }
                }
                return conditionCount;
            }
            return 0;
        }

        internal CndGroupingEnum RootConditionType()
        {
            var root = (ConditionGroup)trvNodes.Nodes[0].Tag;
            return root.Grouping;
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            ConditionGroup re = new ConditionGroup();
            TreeNode tn = new TreeNode();
            AttachConditionComponentToNode(tn, re);
            TreeNode tx = trvNodes.SelectedNode;
            ConditionComponent rx = (ConditionComponent)tx.Tag;
            if (rx is ConditionSingle)
            {
                tx = GetReverseLookup(rx.Parent);
                re.Parent = rx.Parent;
            }
            if (rx is ConditionGroup)
            {
                tx = GetReverseLookup(rx);
                re.Parent = (ConditionGroup)rx;
            }
            re.Parent.Children.Add(re);
            tx.Nodes.Add(tn);
            RecolorStartingFromNode(tx, tx.Checked);
            TreeSort();
            trvNodes.SelectedNode = tn;
            if (tx.IsExpanded == false)
            {
                tx.Expand();
            }
            OnConditionsUpdated();
        }

        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            ConditionSingle re = new ConditionSingle();
            re.ConditionType = ConditionSingle.CndTypeEnum.StringEqualNocase;
            TreeNode tn = new TreeNode();
            AttachConditionComponentToNode(tn, re);
            TreeNode tx = trvNodes.SelectedNode;
            ConditionComponent rx = (ConditionComponent)tx.Tag;
            if (rx is ConditionSingle)
            {
                tx = GetReverseLookup(rx.Parent);
                re.Parent = rx.Parent;
            }
            if (rx is ConditionGroup)
            {
                tx = GetReverseLookup(rx);
                re.Parent = (ConditionGroup)rx;
            }
            re.Parent.Children.Add(re);
            tx.Nodes.Add(tn);
            RecolorStartingFromNode(tx, tx.Checked);
            TreeSort();
            trvNodes.SelectedNode = tn;
            if (tx.IsExpanded == false)
            {
                tx.Expand();
            }
            expLeft.Focus();
            OnConditionsUpdated();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TreeNode tn = trvNodes.SelectedNode;
            ConditionComponent re = (ConditionComponent)tn.Tag;
            if (re is ConditionSingle)
            {
                if (MessageBox.Show(this, I18n.Translate("internal/ConditionViewer/areyousuresingle", "Are you sure you want to remove the selected condition?") + Environment.NewLine + Environment.NewLine + re.ToString(), I18n.Translate("internal/ConditionViewer/confirm", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    RemoveReverseLookup(re);
                    re.Parent.Children.Remove(re);
                    tn.Parent.Nodes.Remove(tn);
                }
            }
            if (re is ConditionGroup)
            {
                int numgroups = 0, numconditions = 0;
                CountItems((ConditionGroup)re, ref numgroups, ref numconditions);
                string temp = "";
                if (numgroups > 0 || numconditions > 0)
                {
                    temp += Environment.NewLine + Environment.NewLine + I18n.Translate("internal/ConditionViewer/operationwillremove", "This operation will remove:") + Environment.NewLine;
                    if (numgroups > 1)
                    {
                        temp += Environment.NewLine + "∙ " + I18n.Translate("internal/ConditionViewer/groupplural", "{0} groups", numgroups);
                    }
                    else if (numgroups > 0)
                    {
                        temp += Environment.NewLine + "∙ " + I18n.Translate("internal/ConditionViewer/groupsingular", "{0} group", numgroups);
                    }
                    if (numconditions > 1)
                    {
                        temp += Environment.NewLine + "∙ " + I18n.Translate("internal/ConditionViewer/conditionplural", "{0} conditions", numconditions);
                    }
                    else if (numconditions > 0)
                    {
                        temp += Environment.NewLine + "∙ " + I18n.Translate("internal/ConditionViewer/conditionsingular", "{0} condition", numconditions);
                    }
                }
                if (MessageBox.Show(this, I18n.Translate("internal/ConditionViewer/areyousuregroup", "Are you sure you want to remove the selected condition group?") + temp, I18n.Translate("internal/ConditionViewer/confirm", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DeleteGroup((ConditionGroup)re);
                    tn.Parent.Nodes.Remove(tn);
                }
            }
            OnConditionsUpdated();
        }

        private void DeleteGroup(ConditionGroup rge)
        {
            RemoveReverseLookup(rge);
            rge.Parent.Children.Remove(rge);
            rge.Parent = null;
            while (rge.Children.Count > 0)
            {
                ConditionComponent re = rge.Children[0];
                if (re is ConditionSingle)
                {
                    RemoveReverseLookup(re);
                    re.Parent = null;
                    rge.Children.RemoveAt(0);
                }
                if (re is ConditionGroup)
                {
                    DeleteGroup((ConditionGroup)re);
                }
            }
            OnConditionsUpdated();
        }

        internal void CountItems(ConditionGroup rge, ref int numgroups, ref int numrules)
        {
            numgroups++;
            foreach (ConditionComponent re in rge.Children)
            {
                if (re is ConditionSingle)
                {
                    numrules++;
                }
                if (re is ConditionGroup)
                {
                    CountItems((ConditionGroup)re, ref numgroups, ref numrules);
                }
            }
        }

        private void trvNodes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                CopySelected();
            }
            else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                PasteSelected(false);
            }
            else if (e.KeyCode == Keys.V && e.Modifiers == (Keys.Control | Keys.Shift))
            {
                PasteSelected(true);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (btnDelete.Enabled == true)
                {
                    btnDelete_Click(this, null);
                }
            }
            else if (e.KeyCode == Keys.Insert)
            {
                if ((e.Modifiers & Keys.Shift) != 0)
                {
                    if (btnAddGroup.Enabled == true)
                    {
                        btnAddGroup_Click(this, null);
                    }
                }
                else
                {
                    if (btnAddCondition.Enabled == true)
                    {
                        btnAddCondition_Click(this, null);
                    }
                }
            }
        }

        private void cbxExpRType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeNode tn = trvNodes.SelectedNode;
            ConditionSingle re = (ConditionSingle)tn.Tag;
            switch (cbxExpRType.SelectedIndex)
            {
                case 0:
                    expRight.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    re.ExpressionTypeR = ConditionSingle.ExprTypeEnum.String;
                    break;
                case 1:
                    expRight.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
                    re.ExpressionTypeR = ConditionSingle.ExprTypeEnum.Numeric;
                    break;
            }
            TreeSort();
            OnConditionsUpdated();
        }

        private void cbxExpLType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeNode tn = trvNodes.SelectedNode;
            ConditionSingle re = (ConditionSingle)tn.Tag;
            switch (cbxExpLType.SelectedIndex)
            {
                case 0:
                    expLeft.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    re.ExpressionTypeL = ConditionSingle.ExprTypeEnum.String;
                    break;
                case 1:
                    expLeft.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
                    re.ExpressionTypeL = ConditionSingle.ExprTypeEnum.Numeric;
                    break;
            }
            TreeSort();
            OnConditionsUpdated();
        }

        private void trvNodes_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                trvNodes.SelectedNode = e.Node;
            }
        }

        private void trvNodes_AfterCheck(object sender, TreeViewEventArgs e)
        {
            RecolorStartingFromNode(e.Node, e.Node.Checked);
            OnConditionsUpdated();
        }

        private void RecolorStartingFromNode(TreeNode tn, bool pstate)
        {
            object o = tn.Tag;
            TreeNode tnx = tn.Parent;
            while (tnx != null && pstate == true)
            {
                pstate = tnx.Checked;
                tnx = tnx.Parent;
            }
            tn.ForeColor = (tn.Checked == true && pstate == true) ? trvNodes.ForeColor : disabledNodeColor;
            ConditionComponent cc = (ConditionComponent)o;
            cc.Enabled = tn.Checked;
            if (o is ConditionGroup)
            {
                foreach (TreeNode tnn in tn.Nodes)
                {
                    RecolorStartingFromNode(tnn, (tn.Checked == true && pstate == true));
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ctxAddCondition.Enabled = btnAddCondition.Enabled;
            ctxAddGroup.Enabled = btnAddGroup.Enabled;
            ctxRemove.Enabled = btnDelete.Enabled;
            ctxCopy.Enabled = (trvNodes.SelectedNode != null);
            ctxPaste.Enabled = btnAddCondition.Enabled == true && (
                (plug.cfg.UseOsClipboard == false && (plug.ui.Clipboard != null && plug.ui.Clipboard.Length > 0))
                ||
                (plug.cfg.UseOsClipboard == true && System.Windows.Forms.Clipboard.ContainsText() == true)
            );
            ctxPasteOver.Enabled = ctxPaste.Enabled;
        }

        private void ctxBtnConditionGroup_Click(object sender, EventArgs e)
        {
            btnAddGroup_Click(sender, e);
        }

        private void ctxBtnCondition_Click(object sender, EventArgs e)
        {
            btnAddCondition_Click(sender, e);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopySelected();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteSelected(false);
        }

        internal void CopySelected()
        {
            try
            {
                string data = ExportSelection();
                if (plug.cfg.UseOsClipboard == true)
                {
                    System.Windows.Forms.Clipboard.SetText(data);
                }
                else
                {
                    plug.ui.Clipboard = data;
                }
                OnConditionsUpdated();
            }
            catch (Exception ex)
            {
                plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/ConditionViewer/copyfail", "Tree copy failed due to exception: {0}", ex.Message));
            }
        }

        internal void PasteSelected(bool overWrite)
        {
            string data = null;
            try
            {
                if (plug.cfg.UseOsClipboard == true)
                {
                    data = System.Windows.Forms.Clipboard.GetText(TextDataFormat.UnicodeText);
                }
                else
                {
                    data = plug.ui.Clipboard;
                }
                if (data != null && data.Length > 0)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(data);
                    XmlSerializer xs = null;
                    if (doc.DocumentElement.Name == "ConditionGroup")
                    {
                        xs = new XmlSerializer(typeof(ConditionGroup));
                    }
                    else if (doc.DocumentElement.Name == "ConditionSingle")
                    {
                        xs = new XmlSerializer(typeof(ConditionSingle));
                    }
                    else
                    {
                        // doesn't look like valid paste
                        return;
                    }
                    ConditionComponent cx;
                    using (XmlNodeReader nr = new XmlNodeReader(doc.DocumentElement))
                    {
                        cx = (ConditionComponent)xs.Deserialize(nr);
                    }
                    TreeNode tn = trvNodes.SelectedNode;
                    ConditionComponent target = (ConditionComponent)tn.Tag;
                    if (
                        (
                            (cx is ConditionGroup && target is ConditionGroup)
                            ||
                            (cx is ConditionSingle && target is ConditionSingle)
                        )
                        &&
                        overWrite == true
                    )
                    {
                        if (cx is ConditionGroup && target is ConditionGroup)
                        {
                            ConditionGroup sc = (ConditionGroup)cx;
                            ConditionGroup tc = (ConditionGroup)target;
                            tc.Children.AddRange(sc.Children);
                            foreach (ConditionComponent cc in sc.Children)
                            {
                                cc.Parent = tc;
                                BuildTreeFromConditionItem(tn, cc);
                            }
                            tc.Enabled = sc.Enabled;
                            tn.Checked = tc.Enabled;
                            tc.Grouping = sc.Grouping;                            
                            RecolorStartingFromNode(tn, tn.Checked);
                            TreeSort();
                            UpdateEditorToConditionComponent(target);
                            tn.Expand();
                        }
                        else if (cx is ConditionSingle && target is ConditionSingle)
                        {
                            ConditionSingle sc = (ConditionSingle)cx;
                            ConditionSingle tc = (ConditionSingle)target;
                            tc.ConditionType = sc.ConditionType;
                            tc.Enabled = sc.Enabled;
                            tn.Checked = tc.Enabled;
                            tc.ExpressionL = sc.ExpressionL;
                            tc.ExpressionR = sc.ExpressionR;
                            tc.ExpressionTypeL = sc.ExpressionTypeL;
                            tc.ExpressionTypeR = sc.ExpressionTypeR;
                            RecolorStartingFromNode(tn, tn.Checked);
                            TreeSort();
                            UpdateEditorToConditionComponent(target);
                        }
                    }
                    else
                    {
                        if (target is ConditionSingle)
                        {
                            target = target.Parent;
                            tn = tn.Parent;
                        }
                        ConditionGroup tg = (ConditionGroup)target;
                        tg.Children.Add(cx);
                        cx.Parent = tg;
                        TreeNode ex = BuildTreeFromConditionItem(tn, cx);
                        RecolorStartingFromNode(tn, tn.Checked);
                        TreeSort();
                        trvNodes.SelectedNode = ex;
                        ex.ExpandAll();
                    }
                }
                OnConditionsUpdated();
            }
            catch (Exception ex)
            {
                plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/ConditionViewer/pastefail", "Tree paste failed due to exception: {0}", ex.Message));
            }
        }

        private void cbxGroupingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeNode tn = trvNodes.SelectedNode;
            ConditionGroup re = (ConditionGroup)tn.Tag;
            switch (cbxGroupingType.SelectedIndex)
            {
                case 0:
                    re.Grouping = ConditionGroup.CndGroupingEnum.And;
                    break;
                case 1:
                    re.Grouping = ConditionGroup.CndGroupingEnum.Or;
                    break;
                case 2:
                    re.Grouping = ConditionGroup.CndGroupingEnum.Xor;
                    break;
                case 3:
                    re.Grouping = ConditionGroup.CndGroupingEnum.Not;
                    break;
            }
            UpdateNodeIcon(tn);
            TreeSort();
            OnConditionsUpdated();
        }

        private void cbxOpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeNode tn = trvNodes.SelectedNode;
            ConditionSingle re = (ConditionSingle)tn.Tag;
            re.ConditionType = (ConditionSingle.CndTypeEnum)cbxOpType.SelectedIndex;
            TreeSort();
            OnConditionsUpdated();
        }

        private string ExportSelection()
        {
            TreeNode tn = trvNodes.SelectedNode;
            ConditionComponent cc = (ConditionComponent)tn.Tag;
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            string test = "";
            ns.Add("", "");            
            XmlSerializer xs = new XmlSerializer(cc is ConditionSingle == true ? typeof(ConditionSingle) : typeof(ConditionGroup));
            using (MemoryStream ms = new MemoryStream())
            {
                xs.Serialize(ms, cc, ns);
                ms.Position = 0;
                using (StreamReader sr = new StreamReader(ms))
                {
                    test = sr.ReadToEnd();                    
                }
            }
            return test;
        }

        private void pasteOverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteSelected(true);
        }

        private void btnProperties_CheckedChanged(object sender, EventArgs e)
        {
            PanelStateFromOption = btnProperties.Checked;
        }

    }

}
