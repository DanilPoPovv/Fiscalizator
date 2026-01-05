using Fiscalizator.FiscalizationClasses.Entities;
using ISession = NHibernate.ISession;

namespace Fiscalizator.Repository
{
    public class CashRepository : Repository<Counter>
    {
        public CashRepository(ISession session) : base(session) { }
        public Counter GetByKkmId(int kkmId)
        {
            return _session.Query<Counter>().FirstOrDefault(c => c.Kkm.Id == kkmId)!;
        }
    }
}
