// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveDateInputXmlSerializer : IXmlSerializable
    {
        public AdaptiveDateInput Element { get; set; } = new AdaptiveDateInput();

        public static AdaptiveDateInput Read(XmlReader reader)
        {
            var ser = new AdaptiveDateInputXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveDateInput el)
        {
            var ser = new AdaptiveDateInputXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveDateInput.Placeholder):
                        Element.Placeholder = reader.GetAttribute<String>(nameof(AdaptiveDateInput.Placeholder));
                        break;

                    case nameof(AdaptiveDateInput.Value):
                        Element.Value = reader.GetAttribute<String>(nameof(AdaptiveDateInput.Value));
                        break;

                    case nameof(AdaptiveDateInput.Min):
                        Element.Min = reader.GetAttribute<String>(nameof(AdaptiveDateInput.Min));
                        break;

                    case nameof(AdaptiveDateInput.Max):
                        Element.Max = reader.GetAttribute<String>(nameof(AdaptiveDateInput.Max));
                        break;

                    case nameof(AdaptiveDateInput.IsRequired):
                        Element.IsRequired = reader.GetAttribute<Boolean>(nameof(AdaptiveDateInput.IsRequired));
                        break;

                    case nameof(AdaptiveDateInput.Label):
                        Element.Label = reader.GetAttribute<String>(nameof(AdaptiveDateInput.Label));
                        break;

                    case nameof(AdaptiveDateInput.ErrorMessage):
                        Element.ErrorMessage = reader.GetAttribute<String>(nameof(AdaptiveDateInput.ErrorMessage));
                        break;

                    case nameof(AdaptiveDateInput.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveDateInput.Spacing));
                        break;

                    case nameof(AdaptiveDateInput.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveDateInput.Separator));
                        break;

                    case nameof(AdaptiveDateInput.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveDateInput.Speak));
                        break;

                    case nameof(AdaptiveDateInput.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveDateInput.IsVisible));
                        break;

                    case nameof(AdaptiveDateInput.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveDateInput.Id));
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
					
                        case nameof(AdaptiveDateInput.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveDateInput.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.IsRequired != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveDateInput.IsRequired), Element.IsRequired.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveDateInput.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveDateInput.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveDateInput.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
