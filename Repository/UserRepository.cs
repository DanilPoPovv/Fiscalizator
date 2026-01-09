using Fiscalizator.FiscalizationClasses.Entities;
using ISession = NHibernate.ISession;
namespace Fiscalizator.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ISession session) : base(session) { }
        public User GetByLogin(string username)
        {
            return _session.Query<User>().FirstOrDefault(u => u.Username == username)!;
        }
    }
}
