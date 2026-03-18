using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.Repository.Interfaces;
using ISession = NHibernate.ISession;

namespace Fiscalizator.Repository
{
    public class BillRepository : BaseRepository<Bill>,IBillRepository
    {
        public BillRepository(ISession session) : base(session) { }
    }
}
