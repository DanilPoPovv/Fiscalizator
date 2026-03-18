using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Repository
{
    public interface IShiftRepository
    {
        void CloseShift(Shift shift);
        Shift GetLastKkmShift(int kkmId);
    }
}