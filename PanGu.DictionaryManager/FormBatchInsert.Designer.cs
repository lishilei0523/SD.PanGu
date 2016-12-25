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


using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PanGu.DictionaryManager
{
    partial class FormBatchInsert
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormBatchInsert));
            this.label3 = new Label();
            this.numericUpDownFrequency = new NumericUpDown();
            this.label2 = new Label();
            this.textBoxWord = new TextBox();
            this.label1 = new Label();
            this.posCtrl = new PosCtrl();
            this.buttonOk = new Button();
            this.buttonCancel = new Button();
            this.checkBoxAllUse = new CheckBox();
            ((ISupportInitialize)(this.numericUpDownFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(23, 104);
            this.label3.Name = "label3";
            this.label3.Size = new Size(29, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "词性";
            // 
            // numericUpDownFrequency
            // 
            this.numericUpDownFrequency.Location = new Point(71, 50);
            this.numericUpDownFrequency.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numericUpDownFrequency.Name = "numericUpDownFrequency";
            this.numericUpDownFrequency.Size = new Size(70, 21);
            this.numericUpDownFrequency.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(23, 55);
            this.label2.Name = "label2";
            this.label2.Size = new Size(29, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "词频";
            // 
            // textBoxWord
            // 
            this.textBoxWord.Enabled = false;
            this.textBoxWord.Location = new Point(71, 14);
            this.textBoxWord.Name = "textBoxWord";
            this.textBoxWord.Size = new Size(261, 21);
            this.textBoxWord.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new Size(29, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "单词";
            // 
            // posCtrl
            // 
            this.posCtrl.Location = new Point(25, 119);
            this.posCtrl.Name = "posCtrl";
            this.posCtrl.Pos = 0;
            this.posCtrl.Size = new Size(480, 270);
            this.posCtrl.TabIndex = 9;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new Point(22, 469);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new Size(75, 23);
            this.buttonOk.TabIndex = 15;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new Point(122, 469);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(75, 23);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxAllUse
            // 
            this.checkBoxAllUse.AutoSize = true;
            this.checkBoxAllUse.Location = new Point(25, 421);
            this.checkBoxAllUse.Name = "checkBoxAllUse";
            this.checkBoxAllUse.Size = new Size(192, 16);
            this.checkBoxAllUse.TabIndex = 17;
            this.checkBoxAllUse.Text = "所有单词采用相同的词频和词性";
            this.checkBoxAllUse.UseVisualStyleBackColor = true;
            // 
            // FormBatchInsert
            // 
            this.AutoScaleDimensions = new SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(532, 517);
            this.Controls.Add(this.checkBoxAllUse);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownFrequency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.posCtrl);
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBatchInsert";
            this.Text = "批量增加";
            ((ISupportInitialize)(this.numericUpDownFrequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label3;
        private NumericUpDown numericUpDownFrequency;
        private Label label2;
        private TextBox textBoxWord;
        private Label label1;
        private PosCtrl posCtrl;
        private Button buttonOk;
        private Button buttonCancel;
        private CheckBox checkBoxAllUse;
    }
}