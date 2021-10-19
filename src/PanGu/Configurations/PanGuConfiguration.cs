using PanGu.Configurations;
using System.Configuration;

// ReSharper disable once CheckNamespace
namespace PanGu
{
    /// <summary>
    /// 盘古分词配置
    /// </summary>
    internal class PanGuConfiguration : ConfigurationSection
    {
        #region # 访问器 —— static PanGuConfiguration Setting
        /// <summary>
        /// 访问器
        /// </summary>
        public static PanGuConfiguration Setting
        {
            get
            {
                try
                {
                    PanGuConfiguration setting = (PanGuConfiguration)ConfigurationManager.GetSection("panGuConfiguration");

                    return setting;
                }
                catch (ConfigurationErrorsException)
                {
                    return null;
                }
            }
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
