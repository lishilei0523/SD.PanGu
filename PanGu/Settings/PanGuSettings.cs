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
using System.Xml.Serialization;

namespace PanGu.Settings
{
    [Serializable, XmlRoot(Namespace = "http://www.codeplex.com/pangusegment")]
    public class PanGuSettings
    {
        #region # 静态字段与构造器

        /// <summary>
        /// 当前字典路径字段
        /// </summary>
        private static readonly string _CurrentDictionaryPath;

        /// <summary>
        /// 当前匹配选项字段
        /// </summary>
        private static readonly MatchOption _CurrentMatchOption;

        /// <summary>
        /// 当前匹配参数字段
        /// </summary>
        private static readonly MatchParameter _CurrentMatchParameter;

        /// <summary>
        /// 静态构造器
        /// </summary>
        static PanGuSettings()
        {
            //字典路径
            _CurrentDictionaryPath = PanGuConfiguration.Setting.DictionaryPathElement.Path;

            //匹配选项
            _CurrentMatchOption = new MatchOption
            {
                ChineseNameIdentify = PanGuConfiguration.Setting.MatchOptionsElement.ChineseNameIdentifyElement.Enabled,
                FrequencyFirst = PanGuConfiguration.Setting.MatchOptionsElement.FrequencyFirstElement.Enabled,
                MultiDimensionality = PanGuConfiguration.Setting.MatchOptionsElement.MultiDimensionalityElement.Enabled,
                EnglishMultiDimensionality = PanGuConfiguration.Setting.MatchOptionsElement.EnglishMultiDimensionalityElement.Enabled,
                FilterStopWords = PanGuConfiguration.Setting.MatchOptionsElement.FilterStopWordsElement.Enabled,
                IgnoreSpace = PanGuConfiguration.Setting.MatchOptionsElement.IgnoreSpaceElement.Enabled,
                ForceSingleWord = PanGuConfiguration.Setting.MatchOptionsElement.ForceSingleWordElement.Enabled,
                TraditionalChineseEnabled = PanGuConfiguration.Setting.MatchOptionsElement.TraditionalChineseEnabledElement.Enabled,
                OutputSimplifiedTraditional = PanGuConfiguration.Setting.MatchOptionsElement.OutputSimplifiedTraditionalElement.Enabled,
                UnknownWordIdentify = PanGuConfiguration.Setting.MatchOptionsElement.UnknownWordIdentifyElement.Enabled,
                FilterEnglish = PanGuConfiguration.Setting.MatchOptionsElement.FilterEnglishElement.Enabled,
                FilterNumeric = PanGuConfiguration.Setting.MatchOptionsElement.FilterNumericElement.Enabled,
                IgnoreCapital = PanGuConfiguration.Setting.MatchOptionsElement.IgnoreCapitalElement.Enabled,
                EnglishSegment = PanGuConfiguration.Setting.MatchOptionsElement.EnglishSegmentElement.Enabled,
                SynonymOutput = PanGuConfiguration.Setting.MatchOptionsElement.SynonymOutputElement.Enabled,
                WildcardOutput = PanGuConfiguration.Setting.MatchOptionsElement.WildcardOutputElement.Enabled,
                WildcardSegment = PanGuConfiguration.Setting.MatchOptionsElement.WildcardSegmentElement.Enabled,
                CustomRule = PanGuConfiguration.Setting.MatchOptionsElement.CustomRuleElement.Enabled
            };

            //匹配参数
            _CurrentMatchParameter = new MatchParameter
            {
                UnknowRank = PanGuConfiguration.Setting.MatchParametersElement.UnknowRankElement.Rank,
                BestRank = PanGuConfiguration.Setting.MatchParametersElement.BestRankElement.Rank,
                SecRank = PanGuConfiguration.Setting.MatchParametersElement.SecRankElement.Rank,
                ThirdRank = PanGuConfiguration.Setting.MatchParametersElement.ThirdRankElement.Rank,
                SingleRank = PanGuConfiguration.Setting.MatchParametersElement.SingleRankElement.Rank,
                NumericRank = PanGuConfiguration.Setting.MatchParametersElement.NumericRankElement.Rank,
                EnglishRank = PanGuConfiguration.Setting.MatchParametersElement.EnglishRankElement.Rank,
                EnglishLowerRank = PanGuConfiguration.Setting.MatchParametersElement.EnglishLowerRankElement.Rank,
                EnglishStemRank = PanGuConfiguration.Setting.MatchParametersElement.EnglishStemRankElement.Rank,
                SymbolRank = PanGuConfiguration.Setting.MatchParametersElement.SymbolRankElement.Rank,
                SimplifiedTraditionalRank = PanGuConfiguration.Setting.MatchParametersElement.SimplifiedTraditionalRankElement.Rank,
                SynonymRank = PanGuConfiguration.Setting.MatchParametersElement.SynonymRankElement.Rank,
                WildcardRank = PanGuConfiguration.Setting.MatchParametersElement.WildcardRankElement.Rank,
                FilterEnglishLength = PanGuConfiguration.Setting.MatchParametersElement.FilterEnglishLengthElement.Length,
                FilterNumericLength = PanGuConfiguration.Setting.MatchParametersElement.FilterNumericLengthElement.Length,
                CustomRuleAssemblyFileName = PanGuConfiguration.Setting.MatchParametersElement.CustomRuleAssemblyFileNameElement.Name,
                CustomRuleFullClassName = PanGuConfiguration.Setting.MatchParametersElement.CustomRuleFullClassNameElement.Name,
                Redundancy = PanGuConfiguration.Setting.MatchParametersElement.RedundancyElement.Value
            };
        }

        #endregion

        #region # 当前字典路径 —— static string CurrentDictionaryPath
        /// <summary>
        /// 当前字典路径
        /// </summary>
        public static string CurrentDictionaryPath
        {
            get { return _CurrentDictionaryPath; }
        }
        #endregion

        #region # 当前匹配选项 —— static MatchOption CurrentMatchOption
        /// <summary>
        /// 当前匹配选项
        /// </summary>
        public static MatchOption CurrentMatchOption
        {
            get { return _CurrentMatchOption; }
        }
        #endregion

        #region # 当前匹配参数 —— static MatchParameter CurrentMatchParameter
        /// <summary>
        /// 当前匹配参数
        /// </summary>
        public static MatchParameter CurrentMatchParameter
        {
            get { return _CurrentMatchParameter; }
        }
        #endregion
    }
}
