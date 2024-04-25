// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveFactXmlSerializer : IXmlSerializable
    {
        public AdaptiveFact Element { get; set; } = new AdaptiveFact();

        public static AdaptiveFact Read(XmlReader reader)
        {
            var ser = new AdaptiveFactXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveFact el)
        {
            var ser = new AdaptiveFactXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveFact.Title):
                        Element.Title = reader.GetAttribute<String>(nameof(AdaptiveFact.Title));
                        break;

                    case nameof(AdaptiveFact.Value):
                        Element.Value = reader.GetAttribute<String>(nameof(AdaptiveFact.Value));
                        break;

                    case nameof(AdaptiveFact.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveFact.Speak));
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
