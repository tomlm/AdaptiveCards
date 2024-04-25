// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveActionXmlSerializer : IXmlSerializable
    {
        public AdaptiveAction Element { get; set; } = new AdaptiveAction();

        public static AdaptiveAction Read(XmlReader reader)
        {
            var ser = new AdaptiveActionXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveAction el)
        {
            var ser = new AdaptiveActionXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveAction.Title):
                        Element.Title = reader.GetAttribute<String>(nameof(AdaptiveAction.Title));
                        break;

                    case nameof(AdaptiveAction.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveAction.Speak));
                        break;

                    case nameof(AdaptiveAction.IconUrl):
                        Element.IconUrl = reader.GetAttribute<String>(nameof(AdaptiveAction.IconUrl));
                        break;

                    case nameof(AdaptiveAction.Style):
                        Element.Style = reader.GetAttribute<String>(nameof(AdaptiveAction.Style));
                        break;

                    case nameof(AdaptiveAction.IsEnabled):
                        Element.IsEnabled = reader.GetAttribute<Boolean>(nameof(AdaptiveAction.IsEnabled));
                        break;

                    case nameof(AdaptiveAction.Mode):
                        Element.Mode = reader.GetAttribute<AdaptiveActionMode>(nameof(AdaptiveAction.Mode));
                        break;

                    case nameof(AdaptiveAction.Tooltip):
                        Element.Tooltip = reader.GetAttribute<String>(nameof(AdaptiveAction.Tooltip));
                        break;

                    case nameof(AdaptiveAction.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveAction.Id));
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
					
                        case nameof(AdaptiveAction.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.IsEnabled != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveAction.IsEnabled), Element.IsEnabled.ToString());

            if (Element.Mode != default(AdaptiveActionMode))
                writer.WriteAttributeString(nameof(AdaptiveAction.Mode), Element.Mode.ToString());

        }

    }
}
#endif
