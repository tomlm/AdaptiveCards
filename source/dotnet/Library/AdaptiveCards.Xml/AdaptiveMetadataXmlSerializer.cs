// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveMetadataXmlSerializer : IXmlSerializable
    {
        public AdaptiveMetadata Element { get; set; } = new AdaptiveMetadata();

        public static AdaptiveMetadata Read(XmlReader reader)
        {
            var ser = new AdaptiveMetadataXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveMetadata el)
        {
            var ser = new AdaptiveMetadataXmlSerializer() { Element = el };
            ser.WriteXml(writer);
        }

        public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			string val;
			reader.MoveToContent();
			while (reader.MoveToNextAttribute())
			{
				switch (reader.Name)
				{
                    case nameof(AdaptiveMetadata.WebUrl):
                        Element.WebUrl = reader.GetAttribute<String>(nameof(AdaptiveMetadata.WebUrl));
                        break;

	            }
            }
        }


        public void WriteXml(XmlWriter writer)
		{
        }

    }
}
#endif
