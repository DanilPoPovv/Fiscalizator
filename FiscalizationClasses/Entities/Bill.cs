
using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class Bill
    {
        public virtual int Id { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime OperationDateTime { get; set; } = DateTime.Now;
        public virtual IList<Commodity> Commodities { get; set; } = new List<Commodity>();
        public virtual Kkm Kkm { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Cashier Cashier { get; set; }
    }
}
