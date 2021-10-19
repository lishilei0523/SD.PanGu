using System;
using System.Reflection;

namespace PanGu.Settings
{
    /// <summary>
    /// 匹配参数
    /// </summary>
    [Serializable]
    public class MatchParameter : ICloneable
    {
        #region # 构造器

        /// <summary>
        /// 无参构造器
        /// </summary>
        public MatchParameter()
        {
            //默认值
            this.UnknowRank = 1;
            this.BestRank = 5;
            this.SecRank = 3;
            this.ThirdRank = 2;
            this.SingleRank = 1;
            this.NumericRank = 1;
            this.EnglishRank = 5;
            this.EnglishLowerRank = 3;
            this.EnglishStemRank = 2;
            this.SymbolRank = 1;
            this.SimplifiedTraditionalRank = 1;
            this.SynonymRank = 1;
            this.WildcardRank = 1;
            this.FilterEnglishLength = 0;
            this.FilterNumericLength = 0;
            this.CustomRuleAssemblyFileName = string.Empty;
            this.CustomRuleFullClassName = string.Empty;
            this.Redundancy = 0;
        }

        /// <summary>
        /// 基础构造器
        /// </summary>
        public MatchParameter(int unknowRank, int bestRank, int secRank, int thirdRank, int singleRank, int numericRank, int englishRank, int englishLowerRank, int englishStemRank, int symbolRank, int simplifiedTraditionalRank, int synonymRank, int wildcardRank, int filterEnglishLength, int filterNumericLength, string customRuleAssemblyFileName, string customRuleFullClassName, int redundancy)
        {
            this.UnknowRank = unknowRank;
            this.BestRank = bestRank;
            this.SecRank = secRank;
            this.ThirdRank = thirdRank;
            this.SingleRank = singleRank;
            this.NumericRank = numericRank;
            this.EnglishRank = englishRank;
            this.EnglishLowerRank = englishLowerRank;
            this.EnglishStemRank = englishStemRank;
            this.SymbolRank = symbolRank;
            this.SimplifiedTraditionalRank = simplifiedTraditionalRank;
            this.SynonymRank = synonymRank;
            this.WildcardRank = wildcardRank;
            this.FilterEnglishLength = filterEnglishLength;
            this.FilterNumericLength = filterNumericLength;
            this.CustomRuleAssemblyFileName = customRuleAssemblyFileName;
            this.CustomRuleFullClassName = customRuleFullClassName;

            if (redundancy < 0)
            {
                this.Redundancy = 0;
            }
            else if (redundancy >= 3)
            {
                this.Redundancy = 2;
            }
            else
            {
                this.Redundancy = redundancy;
            }
        }

        #endregion

        #region # 属性

        #region 未登录词权值 —— int UnknowRank
        /// <summary>
        /// 未登录词权值
        /// </summary>
        public int UnknowRank { get; private set; }
        #endregion

        #region 最匹配词权值 —— int BestRank
        /// <summary>
        /// 最匹配词权值
        /// </summary>
        public int BestRank { get; private set; }
        #endregion

        #region 次匹配词权值 —— int SecRank
        /// <summary>
        /// 次匹配词权值
        /// </summary>
        public int SecRank { get; private set; }
        #endregion

        #region 再次匹配词权值 —— int ThirdRank
        /// <summary>
        /// 再次匹配词权值
        /// </summary>
        public int ThirdRank { get; private set; }
        #endregion

        #region 强行输出的单字的权值 —— int SingleRank
        /// <summary>
        /// 强行输出的单字的权值
        /// </summary>
        public int SingleRank { get; private set; }
        #endregion

        #region 数字的权值 —— int NumericRank
        /// <summary>
        /// 数字的权值
        /// </summary>
        public int NumericRank { get; private set; }
        #endregion

        #region 英文词汇权值 —— int EnglishRank
        /// <summary>
        /// 英文词汇权值
        /// </summary>
        public int EnglishRank { get; private set; }
        #endregion

        #region 英文词汇小写的权值 —— int EnglishLowerRank
        /// <summary>
        /// 英文词汇小写的权值
        /// </summary>
        public int EnglishLowerRank { get; private set; }
        #endregion

        #region 英文词汇词根的权值 —— int EnglishStemRank
        /// <summary>
        /// 英文词汇词根的权值
        /// </summary>
        public int EnglishStemRank { get; private set; }
        #endregion

        #region 符号的权值 —— int SymbolRank
        /// <summary>
        /// 符号的权值
        /// </summary>
        public int SymbolRank { get; private set; }
        #endregion

        #region 非原来文本的汉字输出权值 —— int SimplifiedTraditionalRank
        /// <summary>
        /// 强制同时输出简繁汉字时，非原来文本的汉字输出权值。
        /// </summary>
        /// <remarks>
        /// 比如原来文本是简体，这里就是输出的繁体字的权值，反之亦然。
        /// </remarks>
        public int SimplifiedTraditionalRank { get; private set; }
        #endregion

        #region 同义词权值 —— int SynonymRank
        /// <summary>
        /// 同义词权值
        /// </summary>
        public int SynonymRank { get; private set; }
        #endregion

        #region 通配符匹配结果的权值 —— int WildcardRank
        /// <summary>
        /// 通配符匹配结果的权值
        /// </summary>
        public int WildcardRank { get; private set; }
        #endregion

        #region 过滤大于这个长度的英文 —— int FilterEnglishLength
        /// <summary>
        /// 过滤英文选项生效时，过滤大于这个长度的英文。
        /// </summary>
        public int FilterEnglishLength { get; private set; }
        #endregion

        #region 过滤大于这个长度的数字 —— int FilterNumericLength
        /// <summary>
        /// 过滤数字选项生效时，过滤大于这个长度的数字。
        /// </summary>
        public int FilterNumericLength { get; private set; }
        #endregion

        #region 用户自定义规则的配件程序集名 —— string CustomRuleAssemblyFileName
        /// <summary>
        /// 用户自定义规则的配件程序集名
        /// </summary>
        public string CustomRuleAssemblyFileName { get; private set; }
        #endregion

        #region 用户自定义规则的类的完整类名 —— string CustomRuleFullClassName
        /// <summary>
        /// 用户自定义规则的类的完整类名，即带名字空间的名称
        /// </summary>
        public string CustomRuleFullClassName { get; private set; }
        #endregion

        #region 多元分词冗余度 —— int Redundancy
        /// <summary>
        /// 多元分词冗余度
        /// </summary>
        public int Redundancy { get; private set; }
        #endregion

        #endregion

        #region # 方法

        #region 修改信息 —— void Update(int filterEnglishLength, int filterNumericLength, int redundancy)
        /// <summary>
        /// 修改信息
        /// </summary>
        public void Update(int filterEnglishLength, int filterNumericLength, int redundancy)
        {
            this.FilterEnglishLength = filterEnglishLength;
            this.FilterNumericLength = filterNumericLength;
            this.Redundancy = redundancy;
        }
        #endregion

        #region 深拷贝 —— object Clone()
        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <returns>克隆实例</returns>
        public object Clone()
        {
            MatchParameter result = new MatchParameter();

            foreach (FieldInfo fi in this.GetType().GetFields())
            {
                object value = fi.GetValue(this);
                fi.SetValue(result, value);
            }

            return result;
        }
        #endregion

        #endregion
    }
}
