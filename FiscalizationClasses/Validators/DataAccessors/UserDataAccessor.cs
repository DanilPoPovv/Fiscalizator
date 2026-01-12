using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.DataAccessors
{
    public class UserDataAccessor : IUserDataAccessor, IClientDataAccessor
    {
        public UserDataAccessor(ISession session)
        {
            Users = new UserRepository(session);
            Clients = new ClientRepository(session);
        }

        public UserRepository Users { get; }
        public ClientRepository Clients { get; }
    }
}
