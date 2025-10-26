using FluentNHibernate.Mapping;
using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.NHibernate
{
    public class KkmMapper : ClassMap<Kkm>
    {
        public KkmMapper() 
        {
            Table("Kkm");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.SerialNumber).Not.Nullable().Unique();
            Map(x => x.Location).Nullable();

            HasMany(x => x.Shifts).KeyColumn("KkmId").Cascade.None().Inverse();
            HasMany(x => x.Bills).KeyColumn("KkmId").Cascade.None().Inverse();
        }
    }
}
