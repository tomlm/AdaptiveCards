// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveMediaSourceXmlSerializer : IXmlSerializable
    {
        public AdaptiveMediaSource Element { get; set; } = new AdaptiveMediaSource();

        public static AdaptiveMediaSource Read(XmlReader reader)
        {
            var ser = new AdaptiveMediaSourceXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveMediaSource el)
        {
            var ser = new AdaptiveMediaSourceXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveMediaSource.MimeType):
                        Element.MimeType = reader.GetAttribute<String>(nameof(AdaptiveMediaSource.MimeType));
                        break;

                    case nameof(AdaptiveMediaSource.Url):
                        Element.Url = reader.GetAttribute<String>(nameof(AdaptiveMediaSource.Url));
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
