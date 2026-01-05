using Fiscalizator.FiscalizationClasses.Entities;
using ISession = NHibernate.ISession;

namespace Fiscalizator.Repository
{
    public class CashOperationRepository : Repository<CashOperation>
    {
        public CashOperationRepository(ISession session) : base(session) { }
    }
}
