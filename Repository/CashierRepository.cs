using Fiscalizator.FiscalizationClasses.Entities;
using ISession = NHibernate.ISession;
namespace Fiscalizator.Repository
{
    public class CashierRepository : Repository<Cashier>
    {
        public CashierRepository(ISession session) : base(session) { }

        public Cashier GetByName(string name)
        {
            return _session.Query<Cashier>().FirstOrDefault(c => c.Name == name);
        }
        public IEnumerable<Cashier> GetAllClientCashier(int ClientCode)
        {
            return _session.Query<Cashier>().Where(c => c.Client.Code == ClientCode).ToList();
        }
    }
}
