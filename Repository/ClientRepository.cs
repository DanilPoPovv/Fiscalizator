using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.Repository.Interfaces;
using NHibernate.Linq;
using ISession = NHibernate.ISession;
namespace Fiscalizator.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(ISession session) : base(session) { }

        public Client GetByCode(int Code)
        {
            return _session.Query<Client>().FirstOrDefault(c => c.ClientCode == Code)!;
        }
        public Client GetByName(string name)
        {
            return _session.Query<Client>().FirstOrDefault(c => c.Name == name)!;
        }
        public void DeleteByCode(int code)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var client = _session.Query<Client>().FirstOrDefault(c => c.ClientCode == code);
                if (client != null)
                {
                    _session.Delete(client);
                    transaction.Commit();
                }
            }
        }
        public List<Kkm> GetAllClientKkm(int ClientCode)
        {
            return _session.Query<Client>().Where(c => c.ClientCode == ClientCode)
                .SelectMany(c => c.Kkms)
                .ToList();
        }
        public List<Client> GetAll()
        {
            return _session.Query<Client>().ToList();
        }
    }
}
