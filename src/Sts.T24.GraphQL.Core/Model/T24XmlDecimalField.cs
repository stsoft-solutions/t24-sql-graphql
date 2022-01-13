using System.Diagnostics;
using System.Xml.Serialization;

namespace Sts.T24.GraphQL.Core.Model
{
    [DebuggerDisplay("{Value} (m:{MultiValueIndex}, s:{SubValueIndex})")]
    public sealed class T24XmlDecimalField 
    {
        [XmlText]
        public decimal Value { get; set; }

        [XmlAttribute("m")]
        public int MultiValueIndex { get; set; } = 1;

        [XmlAttribute("s")]
        public int SubValueIndex { get; set; } = 1;
    }
}