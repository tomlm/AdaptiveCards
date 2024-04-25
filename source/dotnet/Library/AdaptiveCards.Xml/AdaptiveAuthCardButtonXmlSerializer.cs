// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveAuthCardButtonXmlSerializer : IXmlSerializable
    {
        public AdaptiveAuthCardButton Element { get; set; } = new AdaptiveAuthCardButton();

        public static AdaptiveAuthCardButton Read(XmlReader reader)
        {
            var ser = new AdaptiveAuthCardButtonXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveAuthCardButton el)
        {
            var ser = new AdaptiveAuthCardButtonXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveAuthCardButton.Title):
                        Element.Title = reader.GetAttribute<String>(nameof(AdaptiveAuthCardButton.Title));
                        break;

                    case nameof(AdaptiveAuthCardButton.Image):
                        Element.Image = reader.GetAttribute<String>(nameof(AdaptiveAuthCardButton.Image));
                        break;

                    case nameof(AdaptiveAuthCardButton.Value):
                        Element.Value = reader.GetAttribute<String>(nameof(AdaptiveAuthCardButton.Value));
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
