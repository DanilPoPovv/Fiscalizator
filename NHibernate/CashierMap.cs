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
            Map(x => x.SystemId).Not.Nullable().UniqueKey("UQ_Cashier_Client_SystemId");
            References(x => x.Client).Column("ClientId").Cascade.None().Not.Nullable().UniqueKey("UQ_Cashier_Client_SystemId");

            HasMany(x => x.Bills).KeyColumn("CashierId").Cascade.None().Inverse();
        }
    }
}
