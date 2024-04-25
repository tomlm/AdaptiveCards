// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveElementXmlSerializer : IXmlSerializable
    {
        public AdaptiveElement Element { get; set; } = new AdaptiveElement();

        public static AdaptiveElement Read(XmlReader reader)
        {
            var ser = new AdaptiveElementXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveElement el)
        {
            var ser = new AdaptiveElementXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveElement.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveElement.Spacing));
                        break;

                    case nameof(AdaptiveElement.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveElement.Separator));
                        break;

                    case nameof(AdaptiveElement.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveElement.Speak));
                        break;

                    case nameof(AdaptiveElement.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveElement.IsVisible));
                        break;

                    case nameof(AdaptiveElement.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveElement.Id));
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
					
                        case nameof(AdaptiveElement.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveElement.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveElement.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveElement.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveElement.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
