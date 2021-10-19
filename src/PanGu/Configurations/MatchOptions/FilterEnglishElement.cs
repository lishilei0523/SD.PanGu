using System.Configuration;
using System.Xml;

namespace PanGu.Configurations.MatchOptions
{
    /// <summary>
    /// 过滤英文节点
    /// <remarks>
    /// 这个选项只有在过滤停用词选项生效时才有效
    /// </remarks>
    /// </summary>
    internal class FilterEnglishElement : ConfigurationElement
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
