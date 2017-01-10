using System;
using System.Reflection;

namespace PanGu.Settings
{
    /// <summary>
    /// 匹配选项
    /// </summary>
    [Serializable]
    public class MatchOption : ICloneable
    {
        #region # 构造器

        /// <summary>
        /// 无参构造器
        /// </summary>
        public MatchOption()
        {
            //默认值
            this.ChineseNameIdentify = false;
            this.FrequencyFirst = false;
            this.MultiDimensionality = true;
            this.EnglishMultiDimensionality = false;
            this.FilterStopWords = true;
            this.IgnoreSpace = true;
            this.ForceSingleWord = false;
            this.TraditionalChineseEnabled = false;
            this.OutputSimplifiedTraditional = false;
            this.UnknownWordIdentify = true;
            this.FilterEnglish = false;
            this.FilterNumeric = false;
            this.IgnoreCapital = false;
            this.EnglishSegment = false;
            this.SynonymOutput = false;
            this.WildcardOutput = false;
            this.WildcardSegment = false;
            this.CustomRule = false;
        }

        /// <summary>
        /// 基础构造器
        /// </summary>
        public MatchOption(bool chineseNameIdentify, bool frequencyFirst, bool multiDimensionality, bool englishMultiDimensionality, bool filterStopWords, bool ignoreSpace, bool forceSingleWord, bool traditionalChineseEnabled, bool outputSimplifiedTraditional, bool unknownWordIdentify, bool filterEnglish, bool filterNumeric, bool ignoreCapital, bool englishSegment, bool synonymOutput, bool wildcardOutput, bool wildcardSegment, bool customRule)
        {
            this.ChineseNameIdentify = chineseNameIdentify;
            this.FrequencyFirst = frequencyFirst;
            this.MultiDimensionality = multiDimensionality;
            this.EnglishMultiDimensionality = englishMultiDimensionality;
            this.FilterStopWords = filterStopWords;
            this.IgnoreSpace = ignoreSpace;
            this.ForceSingleWord = forceSingleWord;
            this.TraditionalChineseEnabled = traditionalChineseEnabled;
            this.OutputSimplifiedTraditional = outputSimplifiedTraditional;
            this.UnknownWordIdentify = unknownWordIdentify;
            this.FilterEnglish = filterEnglish;
            this.FilterNumeric = filterNumeric;
            this.IgnoreCapital = ignoreCapital;
            this.EnglishSegment = englishSegment;
            this.SynonymOutput = synonymOutput;
            this.WildcardOutput = wildcardOutput;
            this.WildcardSegment = wildcardSegment;
            this.CustomRule = customRule;
        }

        #endregion

        #region # 属性

        #region 中文人名识别 —— bool ChineseNameIdentify
        /// <summary>
        /// 中文人名识别
        /// </summary>
        public bool ChineseNameIdentify { get; private set; }
        #endregion

        #region 词频优先 —— bool FrequencyFirst
        /// <summary>
        /// 词频优先
        /// </summary>
        public bool FrequencyFirst { get; private set; }
        #endregion

        #region 多元分词 —— bool MultiDimensionality
        /// <summary>
        /// 多元分词
        /// </summary>
        public bool MultiDimensionality { get; private set; }
        #endregion

        #region 英文多元分词 —— bool EnglishMultiDimensionality
        /// <summary>
        /// 英文多元分词
        /// </summary>
        /// <remarks>
        /// 这个开关，会将英文中的字母和数字分开。
        /// </remarks>
        public bool EnglishMultiDimensionality { get; private set; }
        #endregion

        #region 过滤停用词 —— bool FilterStopWords
        /// <summary>
        /// 过滤停用词
        /// </summary>
        public bool FilterStopWords { get; private set; }
        #endregion

        #region 忽略空格、回车、Tab —— bool IgnoreSpace
        /// <summary>
        /// 忽略空格、回车、Tab
        /// </summary>
        public bool IgnoreSpace { get; private set; }
        #endregion

        #region 强制一元分词 —— bool ForceSingleWord
        /// <summary>
        /// 强制一元分词
        /// </summary>
        public bool ForceSingleWord { get; private set; }
        #endregion

        #region 繁体中文开关 —— bool TraditionalChineseEnabled
        /// <summary>
        /// 繁体中文开关
        /// </summary>
        public bool TraditionalChineseEnabled { get; private set; }
        #endregion

        #region 同时输出简体和繁体 —— bool OutputSimplifiedTraditional
        /// <summary>
        /// 同时输出简体和繁体
        /// </summary>
        public bool OutputSimplifiedTraditional { get; private set; }
        #endregion

        #region 未登录词识别 —— bool UnknownWordIdentify
        /// <summary>
        /// 未登录词识别
        /// </summary>
        public bool UnknownWordIdentify { get; private set; }
        #endregion

        #region 过滤英文 —— bool FilterEnglish
        /// <summary>
        /// 过滤英文
        /// </summary>
        /// <remarks>
        /// 这个选项只有在过滤停用词选项生效时才有效
        /// </remarks>
        public bool FilterEnglish { get; private set; }
        #endregion

        #region 过滤数字 —— bool FilterNumeric
        /// <summary>
        /// 过滤数字
        /// </summary>
        /// <remarks>
        /// 这个选项只有在过滤停用词选项生效时才有效
        /// </remarks>
        public bool FilterNumeric { get; private set; }
        #endregion

        #region 忽略英文大小写 —— bool IgnoreCapital
        /// <summary>
        /// 忽略英文大小写
        /// </summary>
        public bool IgnoreCapital { get; private set; }
        #endregion

        #region 英文分词 —— bool EnglishSegment
        /// <summary>
        /// 英文分词
        /// </summary>
        public bool EnglishSegment { get; private set; }
        #endregion

        #region 同义词输出 —— bool SynonymOutput
        /// <summary>
        /// 同义词输出
        /// </summary>
        /// <remarks>
        /// 同义词输出功能一般用于对搜索字符串的分词，不建议在索引时使用
        /// </remarks>
        public bool SynonymOutput { get; private set; }
        #endregion

        #region 通配符匹配输出 —— bool WildcardOutput
        /// <summary>
        /// 通配符匹配输出
        /// </summary>
        /// <remarks>
        /// 同义词输出功能一般用于对搜索字符串的分词，不建议在索引时使用
        /// </remarks>
        public bool WildcardOutput { get; private set; }
        #endregion

        #region 对通配符匹配的结果分词 —— bool WildcardSegment
        /// <summary>
        /// 对通配符匹配的结果分词
        /// </summary>
        public bool WildcardSegment { get; private set; }
        #endregion

        #region 是否进行用户自定义规则匹配 —— bool CustomRule
        /// <summary>
        /// 是否进行用户自定义规则匹配
        /// </summary>
        public bool CustomRule { get; private set; }
        #endregion

        #endregion

        #region # 方法

        #region 修改信息 —— void Update(bool synonymOutput, bool wildcardOutput)
        /// <summary>
        /// 修改信息
        /// </summary>
        public void Update(bool synonymOutput, bool wildcardOutput)
        {
            this.SynonymOutput = synonymOutput;
            this.WildcardOutput = wildcardOutput;
        }
        #endregion

        #region 深拷贝 —— object Clone()
        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <returns>克隆实例</returns>
        public object Clone()
        {
            MatchOption result = new MatchOption();

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
