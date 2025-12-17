using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces
{
    public interface IShiftDataAccessor
    {
        ShiftRepository Shifts { get; }
    }
}
