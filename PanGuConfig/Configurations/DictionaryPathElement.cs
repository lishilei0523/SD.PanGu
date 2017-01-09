using System.Configuration;

namespace PanGuConfig.Configurations
{
    public class DictionaryPathElement : ConfigurationElement
    {
        [ConfigurationProperty("data", IsRequired = true)]
        public string Text
        {
            get { return this["data"].ToString(); }
            set { this["data"] = value; }
        }

        //反序列化
        protected override void DeserializeElement(System.Xml.XmlReader reader, bool serializeCollectionKey)
        {
            Text = reader.ReadElementContentAs(typeof(string), null) as string;
        }

        //序列化
        protected override bool SerializeElement(System.Xml.XmlWriter writer, bool serializeCollectionKey)
        {
            if (writer != null) writer.WriteCData(Text);
            return true;
        }
    }
}
