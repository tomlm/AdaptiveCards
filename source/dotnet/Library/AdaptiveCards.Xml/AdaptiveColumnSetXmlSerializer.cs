// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveColumnSetXmlSerializer : IXmlSerializable
    {
        public AdaptiveColumnSet Element { get; set; } = new AdaptiveColumnSet();

        public static AdaptiveColumnSet Read(XmlReader reader)
        {
            var ser = new AdaptiveColumnSetXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveColumnSet el)
        {
            var ser = new AdaptiveColumnSetXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveColumnSet.Style):
                        Element.Style = reader.GetAttribute<AdaptiveCards.AdaptiveContainerStyle?>(nameof(AdaptiveColumnSet.Style));
                        break;

                    case nameof(AdaptiveColumnSet.HorizontalAlignment):
                        Element.HorizontalAlignment = reader.GetAttribute<AdaptiveHorizontalAlignment>(nameof(AdaptiveColumnSet.HorizontalAlignment));
                        break;

                    case nameof(AdaptiveColumnSet.VerticalContentAlignment):
                        Element.VerticalContentAlignment = reader.GetAttribute<AdaptiveVerticalContentAlignment>(nameof(AdaptiveColumnSet.VerticalContentAlignment));
                        break;

                    case nameof(AdaptiveColumnSet.Bleed):
                        Element.Bleed = reader.GetAttribute<Boolean>(nameof(AdaptiveColumnSet.Bleed));
                        break;

                    case nameof(AdaptiveColumnSet.MinHeight):
                        Element.MinHeight = reader.GetAttribute<String>(nameof(AdaptiveColumnSet.MinHeight));
                        break;

                    case nameof(AdaptiveColumnSet.PixelMinHeight):
                        Element.PixelMinHeight = reader.GetAttribute<UInt32>(nameof(AdaptiveColumnSet.PixelMinHeight));
                        break;

                    case nameof(AdaptiveColumnSet.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveColumnSet.Spacing));
                        break;

                    case nameof(AdaptiveColumnSet.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveColumnSet.Separator));
                        break;

                    case nameof(AdaptiveColumnSet.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveColumnSet.Speak));
                        break;

                    case nameof(AdaptiveColumnSet.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveColumnSet.IsVisible));
                        break;

                    case nameof(AdaptiveColumnSet.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveColumnSet.Id));
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
					
                        case nameof(AdaptiveColumnSet.Columns):
					        Element.Columns.Add(AdaptiveColumnXmlSerializer.Read(reader));
					        break;

                        case nameof(AdaptiveColumnSet.SelectAction):
					        Element.SelectAction = AdaptiveActionXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveColumnSet.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveColumnSet.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Style != null)
                writer.WriteAttributeString(nameof(AdaptiveColumnSet.Style), Element.Style.ToString());

            if (Element.HorizontalAlignment != default(AdaptiveHorizontalAlignment))
                writer.WriteAttributeString(nameof(AdaptiveColumnSet.HorizontalAlignment), Element.HorizontalAlignment.ToString());

            if (Element.VerticalContentAlignment != default(AdaptiveVerticalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveColumnSet.VerticalContentAlignment), Element.VerticalContentAlignment.ToString());

            if (Element.Bleed != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveColumnSet.Bleed), Element.Bleed.ToString());

            if (Element.PixelMinHeight != default(UInt32))
                writer.WriteAttributeString(nameof(AdaptiveColumnSet.PixelMinHeight), Element.PixelMinHeight.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveColumnSet.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveColumnSet.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveColumnSet.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
