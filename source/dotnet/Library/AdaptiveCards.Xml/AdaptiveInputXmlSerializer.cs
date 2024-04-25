// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveInputXmlSerializer : IXmlSerializable
    {
        public AdaptiveInput Element { get; set; } = new AdaptiveInput();

        public static AdaptiveInput Read(XmlReader reader)
        {
            var ser = new AdaptiveInputXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveInput el)
        {
            var ser = new AdaptiveInputXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveInput.IsRequired):
                        Element.IsRequired = reader.GetAttribute<Boolean>(nameof(AdaptiveInput.IsRequired));
                        break;

                    case nameof(AdaptiveInput.Label):
                        Element.Label = reader.GetAttribute<String>(nameof(AdaptiveInput.Label));
                        break;

                    case nameof(AdaptiveInput.ErrorMessage):
                        Element.ErrorMessage = reader.GetAttribute<String>(nameof(AdaptiveInput.ErrorMessage));
                        break;

                    case nameof(AdaptiveInput.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveInput.Spacing));
                        break;

                    case nameof(AdaptiveInput.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveInput.Separator));
                        break;

                    case nameof(AdaptiveInput.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveInput.Speak));
                        break;

                    case nameof(AdaptiveInput.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveInput.IsVisible));
                        break;

                    case nameof(AdaptiveInput.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveInput.Id));
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
					
                        case nameof(AdaptiveInput.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveInput.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.IsRequired != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveInput.IsRequired), Element.IsRequired.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveInput.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveInput.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveInput.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
