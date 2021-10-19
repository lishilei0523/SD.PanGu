using System.Configuration;
using System.Xml;

namespace PanGu.Configurations.MatchParameters
{
    /// <summary>
    /// 多元分词冗余度节点
    /// </summary>
    internal class RedundancyElement : ConfigurationElement
    {
        /// <summary>
        /// 冗余度
        /// </summary>
        [ConfigurationProperty("data", IsRequired = true)]
        public int Value
        {
            get { return (int)this["data"]; }
            set { this["data"] = value; }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
        {
            this.Value = (int)reader.ReadElementContentAs(typeof(int), null);
        }
    }
}
