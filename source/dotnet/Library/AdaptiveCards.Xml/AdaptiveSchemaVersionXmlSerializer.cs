// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveSchemaVersionXmlSerializer : IXmlSerializable
    {
        public AdaptiveSchemaVersion Element { get; set; } = new AdaptiveSchemaVersion();

        public static AdaptiveSchemaVersion Read(XmlReader reader)
        {
            var ser = new AdaptiveSchemaVersionXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveSchemaVersion el)
        {
            var ser = new AdaptiveSchemaVersionXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveSchemaVersion.Major):
                        Element.Major = reader.GetAttribute<Int32>(nameof(AdaptiveSchemaVersion.Major));
                        break;

                    case nameof(AdaptiveSchemaVersion.Minor):
                        Element.Minor = reader.GetAttribute<Int32>(nameof(AdaptiveSchemaVersion.Minor));
                        break;

	            }
            }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Major != default(Int32))
                writer.WriteAttributeString(nameof(AdaptiveSchemaVersion.Major), Element.Major.ToString());

            if (Element.Minor != default(Int32))
                writer.WriteAttributeString(nameof(AdaptiveSchemaVersion.Minor), Element.Minor.ToString());

        }

    }
}
#endif
