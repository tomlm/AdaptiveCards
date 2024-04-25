// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveChoiceXmlSerializer : IXmlSerializable
    {
        public AdaptiveChoice Element { get; set; } = new AdaptiveChoice();

        public static AdaptiveChoice Read(XmlReader reader)
        {
            var ser = new AdaptiveChoiceXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveChoice el)
        {
            var ser = new AdaptiveChoiceXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveChoice.Title):
                        Element.Title = reader.GetAttribute<String>(nameof(AdaptiveChoice.Title));
                        break;

                    case nameof(AdaptiveChoice.Value):
                        Element.Value = reader.GetAttribute<String>(nameof(AdaptiveChoice.Value));
                        break;

                    case nameof(AdaptiveChoice.IsSelected):
                        Element.IsSelected = reader.GetAttribute<Boolean>(nameof(AdaptiveChoice.IsSelected));
                        break;

                    case nameof(AdaptiveChoice.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveChoice.Speak));
                        break;

	            }
            }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.IsSelected != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveChoice.IsSelected), Element.IsSelected.ToString());

        }

    }
}
#endif
