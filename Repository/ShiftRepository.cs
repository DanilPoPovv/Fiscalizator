using Fiscalizator.FiscalizationClasses.Entities;
using NHibernate.Linq;
using ISession = NHibernate.ISession;
namespace Fiscalizator.Repository
{
    public class ShiftRepository : Repository<Shift>
    {
        public ShiftRepository(ISession session) : base(session){ }

        public void CloseShift(Shift shift)
        {
            _session.Update(shift);
        }
        public Shift GetLastKkmShift(int kkmId)
        {
            return _session.Query<Shift>()
            .Where(s => s.Kkm.Id == kkmId)
            .OrderByDescending(x => x.ClosureDateTime)
            .FirstOrDefault()!;  

        }
        }
    }
