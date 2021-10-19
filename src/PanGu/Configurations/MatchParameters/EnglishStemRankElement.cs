using System.Configuration;
using System.Xml;

namespace PanGu.Configurations.MatchParameters
{
    /// <summary>
    /// 英文词汇词根的权值节点
    /// </summary>
    internal class EnglishStemRankElement : ConfigurationElement
    {
        /// <summary>
        /// 权值
        /// </summary>
        [ConfigurationProperty("data", IsRequired = true)]
        public int Rank
        {
            get { return (int)this["data"]; }
            set { this["data"] = value; }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
        {
            this.Rank = (int)reader.ReadElementContentAs(typeof(int), null);
        }
    }
}
