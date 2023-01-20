using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Triggernometry.Forms
{

    public partial class KeyListenForm : MemoryForm<KeyListenForm>
    {

        public Keys CurrentKey { get; set; } = Keys.None;

        public KeyListenForm()
        {
            InitializeComponent();
            RestoredSavedDimensions();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.ControlKey))
            {
                keyData = Keys.Control;
            }
            if (keyData == (Keys.Alt | Keys.Menu))
            {
                keyData = Keys.Alt;
            }
            if (keyData == (Keys.Control | Keys.Alt | Keys.Menu))
            {
                keyData = Keys.Alt | Keys.Control;
            }
            if (keyData == (Keys.Shift | Keys.ShiftKey))
            {
                keyData = Keys.Shift;
            }
            string keyRep = new System.Windows.Forms.KeysConverter().ConvertToString(keyData);
            CurrentKey = keyData;
            lblKeypress.Text = keyRep;
            return true;
        }

    }

}
