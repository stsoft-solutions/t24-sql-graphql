using System;
using System.Diagnostics;
using System.Globalization;

namespace Sts.T24.GraphQL.Core.Model
{
    [DebuggerDisplay("{Value} (m:{MultiValueIndex}, s:{SubValueIndex})")]
    public sealed class T24XmlDateField : T24XmlGenericField<string, DateTime>
    {
        #region Overrides of T24XmlGenericField<string,DateTime>

        /// <inheritdoc />
        protected override DateTime ParseRawValue(string rawData)
        {
            return DateTime.ParseExact(rawData, "yyyyMMdd", CultureInfo.InvariantCulture);
        }

        #endregion
    }
}