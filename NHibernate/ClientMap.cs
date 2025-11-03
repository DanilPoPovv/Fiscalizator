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
            Map(x => x.Code).Not.Nullable().Unique();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Address).Nullable();

            HasMany(x => x.Kkms)
                .KeyColumn("ClientId")
                .Cascade.All()
                .Inverse();
        }
    }
}
