// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveShowCardActionXmlSerializer : IXmlSerializable
    {
        public AdaptiveShowCardAction Element { get; set; } = new AdaptiveShowCardAction();

        public static AdaptiveShowCardAction Read(XmlReader reader)
        {
            var ser = new AdaptiveShowCardActionXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveShowCardAction el)
        {
            var ser = new AdaptiveShowCardActionXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveShowCardAction.Title):
                        Element.Title = reader.GetAttribute<String>(nameof(AdaptiveShowCardAction.Title));
                        break;

                    case nameof(AdaptiveShowCardAction.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveShowCardAction.Speak));
                        break;

                    case nameof(AdaptiveShowCardAction.IconUrl):
                        Element.IconUrl = reader.GetAttribute<String>(nameof(AdaptiveShowCardAction.IconUrl));
                        break;

                    case nameof(AdaptiveShowCardAction.Style):
                        Element.Style = reader.GetAttribute<String>(nameof(AdaptiveShowCardAction.Style));
                        break;

                    case nameof(AdaptiveShowCardAction.IsEnabled):
                        Element.IsEnabled = reader.GetAttribute<Boolean>(nameof(AdaptiveShowCardAction.IsEnabled));
                        break;

                    case nameof(AdaptiveShowCardAction.Mode):
                        Element.Mode = reader.GetAttribute<AdaptiveActionMode>(nameof(AdaptiveShowCardAction.Mode));
                        break;

                    case nameof(AdaptiveShowCardAction.Tooltip):
                        Element.Tooltip = reader.GetAttribute<String>(nameof(AdaptiveShowCardAction.Tooltip));
                        break;

                    case nameof(AdaptiveShowCardAction.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveShowCardAction.Id));
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
					
                        case nameof(AdaptiveShowCardAction.Card):
					        Element.Card = AdaptiveCardXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveShowCardAction.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.IsEnabled != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveShowCardAction.IsEnabled), Element.IsEnabled.ToString());

            if (Element.Mode != default(AdaptiveActionMode))
                writer.WriteAttributeString(nameof(AdaptiveShowCardAction.Mode), Element.Mode.ToString());

        }

    }
}
#endif
