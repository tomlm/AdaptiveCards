// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveOpenUrlActionXmlSerializer : IXmlSerializable
    {
        public AdaptiveOpenUrlAction Element { get; set; } = new AdaptiveOpenUrlAction();

        public static AdaptiveOpenUrlAction Read(XmlReader reader)
        {
            var ser = new AdaptiveOpenUrlActionXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveOpenUrlAction el)
        {
            var ser = new AdaptiveOpenUrlActionXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveOpenUrlAction.Url):
                        Element.Url = reader.GetAttribute<Uri>(nameof(AdaptiveOpenUrlAction.Url));
                        break;

                    case nameof(AdaptiveOpenUrlAction.UrlString):
                        Element.UrlString = reader.GetAttribute<String>(nameof(AdaptiveOpenUrlAction.UrlString));
                        break;

                    case nameof(AdaptiveOpenUrlAction.Title):
                        Element.Title = reader.GetAttribute<String>(nameof(AdaptiveOpenUrlAction.Title));
                        break;

                    case nameof(AdaptiveOpenUrlAction.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveOpenUrlAction.Speak));
                        break;

                    case nameof(AdaptiveOpenUrlAction.IconUrl):
                        Element.IconUrl = reader.GetAttribute<String>(nameof(AdaptiveOpenUrlAction.IconUrl));
                        break;

                    case nameof(AdaptiveOpenUrlAction.Style):
                        Element.Style = reader.GetAttribute<String>(nameof(AdaptiveOpenUrlAction.Style));
                        break;

                    case nameof(AdaptiveOpenUrlAction.IsEnabled):
                        Element.IsEnabled = reader.GetAttribute<Boolean>(nameof(AdaptiveOpenUrlAction.IsEnabled));
                        break;

                    case nameof(AdaptiveOpenUrlAction.Mode):
                        Element.Mode = reader.GetAttribute<AdaptiveActionMode>(nameof(AdaptiveOpenUrlAction.Mode));
                        break;

                    case nameof(AdaptiveOpenUrlAction.Tooltip):
                        Element.Tooltip = reader.GetAttribute<String>(nameof(AdaptiveOpenUrlAction.Tooltip));
                        break;

                    case nameof(AdaptiveOpenUrlAction.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveOpenUrlAction.Id));
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
					
                        case nameof(AdaptiveOpenUrlAction.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.IsEnabled != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveOpenUrlAction.IsEnabled), Element.IsEnabled.ToString());

            if (Element.Mode != default(AdaptiveActionMode))
                writer.WriteAttributeString(nameof(AdaptiveOpenUrlAction.Mode), Element.Mode.ToString());

        }

    }
}
#endif
