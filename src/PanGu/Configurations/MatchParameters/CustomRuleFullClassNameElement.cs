using System.Configuration;
using System.Xml;

namespace PanGu.Configurations.MatchParameters
{
    /// <summary>
    /// 用户自定义规则的完整类名节点
    /// </summary>
    internal class CustomRuleFullClassNameElement : ConfigurationElement
    {
        /// <summary>
        /// 完整类名
        /// </summary>
        [ConfigurationProperty("data", IsRequired = true)]
        public string Name
        {
            get { return (string)this["data"]; }
            set { this["data"] = value; }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
        {
            this.Name = (string)reader.ReadElementContentAs(typeof(string), null);
        }
    }
}
