// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveChoiceSetInputXmlSerializer : IXmlSerializable
    {
        public AdaptiveChoiceSetInput Element { get; set; } = new AdaptiveChoiceSetInput();

        public static AdaptiveChoiceSetInput Read(XmlReader reader)
        {
            var ser = new AdaptiveChoiceSetInputXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveChoiceSetInput el)
        {
            var ser = new AdaptiveChoiceSetInputXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveChoiceSetInput.Value):
                        Element.Value = reader.GetAttribute<String>(nameof(AdaptiveChoiceSetInput.Value));
                        break;

                    case nameof(AdaptiveChoiceSetInput.Style):
                        Element.Style = reader.GetAttribute<AdaptiveChoiceInputStyle>(nameof(AdaptiveChoiceSetInput.Style));
                        break;

                    case nameof(AdaptiveChoiceSetInput.IsMultiSelect):
                        Element.IsMultiSelect = reader.GetAttribute<Boolean>(nameof(AdaptiveChoiceSetInput.IsMultiSelect));
                        break;

                    case nameof(AdaptiveChoiceSetInput.Wrap):
                        Element.Wrap = reader.GetAttribute<Boolean>(nameof(AdaptiveChoiceSetInput.Wrap));
                        break;

                    case nameof(AdaptiveChoiceSetInput.Placeholder):
                        Element.Placeholder = reader.GetAttribute<String>(nameof(AdaptiveChoiceSetInput.Placeholder));
                        break;

                    case nameof(AdaptiveChoiceSetInput.IsRequired):
                        Element.IsRequired = reader.GetAttribute<Boolean>(nameof(AdaptiveChoiceSetInput.IsRequired));
                        break;

                    case nameof(AdaptiveChoiceSetInput.Label):
                        Element.Label = reader.GetAttribute<String>(nameof(AdaptiveChoiceSetInput.Label));
                        break;

                    case nameof(AdaptiveChoiceSetInput.ErrorMessage):
                        Element.ErrorMessage = reader.GetAttribute<String>(nameof(AdaptiveChoiceSetInput.ErrorMessage));
                        break;

                    case nameof(AdaptiveChoiceSetInput.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveChoiceSetInput.Spacing));
                        break;

                    case nameof(AdaptiveChoiceSetInput.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveChoiceSetInput.Separator));
                        break;

                    case nameof(AdaptiveChoiceSetInput.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveChoiceSetInput.Speak));
                        break;

                    case nameof(AdaptiveChoiceSetInput.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveChoiceSetInput.IsVisible));
                        break;

                    case nameof(AdaptiveChoiceSetInput.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveChoiceSetInput.Id));
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
					
                        case nameof(AdaptiveChoiceSetInput.Choices):
					        Element.Choices.Add(AdaptiveChoiceXmlSerializer.Read(reader));
					        break;

                        case nameof(AdaptiveChoiceSetInput.DataQuery):
					        Element.DataQuery = AdaptiveDataQueryXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveChoiceSetInput.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveChoiceSetInput.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Style != default(AdaptiveChoiceInputStyle))
                writer.WriteAttributeString(nameof(AdaptiveChoiceSetInput.Style), Element.Style.ToString());

            if (Element.IsMultiSelect != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveChoiceSetInput.IsMultiSelect), Element.IsMultiSelect.ToString());

            if (Element.Wrap != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveChoiceSetInput.Wrap), Element.Wrap.ToString());

            if (Element.IsRequired != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveChoiceSetInput.IsRequired), Element.IsRequired.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveChoiceSetInput.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveChoiceSetInput.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveChoiceSetInput.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
