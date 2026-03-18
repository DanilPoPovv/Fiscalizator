using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.Repository.Interfaces;
using ISession = NHibernate.ISession;
namespace Fiscalizator.Repository
{
    public class ShiftRepository : BaseRepository<Shift>, IShiftRepository
    {
        public ShiftRepository(ISession session) : base(session) { }
        ///TODO : По факту это просто апдейт, нужно убрать этот метод.
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
