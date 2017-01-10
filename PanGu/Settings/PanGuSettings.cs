using System;

namespace PanGu.Settings
{
    /// <summary>
    /// 盘古分词设置
    /// </summary>
    [Serializable]
    public static class PanGuSettings
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
            if (PanGuConfiguration.Setting == null)
            {
                //字典路径
                _CurrentDictionaryPath = "DictionaryFiles";

                //匹配选项
                _CurrentMatchOption = new MatchOption();

                //匹配参数
                _CurrentMatchParameter = new MatchParameter();
            }
            else
            {
                PanGuConfiguration config = PanGuConfiguration.Setting;

                //字典路径
                _CurrentDictionaryPath = config.DictionaryPathElement.Path;

                //匹配选项
                _CurrentMatchOption = new MatchOption
                (
                    config.MatchOptionsElement.ChineseNameIdentifyElement.Enabled,
                    config.MatchOptionsElement.FrequencyFirstElement.Enabled,
                    config.MatchOptionsElement.MultiDimensionalityElement.Enabled,
                    config.MatchOptionsElement.EnglishMultiDimensionalityElement.Enabled,
                    config.MatchOptionsElement.FilterStopWordsElement.Enabled,
                    config.MatchOptionsElement.IgnoreSpaceElement.Enabled,
                    config.MatchOptionsElement.ForceSingleWordElement.Enabled,
                    config.MatchOptionsElement.TraditionalChineseEnabledElement.Enabled,
                    config.MatchOptionsElement.OutputSimplifiedTraditionalElement.Enabled,
                    config.MatchOptionsElement.UnknownWordIdentifyElement.Enabled,
                    config.MatchOptionsElement.FilterEnglishElement.Enabled,
                    config.MatchOptionsElement.FilterNumericElement.Enabled,
                    config.MatchOptionsElement.IgnoreCapitalElement.Enabled,
                    config.MatchOptionsElement.EnglishSegmentElement.Enabled,
                    config.MatchOptionsElement.SynonymOutputElement.Enabled,
                    config.MatchOptionsElement.WildcardOutputElement.Enabled,
                    config.MatchOptionsElement.WildcardSegmentElement.Enabled,
                    config.MatchOptionsElement.CustomRuleElement.Enabled
                );

                //匹配参数
                _CurrentMatchParameter = new MatchParameter
                (
                    config.MatchParametersElement.UnknowRankElement.Rank,
                    config.MatchParametersElement.BestRankElement.Rank,
                    config.MatchParametersElement.SecRankElement.Rank,
                    config.MatchParametersElement.ThirdRankElement.Rank,
                    config.MatchParametersElement.SingleRankElement.Rank,
                    config.MatchParametersElement.NumericRankElement.Rank,
                    config.MatchParametersElement.EnglishRankElement.Rank,
                    config.MatchParametersElement.EnglishLowerRankElement.Rank,
                    config.MatchParametersElement.EnglishStemRankElement.Rank,
                    config.MatchParametersElement.SymbolRankElement.Rank,
                    config.MatchParametersElement.SimplifiedTraditionalRankElement.Rank,
                    config.MatchParametersElement.SynonymRankElement.Rank,
                    config.MatchParametersElement.WildcardRankElement.Rank,
                    config.MatchParametersElement.FilterEnglishLengthElement.Length,
                    config.MatchParametersElement.FilterNumericLengthElement.Length,
                    config.MatchParametersElement.CustomRuleAssemblyFileNameElement.Name,
                    config.MatchParametersElement.CustomRuleFullClassNameElement.Name,
                    config.MatchParametersElement.RedundancyElement.Value
                );
            }
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
