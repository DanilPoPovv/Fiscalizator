using Fiscalizator.FiscalizationClasses.Entities;
using FluentNHibernate.Mapping;

namespace Fiscalizator.NHibernate
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Username).Not.Nullable().Length(50);
            Map(x => x.Role).CustomType<UserRole>().Not.Nullable();
            Map(x => x.PasswordHash).Not.Nullable();
            Map(x => x.ClientId).Nullable();
        }
    }
}
