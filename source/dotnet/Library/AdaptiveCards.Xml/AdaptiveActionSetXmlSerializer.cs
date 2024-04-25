// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveActionSetXmlSerializer : IXmlSerializable
    {
        public AdaptiveActionSet Element { get; set; } = new AdaptiveActionSet();

        public static AdaptiveActionSet Read(XmlReader reader)
        {
            var ser = new AdaptiveActionSetXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveActionSet el)
        {
            var ser = new AdaptiveActionSetXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveActionSet.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveActionSet.Spacing));
                        break;

                    case nameof(AdaptiveActionSet.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveActionSet.Separator));
                        break;

                    case nameof(AdaptiveActionSet.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveActionSet.Speak));
                        break;

                    case nameof(AdaptiveActionSet.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveActionSet.IsVisible));
                        break;

                    case nameof(AdaptiveActionSet.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveActionSet.Id));
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
					
                        case nameof(AdaptiveActionSet.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveActionSet.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                        default:
                            switch(reader.GetAttribute(nameof(Type)))
				            {
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
            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveActionSet.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveActionSet.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveActionSet.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
