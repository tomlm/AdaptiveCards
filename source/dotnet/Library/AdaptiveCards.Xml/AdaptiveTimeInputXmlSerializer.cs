// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveTimeInputXmlSerializer : IXmlSerializable
    {
        public AdaptiveTimeInput Element { get; set; } = new AdaptiveTimeInput();

        public static AdaptiveTimeInput Read(XmlReader reader)
        {
            var ser = new AdaptiveTimeInputXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveTimeInput el)
        {
            var ser = new AdaptiveTimeInputXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveTimeInput.Placeholder):
                        Element.Placeholder = reader.GetAttribute<String>(nameof(AdaptiveTimeInput.Placeholder));
                        break;

                    case nameof(AdaptiveTimeInput.Value):
                        Element.Value = reader.GetAttribute<String>(nameof(AdaptiveTimeInput.Value));
                        break;

                    case nameof(AdaptiveTimeInput.Min):
                        Element.Min = reader.GetAttribute<String>(nameof(AdaptiveTimeInput.Min));
                        break;

                    case nameof(AdaptiveTimeInput.Max):
                        Element.Max = reader.GetAttribute<String>(nameof(AdaptiveTimeInput.Max));
                        break;

                    case nameof(AdaptiveTimeInput.IsRequired):
                        Element.IsRequired = reader.GetAttribute<Boolean>(nameof(AdaptiveTimeInput.IsRequired));
                        break;

                    case nameof(AdaptiveTimeInput.Label):
                        Element.Label = reader.GetAttribute<String>(nameof(AdaptiveTimeInput.Label));
                        break;

                    case nameof(AdaptiveTimeInput.ErrorMessage):
                        Element.ErrorMessage = reader.GetAttribute<String>(nameof(AdaptiveTimeInput.ErrorMessage));
                        break;

                    case nameof(AdaptiveTimeInput.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveTimeInput.Spacing));
                        break;

                    case nameof(AdaptiveTimeInput.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveTimeInput.Separator));
                        break;

                    case nameof(AdaptiveTimeInput.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveTimeInput.Speak));
                        break;

                    case nameof(AdaptiveTimeInput.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveTimeInput.IsVisible));
                        break;

                    case nameof(AdaptiveTimeInput.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveTimeInput.Id));
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
					
                        case nameof(AdaptiveTimeInput.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveTimeInput.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.IsRequired != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTimeInput.IsRequired), Element.IsRequired.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveTimeInput.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTimeInput.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTimeInput.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
