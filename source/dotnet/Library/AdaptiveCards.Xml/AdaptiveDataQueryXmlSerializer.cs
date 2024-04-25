// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveDataQueryXmlSerializer : IXmlSerializable
    {
        public AdaptiveDataQuery Element { get; set; } = new AdaptiveDataQuery();

        public static AdaptiveDataQuery Read(XmlReader reader)
        {
            var ser = new AdaptiveDataQueryXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveDataQuery el)
        {
            var ser = new AdaptiveDataQueryXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveDataQuery.Dataset):
                        Element.Dataset = reader.GetAttribute<String>(nameof(AdaptiveDataQuery.Dataset));
                        break;

                    case nameof(AdaptiveDataQuery.Value):
                        Element.Value = reader.GetAttribute<String>(nameof(AdaptiveDataQuery.Value));
                        break;

                    case nameof(AdaptiveDataQuery.Count):
                        Element.Count = reader.GetAttribute<Int32>(nameof(AdaptiveDataQuery.Count));
                        break;

                    case nameof(AdaptiveDataQuery.Skip):
                        Element.Skip = reader.GetAttribute<Int32>(nameof(AdaptiveDataQuery.Skip));
                        break;

	            }
            }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Count != default(Int32))
                writer.WriteAttributeString(nameof(AdaptiveDataQuery.Count), Element.Count.ToString());

            if (Element.Skip != default(Int32))
                writer.WriteAttributeString(nameof(AdaptiveDataQuery.Skip), Element.Skip.ToString());

        }

    }
}
#endif
