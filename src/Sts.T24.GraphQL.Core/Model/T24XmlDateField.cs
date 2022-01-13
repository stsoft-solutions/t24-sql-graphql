using System;
using System.Diagnostics;
using System.Globalization;

namespace Sts.T24.GraphQL.Core.Model
{
    [DebuggerDisplay("{Value} (m:{MultiValueIndex}, s:{SubValueIndex})")]
    public sealed class T24XmlDateField : T24XmlGenericField<string, DateTime>
    {
        public static T24XmlDateField Empty { get; } = new T24XmlDateField {RawData = DateTime.MinValue.ToString("yyyyMMdd"), IsValueExist = false};

        #region Overrides of T24XmlGenericField<string,DateTime>

        /// <inheritdoc />
        protected override DateTime ParseRawValue(string rawData)
        {
            return DateTime.ParseExact(rawData, "yyyyMMdd", CultureInfo.InvariantCulture);
        }

        #endregion
    }
}