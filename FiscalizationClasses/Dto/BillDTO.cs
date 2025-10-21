using Fiscalizator.FiscalizationClasses.Entities;
using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Dto
{
    public class BillDTO
    {
        [XmlElement("Amount")]
        public decimal Amount { get; set; }
        [XmlElement("OperationDateTime")]
        public DateTime OperationDateTime { get; set; } = DateTime.Now;
        [XmlElement("Commodity")]
        public Commodity[] Commodity { get; set; }
        [XmlElement("Payment")]
        public Payment Payment { get; set; }
        [XmlElement("Cashier")]
        public Cashier Cashier { get; set; }
    }
}
