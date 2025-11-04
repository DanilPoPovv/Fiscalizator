using FluentNHibernate.Mapping;
using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.NHibernate
{
    public class KkmMap : ClassMap<Kkm>
    {
        public KkmMap() 
        {
            Table("Kkm");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.SerialNumber).Not.Nullable().Unique().Insert().Not.Update();
            Map(x => x.Location).Nullable();

            HasMany(x => x.Shifts).KeyColumn("KkmId").Cascade.None().Inverse();
            HasMany(x => x.Bills).KeyColumn("KkmId").Cascade.None().Inverse();

            References(x => x.Client)
                .Column("ClientId")
                .Not.Nullable();
        }
    }
}
