
using System.Configuration;

namespace PanGuConfig.Configurations
{
    public class PanGuConfiguration : ConfigurationSection
    {



        [ConfigurationProperty("dictionaryPath", IsRequired = true)]
        private DictionaryPathElement DictionaryPathElement
        {
            get { return ((DictionaryPathElement)this["dictionaryPath"]); }
        }

        public string DictionaryPath
        {
            get { return this.DictionaryPathElement.Text; }
        }




        [ConfigurationProperty("matchOptions", IsRequired = true)]
        public MatchOptionsElement CommandTwo
        {
            get { return (MatchOptionsElement)this["matchOptions"]; }
        }
    }
}
