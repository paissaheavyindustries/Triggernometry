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

    public partial class Toast : UserControl
    {

        public delegate void ActionDelegate(Toast t, bool result);

        public event ActionDelegate OnYes;
        public event ActionDelegate OnNo;

        public enum ToastTypeEnum
        {
            Undefined,
            YesNo,
            OK
        }

        private ToastTypeEnum _ToastType { get; set; }
        public ToastTypeEnum ToastType
        {
            get
            {
                return _ToastType;
            }
            set
            {
                if (_ToastType != value)
                {
                    _ToastType = value;
                    switch (_ToastType)
                    {
                        case ToastTypeEnum.Undefined:
                            btnToastYes.Visible = false;
                            btnToastNo.Visible = false;
                            break;
                        case ToastTypeEnum.OK:
                            btnToastYes.Visible = false;
                            btnToastNo.Visible = true;
                            btnToastNo.Text = I18n.Translate("plugin/Toast/ok", "OK");
                            break;
                        case ToastTypeEnum.YesNo:
                            btnToastYes.Visible = true;
                            btnToastYes.Text = I18n.Translate("plugin/Toast/yes", "Yes");
                            btnToastNo.Visible = true;
                            btnToastNo.Text = I18n.Translate("plugin/Toast/no", "No");
                            break;
                    }
                }
            }
        }

        public string ToastText
        {
            get
            {
                return label13.Text;
            }
            set
            {
                label13.Text = value;
            }
        }

        public Toast()
        {
            InitializeComponent();
            ToastType = ToastTypeEnum.Undefined;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // yes
            if (OnYes != null)
            {
                OnYes(this, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // no
            if (OnNo != null)
            {
                OnNo(this, false);
            }
        }


    }

}
