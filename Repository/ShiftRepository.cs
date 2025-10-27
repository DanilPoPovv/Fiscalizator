using Fiscalizator.FiscalizationClasses.Entities;
using ISession = NHibernate.ISession;
namespace Fiscalizator.Repository
{
    public class ShiftRepository : Repository<Shift>
    {
        public ShiftRepository(ISession session) : base(session){ }

        public Shift GetCurrentKkmShift(Kkm kkm)
        {
            return _session.Query<Shift>().FirstOrDefault(s => s.Kkm.Id == kkm.Id && s.ClosureDateTime == null);
        }
    }
}
