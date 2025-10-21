using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class Cashier
    {
        [XmlElement("Name")]
        public string Name { get; set; }
    }
}
