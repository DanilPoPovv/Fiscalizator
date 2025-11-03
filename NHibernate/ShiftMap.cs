using Fiscalizator.FiscalizationClasses.Entities;
using FluentNHibernate.Mapping;

namespace Fiscalizator.NHibernate
{
    public class ShiftMap : ClassMap<Shift>
    {
        public ShiftMap() 
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
