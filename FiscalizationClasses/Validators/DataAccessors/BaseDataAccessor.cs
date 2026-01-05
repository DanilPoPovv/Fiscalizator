using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.DataAccessors
{
    public class BaseOperationDataAccessor : ICashierDataAccessor, IKkmDataAccessor, IShiftDataAccessor, ICashDataAccessor
    {
        public KkmRepository Kkms { get; }
        public ShiftRepository Shifts { get; }
        public CashierRepository Cashiers { get; }
        public CashRepository Cash { get; }

        public BaseOperationDataAccessor(ISession session)
        {
            Kkms = new KkmRepository(session);
            Shifts = new ShiftRepository(session);
            Cashiers = new CashierRepository(session);
            Cash = new CashRepository(session); 
        }
        public Counter GetCounter(int kkmId)
        {
            return Cash.GetByKkmId(kkmId);
        }
    }
}
