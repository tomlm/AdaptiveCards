// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveNumberInputXmlSerializer : IXmlSerializable
    {
        public AdaptiveNumberInput Element { get; set; } = new AdaptiveNumberInput();

        public static AdaptiveNumberInput Read(XmlReader reader)
        {
            var ser = new AdaptiveNumberInputXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveNumberInput el)
        {
            var ser = new AdaptiveNumberInputXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveNumberInput.Placeholder):
                        Element.Placeholder = reader.GetAttribute<String>(nameof(AdaptiveNumberInput.Placeholder));
                        break;

                    case nameof(AdaptiveNumberInput.Value):
                        Element.Value = reader.GetAttribute<Double>(nameof(AdaptiveNumberInput.Value));
                        break;

                    case nameof(AdaptiveNumberInput.Min):
                        Element.Min = reader.GetAttribute<Double>(nameof(AdaptiveNumberInput.Min));
                        break;

                    case nameof(AdaptiveNumberInput.Max):
                        Element.Max = reader.GetAttribute<Double>(nameof(AdaptiveNumberInput.Max));
                        break;

                    case nameof(AdaptiveNumberInput.IsRequired):
                        Element.IsRequired = reader.GetAttribute<Boolean>(nameof(AdaptiveNumberInput.IsRequired));
                        break;

                    case nameof(AdaptiveNumberInput.Label):
                        Element.Label = reader.GetAttribute<String>(nameof(AdaptiveNumberInput.Label));
                        break;

                    case nameof(AdaptiveNumberInput.ErrorMessage):
                        Element.ErrorMessage = reader.GetAttribute<String>(nameof(AdaptiveNumberInput.ErrorMessage));
                        break;

                    case nameof(AdaptiveNumberInput.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveNumberInput.Spacing));
                        break;

                    case nameof(AdaptiveNumberInput.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveNumberInput.Separator));
                        break;

                    case nameof(AdaptiveNumberInput.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveNumberInput.Speak));
                        break;

                    case nameof(AdaptiveNumberInput.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveNumberInput.IsVisible));
                        break;

                    case nameof(AdaptiveNumberInput.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveNumberInput.Id));
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
					
                        case nameof(AdaptiveNumberInput.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveNumberInput.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Value != default(Double))
                writer.WriteAttributeString(nameof(AdaptiveNumberInput.Value), Element.Value.ToString());

            if (Element.Min != default(Double))
                writer.WriteAttributeString(nameof(AdaptiveNumberInput.Min), Element.Min.ToString());

            if (Element.Max != default(Double))
                writer.WriteAttributeString(nameof(AdaptiveNumberInput.Max), Element.Max.ToString());

            if (Element.IsRequired != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveNumberInput.IsRequired), Element.IsRequired.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveNumberInput.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveNumberInput.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveNumberInput.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
