using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Repository.Interfaces
{
    public interface IShiftRepository : IBaseRepository<Shift>
    {
        void CloseShift(Shift shift);
        Shift GetLastKkmShift(int kkmId);
    }
}