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
            if (PanGuSection.Setting == null)
            {
                //字典路径
                _CurrentDictionaryPath = "Content";

                //匹配选项
                _CurrentMatchOption = new MatchOption();

                //匹配参数
                _CurrentMatchParameter = new MatchParameter();
            }
            else
            {
                PanGuSection config = PanGuSection.Setting;

                //字典路径
                _CurrentDictionaryPath = config.DictionaryPathElement.Value;

                //匹配选项
                _CurrentMatchOption = new MatchOption
                (
                    config.MatchOptionsElement.ChineseNameIdentifyElement.Value,
                    config.MatchOptionsElement.FrequencyFirstElement.Value,
                    config.MatchOptionsElement.MultiDimensionalityElement.Value,
                    config.MatchOptionsElement.EnglishMultiDimensionalityElement.Value,
                    config.MatchOptionsElement.FilterStopWordsElement.Value,
                    config.MatchOptionsElement.IgnoreSpaceElement.Value,
                    config.MatchOptionsElement.ForceSingleWordElement.Value,
                    config.MatchOptionsElement.TraditionalChineseEnabledElement.Value,
                    config.MatchOptionsElement.OutputSimplifiedTraditionalElement.Value,
                    config.MatchOptionsElement.UnknownWordIdentifyElement.Value,
                    config.MatchOptionsElement.FilterEnglishElement.Value,
                    config.MatchOptionsElement.FilterNumericElement.Value,
                    config.MatchOptionsElement.IgnoreCapitalElement.Value,
                    config.MatchOptionsElement.EnglishSegmentElement.Value,
                    config.MatchOptionsElement.SynonymOutputElement.Value,
                    config.MatchOptionsElement.WildcardOutputElement.Value,
                    config.MatchOptionsElement.WildcardSegmentElement.Value,
                    config.MatchOptionsElement.CustomRuleElement.Value
                );

                //匹配参数
                _CurrentMatchParameter = new MatchParameter
                (
                    config.MatchParametersElement.UnknowRankElement.Value,
                    config.MatchParametersElement.BestRankElement.Value,
                    config.MatchParametersElement.SecRankElement.Value,
                    config.MatchParametersElement.ThirdRankElement.Value,
                    config.MatchParametersElement.SingleRankElement.Value,
                    config.MatchParametersElement.NumericRankElement.Value,
                    config.MatchParametersElement.EnglishRankElement.Value,
                    config.MatchParametersElement.EnglishLowerRankElement.Value,
                    config.MatchParametersElement.EnglishStemRankElement.Value,
                    config.MatchParametersElement.SymbolRankElement.Value,
                    config.MatchParametersElement.SimplifiedTraditionalRankElement.Value,
                    config.MatchParametersElement.SynonymRankElement.Value,
                    config.MatchParametersElement.WildcardRankElement.Value,
                    config.MatchParametersElement.FilterEnglishLengthElement.Value,
                    config.MatchParametersElement.FilterNumericLengthElement.Value,
                    config.MatchParametersElement.CustomRuleAssemblyFileNameElement.Value,
                    config.MatchParametersElement.CustomRuleFullClassNameElement.Value,
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
