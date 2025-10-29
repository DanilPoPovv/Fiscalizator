using FluentNHibernate.Mapping;
using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.NHibernate
{
    public class BillMap : ClassMap<Bill>
    {
        public BillMap()
        {
            Table("Bills");

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Amount).Not.Nullable();
            Map(x => x.OperationDateTime).Not.Nullable();

            Component(x => x.Payment, m =>
            {
                m.Map(x => x.PaymentType);
            });

            HasMany(x => x.Commodities) 
                .KeyColumn("BillId")
                .Cascade.All()
                .Inverse();

            References(x => x.Cashier)
                .Column("CashierId")
                .Cascade.None()
                .Nullable();

            References(x => x.Kkm)
                .Column("KkmId")
                .Cascade.SaveUpdate()
                .Not.Nullable();

            References(x => x.Shift)
                .Column("ShiftId")
                .Cascade.SaveUpdate()
                .Not.Nullable();
        }
    }
}
