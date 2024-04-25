// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveCaptionSourceXmlSerializer : IXmlSerializable
    {
        public AdaptiveCaptionSource Element { get; set; } = new AdaptiveCaptionSource();

        public static AdaptiveCaptionSource Read(XmlReader reader)
        {
            var ser = new AdaptiveCaptionSourceXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveCaptionSource el)
        {
            var ser = new AdaptiveCaptionSourceXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveCaptionSource.MimeType):
                        Element.MimeType = reader.GetAttribute<String>(nameof(AdaptiveCaptionSource.MimeType));
                        break;

                    case nameof(AdaptiveCaptionSource.Url):
                        Element.Url = reader.GetAttribute<String>(nameof(AdaptiveCaptionSource.Url));
                        break;

                    case nameof(AdaptiveCaptionSource.Label):
                        Element.Label = reader.GetAttribute<String>(nameof(AdaptiveCaptionSource.Label));
                        break;

	            }
            }
        }


        public void WriteXml(XmlWriter writer)
		{
        }

    }
}
#endif
