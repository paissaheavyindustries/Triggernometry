using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Triggernometry.CustomControls;
using Triggernometry.Variables;

namespace Triggernometry.Forms
{

    public partial class StateForm : MemoryForm<StateForm>
    {

        internal RealPlugin plug;

        public StateForm()
        {
            InitializeComponent();
            Shown += VariableForm_Shown;
            RestoredSavedDimensions();
            sortedVariableKeys = new List<string>();
            sortType = "name";
            sortAsc = true;
            dgvScalarVariables.Columns[0].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            SetAllHeadersMinWidth(this);
        }

        private void VariableForm_Shown(object sender, EventArgs e)
        {
            RefreshScalarVariables(plug.sessionvars, dgvScalarVariables);
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            sortType = "name";
            sortAsc = true;
            switch (tbcMain.SelectedIndex)
            {
                case 0:
                    tbcScalar.SelectedIndex = 0;
                    dgvScalarVariables.Columns[0].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                    RefreshScalarVariables(plug.sessionvars, dgvScalarVariables);
                    break;
                case 1:
                    tbcList.SelectedIndex = 0;
                    dgvListVariables.Columns[0].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                    RefreshListVariables(plug.sessionvars, dgvListVariables);
                    break;
                case 2:
                    tbcTable.SelectedIndex = 0;
                    dgvTableVariables.Columns[0].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                    RefreshTableVariables(plug.sessionvars, dgvTableVariables);
                    break;
                case 3:
                    tbcDict.SelectedIndex = 0;
                    dgvDictVariables.Columns[0].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                    RefreshDictVariables(plug.sessionvars, dgvDictVariables);
                    break;
                case 4:
                    RefreshMutexes();
                    break;
                case 5:
                    RefreshImageAuras();
                    break;
                case 6:
                    RefreshTextAuras();
                    break;
                case 7:
                    RefreshNamedCallbacks();
                    break;
            }
        }

        private void tbcScalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcScalar.SelectedIndex)
            {
                case 0:
                    RefreshScalarVariables(plug.sessionvars, dgvScalarVariables);
                    break;
                case 1:
                    RefreshScalarVariables(plug.cfg.PersistentVariables, dgvPeScalarVariables);
                    break;
            }
        }

        private void tbcList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcList.SelectedIndex)
            {
                case 0:
                    RefreshListVariables(plug.sessionvars, dgvListVariables);
                    break;
                case 1:
                    RefreshListVariables(plug.cfg.PersistentVariables, dgvPeListVariables);
                    break;
            }
        }

        private void tbcTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcTable.SelectedIndex)
            {
                case 0:
                    RefreshTableVariables(plug.sessionvars, dgvTableVariables);
                    break;
                case 1:
                    RefreshTableVariables(plug.cfg.PersistentVariables, dgvPeTableVariables);
                    break;
            }
        }

        private void tbcDict_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcDict.SelectedIndex)
            {
                case 0:
                    RefreshDictVariables(plug.sessionvars, dgvDictVariables);
                    break;
                case 1:
                    RefreshDictVariables(plug.cfg.PersistentVariables, dgvPeDictVariables);
                    break;
            }
        }

        #region Generic

        private List<string> sortedVariableKeys;
        private string sortType;
        private bool sortAsc;

        private Variable OpenVariableEditor(Variable v, ref string name, bool isNew)
        {
            using (VariableEditorForm vef = new VariableEditorForm())
            {
                vef.VariableName = name;
                vef.VariableToEdit = v.Duplicate();
                vef.IsNew = isNew;
                if (vef.ShowDialog() == DialogResult.OK)
                {
                    name = vef.VariableName;
                    vef.VariableToEdit.LastChanged = DateTime.Now;
                    vef.VariableToEdit.LastChanger = I18n.Translate("internal/VariableForm/variableeditortag", "Variable editor");
                    return vef.VariableToEdit;
                }
            }
            return null;
        }

        private void UpdateSortType(string newType, DataGridView dgv, int colIndex)
        {
            if (sortType == newType)
            {
                sortAsc = !sortAsc;
            }
            else
            {
                sortType = newType;
                sortAsc = true;
            }
            // update sort glyph
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
            dgv.Columns[colIndex].HeaderCell.SortGlyphDirection = (sortAsc) ? SortOrder.Ascending : SortOrder.Descending;
        }

        private void dgvCommon_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string newType = "";
            DataGridView dgv = sender as DataGridView;
            VariableStore vs = (dgv.Name.StartsWith("dgvPe")) ? plug.cfg.PersistentVariables : plug.sessionvars;
            switch (dgv.Name)
            {
                case "dgvScalarVariables":
                case "dgvPeScalarVariables":
                    switch (e.ColumnIndex)
                    {
                        case 0: newType = "name"; break;
                        case 1: newType = "value"; break;
                        case 2: newType = "lastchanged"; break;
                        case 3: newType = "lastchanger"; break;
                    }
                    UpdateSortType(newType, dgv, e.ColumnIndex);
                    RefreshScalarVariables(vs, dgv);
                    break;
                case "dgvListVariables":
                case "dgvPeListVariables":
                    switch (e.ColumnIndex)
                    {
                        case 0: newType = "name"; break;
                        case 1: newType = "size"; break;
                        case 2: newType = "value"; break;
                        case 3: newType = "lastchanged"; break;
                        case 4: newType = "lastchanger"; break;
                    }
                    UpdateSortType(newType, dgv, e.ColumnIndex);
                    RefreshListVariables(vs, dgv);
                    break;
                case "dgvTableVariables":
                case "dgvPeTableVariables":
                    switch (e.ColumnIndex)
                    {
                        case 0: newType = "name"; break;
                        case 1: newType = "width"; break;
                        case 2: newType = "height"; break;
                        case 3: newType = "lastchanged"; break;
                        case 4: newType = "lastchanger"; break;
                    }
                    UpdateSortType(newType, dgv, e.ColumnIndex);
                    RefreshTableVariables(vs, dgv);
                    break;
                case "dgvDictVariables":
                case "dgvPeDictVariables":
                    switch (e.ColumnIndex)
                    {
                        case 0: newType = "name"; break;
                        case 1: newType = "size"; break;
                        case 2: newType = "value"; break;
                        case 3: newType = "lastchanged"; break;
                        case 4: newType = "lastchanger"; break;
                    }
                    UpdateSortType(newType, dgv, e.ColumnIndex);
                    RefreshDictVariables(vs, dgv);
                    break;
                case "dgvMutexes":
                case "dgvImage":
                case "dgvText":
                case "dgvCallback":
                default:
                    return;
            }
        }

        private void SetHeadersMinWidth(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                Size textSize = TextRenderer.MeasureText(column.HeaderText, dgv.Font);
                column.MinimumWidth = textSize.Width + TextRenderer.MeasureText("M", dgv.Font).Width * 3; //  margin and sorting glyph width 
            }
        }

        private void SetAllHeadersMinWidth(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is DataGridView dgv)
                {
                    SetHeadersMinWidth(dgv);
                }
                SetAllHeadersMinWidth(child);
            }
        }

        #endregion

        #region Scalar variables

        private void dgvScalarVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (btnScalarRemove.Enabled == true)
                {
                    btnScalarRemove_Click(this, null);
                }
            }
        }

        private void dgvPeScalarVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (btnPeScalarRemove.Enabled == true)
                {
                    btnPeScalarRemove_Click(this, null);
                }
            }
        }

        private void dgvScalarVariables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            dgvScalarVariables.ClearSelection();
            dgvScalarVariables.Rows[e.RowIndex].Selected = true;
            btnScalarEdit_Click(sender, null);
        }

        private void dgvPeScalarVariables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            dgvPeScalarVariables.ClearSelection();
            dgvPeScalarVariables.Rows[e.RowIndex].Selected = true;
            btnPeScalarEdit_Click(sender, null);
        }

        private void dgvScalarVariables_SelectionChanged(object sender, EventArgs e)
        {
            btnScalarEdit.Enabled = (dgvScalarVariables.SelectedRows.Count == 1);
            btnScalarRemove.Enabled = (dgvScalarVariables.SelectedRows.Count > 0);
        }

        private void dgvPeScalarVariables_SelectionChanged(object sender, EventArgs e)
        {
            btnPeScalarEdit.Enabled = (dgvPeScalarVariables.SelectedRows.Count == 1);
            btnPeScalarRemove.Enabled = (dgvPeScalarVariables.SelectedRows.Count > 0);
        }

        private void SortScalarVariables(VariableStore vs)
        {
            var variables = vs.Scalar;
            Func<KeyValuePair<string, VariableScalar>, object> selector;

            switch (sortType)
            {
                case "value": selector = kvp => kvp.Value; break;
                case "lastchanged": selector = kvp => kvp.Value.LastChanged; break;
                case "lastchanger": selector = kvp => kvp.Value.LastChanger; break;
                default: selector = kvp => kvp.Key; break;
            }

            lock (vs.Scalar)
            {
                if (sortAsc)
                {
                    sortedVariableKeys = variables.OrderBy(selector).ThenBy(kvp => kvp.Key)
                        .Select(kvp => kvp.Key).ToList();
                }
                else
                {
                    sortedVariableKeys = variables.OrderByDescending(selector).ThenBy(kvp => kvp.Key)
                        .Select(kvp => kvp.Key).ToList();
                }
            }
        }

        private void ScalarCellValueNeeded(VariableStore vs, DataGridViewCellValueEventArgs e)
        {
            lock (vs.Scalar)
            {
                string key = sortedVariableKeys[e.RowIndex];
                if (e.RowIndex >= sortedVariableKeys.Count || !vs.Scalar.ContainsKey(key))
                {
                    return;
                }
                var varValue = vs.Scalar[key];
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = key;
                        break;
                    case 1:
                        e.Value = varValue.Value;
                        break;
                    case 2:
                        e.Value = varValue.LastChanged.ToString();
                        break;
                    case 3:
                        e.Value = varValue.LastChanger;
                        break;
                }
            }
        }

        private void dgvScalarVariables_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            ScalarCellValueNeeded(plug.sessionvars, e);
        }

        private void dgvPeScalarVariables_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            ScalarCellValueNeeded(plug.cfg.PersistentVariables, e);
        }

        private void RefreshScalarVariables(VariableStore vs, DataGridView dgv)
        {
            lock (vs.Scalar)
            {
                dgv.RowCount = vs.Scalar.Count;
                SortScalarVariables(vs);
            }
            Refresh();
        }

        private void AddScalarVariable(VariableStore vs, DataGridView dgv)
        {
            VariableScalar v = new VariableScalar();
            string varname = "";
            v = (VariableScalar)OpenVariableEditor(v, ref varname, true);
            if (v != null)
            {
                lock (vs.Scalar)
                {
                    vs.Scalar[varname] = v;
                }
                RefreshScalarVariables(vs, dgv);
            }
        }

        private void EditScalarVariable(VariableStore vs, DataGridView dgv)
        {
            string varname = "";
            foreach (DataGridViewRow r in dgv.SelectedRows)
            {
                varname = r.Cells[0].Value.ToString();
            }
            VariableScalar v = null;
            lock (vs.Scalar)
            {
                if (vs.Scalar.ContainsKey(varname) == true)
                {
                    v = vs.Scalar[varname];
                }
            }
            if (v == null)
            {
                v = new VariableScalar();
            }
            string varname2 = varname;
            v = (VariableScalar)OpenVariableEditor(v, ref varname2, false);
            if (v != null)
            {
                lock (vs.Scalar)
                {
                    if (varname != varname2)
                    {
                        if (vs.Scalar.ContainsKey(varname) == true)
                        {
                            vs.Scalar.Remove(varname);
                        }
                    }
                    vs.Scalar[varname2] = v;
                }
                RefreshScalarVariables(vs, dgv);
            }
        }

        private void RemoveScalarVariable(VariableStore vs, DataGridView dgv)
        {
            string temp;
            if (dgv.SelectedRows.Count > 1)
            {
                temp = I18n.Translate("internal/VariableForm/areyousureplural", "Are you sure you want to remove the selected variables?");
            }
            else
            {
                temp = I18n.Translate("internal/VariableForm/areyousuresingular", "Are you sure you want to remove the selected variable?");
            }
            switch (MessageBox.Show(this, temp, I18n.Translate("internal/VariableForm/confirmremoval", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    List<string> varnames = new List<string>();
                    foreach (DataGridViewRow r in dgv.SelectedRows)
                    {
                        varnames.Add(r.Cells[0].Value.ToString());
                    }
                    lock (vs.Scalar)
                    {
                        foreach (string varname in varnames)
                        {   // Deleted the key check: Remove() would check if the key exists
                            vs.Scalar.Remove(varname); 
                        }
                        dgv.RowCount = vs.Scalar.Count;
                    }
                    dgv.ClearSelection();
                    RefreshScalarVariables(vs, dgv);
                    break;
            }
        }

        private void RemoveAllScalarVariables(VariableStore vs, DataGridView dgv)
        {
            lock (vs.Scalar)
            {
                vs.Scalar.Clear();
            }
            RefreshScalarVariables(vs, dgv);
        }

        private void btnScalarAdd_Click(object sender, EventArgs e)
        {
            AddScalarVariable(plug.sessionvars, dgvScalarVariables);
        }

        private void btnScalarEdit_Click(object sender, EventArgs e)
        {
            EditScalarVariable(plug.sessionvars, dgvScalarVariables);
        }

        private void btnScalarRemove_Click(object sender, EventArgs e)
        {
            RemoveScalarVariable(plug.sessionvars, dgvScalarVariables);
        }

        private void btnRefreshScalar_ButtonClick(object sender, EventArgs e)
        {
            RefreshScalarVariables(plug.sessionvars, dgvScalarVariables);
        }

        private void btnRemoveAllScalar_Click(object sender, EventArgs e)
        {
            RemoveAllScalarVariables(plug.sessionvars, dgvScalarVariables);
        }

        private void btnPeScalarAdd_Click(object sender, EventArgs e)
        {
            AddScalarVariable(plug.cfg.PersistentVariables, dgvPeScalarVariables);
        }

        private void btnPeScalarEdit_Click(object sender, EventArgs e)
        {
            EditScalarVariable(plug.cfg.PersistentVariables, dgvPeScalarVariables);
        }

        private void btnPeScalarRemove_Click(object sender, EventArgs e)
        {
            RemoveScalarVariable(plug.cfg.PersistentVariables, dgvPeScalarVariables);
        }

        private void btnPeScalarRefresh_ButtonClick(object sender, EventArgs e)
        {
            RefreshScalarVariables(plug.cfg.PersistentVariables, dgvPeScalarVariables);
        }

        private void btnPeScalarRemoveAll_Click(object sender, EventArgs e)
        {
            RemoveAllScalarVariables(plug.cfg.PersistentVariables, dgvPeScalarVariables);
        }

        #endregion

        #region List variables

        private void dgvListVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (btnListRemove.Enabled == true)
                {
                    btnListRemove_Click(this, null);
                }
            }
        }

        private void dgvPeListVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (btnPeListRemove.Enabled == true)
                {
                    btnPeListRemove_Click(this, null);
                }
            }
        }

        private void dgvListVariables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            dgvListVariables.ClearSelection();
            dgvListVariables.Rows[e.RowIndex].Selected = true;
            btnListEdit_Click(sender, null);
        }

        private void dgvPeListVariables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            dgvPeListVariables.ClearSelection();
            dgvPeListVariables.Rows[e.RowIndex].Selected = true;
            btnPeListEdit_Click(sender, null);
        }

        private void SortListVariables(VariableStore vs)
        {
            var variables = vs.List;
            Func<KeyValuePair<string, VariableList>, object> selector;

            switch (sortType)
            {
                case "size": selector = kvp => kvp.Value.Size; break;
                case "value": selector = kvp => kvp.Value; break;
                case "lastchanged": selector = kvp => kvp.Value.LastChanged; break;
                case "lastchanger": selector = kvp => kvp.Value.LastChanger; break;
                default: selector = kvp => kvp.Key; break;
            }

            lock (vs.List)
            {
                if (sortAsc)
                {
                    sortedVariableKeys = variables.OrderBy(selector).ThenBy(kvp => kvp.Key)
                        .Select(kvp => kvp.Key).ToList();
                }
                else
                {
                    sortedVariableKeys = variables.OrderByDescending(selector).ThenBy(kvp => kvp.Key)
                        .Select(kvp => kvp.Key).ToList();
                }
            }
        }

        private void ListCellValueNeeded(VariableStore vs, DataGridViewCellValueEventArgs e)
        {
            lock (vs.List)
            {
                string key = sortedVariableKeys[e.RowIndex];
                if (e.RowIndex >= sortedVariableKeys.Count || !vs.List.ContainsKey(key))
                {
                    return;
                }
                var varValue = vs.List[key];
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = key;
                        break;
                    case 1:
                        e.Value = varValue.Size;
                        break;
                    case 2:
                        e.Value = varValue.Join(", ");
                        break;
                    case 3:
                        e.Value = varValue.LastChanged.ToString();
                        break;
                    case 4:
                        e.Value = varValue.LastChanger;
                        break;
                }
            }
        }

        private void dgvListVariables_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            ListCellValueNeeded(plug.sessionvars, e);
        }

        private void dgvPeListVariables_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            ListCellValueNeeded(plug.cfg.PersistentVariables, e);
        }

        private void dgvListVariables_SelectionChanged(object sender, EventArgs e)
        {
            btnListEdit.Enabled = (dgvListVariables.SelectedRows.Count == 1);
            btnListRemove.Enabled = (dgvListVariables.SelectedRows.Count > 0);
        }

        private void dgvPeListVariables_SelectionChanged(object sender, EventArgs e)
        {
            btnPeListEdit.Enabled = (dgvPeListVariables.SelectedRows.Count == 1);
            btnPeListRemove.Enabled = (dgvPeListVariables.SelectedRows.Count > 0);
        }

        private void RefreshListVariables(VariableStore vs, DataGridView dgv)
        {
            lock (vs.List)
            {
                dgv.RowCount = vs.List.Count;
            }
            SortListVariables(vs);
            Refresh();
        }

        private void AddListVariable(VariableStore vs, DataGridView dgv)
        {
            VariableList v = new VariableList();
            string varname = "";
            v = (VariableList)OpenVariableEditor(v, ref varname, true);
            if (v != null)
            {
                lock (vs.List)
                {
                    vs.List[varname] = v;
                }
                RefreshListVariables(vs, dgv);
            }
        }

        private void EditListVariable(VariableStore vs, DataGridView dgv)
        {
            string varname = "";
            foreach (DataGridViewRow r in dgv.SelectedRows)
            {
                varname = r.Cells[0].Value.ToString();
            }
            VariableList v = null;
            lock (vs.List)
            {
                if (vs.List.ContainsKey(varname) == true)
                {
                    v = vs.List[varname];
                }
            }
            if (v == null)
            {
                v = new VariableList();
            }
            string varname2 = varname;
            v = (VariableList)OpenVariableEditor(v, ref varname2, false);
            if (v != null)
            {
                lock (vs.List)
                {
                    if (varname != varname2)
                    {
                        if (vs.List.ContainsKey(varname) == true)
                        {
                            vs.List.Remove(varname);
                        }
                    }
                    vs.List[varname2] = v;
                }
                RefreshListVariables(vs, dgv);
            }
        }

        private void RemoveListVariable(VariableStore vs, DataGridView dgv)
        {
            string temp;
            if (dgv.SelectedRows.Count > 1)
            {
                temp = I18n.Translate("internal/VariableForm/areyousureplural", "Are you sure you want to remove the selected variables?");
            }
            else
            {
                temp = I18n.Translate("internal/VariableForm/areyousuresingular", "Are you sure you want to remove the selected variable?");
            }
            switch (MessageBox.Show(this, temp, I18n.Translate("internal/VariableForm/confirmremoval", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    List<string> varnames = new List<string>();
                    foreach (DataGridViewRow r in dgv.SelectedRows)
                    {
                        varnames.Add(r.Cells[0].Value.ToString());
                    }
                    lock (vs.List)
                    {
                        foreach (string varname in varnames)
                        {
                            vs.List.Remove(varname);
                        }
                        dgv.RowCount = vs.List.Count;
                    }
                    dgv.ClearSelection();
                    RefreshListVariables(vs, dgv);
                    break;
            }
        }

        private void RemoveAllListVariables(VariableStore vs, DataGridView dgv)
        {
            lock (vs.List)
            {
                vs.List.Clear();
            }
            RefreshListVariables(vs, dgv);
        }

        private void btnListAdd_Click(object sender, EventArgs e)
        {
            AddListVariable(plug.sessionvars, dgvListVariables);
        }

        private void btnListEdit_Click(object sender, EventArgs e)
        {
            EditListVariable(plug.sessionvars, dgvListVariables);
        }

        private void btnListRemove_Click(object sender, EventArgs e)
        {
            RemoveListVariable(plug.sessionvars, dgvListVariables);
        }

        private void btnListRefresh_ButtonClick(object sender, EventArgs e)
        {
            RefreshListVariables(plug.sessionvars, dgvListVariables);
        }

        private void btnListRemoveAll_Click(object sender, EventArgs e)
        {
            RemoveAllListVariables(plug.sessionvars, dgvListVariables);
        }

        private void btnPeListAdd_Click(object sender, EventArgs e)
        {
            AddListVariable(plug.cfg.PersistentVariables, dgvPeListVariables);
        }

        private void btnPeListEdit_Click(object sender, EventArgs e)
        {
            EditListVariable(plug.cfg.PersistentVariables, dgvPeListVariables);
        }

        private void btnPeListRemove_Click(object sender, EventArgs e)
        {
            RemoveListVariable(plug.cfg.PersistentVariables, dgvPeListVariables);
        }

        private void btnPeListRefresh_ButtonClick(object sender, EventArgs e)
        {
            RefreshListVariables(plug.cfg.PersistentVariables, dgvPeListVariables);
        }

        private void btnPeListRemoveAll_Click(object sender, EventArgs e)
        {
            RemoveAllListVariables(plug.cfg.PersistentVariables, dgvPeListVariables);
        }

        #endregion

        #region Table variables

        private void dgvTableVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (btnTableRemove.Enabled == true)
                {
                    btnTableRemove_Click(this, null);
                }
            }
        }

        private void dgvPeTableVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (btnPeTableRemove.Enabled == true)
                {
                    btnPeTableRemove_Click(this, null);
                }
            }
        }

        private void dgvTableVariables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            dgvTableVariables.ClearSelection();
            dgvTableVariables.Rows[e.RowIndex].Selected = true;
            btnTableEdit_Click(sender, null);
        }

        private void dgvPeTableVariables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            dgvPeTableVariables.ClearSelection();
            dgvPeTableVariables.Rows[e.RowIndex].Selected = true;
            btnPeTableEdit_Click(sender, null);
        }

        private void SortTableVariables(VariableStore vs)
        {
            var variables = vs.Table;
            Func<KeyValuePair<string, VariableTable>, object> selector;

            switch (sortType)
            {
                case "width": selector = kvp => kvp.Value.Width; break;
                case "height": selector = kvp => kvp.Value.Height; break;
                case "lastchanged": selector = kvp => kvp.Value.LastChanged; break;
                case "lastchanger": selector = kvp => kvp.Value.LastChanger; break;
                default: selector = kvp => kvp.Key; break;
            }
            lock (vs.Table)
            {
                if (sortAsc)
                {
                    sortedVariableKeys = variables.OrderBy(selector).ThenBy(kvp => kvp.Key)
                        .Select(kvp => kvp.Key).ToList();
                }
                else
                {
                    sortedVariableKeys = variables.OrderByDescending(selector).ThenBy(kvp => kvp.Key)
                        .Select(kvp => kvp.Key).ToList();
                }
            }
        }

        private void TableCellValueNeeded(VariableStore vs, DataGridViewCellValueEventArgs e)
        {
            lock (vs.Table)
            {
                string key = sortedVariableKeys[e.RowIndex];
                if (e.RowIndex >= sortedVariableKeys.Count || !vs.Table.ContainsKey(key))
                {
                    return;
                }
                var varValue = vs.Table[key];
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = key;
                        break;
                    case 1:
                        e.Value = varValue.Width;
                        break;
                    case 2:
                        e.Value = varValue.Height;
                        break;
                    case 3:
                        e.Value = varValue.LastChanged.ToString();
                        break;
                    case 4:
                        e.Value = varValue.LastChanger;
                        break;
                }
            }
        }

        private void dgvTableVariables_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            TableCellValueNeeded(plug.sessionvars, e);
        }

        private void dgvPeTableVariables_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            TableCellValueNeeded(plug.cfg.PersistentVariables, e);
        }

        private void dgvTableVariables_SelectionChanged(object sender, EventArgs e)
        {
            btnTableEdit.Enabled = (dgvTableVariables.SelectedRows.Count == 1);
            btnTableRemove.Enabled = (dgvTableVariables.SelectedRows.Count > 0);
        }

        private void dgvPeTableVariables_SelectionChanged(object sender, EventArgs e)
        {
            btnPeTableEdit.Enabled = (dgvPeTableVariables.SelectedRows.Count == 1);
            btnPeTableRemove.Enabled = (dgvPeTableVariables.SelectedRows.Count > 0);
        }

        private void RefreshTableVariables(VariableStore vs, DataGridView dgv)
        {
            lock (vs.Table)
            {
                dgv.RowCount = vs.Table.Count;
                SortTableVariables(vs);
            }
            Refresh();
        }

        private void AddTableVariable(VariableStore vs, DataGridView dgv)
        {
            VariableTable v = new VariableTable();
            string varname = "";
            v = (VariableTable)OpenVariableEditor(v, ref varname, true);
            if (v != null)
            {
                lock (vs.Table)
                {
                    vs.Table[varname] = v;
                }
                RefreshTableVariables(vs, dgv);
            }
        }

        private void EditTableVariable(VariableStore vs, DataGridView dgv)
        {
            string varname = "";
            foreach (DataGridViewRow r in dgv.SelectedRows)
            {
                varname = r.Cells[0].Value.ToString();
            }
            VariableTable v = null;
            lock (vs.Table)
            {
                if (vs.Table.ContainsKey(varname) == true)
                {
                    v = vs.Table[varname];
                }
            }
            if (v == null)
            {
                v = new VariableTable();
            }
            string varname2 = varname;
            v = (VariableTable)OpenVariableEditor(v, ref varname2, false);
            if (v != null)
            {
                lock (vs.Table)
                {
                    if (varname != varname2)
                    {
                        if (vs.Table.ContainsKey(varname) == true)
                        {
                            vs.Table.Remove(varname);
                        }
                    }
                    vs.Table[varname2] = v;
                }
                RefreshTableVariables(vs, dgv);
            }
        }

        private void RemoveTableVariable(VariableStore vs, DataGridView dgv)
        {
            string temp;
            if (dgv.SelectedRows.Count > 1)
            {
                temp = I18n.Translate("internal/VariableForm/areyousureplural", "Are you sure you want to remove the selected variables?");
            }
            else
            {
                temp = I18n.Translate("internal/VariableForm/areyousuresingular", "Are you sure you want to remove the selected variable?");
            }
            switch (MessageBox.Show(this, temp, I18n.Translate("internal/VariableForm/confirmremoval", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    List<string> varnames = new List<string>();
                    foreach (DataGridViewRow r in dgv.SelectedRows)
                    {
                        varnames.Add(r.Cells[0].Value.ToString());
                    }
                    lock (vs.Table)
                    {
                        foreach (string varname in varnames)
                        {
                            vs.Table.Remove(varname);
                        }
                        dgv.RowCount = vs.Table.Count;
                    }
                    dgv.ClearSelection();
                    RefreshTableVariables(vs, dgv);
                    break;
            }
        }

        private void RemoveAllTableVariables(VariableStore vs, DataGridView dgv)
        {
            lock (vs.Table)
            {
                vs.Table.Clear();
            }
            RefreshTableVariables(vs, dgv);
        }

        private void btnTableAdd_Click(object sender, EventArgs e)
        {
            AddTableVariable(plug.sessionvars, dgvTableVariables);
        }

        private void btnTableEdit_Click(object sender, EventArgs e)
        {
            EditTableVariable(plug.sessionvars, dgvTableVariables);
        }

        private void btnTableRemove_Click(object sender, EventArgs e)
        {
            RemoveTableVariable(plug.sessionvars, dgvTableVariables);
        }

        private void btnTableRefresh_ButtonClick(object sender, EventArgs e)
        {
            RefreshTableVariables(plug.sessionvars, dgvTableVariables);
        }

        private void btnTableRemoveAll_Click(object sender, EventArgs e)
        {
            RemoveAllTableVariables(plug.sessionvars, dgvTableVariables);
        }

        private void btnPeTableAdd_Click(object sender, EventArgs e)
        {
            AddTableVariable(plug.cfg.PersistentVariables, dgvPeTableVariables);
        }

        private void btnPeTableEdit_Click(object sender, EventArgs e)
        {
            EditTableVariable(plug.cfg.PersistentVariables, dgvPeTableVariables);
        }

        private void btnPeTableRemove_Click(object sender, EventArgs e)
        {
            RemoveTableVariable(plug.cfg.PersistentVariables, dgvPeTableVariables);
        }

        private void btnPeTableRefresh_ButtonClick(object sender, EventArgs e)
        {
            RefreshTableVariables(plug.cfg.PersistentVariables, dgvPeTableVariables);
        }

        private void btnPeTableRemoveAll_Click(object sender, EventArgs e)
        {
            RemoveAllTableVariables(plug.cfg.PersistentVariables, dgvPeTableVariables);
        }

        #endregion

        #region Dict variables

        private void dgvDictVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (btnDictRemove.Enabled == true)
                {
                    btnDictRemove_Click(this, null);
                }
            }
        }

        private void dgvPeDictVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (btnPeDictRemove.Enabled == true)
                {
                    btnPeDictRemove_Click(this, null);
                }
            }
        }

        private void dgvDictVariables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            dgvDictVariables.ClearSelection();
            dgvDictVariables.Rows[e.RowIndex].Selected = true;
            btnDictEdit_Click(sender, null);
        }

        private void dgvPeDictVariables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            dgvPeDictVariables.ClearSelection();
            dgvPeDictVariables.Rows[e.RowIndex].Selected = true;
            btnPeDictEdit_Click(sender, null);
        }

        private void SortDictVariables(VariableStore vs)
        {
            var variables = vs.Dict;
            Func<KeyValuePair<string, VariableDictionary>, object> selector;

            switch (sortType)
            {
                case "size": selector = kvp => kvp.Value.Size; break;
                case "value": selector = kvp => kvp.Value; break;
                case "lastchanged": selector = kvp => kvp.Value.LastChanged; break;
                case "lastchanger": selector = kvp => kvp.Value.LastChanger; break;
                default: selector = kvp => kvp.Key; break;
            }

            lock (vs.Dict)
            {
                if (sortAsc)
                {
                    sortedVariableKeys = variables.OrderBy(selector).ThenBy(kvp => kvp.Key)
                        .Select(kvp => kvp.Key).ToList();
                }
                else
                {
                    sortedVariableKeys = variables.OrderByDescending(selector).ThenBy(kvp => kvp.Key)
                        .Select(kvp => kvp.Key).ToList();
                }
            }
        }

        private void DictCellValueNeeded(VariableStore vs, DataGridViewCellValueEventArgs e)
        {
            lock (vs.Dict)
            {
                string key = sortedVariableKeys[e.RowIndex];
                if (e.RowIndex >= sortedVariableKeys.Count || !vs.Dict.ContainsKey(key))
                {
                    return;
                }
                var varDict = vs.Dict[key];
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = key;
                        break;
                    case 1:
                        e.Value = varDict.Size;
                        break;
                    case 2:
                        e.Value = varDict.JoinAll(":", ", ");
                        break;
                    case 3:
                        e.Value = varDict.LastChanged.ToString();
                        break;
                    case 4:
                        e.Value = varDict.LastChanger;
                        break;
                }
            }
        }

        private void dgvDictVariables_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DictCellValueNeeded(plug.sessionvars, e);
        }

        private void dgvPeDictVariables_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DictCellValueNeeded(plug.cfg.PersistentVariables, e);
        }

        private void dgvDictVariables_SelectionChanged(object sender, EventArgs e)
        {
            btnDictEdit.Enabled = (dgvDictVariables.SelectedRows.Count == 1);
            btnDictRemove.Enabled = (dgvDictVariables.SelectedRows.Count > 0);
        }

        private void dgvPeDictVariables_SelectionChanged(object sender, EventArgs e)
        {
            btnPeDictEdit.Enabled = (dgvPeDictVariables.SelectedRows.Count == 1);
            btnPeDictRemove.Enabled = (dgvPeDictVariables.SelectedRows.Count > 0);
        }

        private void RefreshDictVariables(VariableStore vs, DataGridView dgv)
        {
            lock (vs.Dict)
            {
                dgv.RowCount = vs.Dict.Count;
                SortDictVariables(vs);
            }
            Refresh();
        }

        private void AddDictVariable(VariableStore vs, DataGridView dgv)
        {
            VariableDictionary v = new VariableDictionary();
            string varname = "";
            v = (VariableDictionary)OpenVariableEditor(v, ref varname, true);
            if (v != null)
            {
                lock (vs.Dict)
                {
                    vs.Dict[varname] = v;
                }
                RefreshDictVariables(vs, dgv);
            }
        }

        private void EditDictVariable(VariableStore vs, DataGridView dgv)
        {
            string varname = "";
            foreach (DataGridViewRow r in dgv.SelectedRows)
            {
                varname = r.Cells[0].Value.ToString();
            }
            VariableDictionary v = null;
            lock (vs.Dict)
            {
                if (vs.Dict.ContainsKey(varname) == true)
                {
                    v = vs.Dict[varname];
                }
            }
            if (v == null)
            {
                v = new VariableDictionary();
            }
            string varname2 = varname;
            v = (VariableDictionary)OpenVariableEditor(v, ref varname2, false);
            if (v != null)
            {
                lock (vs.Dict)
                {
                    if (varname != varname2)
                    {
                        if (vs.Dict.ContainsKey(varname) == true)
                        {
                            vs.Dict.Remove(varname);
                        }
                    }
                    vs.Dict[varname2] = v;
                }
                RefreshDictVariables(vs, dgv);
            }
        }

        private void RemoveDictVariable(VariableStore vs, DataGridView dgv)
        {
            string temp;
            if (dgv.SelectedRows.Count > 1)
            {
                temp = I18n.Translate("internal/VariableForm/areyousureplural", "Are you sure you want to remove the selected variables?");
            }
            else
            {
                temp = I18n.Translate("internal/VariableForm/areyousuresingular", "Are you sure you want to remove the selected variable?");
            }
            switch (MessageBox.Show(this, temp, I18n.Translate("internal/VariableForm/confirmremoval", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    List<string> varnames = new List<string>();
                    foreach (DataGridViewRow r in dgv.SelectedRows)
                    {
                        varnames.Add(r.Cells[0].Value.ToString());
                    }
                    lock (vs.Dict)
                    {
                        foreach (string varname in varnames)
                        {
                            vs.Dict.Remove(varname);
                        }
                        dgv.RowCount = vs.Dict.Count;
                    }
                    dgv.ClearSelection();
                    RefreshDictVariables(vs, dgv);
                    break;
            }
        }

        private void RemoveAllDictVariables(VariableStore vs, DataGridView dgv)
        {
            lock (vs.Dict)
            {
                vs.Dict.Clear();
            }
            RefreshDictVariables(vs, dgv);
        }

        private void btnDictAdd_Click(object sender, EventArgs e)
        {
            AddDictVariable(plug.sessionvars, dgvDictVariables);
        }

        private void btnDictEdit_Click(object sender, EventArgs e)
        {
            EditDictVariable(plug.sessionvars, dgvDictVariables);
        }

        private void btnDictRemove_Click(object sender, EventArgs e)
        {
            RemoveDictVariable(plug.sessionvars, dgvDictVariables);
        }

        private void btnDictRefresh_ButtonClick(object sender, EventArgs e)
        {
            RefreshDictVariables(plug.sessionvars, dgvDictVariables);
        }

        private void btnDictRemoveAll_Click(object sender, EventArgs e)
        {
            RemoveAllDictVariables(plug.sessionvars, dgvDictVariables);
        }

        private void btnPeDictAdd_Click(object sender, EventArgs e)
        {
            AddDictVariable(plug.cfg.PersistentVariables, dgvPeDictVariables);
        }

        private void btnPeDictEdit_Click(object sender, EventArgs e)
        {
            EditDictVariable(plug.cfg.PersistentVariables, dgvPeDictVariables);
        }

        private void btnPeDictRemove_Click(object sender, EventArgs e)
        {
            RemoveDictVariable(plug.cfg.PersistentVariables, dgvPeDictVariables);
        }

        private void btnPeDictRefresh_ButtonClick(object sender, EventArgs e)
        {
            RefreshDictVariables(plug.cfg.PersistentVariables, dgvPeDictVariables);
        }

        private void btnPeDictRemoveAll_Click(object sender, EventArgs e)
        {
            RemoveAllDictVariables(plug.cfg.PersistentVariables, dgvPeDictVariables);
        }

        #endregion

        #region Mutexes

        private void dgvMutexes_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            lock (plug.mutexes)
            {
                if (e.RowIndex >= plug.mutexes.Count)
                {
                    return;
                }
                KeyValuePair<string, RealPlugin.MutexInformation> kp = plug.mutexes.ElementAt(e.RowIndex);
                lock (kp.Value)
                {
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = kp.Key;
                            break;
                        case 1:
                            e.Value = kp.Value.heldBy != null ? kp.Value.heldBy.ToString() : "Not owned";
                            break;
                        case 2:
                            e.Value = kp.Value.refCount.ToString();
                            break;
                        case 3:
                            {
                                List<string> acx = new List<string>();
                                foreach (RealPlugin.MutexTicket m in kp.Value.acquireQueue)
                                {
                                    acx.Add(m.ctx.ToString());
                                }
                                e.Value = String.Join(", ", acx);
                            }
                            break;
                    }
                }
            }
        }

        private void RefreshMutexes()
        {
            lock (plug.mutexes)
            {
                dgvMutexes.RowCount = plug.mutexes.Count;
            }
            Refresh();
        }

        private void btnMutexRefresh_Click(object sender, EventArgs e)
        {
            RefreshMutexes();
        }

        private void btnMutexForce_Click(object sender, EventArgs e)
        {
            List<string> mnames = new List<string>();
            foreach (DataGridViewRow r in dgvMutexes.SelectedRows)
            {
                mnames.Add(r.Cells[0].Value.ToString());
            }
            lock (plug.mutexes)
            {
                foreach (string mname in mnames)
                {
                    if (plug.mutexes.ContainsKey(mname) == true)
                    {
                        plug.mutexes[mname].ForceRelease();
                    }
                }                
            }
            btnMutexRefresh_Click(sender, e);
        }

        private void dgvMutexes_SelectionChanged(object sender, EventArgs e)
        {
            btnMutexForce.Enabled = (dgvMutexes.SelectedRows.Count > 0);
        }

        #endregion

        #region Image auras
        private void RefreshImageAuras()
        {

            if (plug.sc != null)
            {
                lock (plug.sc.imageitems)
                {
                    dgvImage.RowCount = plug.sc.imageitems.Count;
                }
            }
            else
            {
                lock (plug.imageauras)
                {
                    dgvImage.RowCount = plug.imageauras.Count;
                }
            }
            Refresh();
        }

        private void btnImageRefresh_Click(object sender, EventArgs e)
        {
            dgvImage.ClearSelection();
            RefreshImageAuras();
        }

        private void dgvImage_SelectionChanged(object sender, EventArgs e)
        {
            btnImageForce.Enabled = (dgvImage.SelectedRows.Count > 0);
        }

        private void btnImageForce_Click(object sender, EventArgs e)
        {
            List<string> anames = new List<string>();
            foreach (DataGridViewRow r in dgvImage.SelectedRows)
            {
                anames.Add(r.Cells[0].Value.ToString());
            }
            if (plug.sc != null)
            {
                Scarborough.Scarborough.ItemAction ia = new Scarborough.Scarborough.ItemAction();
                ia.Action = Scarborough.Scarborough.ItemAction.ActionTypeEnum.Deactivate;
                ia.Item = null;
                ia.ItemType = Scarborough.Scarborough.ItemAction.ItemTypeEnum.Image;
                foreach (string aname in anames)
                {
                    ia.Id = aname;
                    plug.sc.ExecuteAction(ia);
                }
            }
            else
            {
                foreach (string aname in anames)
                {
                    lock (plug.imageauras)
                    {
                        if (plug.imageauras.ContainsKey(aname) == true)
                        {
                            Forms.AuraContainerForm acf = plug.imageauras[aname];
                            acf.AuraDeactivate();
                        }
                    }
                }
            }
            btnImageRefresh_Click(sender, e);
        }

        private void dgvImage_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (plug.sc != null)
            {
                lock (plug.sc.imageitems)
                {
                    if (e.RowIndex >= plug.sc.imageitems.Count)
                    {
                        return;
                    }
                    KeyValuePair<string, Scarborough.ScarboroughImage> kp = plug.sc.imageitems.ElementAt(e.RowIndex);
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = kp.Key;
                            break;
                        case 1:
                            e.Value = kp.Value.ctx != null ? kp.Value.ctx.ToString() : "(unknown)";
                            break;
                    }
                }
            }
            else
            {
                lock (plug.imageauras)
                {
                    if (e.RowIndex >= plug.imageauras.Count)
                    {
                        return;
                    }
                    KeyValuePair<string, AuraContainerForm> kp = plug.imageauras.ElementAt(e.RowIndex);
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = kp.Key;
                            break;
                        case 1:
                            e.Value = kp.Value.ctx != null ? kp.Value.ctx.ToString() : "(unknown)";
                            break;
                    }
                }
            }
        }
        #endregion

        #region Text auras
        private void RefreshTextAuras()
        {
            if (plug.sc != null)
            {
                lock (plug.sc.textitems)
                {
                    dgvText.RowCount = plug.sc.textitems.Count;
                }
            }
            else
            {
                lock (plug.textauras)
                {
                    dgvText.RowCount = plug.textauras.Count;
                }
            }
            Refresh();
        }

        private void btnTextRefresh_Click(object sender, EventArgs e)
        {
            dgvText.ClearSelection();
            RefreshTextAuras();
        }

        private void dgvText_SelectionChanged(object sender, EventArgs e)
        {
            btnTextForce.Enabled = (dgvText.SelectedRows.Count > 0);
        }

        private void btnTextForce_Click(object sender, EventArgs e)
        {
            List<string> anames = new List<string>();
            foreach (DataGridViewRow r in dgvText.SelectedRows)
            {
                anames.Add(r.Cells[0].Value.ToString());
            }
            if (plug.sc != null)
            {
                Scarborough.Scarborough.ItemAction ia = new Scarborough.Scarborough.ItemAction();
                ia.Action = Scarborough.Scarborough.ItemAction.ActionTypeEnum.Deactivate;
                ia.Item = null;
                ia.ItemType = Scarborough.Scarborough.ItemAction.ItemTypeEnum.Text;
                foreach (string aname in anames)
                {
                    ia.Id = aname;
                    plug.sc.ExecuteAction(ia);
                }
            }
            else
            {
                foreach (string aname in anames)
                {
                    lock (plug.textauras)
                    {
                        if (plug.textauras.ContainsKey(aname) == true)
                        {
                            Forms.AuraContainerForm acf = plug.textauras[aname];
                            acf.AuraDeactivate();
                        }
                    }
                }
            }
            btnTextRefresh_Click(sender, e);
        }

        private void dgvText_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (plug.sc != null)
            {
                lock (plug.sc.textitems)
                {
                    if (e.RowIndex >= plug.sc.textitems.Count)
                    {
                        return;
                    }
                    KeyValuePair<string, Scarborough.ScarboroughText> kp = plug.sc.textitems.ElementAt(e.RowIndex);
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = kp.Key;
                            break;
                        case 1:
                            e.Value = kp.Value.ctx != null ? kp.Value.ctx.ToString() : "(unknown)";
                            break;
                    }
                }
            }
            else
            {
                lock (plug.textauras)
                {
                    if (e.RowIndex >= plug.textauras.Count)
                    {
                        return;
                    }
                    KeyValuePair<string, AuraContainerForm> kp = plug.textauras.ElementAt(e.RowIndex);
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = kp.Key;
                            break;
                        case 1:
                            e.Value = kp.Value.ctx != null ? kp.Value.ctx.ToString() : "(unknown)";
                            break;
                    }
                }
            }
        }
        #endregion

        #region Named callbacks
        private void RefreshNamedCallbacks()
        {
            lock (plug.callbacksById)
            {
                dgvCallback.RowCount = plug.callbacksById.Count;
            }
            Refresh();
        }

        private void btnCallbackRefresh_Click(object sender, EventArgs e)
        {
            RefreshNamedCallbacks();
        }

        private void dgvCallback_SelectionChanged(object sender, EventArgs e)
        {
            dgvCallback.ClearSelection();
        }

        private void dgvCallback_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            lock (plug.callbacksById)
            {
                if (e.RowIndex >= plug.callbacksById.Count)
                {
                    return;
                }
                int cbid = plug.callbacksById.Keys.ElementAt(e.RowIndex);
                RealPlugin.NamedCallback cb = plug.callbacksById[cbid];
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = cb.Id.ToString(CultureInfo.InvariantCulture);
                        break;
                    case 1:
                        e.Value = cb.Name; break;
                    case 2:
                        e.Value = cb.Registrant; break;
                    case 3:
                        e.Value = cb.RegistrationTime.ToString(); break;
                    case 4:
                        e.Value = cb.LastInvoked?.ToString() ?? ""; break;
                }
            }
        }
        #endregion

    }

}
