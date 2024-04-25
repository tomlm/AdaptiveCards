// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveSubmitActionXmlSerializer : IXmlSerializable
    {
        public AdaptiveSubmitAction Element { get; set; } = new AdaptiveSubmitAction();

        public static AdaptiveSubmitAction Read(XmlReader reader)
        {
            var ser = new AdaptiveSubmitActionXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveSubmitAction el)
        {
            var ser = new AdaptiveSubmitActionXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveSubmitAction.AssociatedInputs):
                        Element.AssociatedInputs = reader.GetAttribute<AdaptiveAssociatedInputs>(nameof(AdaptiveSubmitAction.AssociatedInputs));
                        break;

                    case nameof(AdaptiveSubmitAction.DataJson):
                        Element.DataJson = reader.GetAttribute<String>(nameof(AdaptiveSubmitAction.DataJson));
                        break;

                    case nameof(AdaptiveSubmitAction.Title):
                        Element.Title = reader.GetAttribute<String>(nameof(AdaptiveSubmitAction.Title));
                        break;

                    case nameof(AdaptiveSubmitAction.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveSubmitAction.Speak));
                        break;

                    case nameof(AdaptiveSubmitAction.IconUrl):
                        Element.IconUrl = reader.GetAttribute<String>(nameof(AdaptiveSubmitAction.IconUrl));
                        break;

                    case nameof(AdaptiveSubmitAction.Style):
                        Element.Style = reader.GetAttribute<String>(nameof(AdaptiveSubmitAction.Style));
                        break;

                    case nameof(AdaptiveSubmitAction.IsEnabled):
                        Element.IsEnabled = reader.GetAttribute<Boolean>(nameof(AdaptiveSubmitAction.IsEnabled));
                        break;

                    case nameof(AdaptiveSubmitAction.Mode):
                        Element.Mode = reader.GetAttribute<AdaptiveActionMode>(nameof(AdaptiveSubmitAction.Mode));
                        break;

                    case nameof(AdaptiveSubmitAction.Tooltip):
                        Element.Tooltip = reader.GetAttribute<String>(nameof(AdaptiveSubmitAction.Tooltip));
                        break;

                    case nameof(AdaptiveSubmitAction.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveSubmitAction.Id));
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
					
                        case nameof(AdaptiveSubmitAction.Data):
					        Element.Data = ObjectXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveSubmitAction.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.AssociatedInputs != default(AdaptiveAssociatedInputs))
                writer.WriteAttributeString(nameof(AdaptiveSubmitAction.AssociatedInputs), Element.AssociatedInputs.ToString());

            if (Element.IsEnabled != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveSubmitAction.IsEnabled), Element.IsEnabled.ToString());

            if (Element.Mode != default(AdaptiveActionMode))
                writer.WriteAttributeString(nameof(AdaptiveSubmitAction.Mode), Element.Mode.ToString());

        }

    }
}
#endif
