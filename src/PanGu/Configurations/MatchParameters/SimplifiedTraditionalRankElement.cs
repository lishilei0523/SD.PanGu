using System.Configuration;
using System.Xml;

namespace PanGu.Configurations.MatchParameters
{
    /// <summary>
    /// 强制同时输出简繁汉字时，非原来文本的汉字输出权值节点
    /// </summary>
    /// <remarks>
    /// 比如原来文本是简体，这里就是输出的繁体字的权值，反之亦然。
    /// </remarks>
    internal class SimplifiedTraditionalRankElement : ConfigurationElement
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
