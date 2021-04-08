using System;
using System.Windows.Forms;

namespace PanGu.DictionaryManager
{
    public partial class FindView : Form
    {
        public enum SearchMode
        {
            None = 0,
            ByPos = 1,
            ByLength = 2,
        }

        SearchMode _SearchMode  = SearchMode.None;

        public SearchMode Mode
        {
            get
            {
                return this._SearchMode;
            }

        }

        public int POS
        {
            get
            {
                return this.posCtrl.Pos;
            }
        }

        public int Length
        {
            get
            {
                return (int)this.numericUpDownLength.Value;
            }
        }

        public FindView()
        {
            this.InitializeComponent();
        }

        private void radioButtonByPos_CheckedChanged(object sender, EventArgs e)
        {
            this.posCtrl.Enabled = true;
            this.numericUpDownLength.Enabled = false;
        }

        private void radioButtonByLength_CheckedChanged(object sender, EventArgs e)
        {
            this.posCtrl.Enabled = false;
            this.numericUpDownLength.Enabled = true;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (this.radioButtonByLength.Checked)
            {
                this._SearchMode = SearchMode.ByLength;
            }
            else if (this.radioButtonByPos.Checked)
            {
                this._SearchMode = SearchMode.ByPos;
            }
            else
            {
                this._SearchMode = SearchMode.None;
            }

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this._SearchMode = SearchMode.None;
            this.Close();
        }
    }
}