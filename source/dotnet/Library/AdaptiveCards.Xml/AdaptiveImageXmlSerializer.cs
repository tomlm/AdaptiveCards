// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveImageXmlSerializer : IXmlSerializable
    {
        public AdaptiveImage Element { get; set; } = new AdaptiveImage();

        public static AdaptiveImage Read(XmlReader reader)
        {
            var ser = new AdaptiveImageXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveImage el)
        {
            var ser = new AdaptiveImageXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveImage.Size):
                        Element.Size = reader.GetAttribute<AdaptiveImageSize>(nameof(AdaptiveImage.Size));
                        break;

                    case nameof(AdaptiveImage.Style):
                        Element.Style = reader.GetAttribute<AdaptiveImageStyle>(nameof(AdaptiveImage.Style));
                        break;

                    case nameof(AdaptiveImage.Url):
                        Element.Url = reader.GetAttribute<Uri>(nameof(AdaptiveImage.Url));
                        break;

                    case nameof(AdaptiveImage.UrlString):
                        Element.UrlString = reader.GetAttribute<String>(nameof(AdaptiveImage.UrlString));
                        break;

                    case nameof(AdaptiveImage.HorizontalAlignment):
                        Element.HorizontalAlignment = reader.GetAttribute<AdaptiveHorizontalAlignment>(nameof(AdaptiveImage.HorizontalAlignment));
                        break;

                    case nameof(AdaptiveImage.BackgroundColor):
                        Element.BackgroundColor = reader.GetAttribute<String>(nameof(AdaptiveImage.BackgroundColor));
                        break;

                    case nameof(AdaptiveImage.AltText):
                        Element.AltText = reader.GetAttribute<String>(nameof(AdaptiveImage.AltText));
                        break;

                    case nameof(AdaptiveImage.PixelWidth):
                        Element.PixelWidth = reader.GetAttribute<UInt32>(nameof(AdaptiveImage.PixelWidth));
                        break;

                    case nameof(AdaptiveImage.PixelHeight):
                        Element.PixelHeight = reader.GetAttribute<UInt32>(nameof(AdaptiveImage.PixelHeight));
                        break;

                    case nameof(AdaptiveImage.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveImage.Spacing));
                        break;

                    case nameof(AdaptiveImage.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveImage.Separator));
                        break;

                    case nameof(AdaptiveImage.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveImage.Speak));
                        break;

                    case nameof(AdaptiveImage.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveImage.IsVisible));
                        break;

                    case nameof(AdaptiveImage.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveImage.Id));
                        break;

	            }
            }
            
            while (reader.MoveToElement())
            {
                reader.ReadStartElement();
				var isEmptyElement = reader.IsEmptyElement;
                if (!isEmptyElement)
                {
                    switch (reader.Name)
                    {
					
                        case nameof(AdaptiveImage.SelectAction):
					        Element.SelectAction = AdaptiveActionXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveImage.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveImage.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Size != default(AdaptiveImageSize))
                writer.WriteAttributeString(nameof(AdaptiveImage.Size), Element.Size.ToString());

            if (Element.Style != default(AdaptiveImageStyle))
                writer.WriteAttributeString(nameof(AdaptiveImage.Style), Element.Style.ToString());

            if (Element.HorizontalAlignment != default(AdaptiveHorizontalAlignment))
                writer.WriteAttributeString(nameof(AdaptiveImage.HorizontalAlignment), Element.HorizontalAlignment.ToString());

            if (Element.PixelWidth != default(UInt32))
                writer.WriteAttributeString(nameof(AdaptiveImage.PixelWidth), Element.PixelWidth.ToString());

            if (Element.PixelHeight != default(UInt32))
                writer.WriteAttributeString(nameof(AdaptiveImage.PixelHeight), Element.PixelHeight.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveImage.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveImage.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveImage.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
