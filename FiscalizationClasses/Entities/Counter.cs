namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class Counter 
    {
        public virtual int Id { get; set; }
        public virtual decimal CashValue { get; set; }
        public virtual Kkm Kkm { get; set; }
        public Counter(Kkm kkm)
        {
            Kkm = kkm;
            CashValue = 0m;
        }
        public Counter()
        {
        }
    }
}
