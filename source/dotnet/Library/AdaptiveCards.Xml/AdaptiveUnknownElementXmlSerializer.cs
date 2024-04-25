// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveUnknownElementXmlSerializer : IXmlSerializable
    {
        public AdaptiveUnknownElement Element { get; set; } = new AdaptiveUnknownElement();

        public static AdaptiveUnknownElement Read(XmlReader reader)
        {
            var ser = new AdaptiveUnknownElementXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveUnknownElement el)
        {
            var ser = new AdaptiveUnknownElementXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveUnknownElement.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveUnknownElement.Spacing));
                        break;

                    case nameof(AdaptiveUnknownElement.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveUnknownElement.Separator));
                        break;

                    case nameof(AdaptiveUnknownElement.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveUnknownElement.Speak));
                        break;

                    case nameof(AdaptiveUnknownElement.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveUnknownElement.IsVisible));
                        break;

                    case nameof(AdaptiveUnknownElement.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveUnknownElement.Id));
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
					
                        case nameof(AdaptiveUnknownElement.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveUnknownElement.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveUnknownElement.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveUnknownElement.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveUnknownElement.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
