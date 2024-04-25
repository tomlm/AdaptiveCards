// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if !NETSTANDARD1_3
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdaptiveCards.Xml
{
    public static class SerializerExtensions
    {
        public static T GetAttribute<T>(this XmlReader reader, string attributeName)
        {
            var value = reader.GetAttribute(attributeName);
            var underlyingType = Nullable.GetUnderlyingType(typeof(T));

            if (string.IsNullOrEmpty(value))
                return default(T);

            if (underlyingType != null)
            {
                return (T)Convert(value, underlyingType);
            }

            return (T)Convert(value, typeof(T));
        }

        private static object Convert(string value, Type type)
        {
            if (type == typeof(Uri))
                return new Uri(value);

            if (type.IsEnum)
            {
                return Enum.Parse(type, value);
            }
            return System.Convert.ChangeType(value, type);
        }
    }
}
#endif
