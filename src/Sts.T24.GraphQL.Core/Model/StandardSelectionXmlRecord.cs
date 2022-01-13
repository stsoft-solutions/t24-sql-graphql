using System;
using System.Xml.Serialization;

namespace Sts.T24.GraphQL.Core.Model
{
    [Serializable]
    [XmlRoot("row")]
    public sealed class StandardSelectionXmlRecord : T24XmlRecord
    {
        [XmlElement(ElementName = "c1")]
        public T24XmlStringField[] Names { get; set; } = Array.Empty<T24XmlStringField>();

        [XmlElement(ElementName = "c2")]
        public T24XmlStringField[] DataFlags { get; set; } = Array.Empty<T24XmlStringField>();

        [XmlElement(ElementName = "c3")]
        public T24XmlStringField[] TagNumbers { get; set; } = Array.Empty<T24XmlStringField>();

        [XmlElement(ElementName = "c4")]
        public T24XmlStringField[] InputTypes { get; set; } = Array.Empty<T24XmlStringField>();

        [XmlElement(ElementName = "c10")]
        public T24XmlStringField[] MultiValueTypes { get; set; } = Array.Empty<T24XmlStringField>();
    }
}