// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveImageSetXmlSerializer : IXmlSerializable
    {
        public AdaptiveImageSet Element { get; set; } = new AdaptiveImageSet();

        public static AdaptiveImageSet Read(XmlReader reader)
        {
            var ser = new AdaptiveImageSetXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveImageSet el)
        {
            var ser = new AdaptiveImageSetXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveImageSet.ImageSize):
                        Element.ImageSize = reader.GetAttribute<AdaptiveImageSize>(nameof(AdaptiveImageSet.ImageSize));
                        break;

                    case nameof(AdaptiveImageSet.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveImageSet.Spacing));
                        break;

                    case nameof(AdaptiveImageSet.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveImageSet.Separator));
                        break;

                    case nameof(AdaptiveImageSet.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveImageSet.Speak));
                        break;

                    case nameof(AdaptiveImageSet.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveImageSet.IsVisible));
                        break;

                    case nameof(AdaptiveImageSet.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveImageSet.Id));
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
					
                        case nameof(AdaptiveImageSet.Images):
					        Element.Images.Add(AdaptiveImageXmlSerializer.Read(reader));
					        break;

                        case nameof(AdaptiveImageSet.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveImageSet.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.ImageSize != default(AdaptiveImageSize))
                writer.WriteAttributeString(nameof(AdaptiveImageSet.ImageSize), Element.ImageSize.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveImageSet.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveImageSet.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveImageSet.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
