// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveTableRowXmlSerializer : IXmlSerializable
    {
        public AdaptiveTableRow Element { get; set; } = new AdaptiveTableRow();

        public static AdaptiveTableRow Read(XmlReader reader)
        {
            var ser = new AdaptiveTableRowXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveTableRow el)
        {
            var ser = new AdaptiveTableRowXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveTableRow.Rtl):
                        Element.Rtl = reader.GetAttribute<System.Boolean?>(nameof(AdaptiveTableRow.Rtl));
                        break;

                    case nameof(AdaptiveTableRow.VerticalCellContentAlignment):
                        Element.VerticalCellContentAlignment = reader.GetAttribute<AdaptiveVerticalContentAlignment>(nameof(AdaptiveTableRow.VerticalCellContentAlignment));
                        break;

                    case nameof(AdaptiveTableRow.HorizontalCellContentAlignment):
                        Element.HorizontalCellContentAlignment = reader.GetAttribute<AdaptiveHorizontalContentAlignment>(nameof(AdaptiveTableRow.HorizontalCellContentAlignment));
                        break;

                    case nameof(AdaptiveTableRow.Style):
                        Element.Style = reader.GetAttribute<AdaptiveCards.AdaptiveContainerStyle?>(nameof(AdaptiveTableRow.Style));
                        break;

                    case nameof(AdaptiveTableRow.HorizontalAlignment):
                        Element.HorizontalAlignment = reader.GetAttribute<AdaptiveHorizontalAlignment>(nameof(AdaptiveTableRow.HorizontalAlignment));
                        break;

                    case nameof(AdaptiveTableRow.VerticalContentAlignment):
                        Element.VerticalContentAlignment = reader.GetAttribute<AdaptiveVerticalContentAlignment>(nameof(AdaptiveTableRow.VerticalContentAlignment));
                        break;

                    case nameof(AdaptiveTableRow.Bleed):
                        Element.Bleed = reader.GetAttribute<Boolean>(nameof(AdaptiveTableRow.Bleed));
                        break;

                    case nameof(AdaptiveTableRow.MinHeight):
                        Element.MinHeight = reader.GetAttribute<String>(nameof(AdaptiveTableRow.MinHeight));
                        break;

                    case nameof(AdaptiveTableRow.PixelMinHeight):
                        Element.PixelMinHeight = reader.GetAttribute<UInt32>(nameof(AdaptiveTableRow.PixelMinHeight));
                        break;

                    case nameof(AdaptiveTableRow.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveTableRow.Spacing));
                        break;

                    case nameof(AdaptiveTableRow.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveTableRow.Separator));
                        break;

                    case nameof(AdaptiveTableRow.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveTableRow.Speak));
                        break;

                    case nameof(AdaptiveTableRow.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveTableRow.IsVisible));
                        break;

                    case nameof(AdaptiveTableRow.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveTableRow.Id));
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
					
                        case nameof(AdaptiveTableRow.Cells):
					        Element.Cells.Add(AdaptiveTableCellXmlSerializer.Read(reader));
					        break;

                        case nameof(AdaptiveTableRow.SelectAction):
					        Element.SelectAction = AdaptiveActionXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveTableRow.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveTableRow.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Rtl != null)
                writer.WriteAttributeString(nameof(AdaptiveTableRow.Rtl), Element.Rtl.ToString());

            if (Element.VerticalCellContentAlignment != default(AdaptiveVerticalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTableRow.VerticalCellContentAlignment), Element.VerticalCellContentAlignment.ToString());

            if (Element.HorizontalCellContentAlignment != default(AdaptiveHorizontalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTableRow.HorizontalCellContentAlignment), Element.HorizontalCellContentAlignment.ToString());

            if (Element.Style != null)
                writer.WriteAttributeString(nameof(AdaptiveTableRow.Style), Element.Style.ToString());

            if (Element.HorizontalAlignment != default(AdaptiveHorizontalAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTableRow.HorizontalAlignment), Element.HorizontalAlignment.ToString());

            if (Element.VerticalContentAlignment != default(AdaptiveVerticalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTableRow.VerticalContentAlignment), Element.VerticalContentAlignment.ToString());

            if (Element.Bleed != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTableRow.Bleed), Element.Bleed.ToString());

            if (Element.PixelMinHeight != default(UInt32))
                writer.WriteAttributeString(nameof(AdaptiveTableRow.PixelMinHeight), Element.PixelMinHeight.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveTableRow.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTableRow.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTableRow.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
