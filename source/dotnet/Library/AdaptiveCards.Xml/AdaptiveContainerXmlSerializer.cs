// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveContainerXmlSerializer : IXmlSerializable
    {
        public AdaptiveContainer Element { get; set; } = new AdaptiveContainer();

        public static AdaptiveContainer Read(XmlReader reader)
        {
            var ser = new AdaptiveContainerXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveContainer el)
        {
            var ser = new AdaptiveContainerXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveContainer.Rtl):
                        Element.Rtl = reader.GetAttribute<System.Boolean?>(nameof(AdaptiveContainer.Rtl));
                        break;

                    case nameof(AdaptiveContainer.Style):
                        Element.Style = reader.GetAttribute<AdaptiveCards.AdaptiveContainerStyle?>(nameof(AdaptiveContainer.Style));
                        break;

                    case nameof(AdaptiveContainer.HorizontalAlignment):
                        Element.HorizontalAlignment = reader.GetAttribute<AdaptiveHorizontalAlignment>(nameof(AdaptiveContainer.HorizontalAlignment));
                        break;

                    case nameof(AdaptiveContainer.VerticalContentAlignment):
                        Element.VerticalContentAlignment = reader.GetAttribute<AdaptiveVerticalContentAlignment>(nameof(AdaptiveContainer.VerticalContentAlignment));
                        break;

                    case nameof(AdaptiveContainer.Bleed):
                        Element.Bleed = reader.GetAttribute<Boolean>(nameof(AdaptiveContainer.Bleed));
                        break;

                    case nameof(AdaptiveContainer.MinHeight):
                        Element.MinHeight = reader.GetAttribute<String>(nameof(AdaptiveContainer.MinHeight));
                        break;

                    case nameof(AdaptiveContainer.PixelMinHeight):
                        Element.PixelMinHeight = reader.GetAttribute<UInt32>(nameof(AdaptiveContainer.PixelMinHeight));
                        break;

                    case nameof(AdaptiveContainer.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveContainer.Spacing));
                        break;

                    case nameof(AdaptiveContainer.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveContainer.Separator));
                        break;

                    case nameof(AdaptiveContainer.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveContainer.Speak));
                        break;

                    case nameof(AdaptiveContainer.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveContainer.IsVisible));
                        break;

                    case nameof(AdaptiveContainer.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveContainer.Id));
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
					
                        case nameof(AdaptiveContainer.BackgroundImage):
					        Element.BackgroundImage = AdaptiveBackgroundImageXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveContainer.SelectAction):
					        Element.SelectAction = AdaptiveActionXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveContainer.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveContainer.Fallback):
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
                writer.WriteAttributeString(nameof(AdaptiveContainer.Rtl), Element.Rtl.ToString());

            if (Element.Style != null)
                writer.WriteAttributeString(nameof(AdaptiveContainer.Style), Element.Style.ToString());

            if (Element.HorizontalAlignment != default(AdaptiveHorizontalAlignment))
                writer.WriteAttributeString(nameof(AdaptiveContainer.HorizontalAlignment), Element.HorizontalAlignment.ToString());

            if (Element.VerticalContentAlignment != default(AdaptiveVerticalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveContainer.VerticalContentAlignment), Element.VerticalContentAlignment.ToString());

            if (Element.Bleed != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveContainer.Bleed), Element.Bleed.ToString());

            if (Element.PixelMinHeight != default(UInt32))
                writer.WriteAttributeString(nameof(AdaptiveContainer.PixelMinHeight), Element.PixelMinHeight.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveContainer.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveContainer.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveContainer.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
