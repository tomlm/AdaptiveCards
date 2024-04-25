// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveTextRunXmlSerializer : IXmlSerializable
    {
        public AdaptiveTextRun Element { get; set; } = new AdaptiveTextRun();

        public static AdaptiveTextRun Read(XmlReader reader)
        {
            var ser = new AdaptiveTextRunXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveTextRun el)
        {
            var ser = new AdaptiveTextRunXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveTextRun.Size):
                        Element.Size = reader.GetAttribute<AdaptiveTextSize>(nameof(AdaptiveTextRun.Size));
                        break;

                    case nameof(AdaptiveTextRun.Weight):
                        Element.Weight = reader.GetAttribute<AdaptiveTextWeight>(nameof(AdaptiveTextRun.Weight));
                        break;

                    case nameof(AdaptiveTextRun.Color):
                        Element.Color = reader.GetAttribute<AdaptiveTextColor>(nameof(AdaptiveTextRun.Color));
                        break;

                    case nameof(AdaptiveTextRun.IsSubtle):
                        Element.IsSubtle = reader.GetAttribute<Boolean>(nameof(AdaptiveTextRun.IsSubtle));
                        break;

                    case nameof(AdaptiveTextRun.Italic):
                        Element.Italic = reader.GetAttribute<Boolean>(nameof(AdaptiveTextRun.Italic));
                        break;

                    case nameof(AdaptiveTextRun.Strikethrough):
                        Element.Strikethrough = reader.GetAttribute<Boolean>(nameof(AdaptiveTextRun.Strikethrough));
                        break;

                    case nameof(AdaptiveTextRun.Highlight):
                        Element.Highlight = reader.GetAttribute<Boolean>(nameof(AdaptiveTextRun.Highlight));
                        break;

                    case nameof(AdaptiveTextRun.Text):
                        Element.Text = reader.GetAttribute<String>(nameof(AdaptiveTextRun.Text));
                        break;

                    case nameof(AdaptiveTextRun.FontType):
                        Element.FontType = reader.GetAttribute<AdaptiveFontType>(nameof(AdaptiveTextRun.FontType));
                        break;

                    case nameof(AdaptiveTextRun.Underline):
                        Element.Underline = reader.GetAttribute<Boolean>(nameof(AdaptiveTextRun.Underline));
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
					
                        case nameof(AdaptiveTextRun.SelectAction):
					        Element.SelectAction = AdaptiveActionXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Size != default(AdaptiveTextSize))
                writer.WriteAttributeString(nameof(AdaptiveTextRun.Size), Element.Size.ToString());

            if (Element.Weight != default(AdaptiveTextWeight))
                writer.WriteAttributeString(nameof(AdaptiveTextRun.Weight), Element.Weight.ToString());

            if (Element.Color != default(AdaptiveTextColor))
                writer.WriteAttributeString(nameof(AdaptiveTextRun.Color), Element.Color.ToString());

            if (Element.IsSubtle != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextRun.IsSubtle), Element.IsSubtle.ToString());

            if (Element.Italic != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextRun.Italic), Element.Italic.ToString());

            if (Element.Strikethrough != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextRun.Strikethrough), Element.Strikethrough.ToString());

            if (Element.Highlight != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextRun.Highlight), Element.Highlight.ToString());

            if (Element.FontType != default(AdaptiveFontType))
                writer.WriteAttributeString(nameof(AdaptiveTextRun.FontType), Element.FontType.ToString());

            if (Element.Underline != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextRun.Underline), Element.Underline.ToString());

        }

    }
}
#endif
