using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces
{
    public interface ICashierDataAccessor
    {
        public CashierRepository Cashiers { get; }
    }
}
