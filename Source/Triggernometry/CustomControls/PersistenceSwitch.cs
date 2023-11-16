using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.CustomControls
{

    public partial class PersistenceSwitch : UserControl
    {

        private bool _IsPersistent = false;
        public bool IsPersistent
        {
            get
            {
                return _IsPersistent;
            }
            set
            {
                if (_IsPersistent != value)
                {
                    _IsPersistent = value;
                    RelatedTextbox.IsPersistent = value;
                    RefreshIcon();
                }
            }
        }

        public PersistenceSwitch()
        {
            InitializeComponent();
            Tag = BackgroundImage;
            Click += PersistenceSwitch_Click;
            DoubleClick += PersistenceSwitch_Click;
            EnabledChanged += PersistenceSwitch_EnabledChanged;
            RefreshIcon();
            toolTip1.SetToolTip(this, I18n.Translate("internal/PersistenceSwitch/string", "Determines if the variable to be modified is persistent, as in, will be saved to disk on exit and loaded back in when Triggernometry starts. Persistent variables live in a different namespace from regular variables."));            
        }

        private void PersistenceSwitch_EnabledChanged(object sender, EventArgs e)
        {
            RefreshIcon();
        }

        private void PersistenceSwitch_Click(object sender, EventArgs e)
        {
            TogglePersistence();
        }

        private void TogglePersistence()
        {
            IsPersistent = (IsPersistent == false);
        }

        private void RefreshIcon()
        {
            if (_IsPersistent == true && Enabled == true)
            {
                BackgroundImage = panel1.BackgroundImage;
            }
            else
            {
                BackgroundImage = (Image)Tag;
            }
        }
        public ExpressionTextBox RelatedTextbox { get; set; }

    }

}
