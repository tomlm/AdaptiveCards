// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveFactSetXmlSerializer : IXmlSerializable
    {
        public AdaptiveFactSet Element { get; set; } = new AdaptiveFactSet();

        public static AdaptiveFactSet Read(XmlReader reader)
        {
            var ser = new AdaptiveFactSetXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveFactSet el)
        {
            var ser = new AdaptiveFactSetXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveFactSet.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveFactSet.Spacing));
                        break;

                    case nameof(AdaptiveFactSet.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveFactSet.Separator));
                        break;

                    case nameof(AdaptiveFactSet.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveFactSet.Speak));
                        break;

                    case nameof(AdaptiveFactSet.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveFactSet.IsVisible));
                        break;

                    case nameof(AdaptiveFactSet.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveFactSet.Id));
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
					
                        case nameof(AdaptiveFactSet.Facts):
					        Element.Facts.Add(AdaptiveFactXmlSerializer.Read(reader));
					        break;

                        case nameof(AdaptiveFactSet.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveFactSet.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveFactSet.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveFactSet.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveFactSet.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
