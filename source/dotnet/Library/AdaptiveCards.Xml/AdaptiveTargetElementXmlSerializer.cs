// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveTargetElementXmlSerializer : IXmlSerializable
    {
        public AdaptiveTargetElement Element { get; set; } = new AdaptiveTargetElement();

        public static AdaptiveTargetElement Read(XmlReader reader)
        {
            var ser = new AdaptiveTargetElementXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveTargetElement el)
        {
            var ser = new AdaptiveTargetElementXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveTargetElement.ElementId):
                        Element.ElementId = reader.GetAttribute<String>(nameof(AdaptiveTargetElement.ElementId));
                        break;

                    case nameof(AdaptiveTargetElement.IsVisible):
                        Element.IsVisible = reader.GetAttribute<System.Boolean?>(nameof(AdaptiveTargetElement.IsVisible));
                        break;

	            }
            }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.IsVisible != null)
                writer.WriteAttributeString(nameof(AdaptiveTargetElement.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
