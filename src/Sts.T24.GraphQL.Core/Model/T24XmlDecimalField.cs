using System;
using System.Diagnostics;

namespace Sts.T24.GraphQL.Core.Model
{
    [DebuggerDisplay("{Value} (m:{MultiValueIndex}, s:{SubValueIndex})")]
    [Serializable]
    public sealed class T24XmlDecimalField : T24XmlGenericField<decimal, decimal>
    {
        public static T24XmlDecimalField Empty { get; } = new T24XmlDecimalField {IsValueExist = false};
    }
}