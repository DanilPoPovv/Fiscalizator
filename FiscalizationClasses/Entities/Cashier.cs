using System.Text.Json.Serialization;

namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class Cashier
    {
        [JsonIgnore]
        public virtual int Id{ get; set; }
        public virtual int SystemId { get; set; }
        public virtual string Name { get; set; }
        [JsonIgnore]
        public virtual IList<Bill> Bills { get; set; }
        public Cashier()
        {
            Bills = new List<Bill>();
        }
        [JsonIgnore]
        public virtual int ClientId { get; set; }
        [JsonIgnore]
        public virtual Client Client { get; set; }

    }
}
