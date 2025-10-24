namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class Shift
    {
        public virtual int Id { get; set; }
        public virtual DateTime OpeningDateTime { get; set; } 
        public virtual DateTime? ClosureDateTime { get; set; }
        public virtual int ShiftNumber { get; set; }
        public virtual Kkm kkm { get; set; }
        public virtual IList<Bill> bills { get; set; } = new List<Bill>();
    }
}
