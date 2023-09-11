using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Triggernometry.CustomControls
{

    public partial class ActionViewer : UserControl
    {

        private bool IsReadonly { get; set; } = false;

        internal List<Action> Actions { get; set; } = null;

        internal WMPLib.WindowsMediaPlayer wmp;
        internal SpeechSynthesizer tts;
        internal RealPlugin plug;
        internal ImageList imgs;
        internal TreeView trv;
        internal Context fakectx;

        internal string ClipboardAction = "";
        internal List<Action> PrevActions;
        internal List<int> PrevSelectedIndices;

        public ActionViewer()
        {
            InitializeComponent();
            fakectx = new Context();
            dgvActions.MouseClick += dgvActions_MouseClick;
        }

        internal event EventHandler ActionsUpdated;

        internal void OnActionsUpdated()
        {
            ActionsUpdated?.Invoke(this, EventArgs.Empty);
        }

        internal void RefreshDgv()
        {
            dgvActions.RowCount = Actions.Count;
        }

        internal void SetReadOnly()
        {
            IsReadonly = true;
            btnAddAction.Enabled = false;
            btnActionUp.Enabled = false;
            btnActionDown.Enabled = false;
            btnActionTop.Enabled = false;
            btnActionBottom.Enabled = false;
            btnRemoveAction.Enabled = false;
            btnUndo.Enabled = false;
        }

        private void CloseTree(TreeNode tn)
        {
            if (tn.Tag is Folder)
            {
                tn.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForClosedFolder((Folder)tn.Tag);
                tn.SelectedImageIndex = tn.ImageIndex;
            }
            foreach (TreeNode tc in tn.Nodes)
            {
                CloseTree(tc);
            }
        }

        private bool RemoveTriggerNodesFromTree(TreeNode tn)
        {
            if (tn == null)
            {
                return true;
            }
            if (tn.Tag is Trigger)
            {
                return true;
            }
            List<TreeNode> rems = new List<TreeNode>();
            foreach (TreeNode tnx in tn.Nodes)
            {
                if (RemoveTriggerNodesFromTree(tnx) == true)
                {
                    rems.Add(tnx);
                }
            }
            foreach (TreeNode tnr in rems)
            {
                tnr.Remove();
            }
            return false;
        }

        private bool RemoveNonRepositoryNodesFromTree(TreeNode tn)
        {
            if (tn == null)
            {
                return true;
            }
            if ((tn.Tag is Repository) == false && tn.Parent != null)
            {
                return true;
            }
            List<TreeNode> rems = new List<TreeNode>();
            foreach (TreeNode tnx in tn.Nodes)
            {
                if (RemoveNonRepositoryNodesFromTree(tnx) == true)
                {
                    rems.Add(tnx);
                }
            }
            foreach (TreeNode tnr in rems)
            {
                tnr.Remove();
            }
            return false;
        }

        private void dgvActions_SelectionChanged(object sender, EventArgs e)
        {
            btnEditAction.Enabled = (dgvActions.SelectedRows.Count == 1);
            btnRemoveAction.Enabled = IsReadonly == false && (dgvActions.SelectedRows.Count > 0);
            btnActionUp.Enabled = IsReadonly == false;
            btnActionDown.Enabled = IsReadonly == false;
            btnActionTop.Enabled = btnActionUp.Enabled;
            btnActionBottom.Enabled = btnActionDown.Enabled;
        }

        private void dgvActions_Leave(object sender, EventArgs e)
        {
            dgvActions.ClearSelection();
        }

        private void dgvActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                CopySelectedAction();
            }
            else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                PasteSelectedAction();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (btnRemoveAction.Enabled == true)
                {
                    btnRemoveAction_Click(this, null);
                }
            }
        }

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            using (Forms.ActionForm af = new Forms.ActionForm())
            {
                af.plug = plug;
                ExpressionTextBox.SetPlugForTextBoxes(af, plug);
                af.wmp = wmp;
                af.tts = tts;
                af.trv = trv;
                af.fakectx = fakectx;
                af.imgs = imgs;
                af.trvTrigger.ImageList = imgs;
                af.trvTrigger.Nodes.Add((TreeNode)trv.Nodes[0].Clone());
                CloseTree(af.trvTrigger.Nodes[0]);
                af.trvRepositoryLink.ImageList = imgs;
                af.trvRepositoryLink.Nodes.Add((TreeNode)trv.Nodes[1].Clone());
                RemoveNonRepositoryNodesFromTree(af.trvRepositoryLink.Nodes[0]);
                CloseTree(af.trvRepositoryLink.Nodes[0]);
                af.trvFolder.ImageList = imgs;
                af.trvFolder.Nodes.Add((TreeNode)trv.Nodes[0].Clone());
                RemoveTriggerNodesFromTree(af.trvFolder.Nodes[0]);
                CloseTree(af.trvFolder.Nodes[0]);
                af.SettingsFromAction(null);
                if (IsReadonly == true)
                {
                    af.SetReadOnly();
                }
                af.Text = I18n.Translate("internal/TriggerForm/addnewaction", "Add new action");
                af.btnOk.Text = I18n.Translate("internal/TriggerForm/add", "Add");                
                if (af.ShowDialog() == DialogResult.OK)
                {
                    Action a = new Action();
                    af.SettingsToAction(a);
                    a._Enabled = true;
                    int insertIndex = (dgvActions.Rows.Count > 0) ? (dgvActions.SelectedRows[0].Index + 1) : 0;
                    Actions.Insert(insertIndex, a);
                    a.OrderNumber = insertIndex + 1;
                    for (int i = insertIndex + 1; i < Actions.Count; i++) { Actions[i].OrderNumber++; }
                    dgvActions.RowCount = Actions.Count;
                    dgvActions.ClearSelection();
                    dgvActions.Rows[insertIndex].Selected = true;
                    OnActionsUpdated();
                }
            }
        }

        private void btnEditAction_Click(object sender, EventArgs e)
        {
            Context ctx = new Context();
            ctx.plug = plug;
            ctx.trig = fakectx.trig;
            using (Forms.ActionForm af = new Forms.ActionForm())
            {
                Action a = Actions[dgvActions.SelectedRows[0].Index];
                af.plug = plug;
                ExpressionTextBox.SetPlugForTextBoxes(af, plug);
                af.wmp = wmp;
                af.trv = trv;
                af.fakectx = fakectx;
                af.imgs = imgs;
                af.trvTrigger.ImageList = imgs;
                af.trvTrigger.Nodes.Add((TreeNode)trv.Nodes[0].Clone());
                CloseTree(af.trvTrigger.Nodes[0]);
                af.trvRepositoryLink.ImageList = imgs;
                af.trvRepositoryLink.Nodes.Add((TreeNode)trv.Nodes[1].Clone());
                RemoveNonRepositoryNodesFromTree(af.trvRepositoryLink.Nodes[0]);
                CloseTree(af.trvRepositoryLink.Nodes[0]);
                af.trvFolder.ImageList = imgs;
                af.trvFolder.Nodes.Add((TreeNode)trv.Nodes[0].Clone());
                RemoveTriggerNodesFromTree(af.trvFolder.Nodes[0]);
                CloseTree(af.trvFolder.Nodes[0]);
                af.SettingsFromAction(a);
                if (IsReadonly == true)
                {
                    af.SetReadOnly();
                }
                af.tts = tts;
                af.Text = I18n.Translate("internal/TriggerForm/editaction", "Edit action '{0}'", a.GetDescription(ctx));
                af.btnOk.Text = I18n.Translate("internal/TriggerForm/savechanges", "Save changes");
                if (af.ShowDialog() == DialogResult.OK)
                {
                    af.SettingsToAction(a);
                    dgvActions.Refresh();
                    OnActionsUpdated();
                }
            }
        }

        private void MoveSelectedRows(string moveType)
        {
            int length = Actions.Count;
            List<int> selectedRowIndices = dgvActions.SelectedRows.Cast<DataGridViewRow>().Select(row => row.Index).ToList();
            List<int> unselectedRowIndices = Enumerable.Range(0, length).Except(selectedRowIndices).ToList();
            selectedRowIndices.Sort();
            int start, end;
            switch (moveType)
            {
                case "up":
                    start = Math.Max(selectedRowIndices[0] - 1, 0); // the first selected row move to this index
                    end = start + selectedRowIndices.Count - 1;     // the last selected row move to this index
                    break;
                case "top":
                    start = 0;
                    end = selectedRowIndices.Count - 1;
                    break;
                case "down":
                    end = Math.Min(selectedRowIndices[selectedRowIndices.Count - 1] + 1, length - 1);
                    start = end - selectedRowIndices.Count + 1;
                    break;
                case "bottom":
                    end = length - 1;
                    start = length - selectedRowIndices.Count;
                    break;
                default: throw new Exception($"Wrong moveType argument {moveType}");
            }

            List<int> ordMap = new List<int>(new int[length]);

            for (int i = 0; i < length; i++)
            {
                if (i >= start && i <= end)
                {
                    ordMap[i] = selectedRowIndices[0] + 1;
                    selectedRowIndices.RemoveAt(0);
                }
                else
                {
                    ordMap[i] = unselectedRowIndices[0] + 1;
                    unselectedRowIndices.RemoveAt(0);
                }
            }

            for (int i = 0; i < length; i++)
            {
                Actions[ordMap[i] - 1].OrderNumber = i + 1;
            }

            Actions.Sort((a, b) => a.OrderNumber.CompareTo(b.OrderNumber));

            dgvActions.ClearSelection();
            for (int i = start; i <= end; i++)
            {
                dgvActions.Rows[i].Selected = true;
            }

            dgvActions.Refresh();
        }

        private void btnActionUp_Click(object sender, EventArgs e)
        {
            StoreActions();
            MoveSelectedRows("up");
            // OnActionsUpdated();  not used since moving actions would not change trigger descriptions
        }

        private void btnActionDown_Click(object sender, EventArgs e)
        {
            StoreActions();
            MoveSelectedRows("down");
        }

        private void btnActionTop_Click(object sender, EventArgs e)
        {
            StoreActions();
            MoveSelectedRows("top");
        }

        private void btnActionBottom_Click(object sender, EventArgs e)
        {
            StoreActions();
            MoveSelectedRows("bottom");
        }

        private void btnRemoveAction_Click(object sender, EventArgs e)
        {
            string temp;
            if (dgvActions.SelectedRows.Count > 1)
            {
                temp = I18n.Translate("internal/TriggerForm/areyousureplural", "Are you sure you want to remove the selected actions?");
            }
            else
            {
                temp = I18n.Translate("internal/TriggerForm/areyousuresingular", "Are you sure you want to remove the selected action?");
            }
            switch (MessageBox.Show(this, temp, I18n.Translate("internal/TriggerForm/confirmremoval", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    StoreActions();
                    List<Action> acts = new List<Action>();
                    foreach (DataGridViewRow r in dgvActions.SelectedRows)
                    {
                        acts.Add(Actions[r.Index]);
                    }
                    foreach (Action a in acts)
                    {
                        Actions.Remove(a);
                        List<Action> px = new List<Action>();
                        px.AddRange(from ax in Actions where ax.OrderNumber > a.OrderNumber select ax);
                        foreach (Action aaa in px)
                        {
                            aaa.OrderNumber--;
                        }
                    }
                    dgvActions.RowCount = Actions.Count;
                    dgvActions.ClearSelection();
                    dgvActions.Refresh();
                    OnActionsUpdated();
                    break;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (PrevActions == null || PrevSelectedIndices == null) { return; }

            var tempActions = Actions;
            Actions = PrevActions;
            PrevActions = tempActions;

            var tempIndices = PrevSelectedIndices;
            PrevSelectedIndices = dgvActions.SelectedRows.Cast<DataGridViewRow>()
                .Select(row => row.Index).ToList();
            dgvActions.RowCount = Actions.Count;
            dgvActions.ClearSelection();
            dgvActions.Refresh();
            foreach (int index in tempIndices)
            {
                if (index < dgvActions.RowCount)
                {
                    dgvActions.Rows[index].Selected = true;
                }
            }
            OnActionsUpdated();
        }

        private void StoreActions()
        {
            PrevActions = Actions.ToList();
            PrevSelectedIndices = dgvActions.SelectedRows.Cast<DataGridViewRow>()
                .Select(row => row.Index).ToList();
            btnUndo.Enabled = true;
        }

        private void dgvActions_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Actions.Count)
            {
                return;
            }
            switch (e.ColumnIndex)
            {
                case 0:
                    e.Value = Actions[e.RowIndex]._Enabled;
                    break;
                case 1:
                    e.Value = Actions[e.RowIndex].GetDescription(fakectx);
                    break;
            }
        }

        private static Regex regexHexColor = new Regex(@"^#? *(?<rgb>[\dA-Fa-f]{3}|[\dA-Fa-f]{6})$");
        private static Regex regexNumColor = new Regex(@"^(?<r>\d+(?:.\d+)?) *, *(?<g>\d+(?:.\d+)?) *, *(?<b>\d+(?:.\d+)?)$");

        public static Color ParseColor(string rawColor)
        {
            rawColor = rawColor.Trim();

            Color namedColor = Color.FromName(rawColor);
            if (namedColor.IsKnownColor)
            {   // "white"
                return namedColor;
            }

            int r, g, b;
            Match hexMatch = regexHexColor.Match(rawColor);
            if (hexMatch.Success)
            {
                string rgb = hexMatch.Groups["rgb"].Value;
                if (rgb.Length == 3)
                {   // "#fff" or "fff"
                    rgb = string.Concat(rgb[0], rgb[0], rgb[1], rgb[1], rgb[2], rgb[2]);
                }
                // "#ffffff" or "ffffff"
                r = Convert.ToInt32(rgb.Substring(0, 2), 16);
                g = Convert.ToInt32(rgb.Substring(2, 2), 16);
                b = Convert.ToInt32(rgb.Substring(4, 2), 16);
            }
            else
            {   // "255, 255, 255"
                Match numMatch = regexNumColor.Match(rawColor);
                if (numMatch.Success)
                {
                    r = (int)Math.Round(double.Parse(numMatch.Groups["r"].Value));
                    g = (int)Math.Round(double.Parse(numMatch.Groups["g"].Value));
                    b = (int)Math.Round(double.Parse(numMatch.Groups["b"].Value));
                }
                else return Color.Empty;
            }

            return Color.FromArgb( r < 0 ? 0 : r > 255 ? 255 : r,
                                   g < 0 ? 0 : g > 255 ? 255 : g,
                                   b < 0 ? 0 : b > 255 ? 255 : b );
        }

        private void dgvActions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Actions.Count)
            {
                return;
            }
            Action a = Actions[e.RowIndex];

            // set a warning color when a delay (not zero) is hidden under the description
            string delay = "0" + a._ExecutionDelayExpression.Trim();
            if (a._Enabled && a._DescriptionOverride && !(double.TryParse(delay, out double result) && result == 0))
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 224, 128); // light yellow
                e.CellStyle.ForeColor = SystemColors.InactiveCaptionText;
            }
            else 
            {   
                // customized colors
                Color bgColor, textColor;
                try
                {
                    string rawBgColor = fakectx.ExpandVariables(null, null, false, a._DescBgColor);
                    bgColor = ParseColor(rawBgColor);
                }
                catch { bgColor = Color.Empty; }

                try
                {
                    string rawTextColor = fakectx.ExpandVariables(null, null, false, a._DescTextColor);
                    textColor = ParseColor(rawTextColor);
                }
                catch { textColor = Color.Empty; }

                // placeholder / normal color
                if (a.ActionType == Action.ActionTypeEnum.Placeholder)
                {
                    e.CellStyle.BackColor = (bgColor != Color.Empty) ? bgColor : SystemColors.InactiveCaption;
                    e.CellStyle.ForeColor = (textColor != Color.Empty) ? textColor : SystemColors.InactiveCaptionText;
                }
                else
                {
                    e.CellStyle.BackColor = (bgColor != Color.Empty) ? bgColor : dgvActions.DefaultCellStyle.BackColor;
                    e.CellStyle.ForeColor = (textColor != Color.Empty) ? textColor :
                                            (a._Enabled) ? dgvActions.DefaultCellStyle.ForeColor : Color.FromArgb(176, 192, 208);
                }
            }
        }

        private void dgvActions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Actions.Count)
            {
                return;
            }
            if (e.ColumnIndex != 0)
            {
                return;
            }
            Actions[e.RowIndex]._Enabled = !Actions[e.RowIndex]._Enabled;
            OnActionsUpdated();
        }

        private void dgvActions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Actions.Count)
            {
                return;
            }
            if (e.ColumnIndex == 1)
            {
                btnEditAction_Click(sender, null);
                return;
            }
            Actions[e.RowIndex]._Enabled = (Actions[e.RowIndex]._Enabled == false);
        }

        private string ExportActionSelection()
        {
            string data = "";
            object toSerialize = null;
            XmlSerializer xs;
            if (dgvActions.SelectedRows.Count > 1)
            {
                Action.ActionBundle ab = new Action.ActionBundle();
                foreach (DataGridViewRow r in dgvActions.SelectedRows)
                {
                    ab.Actions.Add(Actions[r.Index]);
                }
                ab.Actions.Sort((a, b) => a.OrderNumber.CompareTo(b.OrderNumber));
                toSerialize = ab;
                xs = new XmlSerializer(typeof(Action.ActionBundle));
            }
            else
            {
                int idx = dgvActions.SelectedRows[0].Index;
                toSerialize = Actions[idx];
                xs = new XmlSerializer(typeof(Action));
            }
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");            
            using (MemoryStream ms = new MemoryStream())
            {
                xs.Serialize(ms, toSerialize, ns);
                ms.Position = 0;
                using (StreamReader sr = new StreamReader(ms))
                {
                    data = sr.ReadToEnd();
                }
            }
            return data;
        }

        private void CopySelectedAction()
        {
            try
            {
                if (btnRemoveAction.Enabled == true)
                {
                    if (plug.cfg.UseOsClipboard == true)
                    {
                        System.Windows.Forms.Clipboard.SetText(ExportActionSelection());
                    }
                    else
                    {
                        ClipboardAction = ExportActionSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/TriggerForm/actioncopyfail", "Action copy failed due to exception: {0}", ex.Message));
            }
        }

        private void PasteSelectedAction()
        {
            if (OkToPasteAction() == false)
            {
                return;
            }
            string data = null;
            if (plug.cfg.UseOsClipboard == true)
            {
                data = System.Windows.Forms.Clipboard.GetText(TextDataFormat.UnicodeText);
            }
            else
            {
                data = ClipboardAction;
            }
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);
                if (doc.DocumentElement.Name == "ActionBundle")
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Action.ActionBundle));
                    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
                    {
                        Action.ActionBundle ab = (Action.ActionBundle)xs.Deserialize(ms);
                        int idx = 0;
                        if (dgvActions.SelectedRows.Count > 0)
                        {
                            idx = dgvActions.SelectedRows[dgvActions.SelectedRows.Count - 1].Index;
                            Action origo = Actions[idx];
                            int i = 1;
                            foreach (Action a in ab.Actions)
                            {
                                a.OrderNumber = origo.OrderNumber + i++;
                            }
                            foreach (Action c in Actions)
                            {
                                if (c.OrderNumber > origo.OrderNumber)
                                {
                                    int newidx = origo.OrderNumber + i++;
                                    c.OrderNumber = newidx;
                                }
                            }
                            Actions.AddRange(ab.Actions);
                            Actions.Sort((a, b) => a.OrderNumber.CompareTo(b.OrderNumber));
                        }
                        else
                        {
                            var actions = from ix in ab.Actions orderby ix.OrderNumber ascending select ix;
                            int i = 1;
                            foreach (Action a in actions)
                            {
                                a.OrderNumber = i++;
                                Actions.Add(a);
                            }
                        }
                        dgvActions.RowCount = Actions.Count;
                        dgvActions.Invalidate();
                    }

                }
                else
                { 
                    XmlSerializer xs = new XmlSerializer(typeof(Action));
                    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
                    {
                        Action cx = (Action)xs.Deserialize(ms);
                        int idx = 0;
                        if (dgvActions.SelectedRows.Count > 0)
                        {
                            idx = dgvActions.SelectedRows[dgvActions.SelectedRows.Count - 1].Index;
                            Action origo = Actions[idx];
                            cx.OrderNumber = origo.OrderNumber + 1;
                            foreach (Action c in Actions)
                            {
                                if (c.OrderNumber >= cx.OrderNumber)
                                {
                                    c.OrderNumber++;
                                }
                            }
                        }
                        else
                        {
                            cx.OrderNumber = 1;
                        }
                        Actions.Insert(cx.OrderNumber - 1, cx);
                        dgvActions.RowCount = Actions.Count;
                        dgvActions.Invalidate();
                    }
                }
                OnActionsUpdated();
            }
            catch (Exception ex)
            {
                plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/TriggerForm/actionpastefail", "Action paste failed due to exception: {0}", ex.Message));
            }
        }

        public List<string> GetActionDescriptions()
        {
            List<string> descriptions = new List<string>();
            foreach (Action action in Actions)
            {
                descriptions.Add(action.GetDescription(fakectx));
            }
            return descriptions;
        }

        public double GetActionTotalDelay()
        {   // return the total delay, or NaN if at least one of the expressions is not numeric
            double totalDelay = 0;
            foreach (var action in Actions)
            {
                string delay = action._ExecutionDelayExpression;
                if (delay.Contains("$") || delay.ToLower().Contains("random"))
                {
                    return Double.NaN;
                }
                else
                {
                    try { totalDelay += fakectx.EvaluateNumericExpression(null, null, delay); }
                    catch { return Double.NaN; }
                }
            }
            return totalDelay;
        }

        private void ctxAddAction_Click(object sender, EventArgs e)
        {
            btnAddAction_Click(sender, e);
        }

        private void ctxEditAction_Click(object sender, EventArgs e)
        {
            btnEditAction_Click(sender, e);
        }

        private void ctxCopyAction_Click(object sender, EventArgs e)
        {
            CopySelectedAction();
        }

        private void ctxPasteAction_Click(object sender, EventArgs e)
        {
            PasteSelectedAction();
        }

        private void ctxMoveUp_Click(object sender, EventArgs e)
        {
            btnActionUp_Click(sender, e);
        }

        private void ctxMoveDown_Click(object sender, EventArgs e)
        {
            btnActionDown_Click(sender, e);
        }

        private void ctxMoveTop_Click(object sender, EventArgs e)
        {
            btnActionTop_Click(sender, e);
        }

        private void ctxMoveBottom_Click(object sender, EventArgs e)
        {
            btnActionBottom_Click(sender, e);
        }

        private void ctxRemoveAction_Click(object sender, EventArgs e)
        {
            btnRemoveAction_Click(sender, e);
        }

        private void ctxUndo_Click(object sender, EventArgs e)
        {
            btnUndo_Click(sender, e);
        }

        private void ctxAction_Opening(object sender, CancelEventArgs e)
        {
            ctxAddAction.Enabled = btnAddAction.Enabled;
            ctxEditAction.Enabled = btnEditAction.Enabled;
            ctxCopyAction.Enabled = btnEditAction.Enabled;
            ctxMoveUp.Enabled = btnActionUp.Enabled;
            ctxMoveDown.Enabled = btnActionDown.Enabled;
            ctxMoveTop.Enabled = btnActionTop.Enabled;
            ctxMoveBottom.Enabled = btnActionBottom.Enabled;
            ctxRemoveAction.Enabled = btnRemoveAction.Enabled;
            ctxUndo.Enabled = btnUndo.Enabled;
            ctxPasteAction.Enabled = OkToPasteAction();
        }

        private bool OkToPasteAction()
        {
            string data = null;
            if (plug.cfg.UseOsClipboard == true)
            {
                data = System.Windows.Forms.Clipboard.GetText(TextDataFormat.UnicodeText);
            }
            else
            {
                data = ClipboardAction;
            }
            return IsReadonly == false && (data != null && data.Length > 0);
        }

        private void dgvActions_MouseClick(object sender, MouseEventArgs e)
        {   // clicking the grey region
            int rowIndex = dgvActions.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex == -1 || rowIndex >= dgvActions.RowCount)
            {
                dgvActions.ClearSelection();
            }
        }

    }

}
