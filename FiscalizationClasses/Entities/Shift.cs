namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class Shift
    {
        public virtual int Id { get; set; }
        public virtual DateTime OpeningDateTime { get; set; } 
        public virtual DateTime LastOperationDateTime { get; set; }
        public virtual DateTime? ClosureDateTime { get; set; }
        public virtual int ShiftNumber { get; set; }
        public virtual Kkm Kkm { get; set; }
        public virtual IList<Bill> Bills { get; set; } = new List<Bill>();
    }
}
