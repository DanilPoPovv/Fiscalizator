using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.DataAccessors
{
    public class CashierCrudDataAccessor : ICashierDataAccessor, IClientDataAccessor
    {
        public ClientRepository Clients{ get; }
        public CashierRepository Cashiers { get; }

        public CashierCrudDataAccessor(ISession session)
        {
            Clients = new ClientRepository(session);
            Cashiers = new CashierRepository(session);
        }
    }
}
