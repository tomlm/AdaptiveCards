// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveTableXmlSerializer : IXmlSerializable
    {
        public AdaptiveTable Element { get; set; } = new AdaptiveTable();

        public static AdaptiveTable Read(XmlReader reader)
        {
            var ser = new AdaptiveTableXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveTable el)
        {
            var ser = new AdaptiveTableXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveTable.GridStyle):
                        Element.GridStyle = reader.GetAttribute<AdaptiveCards.AdaptiveContainerStyle?>(nameof(AdaptiveTable.GridStyle));
                        break;

                    case nameof(AdaptiveTable.ShowGridLines):
                        Element.ShowGridLines = reader.GetAttribute<Boolean>(nameof(AdaptiveTable.ShowGridLines));
                        break;

                    case nameof(AdaptiveTable.FirstRowAsHeaders):
                        Element.FirstRowAsHeaders = reader.GetAttribute<Boolean>(nameof(AdaptiveTable.FirstRowAsHeaders));
                        break;

                    case nameof(AdaptiveTable.VerticalCellContentAlignment):
                        Element.VerticalCellContentAlignment = reader.GetAttribute<AdaptiveVerticalContentAlignment>(nameof(AdaptiveTable.VerticalCellContentAlignment));
                        break;

                    case nameof(AdaptiveTable.HorizontalCellContentAlignment):
                        Element.HorizontalCellContentAlignment = reader.GetAttribute<AdaptiveHorizontalContentAlignment>(nameof(AdaptiveTable.HorizontalCellContentAlignment));
                        break;

                    case nameof(AdaptiveTable.Style):
                        Element.Style = reader.GetAttribute<AdaptiveCards.AdaptiveContainerStyle?>(nameof(AdaptiveTable.Style));
                        break;

                    case nameof(AdaptiveTable.HorizontalAlignment):
                        Element.HorizontalAlignment = reader.GetAttribute<AdaptiveHorizontalAlignment>(nameof(AdaptiveTable.HorizontalAlignment));
                        break;

                    case nameof(AdaptiveTable.VerticalContentAlignment):
                        Element.VerticalContentAlignment = reader.GetAttribute<AdaptiveVerticalContentAlignment>(nameof(AdaptiveTable.VerticalContentAlignment));
                        break;

                    case nameof(AdaptiveTable.Bleed):
                        Element.Bleed = reader.GetAttribute<Boolean>(nameof(AdaptiveTable.Bleed));
                        break;

                    case nameof(AdaptiveTable.MinHeight):
                        Element.MinHeight = reader.GetAttribute<String>(nameof(AdaptiveTable.MinHeight));
                        break;

                    case nameof(AdaptiveTable.PixelMinHeight):
                        Element.PixelMinHeight = reader.GetAttribute<UInt32>(nameof(AdaptiveTable.PixelMinHeight));
                        break;

                    case nameof(AdaptiveTable.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveTable.Spacing));
                        break;

                    case nameof(AdaptiveTable.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveTable.Separator));
                        break;

                    case nameof(AdaptiveTable.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveTable.Speak));
                        break;

                    case nameof(AdaptiveTable.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveTable.IsVisible));
                        break;

                    case nameof(AdaptiveTable.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveTable.Id));
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
					
                        case nameof(AdaptiveTable.Rows):
					        Element.Rows.Add(AdaptiveTableRowXmlSerializer.Read(reader));
					        break;

                        case nameof(AdaptiveTable.Columns):
					        Element.Columns.Add(AdaptiveTableColumnDefinitionXmlSerializer.Read(reader));
					        break;

                        case nameof(AdaptiveTable.SelectAction):
					        Element.SelectAction = AdaptiveActionXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveTable.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveTable.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.GridStyle != null)
                writer.WriteAttributeString(nameof(AdaptiveTable.GridStyle), Element.GridStyle.ToString());

            if (Element.ShowGridLines != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTable.ShowGridLines), Element.ShowGridLines.ToString());

            if (Element.FirstRowAsHeaders != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTable.FirstRowAsHeaders), Element.FirstRowAsHeaders.ToString());

            if (Element.VerticalCellContentAlignment != default(AdaptiveVerticalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTable.VerticalCellContentAlignment), Element.VerticalCellContentAlignment.ToString());

            if (Element.HorizontalCellContentAlignment != default(AdaptiveHorizontalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTable.HorizontalCellContentAlignment), Element.HorizontalCellContentAlignment.ToString());

            if (Element.Style != null)
                writer.WriteAttributeString(nameof(AdaptiveTable.Style), Element.Style.ToString());

            if (Element.HorizontalAlignment != default(AdaptiveHorizontalAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTable.HorizontalAlignment), Element.HorizontalAlignment.ToString());

            if (Element.VerticalContentAlignment != default(AdaptiveVerticalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTable.VerticalContentAlignment), Element.VerticalContentAlignment.ToString());

            if (Element.Bleed != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTable.Bleed), Element.Bleed.ToString());

            if (Element.PixelMinHeight != default(UInt32))
                writer.WriteAttributeString(nameof(AdaptiveTable.PixelMinHeight), Element.PixelMinHeight.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveTable.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTable.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTable.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
