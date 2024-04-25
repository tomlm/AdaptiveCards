// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveWidthXmlSerializer : IXmlSerializable
    {
        public AdaptiveWidth Element { get; set; } = new AdaptiveWidth();

        public static AdaptiveWidth Read(XmlReader reader)
        {
            var ser = new AdaptiveWidthXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveWidth el)
        {
            var ser = new AdaptiveWidthXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveWidth.WidthType):
                        Element.WidthType = reader.GetAttribute<AdaptiveWidthType>(nameof(AdaptiveWidth.WidthType));
                        break;

                    case nameof(AdaptiveWidth.Unit):
                        Element.Unit = reader.GetAttribute<System.UInt32?>(nameof(AdaptiveWidth.Unit));
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
					
                        case nameof(AdaptiveWidth.Auto):
					        Element.Auto = AdaptiveWidthXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveWidth.Stretch):
					        Element.Stretch = AdaptiveWidthXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.WidthType != default(AdaptiveWidthType))
                writer.WriteAttributeString(nameof(AdaptiveWidth.WidthType), Element.WidthType.ToString());

            if (Element.Unit != null)
                writer.WriteAttributeString(nameof(AdaptiveWidth.Unit), Element.Unit.ToString());

        }

    }
}
#endif
