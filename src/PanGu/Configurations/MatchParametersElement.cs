using System.Configuration;

namespace PanGu.Configurations
{
    /// <summary>
    /// 参数节点
    /// </summary>
    internal class MatchParametersElement : ConfigurationElement
    {
        #region # 未登录词权值节点 —— NumericElement UnknowRankElement
        /// <summary>
        /// 未登录词权值节点
        /// </summary>
        [ConfigurationProperty("unknowRank", IsRequired = true)]
        public NumericElement UnknowRankElement
        {
            get { return (NumericElement)this["unknowRank"]; }
            set { this["unknowRank"] = value; }
        }
        #endregion

        #region # 最匹配词权值节点 —— NumericElement BestRankElement
        /// <summary>
        /// 最匹配词权值节点
        /// </summary>
        [ConfigurationProperty("bestRank", IsRequired = true)]
        public NumericElement BestRankElement
        {
            get { return (NumericElement)this["bestRank"]; }
            set { this["bestRank"] = value; }
        }
        #endregion

        #region # 次匹配词权值节点 —— NumericElement SecRankElement
        /// <summary>
        /// 次匹配词权值节点
        /// </summary>
        [ConfigurationProperty("secRank", IsRequired = true)]
        public NumericElement SecRankElement
        {
            get { return (NumericElement)this["secRank"]; }
            set { this["secRank"] = value; }
        }
        #endregion

        #region # 再次匹配词权值节点 —— NumericElement ThirdRankElement
        /// <summary>
        /// 再次匹配词权值节点
        /// </summary>
        [ConfigurationProperty("thirdRank", IsRequired = true)]
        public NumericElement ThirdRankElement
        {
            get { return (NumericElement)this["thirdRank"]; }
            set { this["thirdRank"] = value; }
        }
        #endregion

        #region # 强行输出的单字的权值节点 —— NumericElement SingleRankElement
        /// <summary>
        /// 强行输出的单字的权值节点
        /// </summary>
        [ConfigurationProperty("singleRank", IsRequired = true)]
        public NumericElement SingleRankElement
        {
            get { return (NumericElement)this["singleRank"]; }
            set { this["singleRank"] = value; }
        }
        #endregion

        #region # 数字的权值节点 —— NumericElement NumericRankElement
        /// <summary>
        /// 数字的权值节点
        /// </summary>
        [ConfigurationProperty("numericRank", IsRequired = true)]
        public NumericElement NumericRankElement
        {
            get { return (NumericElement)this["numericRank"]; }
            set { this["numericRank"] = value; }
        }
        #endregion

        #region # 英文词汇的权值节点 —— NumericElement EnglishRankElement
        /// <summary>
        /// 英文词汇的权值节点
        /// </summary>
        [ConfigurationProperty("englishRank", IsRequired = true)]
        public NumericElement EnglishRankElement
        {
            get { return (NumericElement)this["englishRank"]; }
            set { this["englishRank"] = value; }
        }
        #endregion

        #region # 英文词汇小写的权值节点 —— NumericElement EnglishLowerRankElement
        /// <summary>
        /// 英文词汇小写的权值节点
        /// </summary>
        [ConfigurationProperty("englishLowerRank", IsRequired = true)]
        public NumericElement EnglishLowerRankElement
        {
            get { return (NumericElement)this["englishLowerRank"]; }
            set { this["englishLowerRank"] = value; }
        }
        #endregion

        #region # 英文词汇词根的权值节点 —— NumericElement EnglishStemRankElement
        /// <summary>
        /// 英文词汇词根的权值节点
        /// </summary>
        [ConfigurationProperty("englishStemRank", IsRequired = true)]
        public NumericElement EnglishStemRankElement
        {
            get { return (NumericElement)this["englishStemRank"]; }
            set { this["englishStemRank"] = value; }
        }
        #endregion

        #region # 符号的权值节点 —— NumericElement SymbolRankElement
        /// <summary>
        /// 符号的权值节点
        /// </summary>
        [ConfigurationProperty("symbolRank", IsRequired = true)]
        public NumericElement SymbolRankElement
        {
            get { return (NumericElement)this["symbolRank"]; }
            set { this["symbolRank"] = value; }
        }
        #endregion

        #region # 强制同时输出简繁汉字时，非原来文本的汉字输出权值节点 —— NumericElement...
        /// <summary>
        /// 强制同时输出简繁汉字时，非原来文本的汉字输出权值节点
        /// </summary>
        [ConfigurationProperty("simplifiedTraditionalRank", IsRequired = true)]
        public NumericElement SimplifiedTraditionalRankElement
        {
            get { return (NumericElement)this["simplifiedTraditionalRank"]; }
            set { this["simplifiedTraditionalRank"] = value; }
        }
        #endregion

        #region # 同义词的权值节点 —— NumericElement SynonymRankElement
        /// <summary>
        /// 同义词的权值节点
        /// </summary>
        [ConfigurationProperty("synonymRank", IsRequired = true)]
        public NumericElement SynonymRankElement
        {
            get { return (NumericElement)this["synonymRank"]; }
            set { this["synonymRank"] = value; }
        }
        #endregion

        #region # 通配符匹配结果的权值节点 —— NumericElement WildcardRankElement
        /// <summary>
        /// 通配符匹配结果的权值节点
        /// </summary>
        [ConfigurationProperty("wildcardRank", IsRequired = true)]
        public NumericElement WildcardRankElement
        {
            get { return (NumericElement)this["wildcardRank"]; }
            set { this["wildcardRank"] = value; }
        }
        #endregion

        #region # 过滤大于此长度的英文节点 —— NumericElement FilterEnglishLengthElement
        /// <summary>
        /// 过滤大于此长度的英文节点
        /// </summary>
        [ConfigurationProperty("filterEnglishLength", IsRequired = true)]
        public NumericElement FilterEnglishLengthElement
        {
            get { return (NumericElement)this["filterEnglishLength"]; }
            set { this["filterEnglishLength"] = value; }
        }
        #endregion

        #region # 过滤大于此长度的数字节点 —— NumericElement FilterNumericLengthElement
        /// <summary>
        /// 过滤大于此长度的数字节点
        /// </summary>
        [ConfigurationProperty("filterNumericLength", IsRequired = true)]
        public NumericElement FilterNumericLengthElement
        {
            get { return (NumericElement)this["filterNumericLength"]; }
            set { this["filterNumericLength"] = value; }
        }
        #endregion

        #region # 用户自定义规则程序集节点 —— TextElement CustomRuleAssembly...
        /// <summary>
        /// 用户自定义规则程序集节点
        /// </summary>
        [ConfigurationProperty("customRuleAssemblyFileName", IsRequired = false)]
        public TextElement CustomRuleAssemblyFileNameElement
        {
            get { return (TextElement)this["customRuleAssemblyFileName"]; }
            set { this["customRuleAssemblyFileName"] = value; }
        }
        #endregion

        #region # 用户自定义规则的完整类名节点 —— TextElement CustomRuleFul...
        /// <summary>
        /// 用户自定义规则的完整类名节点
        /// </summary>
        [ConfigurationProperty("customRuleFullClassName", IsRequired = false)]
        public TextElement CustomRuleFullClassNameElement
        {
            get { return (TextElement)this["customRuleFullClassName"]; }
            set { this["customRuleFullClassName"] = value; }
        }
        #endregion

        #region # 多元分词冗余度节点 —— NumericElement RedundancyElement
        /// <summary>
        /// 多元分词冗余度节点
        /// </summary>
        [ConfigurationProperty("redundancy", IsRequired = true)]
        public NumericElement RedundancyElement
        {
            get { return (NumericElement)this["redundancy"]; }
            set { this["redundancy"] = value; }
        }
        #endregion
    }
}
