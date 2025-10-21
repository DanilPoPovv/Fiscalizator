using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Dto
{
    public class PaymentDTO
    {
        [XmlElement("PaymentType")]
        public string PaymentType { get; set; }
        [XmlElement("Amount")]
        public decimal Amount { get; set; }

    }
}
