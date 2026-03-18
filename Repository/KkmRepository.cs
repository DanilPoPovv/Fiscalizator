using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.Repository.Interfaces;
using ISession = NHibernate.ISession;
namespace Fiscalizator.Repository
{
    public class KkmRepository : BaseRepository<Kkm>, IKkmRepository
    {
        public KkmRepository(ISession session) : base(session) { }

        public Kkm GetBySerialNumber(int serialNumber)
        {
            return _session.Query<Kkm>().FirstOrDefault(k => k.SerialNumber == serialNumber)!;
        }
    }
}
