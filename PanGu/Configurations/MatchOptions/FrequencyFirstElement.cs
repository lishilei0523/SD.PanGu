﻿using System.Configuration;
using System.Xml;

namespace PanGu.Configurations.MatchOptions
{
    /// <summary>
    /// 词频优先节点
    /// </summary>
    internal class FrequencyFirstElement : ConfigurationElement
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