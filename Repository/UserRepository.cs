using Fiscalizator.FiscalizationClasses.Entities;
using ISession = NHibernate.ISession;
namespace Fiscalizator.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ISession session) : base(session) { }
        public User GetByUserName(string username)
        {
            return _session.Query<User>().FirstOrDefault(u => u.Username == username)!;
        }
        public bool ExistsInClient(string userName, int clientId)
        {
            return _session.Query<User>().Any(u => u.Username == userName && u.ClientId == clientId);
        }
        public User GetGlobalUserByName(string userName)
        {
            return _session.Query<User>().FirstOrDefault(u => u.Username == userName && u.ClientId == null)!;
        }
    }
}
