using Fiscalizator.FiscalizationClasses.Entities;
using FluentNHibernate.Mapping;

namespace Fiscalizator.NHibernate
{
    public class CounterMap : ClassMap<Counter>
    {
        public CounterMap()
        {
            Table("Counters");

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.CashValue).Not.Nullable();

            References(x => x.Kkm)
                .Column("KkmId")
                .Not.Nullable()
                .Unique();            
        }
    }
}
