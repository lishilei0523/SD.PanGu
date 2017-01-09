/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


using PanGu.Dict;
using PanGu.Enums;
using PanGu.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PanGu.DictionaryManager
{
    public partial class FormMain : Form
    {
        WordDictionary _WordDict = null;
        String m_DictFileName;
        string _Version = "";

        private int Count
        {
            get
            {
                if (this._WordDict != null)
                {
                    return this._WordDict.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public FormMain()
        {
            this.InitializeComponent();
        }

        private void ShowCount()
        {
            this.labelCount.Text = this.Count.ToString();
        }

        private void openBinDictFile13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialogDict.RestoreDirectory = true;
            this.openFileDialogDict.FileName = "Dict.dct";
            this.openFileDialogDict.Filter = "Dictionay file|*.dct";

            if (this.openFileDialogDict.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DateTime old = DateTime.Now;
                    this._WordDict = new WordDictionary();
                    this._WordDict.Load(this.openFileDialogDict.FileName, out this._Version);

                    TimeSpan s = DateTime.Now - old;
                    this.statusStrip.Items[0].Text = s.TotalMilliseconds.ToString() + "ms";
                }
                catch (Exception e1)
                {
                    MessageBox.Show(String.Format("Can not open dictionary, errmsg:{0}", e1.Message));
                    return;
                }

                this.panelMain.Enabled = true;
                this.m_DictFileName = this.openFileDialogDict.FileName;
                this.Text = "V" + this._Version + " " + this.openFileDialogDict.FileName;
                this.ShowCount();
            }

        }

        private void saveBinDictFile13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._WordDict == null)
            {
                return;
            }

            this.saveFileDialogDict.RestoreDirectory = true;
            this.saveFileDialogDict.FileName = "Dict.dct";
            this.saveFileDialogDict.Filter = "Dictionay file|*.dct";

            if (this.saveFileDialogDict.ShowDialog() == DialogResult.OK)
            {
                FormInputDictVersion frmInputDictVersion = new FormInputDictVersion();
                frmInputDictVersion.Version = this._Version;
                if (frmInputDictVersion.ShowDialog() == DialogResult.OK)
                {
                    this._WordDict.Save(this.saveFileDialogDict.FileName,
                        frmInputDictVersion.Version);
                }
            }

        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (this.textBoxSearch.Text.Trim() == "")
            {
                return;
            }

            List<SearchWordResult> result = this._WordDict.Search(this.textBoxSearch.Text.Trim());

            result.Sort();

            this.listBoxList.Items.Clear();

            foreach (SearchWordResult word in result)
            {
                this.listBoxList.Items.Add(word);
            }

            this.label.Text = "符合条件的记录数:" + result.Count.ToString();
        }

        private void listBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.listBoxList.SelectedIndex;

            if (index < 0)
            {
                return;
            }

            object obj = this.listBoxList.Items[index];
            SearchWordResult word = (SearchWordResult)obj;

            this.textBoxWord.Text = word.Word.Word;
            this.numericUpDownFrequency.Value = (decimal)word.Word.Frequency;
            this.posCtrl.Pos = (int)word.Word.Pos;
        }

        private void textBoxWord_TextChanged(object sender, EventArgs e)
        {
            String word = this.textBoxWord.Text.Trim();
            if (word == "")
            {
                this.buttonUpdate.Enabled = false;
                this.buttonInsert.Enabled = false;
                this.buttonDelete.Enabled = false;
                return;
            }

            WordAttribute selWord = this._WordDict.GetWordAttr(word);
            if (selWord != null)
            {
                this.buttonUpdate.Enabled = true;
                this.buttonInsert.Enabled = false;
                this.buttonDelete.Enabled = true;
                this.numericUpDownFrequency.Value = (decimal)selWord.Frequency;
                this.posCtrl.Pos = (int)selWord.Pos;
            }
            else
            {
                this.buttonUpdate.Enabled = false;
                this.buttonInsert.Enabled = true;
                this.buttonDelete.Enabled = false;
                this.numericUpDownFrequency.Value = 0;
                this.posCtrl.Pos = 0;

            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            this._WordDict.InsertWord(this.textBoxWord.Text.Trim(), (double)this.numericUpDownFrequency.Value, (POS)this.posCtrl.Pos);
            MessageBox.Show("增加成功", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.ShowCount();
            this.textBoxWord_TextChanged(sender, e);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            this._WordDict.UpdateWord(this.textBoxWord.Text.Trim(), (double)this.numericUpDownFrequency.Value, (POS)this.posCtrl.Pos);
            MessageBox.Show("修改成功", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.ShowCount();
            this.textBoxWord_TextChanged(sender, e);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除改单词?", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.Yes)
            {
                this._WordDict.DeleteWord(this.textBoxWord.Text.Trim());
                MessageBox.Show("删除成功", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.ShowCount();
            this.textBoxWord_TextChanged(sender, e);
        }

        private void BatchInsert(String fileName, String encoder)
        {
            String content = File.ReadFileToString(fileName, Encoding.GetEncoding(encoder));

            String[] words = Regex.Split(content, @"\r\n");

            bool allUse = false;
            WordAttribute lstWord = null;

            foreach (String word in words)
            {
                if (word == null)
                {
                    continue;
                }

                if (word.Trim() == "")
                {
                    continue;
                }

                FormBatchInsert frmBatchInsert = new FormBatchInsert();

                if (!allUse || lstWord == null)
                {
                    frmBatchInsert.Word.Word = word.Trim();

                    if (frmBatchInsert.ShowDialog() == DialogResult.OK)
                    {
                        lstWord = frmBatchInsert.Word;
                        allUse = frmBatchInsert.AllUse;
                        this._WordDict.InsertWord(lstWord.Word, lstWord.Frequency, lstWord.Pos);
                    }
                }
                else
                {
                    lstWord.Word = word.Trim();
                    this._WordDict.InsertWord(lstWord.Word, lstWord.Frequency, lstWord.Pos);
                }
            }
        }


        private void buttonBatchInsert_Click(object sender, EventArgs e)
        {
            this.openFileDialogDict.RestoreDirectory = true;
            this.openFileDialogDict.FileName = "*.txt";
            this.openFileDialogDict.Filter = "Text files|*.txt";

            if (this.openFileDialogDict.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FormEncoder frmEncoder = new FormEncoder();
                    if (frmEncoder.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    this.BatchInsert(this.openFileDialogDict.FileName, frmEncoder.Encoding);
                    MessageBox.Show("批量增加成功,注意只有保存字典后,导入的单词才会生效!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ShowCount();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ListWordsByPos(int pos)
        {
            List<SearchWordResult> result = this._WordDict.SearchByPos((POS)pos);

            result.Sort();

            this.listBoxList.Items.Clear();

            foreach (SearchWordResult word in result)
            {
                this.listBoxList.Items.Add(word);
            }

            this.label.Text = "符合条件的记录数:" + result.Count.ToString();

        }

        private void ListWordsByLength(int length)
        {
            List<SearchWordResult> result = this._WordDict.SearchByLength(length);

            result.Sort();

            this.listBoxList.Items.Clear();

            foreach (SearchWordResult word in result)
            {
                this.listBoxList.Items.Add(word);
            }

            this.label.Text = "符合条件的记录数:" + result.Count.ToString();

        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFind frmFind = new FormFind();

            frmFind.ShowDialog();

            switch (frmFind.Mode)
            {
                case FormFind.SearchMode.None:
                    this.listBoxList.Items.Clear();
                    break;

                case FormFind.SearchMode.ByPos:
                    this.ListWordsByPos(frmFind.POS);
                    break;

                case FormFind.SearchMode.ByLength:
                    this.ListWordsByLength(frmFind.Length);
                    break;
            }

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialogText.ShowDialog() == DialogResult.OK)
            {
                StringBuilder str = new StringBuilder();

                foreach (object text in this.listBoxList.Items)
                {
                    str.AppendLine(text.ToString());
                }

                File.WriteString(this.saveFileDialogText.FileName, str.ToString(), Encoding.UTF8);
                MessageBox.Show("Save OK!");
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            this.buttonSearch_Click(sender, e);
        }

        private void OpenAsTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialogDict.RestoreDirectory = true;
            this.openFileDialogDict.FileName = "Dict.txt";
            this.openFileDialogDict.Filter = "Dictionay file|*.txt";

            if (this.openFileDialogDict.ShowDialog() == DialogResult.OK)
            {
                this._Version = "";

                try
                {
                    DateTime old = DateTime.Now;
                    this._WordDict = new WordDictionary();

                    this._WordDict.Load(this.openFileDialogDict.FileName, true, out this._Version);

                    TimeSpan s = DateTime.Now - old;
                    this.statusStrip.Items[0].Text = s.TotalMilliseconds.ToString() + "ms";
                }
                catch (Exception e1)
                {
                    MessageBox.Show(String.Format("Can not open dictionary, errmsg:{0}", e1.Message));
                    return;
                }

                this.panelMain.Enabled = true;
                this.m_DictFileName = this.openFileDialogDict.FileName;
                this.Text = "V" + this._Version + " " + this.openFileDialogDict.FileName;
                this.ShowCount();
            }
        }

        private void SaveAsTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._WordDict == null)
            {
                return;
            }

            this.saveFileDialogDict.RestoreDirectory = true;
            this.saveFileDialogDict.FileName = "Dict.txt";
            this.saveFileDialogDict.Filter = "Dictionay file|*.txt";

            if (this.saveFileDialogDict.ShowDialog() == DialogResult.OK)
            {
                this._WordDict.SaveToText(this.saveFileDialogDict.FileName);
            }
        }
    }
}