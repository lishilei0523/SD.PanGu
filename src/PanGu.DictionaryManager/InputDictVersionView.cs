using System;
using System.Windows.Forms;

namespace PanGu.DictionaryManager
{
    public partial class InputDictVersionView : Form
    {
        DialogResult _Result = DialogResult.Cancel;

        public InputDictVersionView()
        {
            this.InitializeComponent();
        }

        public string Version
        {
            get
            {
                return this.textBoxVersion.Text;
            }

            set
            {
                this.textBoxVersion.Text = value;
            }
        }

        new public DialogResult ShowDialog()
        {
            base.ShowDialog();

            return this._Result;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.textBoxVersion.Text = this.textBoxVersion.Text.Trim();
            if (this.textBoxVersion.Text == "")
            {
                MessageBox.Show("版本号不能为空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.textBoxVersion.Text.Length > 8)
            {
                MessageBox.Show("版本号字符串长度不能大于8", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this._Result = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
