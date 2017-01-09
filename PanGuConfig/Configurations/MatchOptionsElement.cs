
using System.Configuration;

namespace PanGuConfig.Configurations
{
    public class MatchOptionsElement : ConfigurationElement
    {

        [ConfigurationProperty("data", IsRequired = true)]
        public string CommandText
        {
            get { return this["data"].ToString(); }
            set { this["data"] = value; }
        }

        //反序列化
        protected override void DeserializeElement(System.Xml.XmlReader reader, bool serializeCollectionKey)
        {
            var obj = reader.Read();

            CommandText = obj.ToString();
        }

        //序列化
        //protected override bool SerializeElement(System.Xml.XmlWriter writer, bool serializeCollectionKey)
        //{
        //    if (writer != null) writer.WriteCData(CommandText);
        //    return true;
        //}
    }
}
