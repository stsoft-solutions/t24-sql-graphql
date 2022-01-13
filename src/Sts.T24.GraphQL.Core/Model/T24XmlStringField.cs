using System.Diagnostics;

namespace Sts.T24.GraphQL.Core.Model
{
    [DebuggerDisplay("{Value} (m:{MultiValueIndex}, s:{SubValueIndex})")]
    public sealed class T24XmlStringField : T24XmlGenericField<string, string>
    {
    }
}