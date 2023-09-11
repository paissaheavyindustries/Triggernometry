using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Triggernometry.CustomControls;
using Triggernometry.Variables;

namespace Triggernometry.Forms
{

    public partial class VariableEditorForm : MemoryForm<VariableEditorForm>
    {

        public string VariableName
        {
            get
            {
                return txtVariableName.Text;
            }
            set
            {
                txtVariableName.Text = value;
            }
        }

        public Variable VariableToEdit { get; set; } = null;
        public bool IsNew { get; set; } = false;

        private StringFormat sf = null;
        private int prevx;
        private int prevy;

        public VariableEditorForm()
        {
            InitializeComponent();
            Disposed += VariableEditorForm_Disposed;
            sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            sf.LineAlignment = StringAlignment.Center;            
            Shown += VariableEditorForm_Shown;
            dgvVariableData.RowHeadersDefaultCellStyle.Padding = new Padding(dgvVariableData.RowHeadersWidth);
            dgvVariableData.RowPostPaint += DgvVariableData_RowPostPaint;
            RestoredSavedDimensions();
        }

        private void VariableEditorForm_Disposed(object sender, EventArgs e)
        {
            if (sf != null)
            {
                sf.Dispose();
                sf = null;
            }
        }

        private void DgvVariableData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            object o = dgvVariableData.Rows[e.RowIndex].HeaderCell.Value;
            Rectangle r = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvVariableData.RowHeadersWidth - 5, e.RowBounds.Height);
            e.Graphics.DrawString(o != null ? o.ToString() : "", dgvVariableData.Font, SystemBrushes.ControlText, r, sf);
        }

        private void VariableEditorForm_Shown(object sender, EventArgs e)
        {
            InitializeValueDisplay();
            dgvVariableData.ClearSelection();
            txtVariableName.Focus();
        }

        private DataGridViewColumn CreateNewColumn(string name, string text)
        {
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.HeaderText = text;            
            col.SortMode = DataGridViewColumnSortMode.NotSortable;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            return col;
        }

        private void InitializeValueDisplay()
        {
            if (VariableToEdit is VariableScalar)
            {
                tlsOptionsList.Visible = false;
                tlsOptionsTable.Visible = false;
                tlsOptionsDict.Visible = false;
                DataGridViewColumn col = CreateNewColumn("col1", I18n.Translate("internal/VariableEditorForm/colvalue", "Value"));
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvVariableData.Columns.Add(col);
                dgvVariableData.RowCount = 1;
                dgvVariableData.RowHeadersVisible = false;
            }
            else if (VariableToEdit is VariableList)
            {
                tlsOptionsList.Visible = true;
                tlsOptionsTable.Visible = false;
                tlsOptionsDict.Visible = false;
                VariableList v = (VariableList)VariableToEdit;
                DataGridViewColumn col = CreateNewColumn("col1", I18n.Translate("internal/VariableEditorForm/colvalue", "Value"));
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                
                dgvVariableData.Columns.Add(col);
                dgvVariableData.RowCount = v.Size;
                RenumberRows();            
                dgvVariableData.RowHeadersVisible = true;
            }
            else if (VariableToEdit is VariableTable)
            {
                tlsOptionsList.Visible = false;
                tlsOptionsTable.Visible = true;
                tlsOptionsDict.Visible = false;
                VariableTable v = (VariableTable)VariableToEdit;
                for (int x = 0; x < v.Width; x++)
                {
                    DataGridViewColumn col = CreateNewColumn("col" + (x + 1), (x + 1).ToString());
                    dgvVariableData.Columns.Add(col);
                }
                dgvVariableData.RowCount = v.Height;
                RenumberRows();
                dgvVariableData.RowHeadersVisible = true;
            }
            else if (VariableToEdit is VariableDictionary)
            {
                tlsOptionsList.Visible = false;
                tlsOptionsTable.Visible = false;
                tlsOptionsDict.Visible = true;
                VariableDictionary v = (VariableDictionary)VariableToEdit;

                DataGridViewColumn colKey = CreateNewColumn("colDictKey", I18n.Translate("internal/VariableEditorForm/coldictkey", "Key"));
                colKey.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colKey.FillWeight = 33.3F;
                dgvVariableData.Columns.Add(colKey);

                DataGridViewColumn colValue = CreateNewColumn("colDictValue", I18n.Translate("internal/VariableEditorForm/coldictvalue", "Value"));
                colValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colValue.FillWeight = 66.7F;
                dgvVariableData.Columns.Add(colValue);

                dgvVariableData.RowCount = v.Size;
                RenumberRows();
                dgvVariableData.RowHeadersVisible = true;
            }
        }

        private void dgvVariableData_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (VariableToEdit is VariableScalar)
            {
                VariableScalar v = (VariableScalar)VariableToEdit;
                e.Value = v.Value;
            }
            else if (VariableToEdit is VariableList)
            {
                VariableList v = (VariableList)VariableToEdit;
                e.Value = e.RowIndex < v.Values.Count ? v.Values[e.RowIndex].ToString() : null;
            }
            else if (VariableToEdit is VariableTable)
            {
                VariableTable v = (VariableTable)VariableToEdit;
                Variable vx = e.RowIndex < v.Height && e.ColumnIndex < v.Width ? v.Rows[e.RowIndex].Values[e.ColumnIndex] : null;
                e.Value = vx != null ? vx.ToString() : "";
            }
            else if (VariableToEdit is VariableDictionary)
            {
                VariableDictionary v = (VariableDictionary)VariableToEdit;
                //var sortedKeys = v.Values.Keys.OrderBy(k => k).ToList();
                if (e.RowIndex < v.Size)
                {
                    var kv = v.Values.ElementAt(e.RowIndex);
                    e.Value = (e.ColumnIndex == 0) ? kv.Key
                            : (e.ColumnIndex == 1) ? kv.Value.ToString() 
                            : "";
                }
                else
                {
                    e.Value = "";
                }
            }
        }

        private bool isInCellValuePushed = false;
        private void dgvVariableData_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            if (isInCellValuePushed) return;
            isInCellValuePushed = true;    // switch back to false before each "return"

            if (VariableToEdit is VariableScalar)
            {
                VariableScalar v = (VariableScalar)VariableToEdit;
                v.Value = (e != null && e.Value != null) ? e.Value.ToString() : "";
            }
            else if (VariableToEdit is VariableList)
            {
                VariableList v = (VariableList)VariableToEdit;
                v.Values[e.RowIndex] = new VariableScalar() { Value = (e != null && e.Value != null) ? e.Value.ToString() : "" };
            }
            else if (VariableToEdit is VariableTable)
            {
                VariableTable v = (VariableTable)VariableToEdit;
                v.Rows[e.RowIndex].Values[e.ColumnIndex] = new VariableScalar() { Value = (e != null && e.Value != null) ? e.Value.ToString() : "" };
            }
            else if (VariableToEdit is VariableDictionary)
            {
                bool isKey = (e.ColumnIndex == 0);
                int rowIndex = e.RowIndex;
                string data = (e.Value ?? "").ToString();
                
                VariableDictionary v = (VariableDictionary)VariableToEdit;
                string oldKey = dgvVariableData.Rows[rowIndex].Cells[0].Value.ToString();
                if (isKey)
                {
                    if (oldKey == data)  // key not changed
                    {
                        isInCellValuePushed = false;
                        return; 
                    }
                    if (!v.Values.ContainsKey(data))  // set a new key
                    {
                        v.Values[data] = new VariableScalar() { Value = dgvVariableData.Rows[rowIndex].Cells[1].Value.ToString() };
                        v.Values.Remove(oldKey);
                    }
                    else  // key already exists
                    {
                        for (int i = 0; i < dgvVariableData.Rows.Count; i++)
                        {
                            if (dgvVariableData.Rows[i].Cells[0].Value.ToString() == data)
                            {
                                BeginInvoke((MethodInvoker)delegate ()
                                {   // otherwise the selected grid will be the user-selected one
                                    dgvVariableData.CurrentCell = dgvVariableData.Rows[i].Cells[0];
                                });
                                MessageBox.Show(I18n.Translate("internal/VariableForm/keyexists", 
                                    "The key {0} already exists (row {1}).", data, i + 1));
                                isInCellValuePushed = false;
                                return;
                            }
                        }
                    }
                    dgvVariableData.Refresh();
                }
                else // value edited
                {
                    v.SetValue(oldKey, data);
                }
            }
            isInCellValuePushed = false;
        }

        private void dgvVariableData_SelectionChanged(object sender, EventArgs e)
        {
            bool enableBtnRemove = (dgvVariableData.SelectedCells.Count > 0);
            btnColumnRemove.Enabled = enableBtnRemove;
            btnRowRemove.Enabled = enableBtnRemove;
            btnItemRemove.Enabled = enableBtnRemove;
            btnKeyRemove.Enabled = enableBtnRemove;
        }

        private void RenumberRows()
        {
            for (int i = 1; i <= dgvVariableData.RowCount; i++)
            {
                dgvVariableData.Rows[i - 1].HeaderCell.Value = i.ToString();
            }
        }

        private void RenumberColumns()
        {
            VariableTable v = (VariableTable)VariableToEdit;
            while (v.Width < dgvVariableData.ColumnCount)
            {
                dgvVariableData.Columns.RemoveAt(dgvVariableData.ColumnCount - 1);
            }
            while (v.Width > dgvVariableData.ColumnCount)
            {
                dgvVariableData.Columns.Add(CreateNewColumn("col", ""));
            }
            for (int i = 1; i <= dgvVariableData.ColumnCount; i++)
            {
                DataGridViewColumn c = dgvVariableData.Columns[i - 1];
                c.HeaderText = i.ToString();
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void ResetEdit()
        {
            dgvVariableData.EndEdit();
            dgvVariableData.EditMode = DataGridViewEditMode.EditProgrammatically;
            PushEdit();
            dgvVariableData.CurrentCell = null;
            dgvVariableData.EditMode = DataGridViewEditMode.EditOnEnter;            
        }

        private void PushEdit()
        {
            prevx = dgvVariableData.CurrentCell != null ? dgvVariableData.CurrentCell.ColumnIndex : 0;
            prevy = dgvVariableData.CurrentCell != null ? dgvVariableData.CurrentCell.RowIndex : 0;
        }

        private void RestoreEdit()
        {
            if (prevx >= dgvVariableData.ColumnCount)
            {
                prevx = dgvVariableData.ColumnCount - 1;
            }
            if (prevy >= dgvVariableData.RowCount)
            {
                prevy = dgvVariableData.RowCount - 1;
            }
            dgvVariableData.CurrentCell = prevx >= 0 && prevy >= 0 ? dgvVariableData.Rows[prevy].Cells[prevx] : null;
        }

        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            int idx = 0;
            if (dgvVariableData.SelectedCells.Count > 0)
            {
                DataGridViewCell c = dgvVariableData.SelectedCells[0];
                idx = c.RowIndex;
            }
            ResetEdit();
            VariableList v = (VariableList)VariableToEdit;
            if (idx >= v.Values.Count)
            {
                idx = v.Values.Count - 1;
            }
            v.Values.Insert(idx + 1, new VariableScalar());
            dgvVariableData.RowCount++;
            RenumberRows();
            dgvVariableData.Refresh();
            dgvVariableData.CurrentCell = dgvVariableData.Rows[idx + 1].Cells[0];
        }

        private void btnItemInsert_Click(object sender, EventArgs e)
        {
            int idx = 0;
            if (dgvVariableData.SelectedCells.Count > 0)
            {
                DataGridViewCell c = dgvVariableData.SelectedCells[0];
                idx = c.RowIndex;
            }
            ResetEdit();
            VariableList v = (VariableList)VariableToEdit;
            v.Values.Insert(idx, new VariableScalar());
            dgvVariableData.RowCount++;
            RenumberRows();
            dgvVariableData.Refresh();
            RestoreEdit();
        }

        private void btnItemRemove_Click(object sender, EventArgs e)
        {
            int idx = 0;
            if (dgvVariableData.SelectedCells.Count > 0)
            {
                DataGridViewCell c = dgvVariableData.SelectedCells[0];
                idx = c.RowIndex;
            }
            ResetEdit();
            VariableList v = (VariableList)VariableToEdit;
            v.Values.RemoveAt(idx);
            dgvVariableData.RowCount--;
            RenumberRows();
            dgvVariableData.Refresh();
            RestoreEdit();
        }

        private void btnRowAdd_Click(object sender, EventArgs e)
        {
            int rowIndex = 0;
            int colIndex = 0;
            dgvVariableData.EndEdit();
            if (dgvVariableData.SelectedCells.Count > 0)
            {
                DataGridViewCell c = dgvVariableData.SelectedCells[0];
                rowIndex = c.RowIndex;
                colIndex = c.ColumnIndex;
            }
            ResetEdit();
            VariableTable v = (VariableTable)VariableToEdit;
            v.InsertRow(rowIndex + 1);
            dgvVariableData.RowCount++;
            RenumberRows();
            RenumberColumns();
            dgvVariableData.Refresh();
            dgvVariableData.CurrentCell = dgvVariableData.Rows[rowIndex + 1].Cells[colIndex];
        }

        private void btnRowInsert_Click(object sender, EventArgs e)
        {
            int idx = 0;
            dgvVariableData.EndEdit();
            if (dgvVariableData.SelectedCells.Count > 0)
            {
                DataGridViewCell c = dgvVariableData.SelectedCells[0];
                idx = c.RowIndex;
            }
            ResetEdit();
            VariableTable v = (VariableTable)VariableToEdit;
            v.InsertRow(idx);
            dgvVariableData.RowCount++;
            RenumberRows();
            RenumberColumns();
            dgvVariableData.Refresh();
            RestoreEdit();
        }

        private void btnRowRemove_Click(object sender, EventArgs e)
        {
            int idx = 0;            
            if (dgvVariableData.SelectedCells.Count > 0)
            {
                DataGridViewCell c = dgvVariableData.SelectedCells[0];
                idx = c.RowIndex;
            }
            ResetEdit();
            VariableTable v = (VariableTable)VariableToEdit;
            v.RemoveRow(idx);
            dgvVariableData.RowCount--;
            RenumberRows();
            RenumberColumns();
            dgvVariableData.Refresh();
            RestoreEdit();
        }

        private void btnColumnAdd_Click(object sender, EventArgs e)
        {
            int rowIndex = 0;
            int colIndex = 0;
            dgvVariableData.EndEdit();
            if (dgvVariableData.SelectedCells.Count > 0)
            {
                DataGridViewCell c = dgvVariableData.SelectedCells[0];
                rowIndex = c.RowIndex;
                colIndex = c.ColumnIndex;
            }
            ResetEdit();
            VariableTable v = (VariableTable)VariableToEdit;
            v.InsertColumn(colIndex + 1);
            if (dgvVariableData.RowCount != v.Height)
            {
                dgvVariableData.RowCount = v.Height;
            }
            RenumberRows();
            RenumberColumns();
            dgvVariableData.Refresh();
            dgvVariableData.CurrentCell = dgvVariableData.Rows[rowIndex].Cells[colIndex + 1];
        }

        private void btnColumnInsert_Click(object sender, EventArgs e)
        {
            int idx = 0;
            if (dgvVariableData.SelectedCells.Count > 0)
            {
                DataGridViewCell c = dgvVariableData.SelectedCells[0];
                idx = c.ColumnIndex;
            }
            ResetEdit();
            VariableTable v = (VariableTable)VariableToEdit;
            v.InsertColumn(idx);
            if (dgvVariableData.RowCount != v.Height)
            {
                dgvVariableData.RowCount = v.Height;
            }
            RenumberRows();
            RenumberColumns();
            dgvVariableData.Refresh();
            RestoreEdit();
        }

        private void btnColumnRemove_Click(object sender, EventArgs e)
        {
            int idx = 0;
            if (dgvVariableData.SelectedCells.Count > 0)
            {
                DataGridViewCell c = dgvVariableData.SelectedCells[0];
                idx = c.ColumnIndex;
            }
            ResetEdit();
            VariableTable v = (VariableTable)VariableToEdit;
            v.RemoveColumn(idx);
            if (dgvVariableData.RowCount != v.Height)
            {
                dgvVariableData.RowCount = v.Height;
            }
            RenumberRows();
            RenumberColumns();
            dgvVariableData.Refresh();
            RestoreEdit();
        }

        private void btnSaveAsCsv_Click(object sender, EventArgs e) 
        {
            saveFileDialog1.FileName = txtVariableName.Text + ".csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                VariableTable v = (VariableTable)VariableToEdit;
                File.WriteAllText(saveFileDialog1.FileName, v.ToCSVString());
            }
        }

        private void btnKeyAdd_Click(object sender, EventArgs e)
        {
            ResetEdit();
            VariableDictionary vd = (VariableDictionary)VariableToEdit;
            if (!vd.Values.ContainsKey(""))
            {
                vd.Values[""] = new VariableScalar();
                dgvVariableData.RowCount++;
            }
            RenumberRows();
            dgvVariableData.Refresh();
            dgvVariableData.CurrentCell = dgvVariableData.Rows[dgvVariableData.RowCount - 1].Cells[0];
            RestoreEdit();
        }

        private void btnKeyRemove_Click(object sender, EventArgs e)
        {
            if (dgvVariableData.SelectedCells.Count <= 0) { return; }
            DataGridViewCell c = dgvVariableData.SelectedCells[0];
            string key = dgvVariableData.Rows[c.RowIndex].Cells[0].Value.ToString();
            ResetEdit();
            VariableDictionary vd = (VariableDictionary)VariableToEdit;
            if (vd.Values.Remove(key))
            {
                dgvVariableData.RowCount--;
            }
            RenumberRows();
            dgvVariableData.Refresh();
            RestoreEdit();
        }
    }

}
