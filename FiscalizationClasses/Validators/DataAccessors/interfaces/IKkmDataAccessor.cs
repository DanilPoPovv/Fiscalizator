using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces
{
    public interface IKkmDataAccessor
    {
        KkmRepository Kkms { get; }
    }
}
