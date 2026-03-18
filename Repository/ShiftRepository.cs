using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.Repository.Interfaces;
using ISession = NHibernate.ISession;
namespace Fiscalizator.Repository
{
    public class ShiftRepository : BaseRepository<Shift>, IShiftRepository
    {
        public ShiftRepository(ISession session) : base(session) { }

        public Shift GetLastKkmShift(int kkmId)
        {
            return _session.Query<Shift>()
            .Where(s => s.Kkm.Id == kkmId)
            .OrderByDescending(x => x.ClosureDateTime)
            .FirstOrDefault()!;
        }
    }
}
