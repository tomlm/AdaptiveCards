// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveFallbackElementXmlSerializer : IXmlSerializable
    {
        public AdaptiveFallbackElement Element { get; set; } = new AdaptiveFallbackElement();

        public static AdaptiveFallbackElement Read(XmlReader reader)
        {
            var ser = new AdaptiveFallbackElementXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveFallbackElement el)
        {
            var ser = new AdaptiveFallbackElementXmlSerializer() { Element = el };
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
	            }
            }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Type != default(AdaptiveFallbackType))
                writer.WriteAttributeString(nameof(AdaptiveFallbackElement.Type), Element.Type.ToString());

        }

    }
}
#endif
