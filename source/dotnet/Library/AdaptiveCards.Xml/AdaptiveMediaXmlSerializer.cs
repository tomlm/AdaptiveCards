// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveMediaXmlSerializer : IXmlSerializable
    {
        public AdaptiveMedia Element { get; set; } = new AdaptiveMedia();

        public static AdaptiveMedia Read(XmlReader reader)
        {
            var ser = new AdaptiveMediaXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveMedia el)
        {
            var ser = new AdaptiveMediaXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveMedia.Poster):
                        Element.Poster = reader.GetAttribute<String>(nameof(AdaptiveMedia.Poster));
                        break;

                    case nameof(AdaptiveMedia.AltText):
                        Element.AltText = reader.GetAttribute<String>(nameof(AdaptiveMedia.AltText));
                        break;

                    case nameof(AdaptiveMedia.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveMedia.Spacing));
                        break;

                    case nameof(AdaptiveMedia.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveMedia.Separator));
                        break;

                    case nameof(AdaptiveMedia.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveMedia.Speak));
                        break;

                    case nameof(AdaptiveMedia.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveMedia.IsVisible));
                        break;

                    case nameof(AdaptiveMedia.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveMedia.Id));
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
					
                        case nameof(AdaptiveMedia.Sources):
					        Element.Sources.Add(AdaptiveMediaSourceXmlSerializer.Read(reader));
					        break;

                        case nameof(AdaptiveMedia.CaptionSources):
					        Element.CaptionSources.Add(AdaptiveCaptionSourceXmlSerializer.Read(reader));
					        break;

                        case nameof(AdaptiveMedia.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveMedia.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveMedia.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveMedia.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveMedia.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
