using Fiscalizator.FiscalizationClasses.Entities;
using FluentNHibernate.Mapping;

namespace Fiscalizator.NHibernate
{
    public class CashOperationMap : ClassMap<CashOperation>
    {
        public CashOperationMap()
        {
            Table("ServiceOperations");

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Amount).Not.Nullable();
            Map(x => x.OperationDateTime).Not.Nullable();
            Map(x => x.OperationType).CustomType<int>().Not.Nullable();

            References(x => x.Cashier)
                .Column("CashierId")
                .Cascade.None()
                .Not.Nullable();
            References(x => x.Kkm).
                Column("KkmId")
                .Cascade.None()
                .Not.Nullable();
            References(x => x.Shift)
                .Column("ShiftId")
                .Cascade.None()
                .Not.Nullable();
        }
    }
}
