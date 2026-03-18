using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Repository.Interfaces
{
    public interface IShiftRepository : IBaseRepository<Shift>
    {
        Shift GetLastKkmShift(int kkmId);
    }
}