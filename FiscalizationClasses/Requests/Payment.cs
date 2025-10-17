using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Requests
{
    public class Payment
    {
        [XmlElement("PaymentType")]
        public string PaymentType { get; set; }
        [XmlElement("Amount")]
        public decimal Amount { get; set; }

    }
}
