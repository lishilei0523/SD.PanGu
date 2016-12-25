using System;
using System.Windows.Forms;

namespace PanGu.DictionaryManager
{
    public partial class FormEncoder : Form
    {
        bool m_Ok;

        public FormEncoder()
        {
            this.InitializeComponent();
        }

        public String Encoding
        {
            get
            {
                return this.comboBoxEncoder.Text;
            }
        }

        new public DialogResult ShowDialog()
        {
            this.m_Ok = false;
            base.ShowDialog();

            if (this.m_Ok)
            {
                return DialogResult.OK;
            }
            else
            {
                return DialogResult.Cancel;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.m_Ok = true;
            this.Close();
        }
    }
}