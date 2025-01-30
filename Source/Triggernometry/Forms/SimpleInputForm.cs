using System;
using System.Drawing;
using System.Windows.Forms;
using Triggernometry.CustomControls;

namespace Triggernometry.Forms
{
    public partial class SimpleInputForm : Form
    {
        private ExpressionTextBox expEditedValue;
        private Button okButton;
        private TableLayoutPanel table;

        public SimpleInputForm(string title, ExpressionTextBox.SupportedExpressionTypeEnum exprType, string defaultValue = "")
        {
            //InitializeComponent();
            Text = title;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(300, 0);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;

            expEditedValue = new ExpressionTextBox
            {
                Anchor = AnchorStyles.None,
                Dock = DockStyle.Fill,
                ExpressionType = exprType,
                Text = defaultValue,
            };
            expEditedValue.textBox1.MinimumSize = new Size(200, 0);

            okButton = new Button
            {
                Text = I18n.Translate("ActionForm/btnOk", "OK"),
                Anchor = AnchorStyles.None,
                Margin = new Padding(10, 20, 10, 10),
                Padding = new Padding(5),
                DialogResult = DialogResult.OK,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };
            AcceptButton = okButton;

            table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                RowCount = 2
            };
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.Controls.Add(expEditedValue, 0, 0);
            table.Controls.Add(okButton, 0, 1);

            Controls.Add(table);

            Shown += (_, __) => BringToFront();
        }

        public string GetInput() => ShowDialog() == DialogResult.OK ? expEditedValue.Text : null;
    }
}
