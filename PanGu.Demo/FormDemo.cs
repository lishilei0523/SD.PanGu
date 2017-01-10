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

using PanGu.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace PanGu.Demo
{
    public partial class FormDemo : Form
    {
        String _InitSource = "盘古分词 简介: 盘古分词 是由eaglet 开发的一款基于字典的中英文分词组件\r\n" +
            "主要功能: 中英文分词，未登录词识别,多元歧义自动识别,全角字符识别能力\r\n" +
            "主要性能指标:\r\n" +
            "分词准确度:90%以上\r\n" +
            "处理速度: 300-600KBytes/s Core Duo 1.8GHz\r\n" +
            "用于测试的句子:\r\n" +
            "长春市长春节致词\r\n" +
            "长春市长春药店\r\n" +
            "IＢM的技术和服务都不错\r\n" +
            "张三在一月份工作会议上说的确实在理\r\n" +
            "于北京时间5月10日举行运动会\r\n" +
            "我的和服务必在明天做好";

        private MatchOption _Options;
        private MatchParameter _Parameters;

        public FormDemo()
        {
            this.InitializeComponent();
        }

        private void FormDemo_Load(object sender, EventArgs e)
        {
            this.textBoxSource.Text = this._InitSource;
            PanGu.Segment.Init();

            MatchOption options = PanGuSettings.CurrentMatchOption;
            this.checkBoxFreqFirst.Checked = options.FrequencyFirst;
            this.checkBoxFilterStopWords.Checked = options.FilterStopWords;
            this.checkBoxMatchName.Checked = options.ChineseNameIdentify;
            this.checkBoxMultiSelect.Checked = options.MultiDimensionality;
            this.checkBoxEnglishMultiSelect.Checked = options.EnglishMultiDimensionality;
            this.checkBoxForceSingleWord.Checked = options.ForceSingleWord;
            this.checkBoxTraditionalChs.Checked = options.TraditionalChineseEnabled;
            this.checkBoxST.Checked = options.OutputSimplifiedTraditional;
            this.checkBoxUnknownWord.Checked = options.UnknownWordIdentify;
            this.checkBoxFilterEnglish.Checked = options.FilterEnglish;
            this.checkBoxFilterNumeric.Checked = options.FilterNumeric;
            this.checkBoxIgnoreCapital.Checked = options.IgnoreCapital;
            this.checkBoxEnglishSegment.Checked = options.EnglishSegment;
            this.checkBoxSynonymOutput.Checked = options.SynonymOutput;
            this.checkBoxWildcard.Checked = options.WildcardOutput;
            this.checkBoxWildcardSegment.Checked = options.WildcardSegment;
            this.checkBoxCustomRule.Checked = options.CustomRule;

            if (this.checkBoxMultiSelect.Checked)
            {
                this.checkBoxDisplayPosition.Checked = true;
            }

            MatchParameter parameters = PanGuSettings.CurrentMatchParameter;

            this.numericUpDownRedundancy.Value = parameters.Redundancy;
            this.numericUpDownFilterEnglishLength.Value = parameters.FilterEnglishLength;
            this.numericUpDownFilterNumericLength.Value = parameters.FilterNumericLength;

            //str = Microsoft.VisualBasic.Strings.StrConv(str, Microsoft.VisualBasic.VbStrConv.SimplifiedChinese, 0);

        }

        private void DisplaySegment()
        {
            this.DisplaySegment(false);
        }

        private void DisplaySegment(bool showPosition)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Segment segment = new Segment();
            ICollection<WordInfo> words = segment.DoSegment(this.textBoxSource.Text, this._Options, this._Parameters);

            watch.Stop();

            this.labelSrcLength.Text = this.textBoxSource.Text.Length.ToString();

            this.labelSegTime.Text = watch.Elapsed.ToString();
            if (watch.ElapsedMilliseconds == 0)
            {
                this.labelRegRate.Text = "无穷大";
            }
            else
            {
                this.labelRegRate.Text = ((double)(this.textBoxSource.Text.Length / watch.ElapsedMilliseconds) * 1000).ToString();
            }


            if (this.checkBoxShowTimeOnly.Checked)
            {
                return;
            }

            StringBuilder wordsString = new StringBuilder();
            foreach (WordInfo wordInfo in words)
            {
                if (wordInfo == null)
                {
                    continue;
                }

                if (showPosition)
                {

                    wordsString.AppendFormat("{0}({1},{2})/", wordInfo.Word, wordInfo.Position, wordInfo.Rank);
                    //if (_Options.MultiDimensionality)
                    //{
                    //}
                    //else
                    //{
                    //    wordsString.AppendFormat("{0}({1})/", wordInfo.Word, wordInfo.Position);
                    //}
                }
                else
                {
                    wordsString.AppendFormat("{0}/", wordInfo.Word);
                }
            }

            this.textBoxSegwords.Text = wordsString.ToString();


        }

        private void DisplaySegmentAndPostion()
        {
            this.DisplaySegment(true);
        }

        private void UpdateSettings()
        {
            this._Options.FrequencyFirst = this.checkBoxFreqFirst.Checked;
            this._Options.FilterStopWords = this.checkBoxFilterStopWords.Checked;
            this._Options.ChineseNameIdentify = this.checkBoxMatchName.Checked;
            this._Options.MultiDimensionality = this.checkBoxMultiSelect.Checked;
            this._Options.EnglishMultiDimensionality = this.checkBoxEnglishMultiSelect.Checked;
            this._Options.ForceSingleWord = this.checkBoxForceSingleWord.Checked;
            this._Options.TraditionalChineseEnabled = this.checkBoxTraditionalChs.Checked;
            this._Options.OutputSimplifiedTraditional = this.checkBoxST.Checked;
            this._Options.UnknownWordIdentify = this.checkBoxUnknownWord.Checked;
            this._Options.FilterEnglish = this.checkBoxFilterEnglish.Checked;
            this._Options.FilterNumeric = this.checkBoxFilterNumeric.Checked;
            this._Options.IgnoreCapital = this.checkBoxIgnoreCapital.Checked;
            this._Options.EnglishSegment = this.checkBoxEnglishSegment.Checked;
            this._Options.SynonymOutput = this.checkBoxSynonymOutput.Checked;
            this._Options.WildcardOutput = this.checkBoxWildcard.Checked;
            this._Options.WildcardSegment = this.checkBoxWildcardSegment.Checked;
            this._Options.CustomRule = this.checkBoxCustomRule.Checked;

            this._Parameters.Redundancy = (int)this.numericUpDownRedundancy.Value;
            this._Parameters.FilterEnglishLength = (int)this.numericUpDownFilterEnglishLength.Value;
            this._Parameters.FilterNumericLength = (int)this.numericUpDownFilterNumericLength.Value;

        }

        private void buttonSegment_Click(object sender, EventArgs e)
        {
            this._Options = PanGuSettings.CurrentMatchOption;
            this._Parameters = PanGuSettings.CurrentMatchParameter;

            this.UpdateSettings();

            if (this.checkBoxDisplayPosition.Checked)
            {
                this.DisplaySegmentAndPostion();
            }
            else
            {
                this.DisplaySegment();
            }
        }

        private void buttonSaveConfig_Click(object sender, EventArgs e)
        {
            this._Options = PanGuSettings.CurrentMatchOption;
            this._Parameters = PanGuSettings.CurrentMatchParameter;

            this.UpdateSettings();

            //TODO 此处暂停使用 2017.1.10
            //PanGuSettings.Save("PanGu.xml");
        }
    }
}
