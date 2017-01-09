using System;
using System.Configuration;
using PanGu.Configurations;

// ReSharper disable once CheckNamespace
namespace PanGu
{
    /// <summary>
    /// 盘古分词配置
    /// </summary>
    internal class PanGuConfiguration : ConfigurationSection
    {
        #region # 字段及构造器

        /// <summary>
        /// 单例
        /// </summary>
        private static readonly PanGuConfiguration _Setting;

        /// <summary>
        /// 静态构造器
        /// </summary>
        static PanGuConfiguration()
        {
            _Setting = (PanGuConfiguration)ConfigurationManager.GetSection("panGuConfiguration");

            #region # 非空验证

            if (_Setting == null)
            {
                throw new ApplicationException("盘古分词节点未配置，请检查程序！");
            }

            #endregion
        }

        #endregion

        #region # 访问器 —— static PanGuConfiguration Setting
        /// <summary>
        /// 访问器
        /// </summary>
        public static PanGuConfiguration Setting
        {
            get { return _Setting; }
        }
        #endregion

        #region # 字典路径节点 —— DictionaryPathElement DictionaryPathElement
        /// <summary>
        /// 字典路径节点
        /// </summary>
        [ConfigurationProperty("dictionaryPath", IsRequired = true)]
        public DictionaryPathElement DictionaryPathElement
        {
            get { return ((DictionaryPathElement)this["dictionaryPath"]); }
        }
        #endregion

        #region # 匹配选项节点 —— MatchOptionsElement MatchOptionsElement
        /// <summary>
        /// 匹配选项节点
        /// </summary>
        [ConfigurationProperty("matchOptions", IsRequired = true)]
        public MatchOptionsElement MatchOptionsElement
        {
            get { return (MatchOptionsElement)this["matchOptions"]; }
        }
        #endregion

        #region # 匹配参数节点 —— MatchParametersElement MatchParametersElement
        /// <summary>
        /// 匹配参数节点
        /// </summary>
        [ConfigurationProperty("matchParameters", IsRequired = true)]
        public MatchParametersElement MatchParametersElement
        {
            get { return (MatchParametersElement)this["matchParameters"]; }
        }
        #endregion
    }
}
