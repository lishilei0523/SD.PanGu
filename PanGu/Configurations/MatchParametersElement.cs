using System.Configuration;
using PanGu.Configurations.MatchParameters;

namespace PanGu.Configurations
{
    /// <summary>
    /// 参数节点
    /// </summary>
    internal class MatchParametersElement : ConfigurationElement
    {
        #region # 未登录词权值节点 —— UnknowRankElement UnknowRankElement
        /// <summary>
        /// 未登录词权值节点
        /// </summary>
        [ConfigurationProperty("unknowRank", IsRequired = true)]
        public UnknowRankElement UnknowRankElement
        {
            get { return (UnknowRankElement)this["unknowRank"]; }
            set { this["unknowRank"] = value; }
        }
        #endregion

        #region # 最匹配词权值节点 —— BestRankElement BestRankElement
        /// <summary>
        /// 最匹配词权值节点
        /// </summary>
        [ConfigurationProperty("bestRank", IsRequired = true)]
        public BestRankElement BestRankElement
        {
            get { return (BestRankElement)this["bestRank"]; }
            set { this["bestRank"] = value; }
        }
        #endregion

        #region # 次匹配词权值节点 —— SecRankElement SecRankElement
        /// <summary>
        /// 次匹配词权值节点
        /// </summary>
        [ConfigurationProperty("secRank", IsRequired = true)]
        public SecRankElement SecRankElement
        {
            get { return (SecRankElement)this["secRank"]; }
            set { this["secRank"] = value; }
        }
        #endregion

        #region # 再次匹配词权值节点 —— ThirdRankElement ThirdRankElement
        /// <summary>
        /// 再次匹配词权值节点
        /// </summary>
        [ConfigurationProperty("thirdRank", IsRequired = true)]
        public ThirdRankElement ThirdRankElement
        {
            get { return (ThirdRankElement)this["thirdRank"]; }
            set { this["thirdRank"] = value; }
        }
        #endregion

        #region # 强行输出的单字的权值节点 —— SingleRankElement SingleRankElement
        /// <summary>
        /// 强行输出的单字的权值节点
        /// </summary>
        [ConfigurationProperty("singleRank", IsRequired = true)]
        public SingleRankElement SingleRankElement
        {
            get { return (SingleRankElement)this["singleRank"]; }
            set { this["singleRank"] = value; }
        }
        #endregion

        #region # 数字的权值节点 —— NumericRankElement NumericRankElement
        /// <summary>
        /// 数字的权值节点
        /// </summary>
        [ConfigurationProperty("numericRank", IsRequired = true)]
        public NumericRankElement NumericRankElement
        {
            get { return (NumericRankElement)this["numericRank"]; }
            set { this["numericRank"] = value; }
        }
        #endregion

        #region # 英文词汇的权值节点 —— EnglishRankElement EnglishRankElement
        /// <summary>
        /// 英文词汇的权值节点
        /// </summary>
        [ConfigurationProperty("englishRank", IsRequired = true)]
        public EnglishRankElement EnglishRankElement
        {
            get { return (EnglishRankElement)this["englishRank"]; }
            set { this["englishRank"] = value; }
        }
        #endregion

        #region # 英文词汇小写的权值节点 —— EnglishLowerRankElement EnglishLowerRankElement
        /// <summary>
        /// 英文词汇小写的权值节点
        /// </summary>
        [ConfigurationProperty("englishLowerRank", IsRequired = true)]
        public EnglishLowerRankElement EnglishLowerRankElement
        {
            get { return (EnglishLowerRankElement)this["englishLowerRank"]; }
            set { this["englishLowerRank"] = value; }
        }
        #endregion

        #region # 英文词汇词根的权值节点 —— EnglishStemRankElement EnglishStemRankElement
        /// <summary>
        /// 英文词汇词根的权值节点
        /// </summary>
        [ConfigurationProperty("englishStemRank", IsRequired = true)]
        public EnglishStemRankElement EnglishStemRankElement
        {
            get { return (EnglishStemRankElement)this["englishStemRank"]; }
            set { this["englishStemRank"] = value; }
        }
        #endregion

        #region # 符号的权值节点 —— SymbolRankElement SymbolRankElement
        /// <summary>
        /// 符号的权值节点
        /// </summary>
        [ConfigurationProperty("symbolRank", IsRequired = true)]
        public SymbolRankElement SymbolRankElement
        {
            get { return (SymbolRankElement)this["symbolRank"]; }
            set { this["symbolRank"] = value; }
        }
        #endregion

        #region # 强制同时输出简繁汉字时，非原来文本的汉字输出权值节点 —— SimplifiedTrad...
        /// <summary>
        /// 强制同时输出简繁汉字时，非原来文本的汉字输出权值节点
        /// </summary>
        [ConfigurationProperty("simplifiedTraditionalRank", IsRequired = true)]
        public SimplifiedTraditionalRankElement SimplifiedTraditionalRankElement
        {
            get { return (SimplifiedTraditionalRankElement)this["simplifiedTraditionalRank"]; }
            set { this["simplifiedTraditionalRank"] = value; }
        }
        #endregion

        #region # 同义词的权值节点 —— SynonymRankElement SynonymRankElement
        /// <summary>
        /// 同义词的权值节点
        /// </summary>
        [ConfigurationProperty("synonymRank", IsRequired = true)]
        public SynonymRankElement SynonymRankElement
        {
            get { return (SynonymRankElement)this["synonymRank"]; }
            set { this["synonymRank"] = value; }
        }
        #endregion

        #region # 通配符匹配结果的权值节点 —— WildcardRankElement WildcardRankElement
        /// <summary>
        /// 通配符匹配结果的权值节点
        /// </summary>
        [ConfigurationProperty("wildcardRank", IsRequired = true)]
        public WildcardRankElement WildcardRankElement
        {
            get { return (WildcardRankElement)this["wildcardRank"]; }
            set { this["wildcardRank"] = value; }
        }
        #endregion

        #region # 过滤大于此长度的英文节点 —— FilterEnglishLengthElement FilterEnglishLengthElement
        /// <summary>
        /// 过滤大于此长度的英文节点
        /// </summary>
        [ConfigurationProperty("filterEnglishLength", IsRequired = true)]
        public FilterEnglishLengthElement FilterEnglishLengthElement
        {
            get { return (FilterEnglishLengthElement)this["filterEnglishLength"]; }
            set { this["filterEnglishLength"] = value; }
        }
        #endregion

        #region # 过滤大于此长度的数字节点 —— FilterNumericLengthElement FilterNumericLengthElement
        /// <summary>
        /// 过滤大于此长度的数字节点
        /// </summary>
        [ConfigurationProperty("filterNumericLength", IsRequired = true)]
        public FilterNumericLengthElement FilterNumericLengthElement
        {
            get { return (FilterNumericLengthElement)this["filterNumericLength"]; }
            set { this["filterNumericLength"] = value; }
        }
        #endregion

        #region # 用户自定义规则程序集节点 —— CustomRuleAssemblyFileNameElement CustomRuleAssembly...
        /// <summary>
        /// 用户自定义规则程序集节点
        /// </summary>
        [ConfigurationProperty("customRuleAssemblyFileName", IsRequired = false)]
        public CustomRuleAssemblyFileNameElement CustomRuleAssemblyFileNameElement
        {
            get { return (CustomRuleAssemblyFileNameElement)this["customRuleAssemblyFileName"]; }
            set { this["customRuleAssemblyFileName"] = value; }
        }
        #endregion

        #region # 用户自定义规则的完整类名节点 —— CustomRuleFullClassNameElement CustomRuleFul...
        /// <summary>
        /// 用户自定义规则的完整类名节点
        /// </summary>
        [ConfigurationProperty("customRuleFullClassName", IsRequired = false)]
        public CustomRuleFullClassNameElement CustomRuleFullClassNameElement
        {
            get { return (CustomRuleFullClassNameElement)this["customRuleFullClassName"]; }
            set { this["customRuleFullClassName"] = value; }
        }
        #endregion

        #region # 多元分词冗余度节点 —— RedundancyElement RedundancyElement
        /// <summary>
        /// 多元分词冗余度节点
        /// </summary>
        [ConfigurationProperty("redundancy", IsRequired = true)]
        public RedundancyElement RedundancyElement
        {
            get { return (RedundancyElement)this["redundancy"]; }
            set { this["redundancy"] = value; }
        }
        #endregion
    }
}
