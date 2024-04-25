// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveTableColumnDefinitionXmlSerializer : IXmlSerializable
    {
        public AdaptiveTableColumnDefinition Element { get; set; } = new AdaptiveTableColumnDefinition();

        public static AdaptiveTableColumnDefinition Read(XmlReader reader)
        {
            var ser = new AdaptiveTableColumnDefinitionXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveTableColumnDefinition el)
        {
            var ser = new AdaptiveTableColumnDefinitionXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveTableColumnDefinition.VerticalContentAlignment):
                        Element.VerticalContentAlignment = reader.GetAttribute<AdaptiveVerticalContentAlignment>(nameof(AdaptiveTableColumnDefinition.VerticalContentAlignment));
                        break;

                    case nameof(AdaptiveTableColumnDefinition.HorizontalContentAlignment):
                        Element.HorizontalContentAlignment = reader.GetAttribute<AdaptiveHorizontalContentAlignment>(nameof(AdaptiveTableColumnDefinition.HorizontalContentAlignment));
                        break;

                    case nameof(AdaptiveTableColumnDefinition.PixelWidth):
                        Element.PixelWidth = reader.GetAttribute<Double>(nameof(AdaptiveTableColumnDefinition.PixelWidth));
                        break;

                    case nameof(AdaptiveTableColumnDefinition.Width):
                        Element.Width = reader.GetAttribute<Double>(nameof(AdaptiveTableColumnDefinition.Width));
                        break;

	            }
            }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.VerticalContentAlignment != default(AdaptiveVerticalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTableColumnDefinition.VerticalContentAlignment), Element.VerticalContentAlignment.ToString());

            if (Element.HorizontalContentAlignment != default(AdaptiveHorizontalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTableColumnDefinition.HorizontalContentAlignment), Element.HorizontalContentAlignment.ToString());

            if (Element.PixelWidth != default(Double))
                writer.WriteAttributeString(nameof(AdaptiveTableColumnDefinition.PixelWidth), Element.PixelWidth.ToString());

            if (Element.Width != default(Double))
                writer.WriteAttributeString(nameof(AdaptiveTableColumnDefinition.Width), Element.Width.ToString());

        }

    }
}
#endif
