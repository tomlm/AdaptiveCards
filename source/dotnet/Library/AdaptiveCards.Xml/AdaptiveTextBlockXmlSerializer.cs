// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveTextBlockXmlSerializer : IXmlSerializable
    {
        public AdaptiveTextBlock Element { get; set; } = new AdaptiveTextBlock();

        public static AdaptiveTextBlock Read(XmlReader reader)
        {
            var ser = new AdaptiveTextBlockXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveTextBlock el)
        {
            var ser = new AdaptiveTextBlockXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveTextBlock.Size):
                        Element.Size = reader.GetAttribute<AdaptiveTextSize>(nameof(AdaptiveTextBlock.Size));
                        break;

                    case nameof(AdaptiveTextBlock.Weight):
                        Element.Weight = reader.GetAttribute<AdaptiveTextWeight>(nameof(AdaptiveTextBlock.Weight));
                        break;

                    case nameof(AdaptiveTextBlock.Color):
                        Element.Color = reader.GetAttribute<AdaptiveTextColor>(nameof(AdaptiveTextBlock.Color));
                        break;

                    case nameof(AdaptiveTextBlock.IsSubtle):
                        Element.IsSubtle = reader.GetAttribute<Boolean>(nameof(AdaptiveTextBlock.IsSubtle));
                        break;

                    case nameof(AdaptiveTextBlock.Italic):
                        Element.Italic = reader.GetAttribute<Boolean>(nameof(AdaptiveTextBlock.Italic));
                        break;

                    case nameof(AdaptiveTextBlock.Strikethrough):
                        Element.Strikethrough = reader.GetAttribute<Boolean>(nameof(AdaptiveTextBlock.Strikethrough));
                        break;

                    case nameof(AdaptiveTextBlock.Text):
                        Element.Text = reader.GetAttribute<String>(nameof(AdaptiveTextBlock.Text));
                        break;

                    case nameof(AdaptiveTextBlock.HorizontalAlignment):
                        Element.HorizontalAlignment = reader.GetAttribute<AdaptiveHorizontalAlignment>(nameof(AdaptiveTextBlock.HorizontalAlignment));
                        break;

                    case nameof(AdaptiveTextBlock.Wrap):
                        Element.Wrap = reader.GetAttribute<Boolean>(nameof(AdaptiveTextBlock.Wrap));
                        break;

                    case nameof(AdaptiveTextBlock.MaxLines):
                        Element.MaxLines = reader.GetAttribute<Int32>(nameof(AdaptiveTextBlock.MaxLines));
                        break;

                    case nameof(AdaptiveTextBlock.MaxWidth):
                        Element.MaxWidth = reader.GetAttribute<Int32>(nameof(AdaptiveTextBlock.MaxWidth));
                        break;

                    case nameof(AdaptiveTextBlock.FontType):
                        Element.FontType = reader.GetAttribute<AdaptiveFontType>(nameof(AdaptiveTextBlock.FontType));
                        break;

                    case nameof(AdaptiveTextBlock.Style):
                        Element.Style = reader.GetAttribute<AdaptiveTextBlockStyle>(nameof(AdaptiveTextBlock.Style));
                        break;

                    case nameof(AdaptiveTextBlock.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveTextBlock.Spacing));
                        break;

                    case nameof(AdaptiveTextBlock.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveTextBlock.Separator));
                        break;

                    case nameof(AdaptiveTextBlock.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveTextBlock.Speak));
                        break;

                    case nameof(AdaptiveTextBlock.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveTextBlock.IsVisible));
                        break;

                    case nameof(AdaptiveTextBlock.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveTextBlock.Id));
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
					
                        case nameof(AdaptiveTextBlock.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveTextBlock.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Size != default(AdaptiveTextSize))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.Size), Element.Size.ToString());

            if (Element.Weight != default(AdaptiveTextWeight))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.Weight), Element.Weight.ToString());

            if (Element.Color != default(AdaptiveTextColor))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.Color), Element.Color.ToString());

            if (Element.IsSubtle != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.IsSubtle), Element.IsSubtle.ToString());

            if (Element.Italic != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.Italic), Element.Italic.ToString());

            if (Element.Strikethrough != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.Strikethrough), Element.Strikethrough.ToString());

            if (Element.HorizontalAlignment != default(AdaptiveHorizontalAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.HorizontalAlignment), Element.HorizontalAlignment.ToString());

            if (Element.Wrap != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.Wrap), Element.Wrap.ToString());

            if (Element.MaxLines != default(Int32))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.MaxLines), Element.MaxLines.ToString());

            if (Element.MaxWidth != default(Int32))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.MaxWidth), Element.MaxWidth.ToString());

            if (Element.FontType != default(AdaptiveFontType))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.FontType), Element.FontType.ToString());

            if (Element.Style != default(AdaptiveTextBlockStyle))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.Style), Element.Style.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextBlock.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
