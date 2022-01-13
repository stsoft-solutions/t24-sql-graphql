using System;
using System.Xml.Serialization;
using Sts.T24.GraphQL.Core.Model;

namespace Sts.T24.GraphQL.Core.Tests.XmlDeserialization;

/// <summary>
/// Fake class for testing
/// </summary>
[Serializable]
[XmlRoot("row")]
public class DbiFakeXmlRecord : T24XmlRecord
{
    [XmlElement(ElementName = "c1")]
    public T24XmlStringField Status { get; set; } = T24XmlField.Empty<T24XmlStringField>();

    [XmlElement(ElementName = "c8")]
    public T24XmlDecimalField Rate { get; set; } = T24XmlField.Empty<T24XmlDecimalField>();

    [XmlElement(ElementName = "c10")]
    public T24XmlDateField ValueDate { get; set; } = T24XmlField.Empty<T24XmlDateField>();

    [XmlElement(ElementName = "c13")]
    public T24XmlDecimalField[] PyiAmount { get; set; } = Array.Empty<T24XmlDecimalField>();

    [XmlElement(ElementName = "c999")]
    public T24XmlDateField UnExistingDateField { get; set; } = T24XmlField.Empty<T24XmlDateField>();
}