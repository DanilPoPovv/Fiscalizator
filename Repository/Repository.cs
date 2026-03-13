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
            using var transaction = _session.BeginTransaction();
            _session.Save(entity);
            transaction.Commit();
        }

        public void Update(T entity)
        {
            using var transaction = _session.BeginTransaction();
            _session.Update(entity);
            transaction.Commit();
        }

        public void Delete(T entity)
        {
            using var transaction = _session.BeginTransaction();
            _session.Delete(entity);
            transaction.Commit();
        }

        public T GetById(int id)
        {
            return _session.Get<T>(id);
        }
    }
}
