namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class CashOperation
    {
        public virtual int Id { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime OperationDateTime { get; set; } = DateTime.Now;
        public virtual CashOperationType OperationType { get; set; }
        public virtual Kkm Kkm { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual Cashier Cashier { get; set; }
    }
}
