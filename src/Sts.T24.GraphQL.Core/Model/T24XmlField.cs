using System;
using System.Collections.Concurrent;
using System.Xml.Serialization;

namespace Sts.T24.GraphQL.Core.Model
{
    /// <summary>
    /// Base T24Xml field
    /// </summary>
    [Serializable]
    public abstract class T24XmlField
    {
        #region Fields

        private static readonly ConcurrentDictionary<Type, T24XmlField> EmptyFields = new ConcurrentDictionary<Type, T24XmlField>();

        #endregion

        /// <summary>
        /// Is value exist in the source xml
        /// </summary>
        [XmlIgnore]
        public bool IsValueExist { get; protected set; } = true;

        /// <summary>
        /// Multi-value index of the field
        /// </summary>
        [XmlAttribute("m")]
        public int MultiValueIndex { get; set; } = 1;

        /// <summary>
        /// Sub-value index of the field
        /// </summary>
        [XmlAttribute("s")]
        public int SubValueIndex { get; set; } = 1;

        /// <summary>
        /// Create an empty field
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Empty<T>() where T : T24XmlField, new()
        {
            return (T) EmptyFields.GetOrAdd(typeof(T), type => new T {IsValueExist = false});
        }
    }
}