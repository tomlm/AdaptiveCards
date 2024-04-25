// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveExecuteActionXmlSerializer : IXmlSerializable
    {
        public AdaptiveExecuteAction Element { get; set; } = new AdaptiveExecuteAction();

        public static AdaptiveExecuteAction Read(XmlReader reader)
        {
            var ser = new AdaptiveExecuteActionXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveExecuteAction el)
        {
            var ser = new AdaptiveExecuteActionXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveExecuteAction.AssociatedInputs):
                        Element.AssociatedInputs = reader.GetAttribute<AdaptiveAssociatedInputs>(nameof(AdaptiveExecuteAction.AssociatedInputs));
                        break;

                    case nameof(AdaptiveExecuteAction.Verb):
                        Element.Verb = reader.GetAttribute<String>(nameof(AdaptiveExecuteAction.Verb));
                        break;

                    case nameof(AdaptiveExecuteAction.DataJson):
                        Element.DataJson = reader.GetAttribute<String>(nameof(AdaptiveExecuteAction.DataJson));
                        break;

                    case nameof(AdaptiveExecuteAction.Title):
                        Element.Title = reader.GetAttribute<String>(nameof(AdaptiveExecuteAction.Title));
                        break;

                    case nameof(AdaptiveExecuteAction.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveExecuteAction.Speak));
                        break;

                    case nameof(AdaptiveExecuteAction.IconUrl):
                        Element.IconUrl = reader.GetAttribute<String>(nameof(AdaptiveExecuteAction.IconUrl));
                        break;

                    case nameof(AdaptiveExecuteAction.Style):
                        Element.Style = reader.GetAttribute<String>(nameof(AdaptiveExecuteAction.Style));
                        break;

                    case nameof(AdaptiveExecuteAction.IsEnabled):
                        Element.IsEnabled = reader.GetAttribute<Boolean>(nameof(AdaptiveExecuteAction.IsEnabled));
                        break;

                    case nameof(AdaptiveExecuteAction.Mode):
                        Element.Mode = reader.GetAttribute<AdaptiveActionMode>(nameof(AdaptiveExecuteAction.Mode));
                        break;

                    case nameof(AdaptiveExecuteAction.Tooltip):
                        Element.Tooltip = reader.GetAttribute<String>(nameof(AdaptiveExecuteAction.Tooltip));
                        break;

                    case nameof(AdaptiveExecuteAction.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveExecuteAction.Id));
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
					
                        case nameof(AdaptiveExecuteAction.Data):
					        Element.Data = ObjectXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveExecuteAction.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.AssociatedInputs != default(AdaptiveAssociatedInputs))
                writer.WriteAttributeString(nameof(AdaptiveExecuteAction.AssociatedInputs), Element.AssociatedInputs.ToString());

            if (Element.IsEnabled != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveExecuteAction.IsEnabled), Element.IsEnabled.ToString());

            if (Element.Mode != default(AdaptiveActionMode))
                writer.WriteAttributeString(nameof(AdaptiveExecuteAction.Mode), Element.Mode.ToString());

        }

    }
}
#endif
