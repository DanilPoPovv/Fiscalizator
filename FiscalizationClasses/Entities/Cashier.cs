using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class Cashier
    {
        public virtual int Id{ get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Bill> Bills { get; set; }
        public Cashier()
        {
            Bills = new List<Bill>();
        }
        public virtual int ClientId { get; set; }
        public virtual Client Client { get; set; }

    }
}
