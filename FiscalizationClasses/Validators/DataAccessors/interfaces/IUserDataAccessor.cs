using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces
{
    interface IUserDataAccessor
    {
        public UserRepository Users { get; }
    }
}
