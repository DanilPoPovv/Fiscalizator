using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Requests
{
    public class Tax
    {
        [XmlElement("TaxType")]
        public string TaxType { get; set; }
        [XmlElement("Percent")]
        public int Percent { get; set; }
        [XmlElement("Sum")]
        public int Sum { get; set; }

    }
}
