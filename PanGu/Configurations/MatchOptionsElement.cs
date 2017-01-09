using System.Configuration;
using PanGu.Configurations.MatchOptions;

namespace PanGu.Configurations
{
    /// <summary>
    /// 匹配选项节点
    /// </summary>
    internal class MatchOptionsElement : ConfigurationElement
    {
        #region # 中文名识别节点 —— ChineseNameIdentifyElement ChineseNameIdentifyElement
        /// <summary>
        /// 中文名识别节点
        /// </summary>
        [ConfigurationProperty("chineseNameIdentify", IsRequired = true)]
        public ChineseNameIdentifyElement ChineseNameIdentifyElement
        {
            get { return (ChineseNameIdentifyElement)this["chineseNameIdentify"]; }
            set { this["chineseNameIdentify"] = value; }
        }
        #endregion

        #region # 词频优先节点 —— FrequencyFirstElement FrequencyFirstElement
        /// <summary>
        /// 词频优先节点
        /// </summary>
        [ConfigurationProperty("frequencyFirst", IsRequired = true)]
        public FrequencyFirstElement FrequencyFirstElement
        {
            get { return (FrequencyFirstElement)this["frequencyFirst"]; }
            set { this["frequencyFirst"] = value; }
        }
        #endregion

        #region # 多元分词节点 —— MultiDimensionalityElement MultiDimensionalityElement
        /// <summary>
        /// 多元分词节点
        /// </summary>
        [ConfigurationProperty("multiDimensionality", IsRequired = true)]
        public MultiDimensionalityElement MultiDimensionalityElement
        {
            get { return (MultiDimensionalityElement)this["multiDimensionality"]; }
            set { this["multiDimensionality"] = value; }
        }
        #endregion

        #region # 英文多元分词节点 —— EnglishMultiDimensionalityElement EnglishMultiDimensionalityElement
        /// <summary>
        /// 英文多元分词节点
        /// </summary>
        [ConfigurationProperty("englishMultiDimensionality", IsRequired = true)]
        public EnglishMultiDimensionalityElement EnglishMultiDimensionalityElement
        {
            get { return (EnglishMultiDimensionalityElement)this["englishMultiDimensionality"]; }
            set { this["englishMultiDimensionality"] = value; }
        }
        #endregion

        #region # 过滤停用词节点 —— FilterStopWordsElement FilterStopWordsElement
        /// <summary>
        /// 过滤停用词节点
        /// </summary>
        [ConfigurationProperty("filterStopWords", IsRequired = true)]
        public FilterStopWordsElement FilterStopWordsElement
        {
            get { return (FilterStopWordsElement)this["filterStopWords"]; }
            set { this["filterStopWords"] = value; }
        }
        #endregion

        #region # 忽略空格、回车、Tab节点 —— IgnoreSpaceElement IgnoreSpaceElement
        /// <summary>
        /// 忽略空格、回车、Tab节点
        /// </summary>
        [ConfigurationProperty("ignoreSpace", IsRequired = true)]
        public IgnoreSpaceElement IgnoreSpaceElement
        {
            get { return (IgnoreSpaceElement)this["ignoreSpace"]; }
            set { this["ignoreSpace"] = value; }
        }
        #endregion

        #region # 强制一元分词节点 —— ForceSingleWordElement ForceSingleWordElement
        /// <summary>
        /// 强制一元分词节点
        /// </summary>
        [ConfigurationProperty("forceSingleWord", IsRequired = true)]
        public ForceSingleWordElement ForceSingleWordElement
        {
            get { return (ForceSingleWordElement)this["forceSingleWord"]; }
            set { this["forceSingleWord"] = value; }
        }
        #endregion

        #region # 繁体中文开关节点 —— TraditionalChineseEnabledElement TraditionalChineseEnabledElement
        /// <summary>
        /// 繁体中文开关节点
        /// </summary>
        [ConfigurationProperty("traditionalChineseEnabled", IsRequired = true)]
        public TraditionalChineseEnabledElement TraditionalChineseEnabledElement
        {
            get { return (TraditionalChineseEnabledElement)this["traditionalChineseEnabled"]; }
            set { this["traditionalChineseEnabled"] = value; }
        }
        #endregion

        #region # 同时输出简体和繁体节点 —— OutputSimplifiedTraditionalElement OutputSimplifiedTraditionalElement
        /// <summary>
        /// 同时输出简体和繁体节点
        /// </summary>
        [ConfigurationProperty("outputSimplifiedTraditional", IsRequired = true)]
        public OutputSimplifiedTraditionalElement OutputSimplifiedTraditionalElement
        {
            get { return (OutputSimplifiedTraditionalElement)this["outputSimplifiedTraditional"]; }
            set { this["outputSimplifiedTraditional"] = value; }
        }
        #endregion

        #region # 未登录词识别节点 —— UnknownWordIdentifyElement UnknownWordIdentifyElement
        /// <summary>
        /// 未登录词识别节点
        /// </summary>
        [ConfigurationProperty("unknownWordIdentify", IsRequired = true)]
        public UnknownWordIdentifyElement UnknownWordIdentifyElement
        {
            get { return (UnknownWordIdentifyElement)this["unknownWordIdentify"]; }
            set { this["unknownWordIdentify"] = value; }
        }
        #endregion

        #region # 过滤英文节点 —— FilterEnglishElement FilterEnglishElement
        /// <summary>
        /// 过滤英文节点
        /// </summary>
        [ConfigurationProperty("filterEnglish", IsRequired = true)]
        public FilterEnglishElement FilterEnglishElement
        {
            get { return (FilterEnglishElement)this["filterEnglish"]; }
            set { this["filterEnglish"] = value; }
        }
        #endregion

        #region # 过滤数字节点 —— FilterNumericElement FilterNumericElement
        /// <summary>
        /// 过滤数字节点
        /// </summary>
        [ConfigurationProperty("filterNumeric", IsRequired = true)]
        public FilterNumericElement FilterNumericElement
        {
            get { return (FilterNumericElement)this["filterNumeric"]; }
            set { this["filterNumeric"] = value; }
        }
        #endregion

        #region # 忽略英文大小写节点 —— IgnoreCapitalElement IgnoreCapitalElement
        /// <summary>
        /// 忽略英文大小写节点
        /// </summary>
        [ConfigurationProperty("ignoreCapital", IsRequired = true)]
        public IgnoreCapitalElement IgnoreCapitalElement
        {
            get { return (IgnoreCapitalElement)this["ignoreCapital"]; }
            set { this["ignoreCapital"] = value; }
        }
        #endregion

        #region # 英文分词节点 —— EnglishSegmentElement EnglishSegmentElement
        /// <summary>
        /// 英文分词节点
        /// </summary>
        [ConfigurationProperty("englishSegment", IsRequired = true)]
        public EnglishSegmentElement EnglishSegmentElement
        {
            get { return (EnglishSegmentElement)this["englishSegment"]; }
            set { this["englishSegment"] = value; }
        }
        #endregion

        #region # 同义词输出节点 —— SynonymOutputElement SynonymOutputElement
        /// <summary>
        /// 同义词输出节点
        /// </summary>
        [ConfigurationProperty("synonymOutput", IsRequired = true)]
        public SynonymOutputElement SynonymOutputElement
        {
            get { return (SynonymOutputElement)this["synonymOutput"]; }
            set { this["synonymOutput"] = value; }
        }
        #endregion

        #region # 通配符匹配输出节点 —— WildcardOutputElement WildcardOutputElement
        /// <summary>
        /// 通配符匹配输出节点
        /// </summary>
        [ConfigurationProperty("wildcardOutput", IsRequired = true)]
        public WildcardOutputElement WildcardOutputElement
        {
            get { return (WildcardOutputElement)this["wildcardOutput"]; }
            set { this["wildcardOutput"] = value; }
        }
        #endregion

        #region # 对通配符匹配的结果分词节点 —— WildcardSegmentElement WildcardSegmentElement
        /// <summary>
        /// 对通配符匹配的结果分词节点
        /// </summary>
        [ConfigurationProperty("wildcardSegment", IsRequired = true)]
        public WildcardSegmentElement WildcardSegmentElement
        {
            get { return (WildcardSegmentElement)this["wildcardSegment"]; }
            set { this["wildcardSegment"] = value; }
        }
        #endregion

        #region # 用户自定义规则匹配节点 —— CustomRuleElement CustomRuleElement
        /// <summary>
        /// 用户自定义规则匹配节点
        /// </summary>
        [ConfigurationProperty("customRule", IsRequired = true)]
        public CustomRuleElement CustomRuleElement
        {
            get { return (CustomRuleElement)this["customRule"]; }
            set { this["customRule"] = value; }
        }
        #endregion
    }
}
