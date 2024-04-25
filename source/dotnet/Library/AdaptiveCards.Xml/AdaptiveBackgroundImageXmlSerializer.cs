// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveBackgroundImageXmlSerializer : IXmlSerializable
    {
        public AdaptiveBackgroundImage Element { get; set; } = new AdaptiveBackgroundImage();

        public static AdaptiveBackgroundImage Read(XmlReader reader)
        {
            var ser = new AdaptiveBackgroundImageXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveBackgroundImage el)
        {
            var ser = new AdaptiveBackgroundImageXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveBackgroundImage.Url):
                        Element.Url = reader.GetAttribute<Uri>(nameof(AdaptiveBackgroundImage.Url));
                        break;

                    case nameof(AdaptiveBackgroundImage.UrlString):
                        Element.UrlString = reader.GetAttribute<String>(nameof(AdaptiveBackgroundImage.UrlString));
                        break;

                    case nameof(AdaptiveBackgroundImage.FillMode):
                        Element.FillMode = reader.GetAttribute<AdaptiveImageFillMode>(nameof(AdaptiveBackgroundImage.FillMode));
                        break;

                    case nameof(AdaptiveBackgroundImage.HorizontalAlignment):
                        Element.HorizontalAlignment = reader.GetAttribute<AdaptiveHorizontalAlignment>(nameof(AdaptiveBackgroundImage.HorizontalAlignment));
                        break;

                    case nameof(AdaptiveBackgroundImage.VerticalAlignment):
                        Element.VerticalAlignment = reader.GetAttribute<AdaptiveVerticalAlignment>(nameof(AdaptiveBackgroundImage.VerticalAlignment));
                        break;

	            }
            }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.FillMode != default(AdaptiveImageFillMode))
                writer.WriteAttributeString(nameof(AdaptiveBackgroundImage.FillMode), Element.FillMode.ToString());

            if (Element.HorizontalAlignment != default(AdaptiveHorizontalAlignment))
                writer.WriteAttributeString(nameof(AdaptiveBackgroundImage.HorizontalAlignment), Element.HorizontalAlignment.ToString());

            if (Element.VerticalAlignment != default(AdaptiveVerticalAlignment))
                writer.WriteAttributeString(nameof(AdaptiveBackgroundImage.VerticalAlignment), Element.VerticalAlignment.ToString());

        }

    }
}
#endif
