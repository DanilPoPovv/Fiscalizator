using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.DataAccessors
{
    public class ClientCrudDataAccesor : IClientDataAccessor
    {
        public ClientRepository Clients { get; }

        public ClientCrudDataAccesor(ISession session)
        {
            Clients = new ClientRepository(session);
        }
    }
}
