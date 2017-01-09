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

using PanGu.Enums;
using System;
using System.Windows.Forms;

namespace PanGu.DictionaryManager
{
    public partial class FormBatchInsert : Form
    {
        WordAttribute m_Word = new WordAttribute();
        bool m_Ok;

        public WordAttribute Word
        {
            get
            {
                return this.m_Word;
            }

            set
            {
                this.m_Word = value;
            }
        }

        public bool AllUse
        {
            get
            {
                return this.checkBoxAllUse.Checked;
            }
        }

        public FormBatchInsert()
        {
            this.InitializeComponent();
        }

        new public DialogResult ShowDialog()
        {
            this.m_Ok = false;
            this.textBoxWord.Text = this.m_Word.Word;
            this.numericUpDownFrequency.Value = (decimal)this.m_Word.Frequency;
            this.posCtrl.Pos = (int)this.m_Word.Pos;

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
            this.m_Word.Frequency = (int)this.numericUpDownFrequency.Value;
            this.m_Word.Pos = (POS)this.posCtrl.Pos;

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}