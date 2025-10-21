using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Entities
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
        public int Sum { get; set; }
        [XmlElement("Tax")]
        public Tax? Tax { get; set; }
        [XmlElement("MeasureUnit")]
        public string MeasureUnit { get; set; } = "ШТ";
    }
}
