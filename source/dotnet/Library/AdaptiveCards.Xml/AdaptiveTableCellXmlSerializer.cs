// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveTableCellXmlSerializer : IXmlSerializable
    {
        public AdaptiveTableCell Element { get; set; } = new AdaptiveTableCell();

        public static AdaptiveTableCell Read(XmlReader reader)
        {
            var ser = new AdaptiveTableCellXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveTableCell el)
        {
            var ser = new AdaptiveTableCellXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveTableCell.Rtl):
                        Element.Rtl = reader.GetAttribute<System.Boolean?>(nameof(AdaptiveTableCell.Rtl));
                        break;

                    case nameof(AdaptiveTableCell.VerticalCellContentAlignment):
                        Element.VerticalCellContentAlignment = reader.GetAttribute<AdaptiveVerticalContentAlignment>(nameof(AdaptiveTableCell.VerticalCellContentAlignment));
                        break;

                    case nameof(AdaptiveTableCell.HorizontalCellContentAlignment):
                        Element.HorizontalCellContentAlignment = reader.GetAttribute<AdaptiveHorizontalContentAlignment>(nameof(AdaptiveTableCell.HorizontalCellContentAlignment));
                        break;

                    case nameof(AdaptiveTableCell.Style):
                        Element.Style = reader.GetAttribute<AdaptiveCards.AdaptiveContainerStyle?>(nameof(AdaptiveTableCell.Style));
                        break;

                    case nameof(AdaptiveTableCell.HorizontalAlignment):
                        Element.HorizontalAlignment = reader.GetAttribute<AdaptiveHorizontalAlignment>(nameof(AdaptiveTableCell.HorizontalAlignment));
                        break;

                    case nameof(AdaptiveTableCell.VerticalContentAlignment):
                        Element.VerticalContentAlignment = reader.GetAttribute<AdaptiveVerticalContentAlignment>(nameof(AdaptiveTableCell.VerticalContentAlignment));
                        break;

                    case nameof(AdaptiveTableCell.Bleed):
                        Element.Bleed = reader.GetAttribute<Boolean>(nameof(AdaptiveTableCell.Bleed));
                        break;

                    case nameof(AdaptiveTableCell.MinHeight):
                        Element.MinHeight = reader.GetAttribute<String>(nameof(AdaptiveTableCell.MinHeight));
                        break;

                    case nameof(AdaptiveTableCell.PixelMinHeight):
                        Element.PixelMinHeight = reader.GetAttribute<UInt32>(nameof(AdaptiveTableCell.PixelMinHeight));
                        break;

                    case nameof(AdaptiveTableCell.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveTableCell.Spacing));
                        break;

                    case nameof(AdaptiveTableCell.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveTableCell.Separator));
                        break;

                    case nameof(AdaptiveTableCell.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveTableCell.Speak));
                        break;

                    case nameof(AdaptiveTableCell.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveTableCell.IsVisible));
                        break;

                    case nameof(AdaptiveTableCell.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveTableCell.Id));
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
					
                        case nameof(AdaptiveTableCell.SelectAction):
					        Element.SelectAction = AdaptiveActionXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveTableCell.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveTableCell.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                        default:
                            switch(reader.GetAttribute(nameof(Type)))
				            {
                                case AdaptiveTextBlock.TypeName: 
					                 Element.Items.Add(AdaptiveTextBlockXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveRichTextBlock.TypeName: 
					                 Element.Items.Add(AdaptiveRichTextBlockXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveImage.TypeName: 
					                 Element.Items.Add(AdaptiveImageXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveContainer.TypeName: 
					                 Element.Items.Add(AdaptiveContainerXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveColumnSet.TypeName: 
					                 Element.Items.Add(AdaptiveColumnSetXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveImageSet.TypeName: 
					                 Element.Items.Add(AdaptiveImageSetXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveFactSet.TypeName: 
					                 Element.Items.Add(AdaptiveFactSetXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveTextInput.TypeName: 
					                 Element.Items.Add(AdaptiveTextInputXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveDateInput.TypeName: 
					                 Element.Items.Add(AdaptiveDateInputXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveTimeInput.TypeName: 
					                 Element.Items.Add(AdaptiveTimeInputXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveNumberInput.TypeName: 
					                 Element.Items.Add(AdaptiveNumberInputXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveToggleInput.TypeName: 
					                 Element.Items.Add(AdaptiveToggleInputXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveChoiceSetInput.TypeName: 
					                 Element.Items.Add(AdaptiveChoiceSetInputXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveMedia.TypeName: 
					                 Element.Items.Add(AdaptiveMediaXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveActionSet.TypeName: 
					                 Element.Items.Add(AdaptiveActionSetXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveTable.TypeName: 
					                 Element.Items.Add(AdaptiveTableXmlSerializer.Read(reader));
					                 break;
									 
                         }
                         break;
                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Rtl != null)
                writer.WriteAttributeString(nameof(AdaptiveTableCell.Rtl), Element.Rtl.ToString());

            if (Element.VerticalCellContentAlignment != default(AdaptiveVerticalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTableCell.VerticalCellContentAlignment), Element.VerticalCellContentAlignment.ToString());

            if (Element.HorizontalCellContentAlignment != default(AdaptiveHorizontalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTableCell.HorizontalCellContentAlignment), Element.HorizontalCellContentAlignment.ToString());

            if (Element.Style != null)
                writer.WriteAttributeString(nameof(AdaptiveTableCell.Style), Element.Style.ToString());

            if (Element.HorizontalAlignment != default(AdaptiveHorizontalAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTableCell.HorizontalAlignment), Element.HorizontalAlignment.ToString());

            if (Element.VerticalContentAlignment != default(AdaptiveVerticalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveTableCell.VerticalContentAlignment), Element.VerticalContentAlignment.ToString());

            if (Element.Bleed != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTableCell.Bleed), Element.Bleed.ToString());

            if (Element.PixelMinHeight != default(UInt32))
                writer.WriteAttributeString(nameof(AdaptiveTableCell.PixelMinHeight), Element.PixelMinHeight.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveTableCell.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTableCell.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTableCell.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
