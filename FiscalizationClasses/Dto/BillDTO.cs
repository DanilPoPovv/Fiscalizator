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
        public CommodityDTO[] Commodity { get; set; }
        [XmlElement("Payment")]
        public PaymentDTO Payment { get; set; }
        [XmlElement("Cashier")]
        public CashierDTO Cashier { get; set; }
    }
}
