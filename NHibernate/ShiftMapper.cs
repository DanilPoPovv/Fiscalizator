using Fiscalizator.FiscalizationClasses.Entities;
using FluentNHibernate.Mapping;

namespace Fiscalizator.NHibernate
{
    public class ShiftMapper : ClassMap<Shift>
    {
        public ShiftMapper() 
        { 
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.OpeningDateTime).Not.Nullable();
            Map(x => x.ClosureDateTime).Nullable();
            Map(x => x.ShiftNumber).Not.Nullable();

            References(x => x.Kkm)
                .Column("KkmId")
                .Not.Nullable();
            HasMany(x => x.Bills)
                .KeyColumn("ShiftId")
                .Not.KeyNullable().Inverse();
        }
    }
}
