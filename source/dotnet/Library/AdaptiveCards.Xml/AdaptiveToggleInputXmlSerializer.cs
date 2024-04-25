// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveToggleInputXmlSerializer : IXmlSerializable
    {
        public AdaptiveToggleInput Element { get; set; } = new AdaptiveToggleInput();

        public static AdaptiveToggleInput Read(XmlReader reader)
        {
            var ser = new AdaptiveToggleInputXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveToggleInput el)
        {
            var ser = new AdaptiveToggleInputXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveToggleInput.Title):
                        Element.Title = reader.GetAttribute<String>(nameof(AdaptiveToggleInput.Title));
                        break;

                    case nameof(AdaptiveToggleInput.ValueOn):
                        Element.ValueOn = reader.GetAttribute<String>(nameof(AdaptiveToggleInput.ValueOn));
                        break;

                    case nameof(AdaptiveToggleInput.ValueOff):
                        Element.ValueOff = reader.GetAttribute<String>(nameof(AdaptiveToggleInput.ValueOff));
                        break;

                    case nameof(AdaptiveToggleInput.Wrap):
                        Element.Wrap = reader.GetAttribute<Boolean>(nameof(AdaptiveToggleInput.Wrap));
                        break;

                    case nameof(AdaptiveToggleInput.Value):
                        Element.Value = reader.GetAttribute<String>(nameof(AdaptiveToggleInput.Value));
                        break;

                    case nameof(AdaptiveToggleInput.IsRequired):
                        Element.IsRequired = reader.GetAttribute<Boolean>(nameof(AdaptiveToggleInput.IsRequired));
                        break;

                    case nameof(AdaptiveToggleInput.Label):
                        Element.Label = reader.GetAttribute<String>(nameof(AdaptiveToggleInput.Label));
                        break;

                    case nameof(AdaptiveToggleInput.ErrorMessage):
                        Element.ErrorMessage = reader.GetAttribute<String>(nameof(AdaptiveToggleInput.ErrorMessage));
                        break;

                    case nameof(AdaptiveToggleInput.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveToggleInput.Spacing));
                        break;

                    case nameof(AdaptiveToggleInput.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveToggleInput.Separator));
                        break;

                    case nameof(AdaptiveToggleInput.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveToggleInput.Speak));
                        break;

                    case nameof(AdaptiveToggleInput.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveToggleInput.IsVisible));
                        break;

                    case nameof(AdaptiveToggleInput.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveToggleInput.Id));
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
					
                        case nameof(AdaptiveToggleInput.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveToggleInput.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Wrap != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveToggleInput.Wrap), Element.Wrap.ToString());

            if (Element.IsRequired != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveToggleInput.IsRequired), Element.IsRequired.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveToggleInput.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveToggleInput.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveToggleInput.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
