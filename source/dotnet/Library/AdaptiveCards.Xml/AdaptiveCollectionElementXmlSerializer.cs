// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveCollectionElementXmlSerializer : IXmlSerializable
    {
        public AdaptiveCollectionElement Element { get; set; } = new AdaptiveCollectionElement();

        public static AdaptiveCollectionElement Read(XmlReader reader)
        {
            var ser = new AdaptiveCollectionElementXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveCollectionElement el)
        {
            var ser = new AdaptiveCollectionElementXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveCollectionElement.Style):
                        Element.Style = reader.GetAttribute<AdaptiveCards.AdaptiveContainerStyle?>(nameof(AdaptiveCollectionElement.Style));
                        break;

                    case nameof(AdaptiveCollectionElement.HorizontalAlignment):
                        Element.HorizontalAlignment = reader.GetAttribute<AdaptiveHorizontalAlignment>(nameof(AdaptiveCollectionElement.HorizontalAlignment));
                        break;

                    case nameof(AdaptiveCollectionElement.VerticalContentAlignment):
                        Element.VerticalContentAlignment = reader.GetAttribute<AdaptiveVerticalContentAlignment>(nameof(AdaptiveCollectionElement.VerticalContentAlignment));
                        break;

                    case nameof(AdaptiveCollectionElement.Bleed):
                        Element.Bleed = reader.GetAttribute<Boolean>(nameof(AdaptiveCollectionElement.Bleed));
                        break;

                    case nameof(AdaptiveCollectionElement.MinHeight):
                        Element.MinHeight = reader.GetAttribute<String>(nameof(AdaptiveCollectionElement.MinHeight));
                        break;

                    case nameof(AdaptiveCollectionElement.PixelMinHeight):
                        Element.PixelMinHeight = reader.GetAttribute<UInt32>(nameof(AdaptiveCollectionElement.PixelMinHeight));
                        break;

                    case nameof(AdaptiveCollectionElement.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveCollectionElement.Spacing));
                        break;

                    case nameof(AdaptiveCollectionElement.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveCollectionElement.Separator));
                        break;

                    case nameof(AdaptiveCollectionElement.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveCollectionElement.Speak));
                        break;

                    case nameof(AdaptiveCollectionElement.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveCollectionElement.IsVisible));
                        break;

                    case nameof(AdaptiveCollectionElement.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveCollectionElement.Id));
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
					
                        case nameof(AdaptiveCollectionElement.SelectAction):
					        Element.SelectAction = AdaptiveActionXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveCollectionElement.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveCollectionElement.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Style != null)
                writer.WriteAttributeString(nameof(AdaptiveCollectionElement.Style), Element.Style.ToString());

            if (Element.HorizontalAlignment != default(AdaptiveHorizontalAlignment))
                writer.WriteAttributeString(nameof(AdaptiveCollectionElement.HorizontalAlignment), Element.HorizontalAlignment.ToString());

            if (Element.VerticalContentAlignment != default(AdaptiveVerticalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveCollectionElement.VerticalContentAlignment), Element.VerticalContentAlignment.ToString());

            if (Element.Bleed != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveCollectionElement.Bleed), Element.Bleed.ToString());

            if (Element.PixelMinHeight != default(UInt32))
                writer.WriteAttributeString(nameof(AdaptiveCollectionElement.PixelMinHeight), Element.PixelMinHeight.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveCollectionElement.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveCollectionElement.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveCollectionElement.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
