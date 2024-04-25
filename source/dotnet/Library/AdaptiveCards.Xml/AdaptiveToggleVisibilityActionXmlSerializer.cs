// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveToggleVisibilityActionXmlSerializer : IXmlSerializable
    {
        public AdaptiveToggleVisibilityAction Element { get; set; } = new AdaptiveToggleVisibilityAction();

        public static AdaptiveToggleVisibilityAction Read(XmlReader reader)
        {
            var ser = new AdaptiveToggleVisibilityActionXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveToggleVisibilityAction el)
        {
            var ser = new AdaptiveToggleVisibilityActionXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveToggleVisibilityAction.Title):
                        Element.Title = reader.GetAttribute<String>(nameof(AdaptiveToggleVisibilityAction.Title));
                        break;

                    case nameof(AdaptiveToggleVisibilityAction.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveToggleVisibilityAction.Speak));
                        break;

                    case nameof(AdaptiveToggleVisibilityAction.IconUrl):
                        Element.IconUrl = reader.GetAttribute<String>(nameof(AdaptiveToggleVisibilityAction.IconUrl));
                        break;

                    case nameof(AdaptiveToggleVisibilityAction.Style):
                        Element.Style = reader.GetAttribute<String>(nameof(AdaptiveToggleVisibilityAction.Style));
                        break;

                    case nameof(AdaptiveToggleVisibilityAction.IsEnabled):
                        Element.IsEnabled = reader.GetAttribute<Boolean>(nameof(AdaptiveToggleVisibilityAction.IsEnabled));
                        break;

                    case nameof(AdaptiveToggleVisibilityAction.Mode):
                        Element.Mode = reader.GetAttribute<AdaptiveActionMode>(nameof(AdaptiveToggleVisibilityAction.Mode));
                        break;

                    case nameof(AdaptiveToggleVisibilityAction.Tooltip):
                        Element.Tooltip = reader.GetAttribute<String>(nameof(AdaptiveToggleVisibilityAction.Tooltip));
                        break;

                    case nameof(AdaptiveToggleVisibilityAction.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveToggleVisibilityAction.Id));
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
					
                        case nameof(AdaptiveToggleVisibilityAction.TargetElements):
					        Element.TargetElements.Add(AdaptiveTargetElementXmlSerializer.Read(reader));
					        break;

                        case nameof(AdaptiveToggleVisibilityAction.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.IsEnabled != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveToggleVisibilityAction.IsEnabled), Element.IsEnabled.ToString());

            if (Element.Mode != default(AdaptiveActionMode))
                writer.WriteAttributeString(nameof(AdaptiveToggleVisibilityAction.Mode), Element.Mode.ToString());

        }

    }
}
#endif
