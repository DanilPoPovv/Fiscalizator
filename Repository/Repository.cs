using ISession = NHibernate.ISession;
namespace Fiscalizator.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ISession _session;
        public Repository(ISession session)
        {
            _session = session;
        }
        public void Add(T entity)
        {
            _session.Save(entity);
        }
        public void Delete(T entity)
        {
            _session.Delete(entity);
        }
        public void Update(T entity)
        {
             _session.Update(entity);
        }
            public T GetById(int id)
        {
            return _session.Get<T>(id);
        }
    }
}
