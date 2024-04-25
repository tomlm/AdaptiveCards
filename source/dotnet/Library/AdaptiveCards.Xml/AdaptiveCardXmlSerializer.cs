// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveCardXmlSerializer : IXmlSerializable
    {
        public AdaptiveCard Element { get; set; } = new AdaptiveCard();

        public static AdaptiveCard Read(XmlReader reader)
        {
            var ser = new AdaptiveCardXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveCard el)
        {
            var ser = new AdaptiveCardXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveCard.FallbackText):
                        Element.FallbackText = reader.GetAttribute<String>(nameof(AdaptiveCard.FallbackText));
                        break;

                    case nameof(AdaptiveCard.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveCard.Speak));
                        break;

                    case nameof(AdaptiveCard.Lang):
                        Element.Lang = reader.GetAttribute<String>(nameof(AdaptiveCard.Lang));
                        break;

                    case nameof(AdaptiveCard.Title):
                        Element.Title = reader.GetAttribute<String>(nameof(AdaptiveCard.Title));
                        break;

                    case nameof(AdaptiveCard.MinHeight):
                        Element.MinHeight = reader.GetAttribute<String>(nameof(AdaptiveCard.MinHeight));
                        break;

                    case nameof(AdaptiveCard.PixelMinHeight):
                        Element.PixelMinHeight = reader.GetAttribute<UInt32>(nameof(AdaptiveCard.PixelMinHeight));
                        break;

                    case nameof(AdaptiveCard.Rtl):
                        Element.Rtl = reader.GetAttribute<System.Boolean?>(nameof(AdaptiveCard.Rtl));
                        break;

                    case nameof(AdaptiveCard.VerticalContentAlignment):
                        Element.VerticalContentAlignment = reader.GetAttribute<AdaptiveVerticalContentAlignment>(nameof(AdaptiveCard.VerticalContentAlignment));
                        break;

                    case nameof(AdaptiveCard.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveCard.Id));
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
					
                        case nameof(AdaptiveCard.Version):
					        Element.Version = AdaptiveSchemaVersionXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveCard.MinVersion):
					        Element.MinVersion = AdaptiveSchemaVersionXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveCard.BackgroundImage):
					        Element.BackgroundImage = AdaptiveBackgroundImageXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveCard.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveCard.SelectAction):
					        Element.SelectAction = AdaptiveActionXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveCard.Refresh):
					        Element.Refresh = AdaptiveRefreshXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveCard.Authentication):
					        Element.Authentication = AdaptiveAuthenticationXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveCard.Metadata):
					        Element.Metadata = AdaptiveMetadataXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveCard.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                        default:
                            switch(reader.GetAttribute(nameof(Type)))
				            {
                                case AdaptiveTextBlock.TypeName: 
					                 Element.Body.Add(AdaptiveTextBlockXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveRichTextBlock.TypeName: 
					                 Element.Body.Add(AdaptiveRichTextBlockXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveImage.TypeName: 
					                 Element.Body.Add(AdaptiveImageXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveContainer.TypeName: 
					                 Element.Body.Add(AdaptiveContainerXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveColumnSet.TypeName: 
					                 Element.Body.Add(AdaptiveColumnSetXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveImageSet.TypeName: 
					                 Element.Body.Add(AdaptiveImageSetXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveFactSet.TypeName: 
					                 Element.Body.Add(AdaptiveFactSetXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveTextInput.TypeName: 
					                 Element.Body.Add(AdaptiveTextInputXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveDateInput.TypeName: 
					                 Element.Body.Add(AdaptiveDateInputXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveTimeInput.TypeName: 
					                 Element.Body.Add(AdaptiveTimeInputXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveNumberInput.TypeName: 
					                 Element.Body.Add(AdaptiveNumberInputXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveToggleInput.TypeName: 
					                 Element.Body.Add(AdaptiveToggleInputXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveChoiceSetInput.TypeName: 
					                 Element.Body.Add(AdaptiveChoiceSetInputXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveMedia.TypeName: 
					                 Element.Body.Add(AdaptiveMediaXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveActionSet.TypeName: 
					                 Element.Body.Add(AdaptiveActionSetXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveTable.TypeName: 
					                 Element.Body.Add(AdaptiveTableXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveOpenUrlAction.TypeName: 
					                 Element.Actions.Add(AdaptiveOpenUrlActionXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveShowCardAction.TypeName: 
					                 Element.Actions.Add(AdaptiveShowCardActionXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveSubmitAction.TypeName: 
					                 Element.Actions.Add(AdaptiveSubmitActionXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveToggleVisibilityAction.TypeName: 
					                 Element.Actions.Add(AdaptiveToggleVisibilityActionXmlSerializer.Read(reader));
					                 break;
									 
                                case AdaptiveExecuteAction.TypeName: 
					                 Element.Actions.Add(AdaptiveExecuteActionXmlSerializer.Read(reader));
					                 break;
									 
                         }
                         break;
                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.PixelMinHeight != default(UInt32))
                writer.WriteAttributeString(nameof(AdaptiveCard.PixelMinHeight), Element.PixelMinHeight.ToString());

            if (Element.Rtl != null)
                writer.WriteAttributeString(nameof(AdaptiveCard.Rtl), Element.Rtl.ToString());

            if (Element.VerticalContentAlignment != default(AdaptiveVerticalContentAlignment))
                writer.WriteAttributeString(nameof(AdaptiveCard.VerticalContentAlignment), Element.VerticalContentAlignment.ToString());

        }

    }
}
#endif
