// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public class AdaptiveTextInputXmlSerializer : IXmlSerializable
    {
        public AdaptiveTextInput Element { get; set; } = new AdaptiveTextInput();

        public static AdaptiveTextInput Read(XmlReader reader)
        {
            var ser = new AdaptiveTextInputXmlSerializer();
            ser.ReadXml(reader);
            return ser.Element;
        }

        public static void Write(XmlWriter writer, AdaptiveTextInput el)
        {
            var ser = new AdaptiveTextInputXmlSerializer() { Element = el };
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
                    case nameof(AdaptiveTextInput.Placeholder):
                        Element.Placeholder = reader.GetAttribute<String>(nameof(AdaptiveTextInput.Placeholder));
                        break;

                    case nameof(AdaptiveTextInput.Value):
                        Element.Value = reader.GetAttribute<String>(nameof(AdaptiveTextInput.Value));
                        break;

                    case nameof(AdaptiveTextInput.Style):
                        Element.Style = reader.GetAttribute<AdaptiveTextInputStyle>(nameof(AdaptiveTextInput.Style));
                        break;

                    case nameof(AdaptiveTextInput.IsMultiline):
                        Element.IsMultiline = reader.GetAttribute<Boolean>(nameof(AdaptiveTextInput.IsMultiline));
                        break;

                    case nameof(AdaptiveTextInput.MaxLength):
                        Element.MaxLength = reader.GetAttribute<Int32>(nameof(AdaptiveTextInput.MaxLength));
                        break;

                    case nameof(AdaptiveTextInput.Regex):
                        Element.Regex = reader.GetAttribute<String>(nameof(AdaptiveTextInput.Regex));
                        break;

                    case nameof(AdaptiveTextInput.IsRequired):
                        Element.IsRequired = reader.GetAttribute<Boolean>(nameof(AdaptiveTextInput.IsRequired));
                        break;

                    case nameof(AdaptiveTextInput.Label):
                        Element.Label = reader.GetAttribute<String>(nameof(AdaptiveTextInput.Label));
                        break;

                    case nameof(AdaptiveTextInput.ErrorMessage):
                        Element.ErrorMessage = reader.GetAttribute<String>(nameof(AdaptiveTextInput.ErrorMessage));
                        break;

                    case nameof(AdaptiveTextInput.Spacing):
                        Element.Spacing = reader.GetAttribute<AdaptiveSpacing>(nameof(AdaptiveTextInput.Spacing));
                        break;

                    case nameof(AdaptiveTextInput.Separator):
                        Element.Separator = reader.GetAttribute<Boolean>(nameof(AdaptiveTextInput.Separator));
                        break;

                    case nameof(AdaptiveTextInput.Speak):
                        Element.Speak = reader.GetAttribute<String>(nameof(AdaptiveTextInput.Speak));
                        break;

                    case nameof(AdaptiveTextInput.IsVisible):
                        Element.IsVisible = reader.GetAttribute<Boolean>(nameof(AdaptiveTextInput.IsVisible));
                        break;

                    case nameof(AdaptiveTextInput.Id):
                        Element.Id = reader.GetAttribute<String>(nameof(AdaptiveTextInput.Id));
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
					
                        case nameof(AdaptiveTextInput.Height):
					        Element.Height = AdaptiveHeightXmlSerializer.Read(reader);
					        break;

                        case nameof(AdaptiveTextInput.Fallback):
					        Element.Fallback = AdaptiveFallbackElementXmlSerializer.Read(reader);
					        break;

                        default:
                            switch(reader.GetAttribute(nameof(Type)))
				            {
                                case AdaptiveOpenUrlAction.TypeName: 
					                 Element.InlineAction = AdaptiveOpenUrlActionXmlSerializer.Read(reader);
					                 break;
									 
                                case AdaptiveShowCardAction.TypeName: 
					                 Element.InlineAction = AdaptiveShowCardActionXmlSerializer.Read(reader);
					                 break;
									 
                                case AdaptiveSubmitAction.TypeName: 
					                 Element.InlineAction = AdaptiveSubmitActionXmlSerializer.Read(reader);
					                 break;
									 
                                case AdaptiveToggleVisibilityAction.TypeName: 
					                 Element.InlineAction = AdaptiveToggleVisibilityActionXmlSerializer.Read(reader);
					                 break;
									 
                                case AdaptiveExecuteAction.TypeName: 
					                 Element.InlineAction = AdaptiveExecuteActionXmlSerializer.Read(reader);
					                 break;
									 
                         }
                         break;
                    }
                }
		    }
        }


        public void WriteXml(XmlWriter writer)
		{
            if (Element.Style != default(AdaptiveTextInputStyle))
                writer.WriteAttributeString(nameof(AdaptiveTextInput.Style), Element.Style.ToString());

            if (Element.IsMultiline != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextInput.IsMultiline), Element.IsMultiline.ToString());

            if (Element.MaxLength != default(Int32))
                writer.WriteAttributeString(nameof(AdaptiveTextInput.MaxLength), Element.MaxLength.ToString());

            if (Element.IsRequired != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextInput.IsRequired), Element.IsRequired.ToString());

            if (Element.Spacing != default(AdaptiveSpacing))
                writer.WriteAttributeString(nameof(AdaptiveTextInput.Spacing), Element.Spacing.ToString());

            if (Element.Separator != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextInput.Separator), Element.Separator.ToString());

            if (Element.IsVisible != default(Boolean))
                writer.WriteAttributeString(nameof(AdaptiveTextInput.IsVisible), Element.IsVisible.ToString());

        }

    }
}
#endif
