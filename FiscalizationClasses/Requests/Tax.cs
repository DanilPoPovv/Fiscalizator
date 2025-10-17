using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Requests
{
    public class Tax
    {
        [XmlElement("TaxType")]
        public string TaxType { get; set; }
        [XmlElement("Percent")]
        public decimal Percent { get; set; }
        [XmlElement("Sum")]
        public decimal Sum { get; set; }

    }
}
