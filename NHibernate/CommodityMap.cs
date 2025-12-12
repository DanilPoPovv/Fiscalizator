using FluentNHibernate.Mapping;
using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.NHibernate
{
    public class CommodityMap : ClassMap<Commodity>
    {
        public CommodityMap()
        {
            Table("Commodities"); 

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Price).Not.Nullable();
            Map(x => x.Quantity).Not.Nullable();
            Map(x => x.Sum).Not.Nullable();

            Component(x => x.Tax, m =>
            {
                m.Map(x => x.TaxType).Nullable();
                m.Map(x => x.TaxPercent).Nullable();
                m.Map(x => x.TaxSum).Nullable();
            });

            Map(x => x.MeasureUnit).Not.Nullable().Default("'ШТ'");

            References(x => x.Bill)
                .Column("BillId")
                .Not.Nullable()
                .Cascade.None();
        }
    }
}
