using Fiscalizator.FiscalizationClasses.Entities;
using FluentNHibernate.Mapping;

namespace Fiscalizator.NHibernate
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Table("Clients");

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.ClientCode).Not.Nullable().Unique().Update();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Address).Nullable();

            HasMany(x => x.Kkms)
                .KeyColumn("Id")
                .Cascade.All()
                .Inverse();

            HasMany(x => x.Cashiers)
                .KeyColumn("Id")
                .Cascade.All()
                .Inverse();
        }
    }
}
