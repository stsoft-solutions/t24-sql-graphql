using System;
using System.Xml.Serialization;

namespace Sts.T24.GraphQL.Core.Model
{
    [Serializable]
    public abstract class T24XmlRecord
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}