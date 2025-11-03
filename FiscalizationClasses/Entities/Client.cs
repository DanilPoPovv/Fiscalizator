namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class Client
    {
        public virtual int Id { get; set; }
        public virtual int Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual IList<Kkm> Kkms { get; set; }
    }
}
