using System.Configuration;
using System.Xml;

namespace PanGu.Configurations.MatchParameters
{
    /// <summary>
    /// 用户自定义规则程序集节点
    /// </summary>
    internal class CustomRuleAssemblyFileNameElement : ConfigurationElement
    {
        /// <summary>
        /// 程序集名称
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
