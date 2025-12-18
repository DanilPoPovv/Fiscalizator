using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces
{
    public interface IKkmDataAccessor
    {
        public KkmRepository Kkms { get; }
    }
}
