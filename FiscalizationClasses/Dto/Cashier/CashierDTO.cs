using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Dto.Cashier
{
    public class CashierDTO
    {
        [XmlElement("CashierId")]
        public int CashierSystemId { get; set; }
    }
}
