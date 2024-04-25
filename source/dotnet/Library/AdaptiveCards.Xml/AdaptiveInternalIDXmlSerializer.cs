// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveInternalIDXmlSerializer : IXmlSerializable
    {
        public AdaptiveInternalID Element { get; set; } = new AdaptiveInternalID();

        public static AdaptiveInternalID Read(XmlReader reader)
        {
            var ser = new AdaptiveInternalIDXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveInternalID el)
        {
            var ser = new AdaptiveInternalIDXmlSerializer() { Element = el };
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
