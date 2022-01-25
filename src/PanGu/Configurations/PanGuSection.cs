using PanGu.Configurations;
using System;
using System.Configuration;

// ReSharper disable once CheckNamespace
namespace PanGu
{
    /// <summary>
    /// 盘古分词配置
    /// </summary>
    public class PanGuSection : ConfigurationSection
    {
        #region # 字段及构造器

        /// <summary>
        /// 单例
        /// </summary>
        private static PanGuSection _Setting;

        /// <summary>
        /// 静态构造器
        /// </summary>
        static PanGuSection()
        {
            _Setting = null;
        }

        #endregion

        #region # 初始化 —— static void Initialize(Configuration configuration)
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configuration">配置</param>
        public static void Initialize(Configuration configuration)
        {
            #region # 验证

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration), @"配置不可为空！");
            }

            #endregion

            _Setting = (PanGuSection)configuration.GetSection("sd.panGu");
        }
        #endregion

        #region # 访问器 —— static PanGuSection Setting
        /// <summary>
        /// 访问器
        /// </summary>
        public static PanGuSection Setting
        {
            get
            {
                try
                {
                    if (_Setting == null)
                    {
                        _Setting = (PanGuSection)ConfigurationManager.GetSection("sd.panGu");
                    }
                    if (_Setting == null)
                    {
                        throw new ApplicationException("SD.PanGu节点未配置，请检查程序！");
                    }

                    return _Setting;
                }
                catch
                {
                    return null;
                }
            }
        }
        #endregion

        #region # 字典路径节点 —— TextElement DictionaryPathElement
        /// <summary>
        /// 字典路径节点
        /// </summary>
        [ConfigurationProperty("dictionaryPath", IsRequired = true)]
        public TextElement DictionaryPathElement
        {
            get { return ((TextElement)this["dictionaryPath"]); }
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
