using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Dto.Bill
{
    public class TaxDTO
    {
        [XmlElement("TaxType")]
        public string TaxType { get; set; }
        [XmlElement("Percent")]
        public decimal Percent { get; set; }
        [XmlElement("Sum")]
        public decimal Sum { get; set; }

    }
}
