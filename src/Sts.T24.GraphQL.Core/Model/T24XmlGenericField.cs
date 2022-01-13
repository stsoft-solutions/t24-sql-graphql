using System;
using System.Xml.Serialization;

namespace Sts.T24.GraphQL.Core.Model
{
    [Serializable]
    public abstract class T24XmlGenericField<TRawData, TData> : T24XmlField
    {
        #region Fields

        private TRawData _rawData;

        #endregion

        [XmlText]
        public TRawData RawData
        {
            get => _rawData;
            set
            {
                _rawData = value;
                if (value is TData data) Value = data;
                else
                    Value = ParseRawValue(value);
            }
        }

        [XmlIgnore]
        public TData Value { get; private set; }

        protected virtual TData ParseRawValue(TRawData rawData)
        {
            throw new InvalidCastException(
                $"{nameof(ParseRawValue)} must be implemented for raw type {typeof(TRawData).Name} and data type {typeof(TData).Name}");
        }
    }
}