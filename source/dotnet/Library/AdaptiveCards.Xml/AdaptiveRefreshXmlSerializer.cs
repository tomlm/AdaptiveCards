// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveRefreshXmlSerializer : IXmlSerializable
    {
        public AdaptiveRefresh Element { get; set; } = new AdaptiveRefresh();

        public static AdaptiveRefresh Read(XmlReader reader)
        {
            var ser = new AdaptiveRefreshXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveRefresh el)
        {
            var ser = new AdaptiveRefreshXmlSerializer() { Element = el };
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
					
                        case nameof(AdaptiveRefresh.UserIds):
					        Element.UserIds.Add((String)reader.ReadContentAs(typeof(String), null));
					        break;

                        default:
                            switch(reader.GetAttribute(nameof(Type)))
				            {
                                case AdaptiveExecuteAction.TypeName: 
					                 Element.Action = AdaptiveExecuteActionXmlSerializer.Read(reader);
					                 break;
									 
                                case AdaptiveSubmitAction.TypeName: 
					                 Element.Action = AdaptiveSubmitActionXmlSerializer.Read(reader);
					                 break;
									 
                         }
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
