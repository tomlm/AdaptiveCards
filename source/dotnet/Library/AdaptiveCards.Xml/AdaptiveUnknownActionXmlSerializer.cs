// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveUnknownActionXmlSerializer : IXmlSerializable
    {
        public AdaptiveUnknownAction Element { get; set; } = new AdaptiveUnknownAction();

        public static AdaptiveUnknownAction Read(XmlReader reader)
        {
            var ser = new AdaptiveUnknownActionXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveUnknownAction el)
        {
            var ser = new AdaptiveUnknownActionXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveUnknownAction.Title):
                        Element.Title = reader.GetAttribute<String>(nameof(AdaptiveUnknownAction.Title));
                        break;

                    case nameof(AdaptiveUnknownAction.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveUnknownAction.Speak));
                        break;

                    case nameof(AdaptiveUnknownAction.IconUrl):
                        Element.IconUrl = reader.GetAttribute<String>(nameof(AdaptiveUnknownAction.IconUrl));
                        break;

                    case nameof(AdaptiveUnknownAction.Style):
                        Element.Style = reader.GetAttribute<String>(nameof(AdaptiveUnknownAction.Style));
                        break;

                    case nameof(AdaptiveUnknownAction.IsEnabled):
                        Element.IsEnabled = reader.GetAttribute<Boolean>(nameof(AdaptiveUnknownAction.IsEnabled));
                        break;

                    case nameof(AdaptiveUnknownAction.Mode):
                        Element.Mode = reader.GetAttribute<AdaptiveActionMode>(nameof(AdaptiveUnknownAction.Mode));
                        break;

                    case nameof(AdaptiveUnknownAction.Tooltip):
                        Element.Tooltip = reader.GetAttribute<String>(nameof(AdaptiveUnknownAction.Tooltip));
                        break;

                    case nameof(AdaptiveUnknownAction.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveUnknownAction.Id));
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
					
                        case nameof(AdaptiveUnknownAction.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.IsEnabled != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveUnknownAction.IsEnabled), Element.IsEnabled.ToString());

            if (Element.Mode != default(AdaptiveActionMode))
                writer.WriteAttributeString(nameof(AdaptiveUnknownAction.Mode), Element.Mode.ToString());

        }

    }
}
#endif
