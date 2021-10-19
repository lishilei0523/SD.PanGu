using System.Configuration;

namespace PanGu.Configurations
{
    /// <summary>
    /// 匹配选项节点
    /// </summary>
    internal class MatchOptionsElement : ConfigurationElement
    {
        #region # 中文名识别节点 —— BooleanElement ChineseNameIdentifyElement
        /// <summary>
        /// 中文名识别节点
        /// </summary>
        [ConfigurationProperty("chineseNameIdentify", IsRequired = true)]
        public BooleanElement ChineseNameIdentifyElement
        {
            get { return (BooleanElement)this["chineseNameIdentify"]; }
            set { this["chineseNameIdentify"] = value; }
        }
        #endregion

        #region # 词频优先节点 —— BooleanElement FrequencyFirstElement
        /// <summary>
        /// 词频优先节点
        /// </summary>
        [ConfigurationProperty("frequencyFirst", IsRequired = true)]
        public BooleanElement FrequencyFirstElement
        {
            get { return (BooleanElement)this["frequencyFirst"]; }
            set { this["frequencyFirst"] = value; }
        }
        #endregion

        #region # 多元分词节点 —— BooleanElement MultiDimensionalityElement
        /// <summary>
        /// 多元分词节点
        /// </summary>
        [ConfigurationProperty("multiDimensionality", IsRequired = true)]
        public BooleanElement MultiDimensionalityElement
        {
            get { return (BooleanElement)this["multiDimensionality"]; }
            set { this["multiDimensionality"] = value; }
        }
        #endregion

        #region # 英文多元分词节点 —— BooleanElement EnglishMultiDimensionalityElement
        /// <summary>
        /// 英文多元分词节点
        /// </summary>
        [ConfigurationProperty("englishMultiDimensionality", IsRequired = true)]
        public BooleanElement EnglishMultiDimensionalityElement
        {
            get { return (BooleanElement)this["englishMultiDimensionality"]; }
            set { this["englishMultiDimensionality"] = value; }
        }
        #endregion

        #region # 过滤停用词节点 —— BooleanElement FilterStopWordsElement
        /// <summary>
        /// 过滤停用词节点
        /// </summary>
        [ConfigurationProperty("filterStopWords", IsRequired = true)]
        public BooleanElement FilterStopWordsElement
        {
            get { return (BooleanElement)this["filterStopWords"]; }
            set { this["filterStopWords"] = value; }
        }
        #endregion

        #region # 忽略空格、回车、Tab节点 —— BooleanElement IgnoreSpaceElement
        /// <summary>
        /// 忽略空格、回车、Tab节点
        /// </summary>
        [ConfigurationProperty("ignoreSpace", IsRequired = true)]
        public BooleanElement IgnoreSpaceElement
        {
            get { return (BooleanElement)this["ignoreSpace"]; }
            set { this["ignoreSpace"] = value; }
        }
        #endregion

        #region # 强制一元分词节点 —— BooleanElement ForceSingleWordElement
        /// <summary>
        /// 强制一元分词节点
        /// </summary>
        [ConfigurationProperty("forceSingleWord", IsRequired = true)]
        public BooleanElement ForceSingleWordElement
        {
            get { return (BooleanElement)this["forceSingleWord"]; }
            set { this["forceSingleWord"] = value; }
        }
        #endregion

        #region # 繁体中文开关节点 —— BooleanElement TraditionalChineseEnabledElement
        /// <summary>
        /// 繁体中文开关节点
        /// </summary>
        [ConfigurationProperty("traditionalChineseEnabled", IsRequired = true)]
        public BooleanElement TraditionalChineseEnabledElement
        {
            get { return (BooleanElement)this["traditionalChineseEnabled"]; }
            set { this["traditionalChineseEnabled"] = value; }
        }
        #endregion

        #region # 同时输出简体和繁体节点 —— BooleanElement OutputSimplifiedTraditionalElement
        /// <summary>
        /// 同时输出简体和繁体节点
        /// </summary>
        [ConfigurationProperty("outputSimplifiedTraditional", IsRequired = true)]
        public BooleanElement OutputSimplifiedTraditionalElement
        {
            get { return (BooleanElement)this["outputSimplifiedTraditional"]; }
            set { this["outputSimplifiedTraditional"] = value; }
        }
        #endregion

        #region # 未登录词识别节点 —— BooleanElement UnknownWordIdentifyElement
        /// <summary>
        /// 未登录词识别节点
        /// </summary>
        [ConfigurationProperty("unknownWordIdentify", IsRequired = true)]
        public BooleanElement UnknownWordIdentifyElement
        {
            get { return (BooleanElement)this["unknownWordIdentify"]; }
            set { this["unknownWordIdentify"] = value; }
        }
        #endregion

        #region # 过滤英文节点 —— BooleanElement FilterEnglishElement
        /// <summary>
        /// 过滤英文节点
        /// </summary>
        [ConfigurationProperty("filterEnglish", IsRequired = true)]
        public BooleanElement FilterEnglishElement
        {
            get { return (BooleanElement)this["filterEnglish"]; }
            set { this["filterEnglish"] = value; }
        }
        #endregion

        #region # 过滤数字节点 —— BooleanElement FilterNumericElement
        /// <summary>
        /// 过滤数字节点
        /// </summary>
        [ConfigurationProperty("filterNumeric", IsRequired = true)]
        public BooleanElement FilterNumericElement
        {
            get { return (BooleanElement)this["filterNumeric"]; }
            set { this["filterNumeric"] = value; }
        }
        #endregion

        #region # 忽略英文大小写节点 —— BooleanElement IgnoreCapitalElement
        /// <summary>
        /// 忽略英文大小写节点
        /// </summary>
        [ConfigurationProperty("ignoreCapital", IsRequired = true)]
        public BooleanElement IgnoreCapitalElement
        {
            get { return (BooleanElement)this["ignoreCapital"]; }
            set { this["ignoreCapital"] = value; }
        }
        #endregion

        #region # 英文分词节点 —— BooleanElement EnglishSegmentElement
        /// <summary>
        /// 英文分词节点
        /// </summary>
        [ConfigurationProperty("englishSegment", IsRequired = true)]
        public BooleanElement EnglishSegmentElement
        {
            get { return (BooleanElement)this["englishSegment"]; }
            set { this["englishSegment"] = value; }
        }
        #endregion

        #region # 同义词输出节点 —— BooleanElement SynonymOutputElement
        /// <summary>
        /// 同义词输出节点
        /// </summary>
        [ConfigurationProperty("synonymOutput", IsRequired = true)]
        public BooleanElement SynonymOutputElement
        {
            get { return (BooleanElement)this["synonymOutput"]; }
            set { this["synonymOutput"] = value; }
        }
        #endregion

        #region # 通配符匹配输出节点 —— BooleanElement WildcardOutputElement
        /// <summary>
        /// 通配符匹配输出节点
        /// </summary>
        [ConfigurationProperty("wildcardOutput", IsRequired = true)]
        public BooleanElement WildcardOutputElement
        {
            get { return (BooleanElement)this["wildcardOutput"]; }
            set { this["wildcardOutput"] = value; }
        }
        #endregion

        #region # 对通配符匹配的结果分词节点 —— BooleanElement WildcardSegmentElement
        /// <summary>
        /// 对通配符匹配的结果分词节点
        /// </summary>
        [ConfigurationProperty("wildcardSegment", IsRequired = true)]
        public BooleanElement WildcardSegmentElement
        {
            get { return (BooleanElement)this["wildcardSegment"]; }
            set { this["wildcardSegment"] = value; }
        }
        #endregion

        #region # 用户自定义规则匹配节点 —— BooleanElement CustomRuleElement
        /// <summary>
        /// 用户自定义规则匹配节点
        /// </summary>
        [ConfigurationProperty("customRule", IsRequired = true)]
        public BooleanElement CustomRuleElement
        {
            get { return (BooleanElement)this["customRule"]; }
            set { this["customRule"] = value; }
        }
        #endregion
    }
}
