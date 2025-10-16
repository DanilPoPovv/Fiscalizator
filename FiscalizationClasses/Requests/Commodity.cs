using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Requests
{
    public class Commodity
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Price")]
        public int Price { get; set; }
        [XmlElement("Quantity")]
        public int Quantity { get; set; }
        [XmlElement("Sum")]
        public int CommoditySum { get; set; }
    }
}
