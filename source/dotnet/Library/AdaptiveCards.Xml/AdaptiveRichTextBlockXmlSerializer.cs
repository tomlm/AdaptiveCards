// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveRichTextBlockXmlSerializer : IXmlSerializable
    {
        public AdaptiveRichTextBlock Element { get; set; } = new AdaptiveRichTextBlock();

        public static AdaptiveRichTextBlock Read(XmlReader reader)
        {
            var ser = new AdaptiveRichTextBlockXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveRichTextBlock el)
        {
            var ser = new AdaptiveRichTextBlockXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveRichTextBlock.HorizontalAlignment):
                        Element.HorizontalAlignment = reader.GetAttribute<AdaptiveHorizontalAlignment>(nameof(AdaptiveRichTextBlock.HorizontalAlignment));
                        break;

                    case nameof(AdaptiveRichTextBlock.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveRichTextBlock.Spacing));
                        break;

                    case nameof(AdaptiveRichTextBlock.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveRichTextBlock.Separator));
                        break;

                    case nameof(AdaptiveRichTextBlock.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveRichTextBlock.Speak));
                        break;

                    case nameof(AdaptiveRichTextBlock.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveRichTextBlock.IsVisible));
                        break;

                    case nameof(AdaptiveRichTextBlock.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveRichTextBlock.Id));
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
					
                        case nameof(AdaptiveRichTextBlock.Inlines):
					        Element.Inlines.Add(AdaptiveInlineXmlSerializer.Read(reader));
					        break;

                        case nameof(AdaptiveRichTextBlock.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveRichTextBlock.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.HorizontalAlignment != default(AdaptiveHorizontalAlignment))
                writer.WriteAttributeString(nameof(AdaptiveRichTextBlock.HorizontalAlignment), Element.HorizontalAlignment.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveRichTextBlock.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveRichTextBlock.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveRichTextBlock.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
