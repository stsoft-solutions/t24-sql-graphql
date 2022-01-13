using System.Diagnostics;
using System.Xml.Serialization;

namespace Sts.T24.GraphQL.Core.Model
{
    //[DebuggerDisplay("{Value} (m:{MultiValueIndex}, s:{SubValueIndex})")]
    //public sealed class T24XmlStringField : T24XmlGenericField<string>
    //{
    //    [XmlText]
    //    public string RawValue { get; set; } = string.Empty;

    //    #region Overrides of T24XmlGenericField<string>

    //    /// <inheritdoc />
    //    public override string Value => RawValue;

    //    #endregion

    //    #region Overrides of T24XmlGenericField

    //    /// <inheritdoc />
    //    [XmlAttribute("m")]
    //    public override int MultiValueIndex { get; set; } = 1;

    //    /// <inheritdoc />
    //    [XmlAttribute("s")]
    //    public override int SubValueIndex { get; set; } = 1;

    //    #endregion
    //}

    [DebuggerDisplay("{Value} (m:{MultiValueIndex}, s:{SubValueIndex})")]
    public sealed class T24XmlStringField
    {
        [XmlText]
        public string Value { get; set; } = string.Empty;

        [XmlAttribute("m")]
        public int MultiValueIndex { get; set; } = 1;

        [XmlAttribute("s")]
        public int SubValueIndex { get; set; } = 1;
    }
}