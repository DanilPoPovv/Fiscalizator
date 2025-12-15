using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;
using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Dto
{
    public class BillDTO : ICashierNameRequire, ISerialNumberRequire, IOpenShiftRequire 
    {
        private DateTime _operationDateTime;
        [XmlElement("Amount")]
        public decimal Amount { get; set; }
        [XmlElement("OperationDateTime")]
        public DateTime OperationDateTime { get; set; }
        [XmlElement("SerialNumber")]
        public int SerialNumber { get; set; }
        [XmlElement("Commodity")]
        public CommodityDTO[] Commodity { get; set; }
        [XmlElement("Payment")]
        public PaymentDTO Payment { get; set; }
        [XmlElement("CashierName")]
        public string CashierName { get; set; }

    }
}
