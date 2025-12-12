using Fiscalizator.FiscalizationClasses.Entities;
using FluentNHibernate.Mapping;

namespace Fiscalizator.NHibernate
{
    public class CashierMap : ClassMap<Cashier>
    {
        public CashierMap()
        {
            Table("Cashiers");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            References(x => x.Client).Column("ClientId").Cascade.None().Not.Nullable();

            HasMany(x => x.Bills).KeyColumn("CashierId").Cascade.None().Inverse();
        }
    }
}
