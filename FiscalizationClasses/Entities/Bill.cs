using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class Bill
    {
        public decimal Amount { get; set; }
        public DateTime OperationDateTime { get; set; } = DateTime.Now;
        public Commodity[] Commodity { get; set; }
        public Payment Payment { get; set; }
        public Cashier Cashier { get; set; }
    }
}
