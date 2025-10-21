
using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime OperationDateTime { get; set; } = DateTime.Now;
        public virtual Commodity[] Commodity { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Cashier Cashier { get; set; }
    }
}
