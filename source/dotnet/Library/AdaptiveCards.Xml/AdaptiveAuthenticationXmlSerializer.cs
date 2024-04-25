// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveAuthenticationXmlSerializer : IXmlSerializable
    {
        public AdaptiveAuthentication Element { get; set; } = new AdaptiveAuthentication();

        public static AdaptiveAuthentication Read(XmlReader reader)
        {
            var ser = new AdaptiveAuthenticationXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveAuthentication el)
        {
            var ser = new AdaptiveAuthenticationXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveAuthentication.Text):
                        Element.Text = reader.GetAttribute<String>(nameof(AdaptiveAuthentication.Text));
                        break;

                    case nameof(AdaptiveAuthentication.ConnectionName):
                        Element.ConnectionName = reader.GetAttribute<String>(nameof(AdaptiveAuthentication.ConnectionName));
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
					
                        case nameof(AdaptiveAuthentication.TokenExchangeResource):
					        Element.TokenExchangeResource = AdaptiveTokenExchangeResourceXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveAuthentication.Buttons):
					        Element.Buttons.Add(AdaptiveAuthCardButtonXmlSerializer.Read(reader));
					        break;

                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
        }

    }
}
#endif
