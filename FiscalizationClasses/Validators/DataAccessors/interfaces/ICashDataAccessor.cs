using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces
{
    public interface ICashDataAccessor
    {
        public CashRepository Cash { get; }
        public Counter GetCounter(int kkmId);
    }
}
