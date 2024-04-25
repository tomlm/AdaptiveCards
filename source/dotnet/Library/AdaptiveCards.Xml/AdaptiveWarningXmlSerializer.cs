// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveWarningXmlSerializer : IXmlSerializable
    {
        public AdaptiveWarning Element { get; set; } = new AdaptiveWarning();

        public static AdaptiveWarning Read(XmlReader reader)
        {
            var ser = new AdaptiveWarningXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveWarning el)
        {
            var ser = new AdaptiveWarningXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveWarning.Code):
                        Element.Code = reader.GetAttribute<Int32>(nameof(AdaptiveWarning.Code));
                        break;

                    case nameof(AdaptiveWarning.Message):
                        Element.Message = reader.GetAttribute<String>(nameof(AdaptiveWarning.Message));
                        break;

	            }
            }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Code != default(Int32))
                writer.WriteAttributeString(nameof(AdaptiveWarning.Code), Element.Code.ToString());

        }

    }
}
#endif
