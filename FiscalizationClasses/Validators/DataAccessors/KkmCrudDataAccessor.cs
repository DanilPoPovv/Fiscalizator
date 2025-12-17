using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.DataAccessors
{
    public class KkmCrudDataAccessor : IKkmDataAccessor
    {
        public KkmRepository Kkms { get; }
        public KkmCrudDataAccessor(ISession session)
        {
            Kkms = new KkmRepository(session);
        }
    }
}
