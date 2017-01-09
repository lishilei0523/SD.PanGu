using System.Configuration;
using System.Xml;

namespace PanGu.Configurations.MatchParameters
{
    /// <summary>
    /// 过滤大于此长度的数字节点
    /// </summary>
    /// <remarks>
    /// 过滤数字选项生效时才有效
    /// </remarks>
    internal class FilterNumericLengthElement : ConfigurationElement
    {
        /// <summary>
        /// 长度
        /// </summary>
        [ConfigurationProperty("data", IsRequired = true)]
        public int Length
        {
            get { return (int)this["data"]; }
            set { this["data"] = value; }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
        {
            this.Length = (int)reader.ReadElementContentAs(typeof(int), null);
        }
    }
}
