// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveCollectionWithContentAlignmentXmlSerializer : IXmlSerializable
    {
        public AdaptiveCollectionWithContentAlignment Element { get; set; } = new AdaptiveCollectionWithContentAlignment();

        public static AdaptiveCollectionWithContentAlignment Read(XmlReader reader)
        {
            var ser = new AdaptiveCollectionWithContentAlignmentXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveCollectionWithContentAlignment el)
        {
            var ser = new AdaptiveCollectionWithContentAlignmentXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveCollectionWithContentAlignment.VerticalCellContentAlignment):
                        Element.VerticalCellContentAlignment = reader.GetAttribute<AdaptiveVerticalContentAlignment>(nameof(AdaptiveCollectionWithContentAlignment.VerticalCellContentAlignment));
                        break;

                    case nameof(AdaptiveCollectionWithContentAlignment.HorizontalCellContentAlignment):
                        Element.HorizontalCellContentAlignment = reader.GetAttribute<AdaptiveHorizontalContentAlignment>(nameof(AdaptiveCollectionWithContentAlignment.HorizontalCellContentAlignment));
                        break;

                    case nameof(AdaptiveCollectionWithContentAlignment.Style):
                        Element.Style = reader.GetAttribute<AdaptiveCards.AdaptiveContainerStyle?>(nameof(AdaptiveCollectionWithContentAlignment.Style));
                        break;

                    case nameof(AdaptiveCollectionWithContentAlignment.HorizontalAlignment):
                        Element.HorizontalAlignment = reader.GetAttribute<AdaptiveHorizontalAlignment>(nameof(AdaptiveCollectionWithContentAlignment.HorizontalAlignment));
                        break;

                    case nameof(AdaptiveCollectionWithContentAlignment.VerticalContentAlignment):
                        Element.VerticalContentAlignment = reader.GetAttribute<AdaptiveVerticalContentAlignment>(nameof(AdaptiveCollectionWithContentAlignment.VerticalContentAlignment));
                        break;

                    case nameof(AdaptiveCollectionWithContentAlignment.Bleed):
                        Element.Bleed = reader.GetAttribute<Boolean>(nameof(AdaptiveCollectionWithContentAlignment.Bleed));
                        break;

                    case nameof(AdaptiveCollectionWithContentAlignment.MinHeight):
                        Element.MinHeight = reader.GetAttribute<String>(nameof(AdaptiveCollectionWithContentAlignment.MinHeight));
                        break;

                    case nameof(AdaptiveCollectionWithContentAlignment.PixelMinHeight):
                        Element.PixelMinHeight = reader.GetAttribute<UInt32>(nameof(AdaptiveCollectionWithContentAlignment.PixelMinHeight));
                        break;

                    case nameof(AdaptiveCollectionWithContentAlignment.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveCollectionWithContentAlignment.Spacing));
                        break;

                    case nameof(AdaptiveCollectionWithContentAlignment.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveCollectionWithContentAlignment.Separator));
                        break;

                    case nameof(AdaptiveCollectionWithContentAlignment.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveCollectionWithContentAlignment.Speak));
                        break;

                    case nameof(AdaptiveCollectionWithContentAlignment.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveCollectionWithContentAlignment.IsVisible));
                        break;

                    case nameof(AdaptiveCollectionWithContentAlignment.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveCollectionWithContentAlignment.Id));
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
					
                        case nameof(AdaptiveCollectionWithContentAlignment.SelectAction):
					        Element.SelectAction = AdaptiveActionXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveCollectionWithContentAlignment.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveCollectionWithContentAlignment.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.VerticalCellContentAlignment != default(AdaptiveVerticalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveCollectionWithContentAlignment.VerticalCellContentAlignment), Element.VerticalCellContentAlignment.ToString());

            if (Element.HorizontalCellContentAlignment != default(AdaptiveHorizontalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveCollectionWithContentAlignment.HorizontalCellContentAlignment), Element.HorizontalCellContentAlignment.ToString());

            if (Element.Style != null)
                writer.WriteAttributeString(nameof(AdaptiveCollectionWithContentAlignment.Style), Element.Style.ToString());

            if (Element.HorizontalAlignment != default(AdaptiveHorizontalAlignment))
                writer.WriteAttributeString(nameof(AdaptiveCollectionWithContentAlignment.HorizontalAlignment), Element.HorizontalAlignment.ToString());

            if (Element.VerticalContentAlignment != default(AdaptiveVerticalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveCollectionWithContentAlignment.VerticalContentAlignment), Element.VerticalContentAlignment.ToString());

            if (Element.Bleed != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveCollectionWithContentAlignment.Bleed), Element.Bleed.ToString());

            if (Element.PixelMinHeight != default(UInt32))
                writer.WriteAttributeString(nameof(AdaptiveCollectionWithContentAlignment.PixelMinHeight), Element.PixelMinHeight.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveCollectionWithContentAlignment.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveCollectionWithContentAlignment.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveCollectionWithContentAlignment.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
