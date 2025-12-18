using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces
{
    public interface IClientDataAccessor
    {
        public ClientRepository Clients { get; }
    }
}
