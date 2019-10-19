using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.CustomControls
{

    public partial class DataGridViewEx : DataGridView
    {

        private DataGridViewCell CellEdited { get; set; } = null;

        public DataGridViewEx()
        {
            InitializeComponent();
            CellBeginEdit += DataGridViewEx_CellBeginEdit;
            CellEndEdit += DataGridViewEx_CellEndEdit;
        }

        private void DataGridViewEx_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            CellEdited = Rows[e.RowIndex].Cells[e.ColumnIndex];
        }

        private void DataGridViewEx_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CellEdited = null;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                EndEdit();
                ClearSelection();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

    }

}
