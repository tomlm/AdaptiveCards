// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveHeightXmlSerializer : IXmlSerializable
    {
        public AdaptiveHeight Element { get; set; } = new AdaptiveHeight();

        public static AdaptiveHeight Read(XmlReader reader)
        {
            var ser = new AdaptiveHeightXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveHeight el)
        {
            var ser = new AdaptiveHeightXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveHeight.HeightType):
                        Element.HeightType = reader.GetAttribute<AdaptiveHeightType>(nameof(AdaptiveHeight.HeightType));
                        break;

                    case nameof(AdaptiveHeight.Unit):
                        Element.Unit = reader.GetAttribute<System.UInt32?>(nameof(AdaptiveHeight.Unit));
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
					
                        case nameof(AdaptiveHeight.Auto):
					        Element.Auto = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveHeight.Stretch):
					        Element.Stretch = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.HeightType != default(AdaptiveHeightType))
                writer.WriteAttributeString(nameof(AdaptiveHeight.HeightType), Element.HeightType.ToString());

            if (Element.Unit != null)
                writer.WriteAttributeString(nameof(AdaptiveHeight.Unit), Element.Unit.ToString());

        }

    }
}
#endif
