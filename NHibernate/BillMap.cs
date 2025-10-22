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

            // Название коллекции должно совпадать с тем, что в сущности Bill
            HasMany(x => x.Commodities) // предполагаю, что в Bill: public virtual IList<Commodity> Commodities { get; set; }
                .KeyColumn("BillId")
                .Cascade.All()
                .Inverse();

            References(x => x.Cashier)
                .Column("CashierId")
                .Nullable();
        }
    }
}
