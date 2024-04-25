// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveColumnSizeXmlSerializer : IXmlSerializable
    {
        public AdaptiveColumnSize Element { get; set; } = new AdaptiveColumnSize();

        public static AdaptiveColumnSize Read(XmlReader reader)
        {
            var ser = new AdaptiveColumnSizeXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveColumnSize el)
        {
            var ser = new AdaptiveColumnSizeXmlSerializer() { Element = el };
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
        }

    }
}
#endif
