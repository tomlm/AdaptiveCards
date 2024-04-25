// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveColumnXmlSerializer : IXmlSerializable
    {
        public AdaptiveColumn Element { get; set; } = new AdaptiveColumn();

        public static AdaptiveColumn Read(XmlReader reader)
        {
            var ser = new AdaptiveColumnXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveColumn el)
        {
            var ser = new AdaptiveColumnXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveColumn.Rtl):
                        Element.Rtl = reader.GetAttribute<System.Boolean?>(nameof(AdaptiveColumn.Rtl));
                        break;

                    case nameof(AdaptiveColumn.Size):
                        Element.Size = reader.GetAttribute<String>(nameof(AdaptiveColumn.Size));
                        break;

                    case nameof(AdaptiveColumn.Width):
                        Element.Width = reader.GetAttribute<String>(nameof(AdaptiveColumn.Width));
                        break;

                    case nameof(AdaptiveColumn.Style):
                        Element.Style = reader.GetAttribute<AdaptiveCards.AdaptiveContainerStyle?>(nameof(AdaptiveColumn.Style));
                        break;

                    case nameof(AdaptiveColumn.HorizontalAlignment):
                        Element.HorizontalAlignment = reader.GetAttribute<AdaptiveHorizontalAlignment>(nameof(AdaptiveColumn.HorizontalAlignment));
                        break;

                    case nameof(AdaptiveColumn.VerticalContentAlignment):
                        Element.VerticalContentAlignment = reader.GetAttribute<AdaptiveVerticalContentAlignment>(nameof(AdaptiveColumn.VerticalContentAlignment));
                        break;

                    case nameof(AdaptiveColumn.Bleed):
                        Element.Bleed = reader.GetAttribute<Boolean>(nameof(AdaptiveColumn.Bleed));
                        break;

                    case nameof(AdaptiveColumn.MinHeight):
                        Element.MinHeight = reader.GetAttribute<String>(nameof(AdaptiveColumn.MinHeight));
                        break;

                    case nameof(AdaptiveColumn.PixelMinHeight):
                        Element.PixelMinHeight = reader.GetAttribute<UInt32>(nameof(AdaptiveColumn.PixelMinHeight));
                        break;

                    case nameof(AdaptiveColumn.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveColumn.Spacing));
                        break;

                    case nameof(AdaptiveColumn.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveColumn.Separator));
                        break;

                    case nameof(AdaptiveColumn.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveColumn.Speak));
                        break;

                    case nameof(AdaptiveColumn.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveColumn.IsVisible));
                        break;

                    case nameof(AdaptiveColumn.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveColumn.Id));
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
					
                        case nameof(AdaptiveColumn.BackgroundImage):
					        Element.BackgroundImage = AdaptiveBackgroundImageXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveColumn.SelectAction):
					        Element.SelectAction = AdaptiveActionXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveColumn.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveColumn.Fallback):
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
                writer.WriteAttributeString(nameof(AdaptiveColumn.Rtl), Element.Rtl.ToString());

            if (Element.Style != null)
                writer.WriteAttributeString(nameof(AdaptiveColumn.Style), Element.Style.ToString());

            if (Element.HorizontalAlignment != default(AdaptiveHorizontalAlignment))
                writer.WriteAttributeString(nameof(AdaptiveColumn.HorizontalAlignment), Element.HorizontalAlignment.ToString());

            if (Element.VerticalContentAlignment != default(AdaptiveVerticalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveColumn.VerticalContentAlignment), Element.VerticalContentAlignment.ToString());

            if (Element.Bleed != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveColumn.Bleed), Element.Bleed.ToString());

            if (Element.PixelMinHeight != default(UInt32))
                writer.WriteAttributeString(nameof(AdaptiveColumn.PixelMinHeight), Element.PixelMinHeight.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveColumn.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveColumn.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveColumn.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
