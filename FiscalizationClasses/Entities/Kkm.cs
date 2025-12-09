using System.Text.Json.Serialization;

namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class Kkm
    {
        public virtual int Id { get; set; }
        public virtual int SerialNumber { get; set; }
        public virtual string? Location { get; set; }
        [JsonIgnore]
        public virtual IList<Shift> Shifts { get; set; } = new List<Shift>();
        [JsonIgnore]
        public virtual IList<Bill> Bills { get; set; } = new List<Bill>();
        [JsonIgnore]
        public virtual Client Client { get; set; }
    }
}
