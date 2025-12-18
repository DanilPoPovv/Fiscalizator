using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces
{
    public interface IShiftDataAccessor
    {
        public ShiftRepository Shifts { get; }
    }
}
