using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces
{
    public interface IClientDataAccessor
    {
        ClientRepository Clients { get; }
    }
}
