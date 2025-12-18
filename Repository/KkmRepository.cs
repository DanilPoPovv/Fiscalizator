using Fiscalizator.FiscalizationClasses.Entities;
using ISession = NHibernate.ISession;
namespace Fiscalizator.Repository
{
    public class KkmRepository : Repository<Kkm>
    {
        public KkmRepository(ISession session) : base(session) { }

        public Kkm GetBySerialNumber(int serialNumber) 
        {
            return _session.Query<Kkm>().FirstOrDefault(k => k.SerialNumber == serialNumber)!;
        }
    }
}
