using System.Configuration;
using System.Xml;

namespace PanGu.Configurations.MatchOptions
{
    /// <summary>
    /// 同义词输出节点
    /// </summary>
    /// <remarks>
    /// 一般用于对搜索字符串的分词，不建议在索引时使用
    /// </remarks>
    internal class SynonymOutputElement : ConfigurationElement
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        [ConfigurationProperty("data", IsRequired = true)]
        public bool Enabled
        {
            get { return (bool)this["data"]; }
            set { this["data"] = value; }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
        {
            this.Enabled = (bool)reader.ReadElementContentAs(typeof(bool), null);
        }
    }
}
