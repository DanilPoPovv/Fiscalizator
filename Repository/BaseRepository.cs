using Fiscalizator.Repository.Interfaces;
using ISession = NHibernate.ISession;
namespace Fiscalizator.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ISession _session;

        public BaseRepository(ISession session)
        {
            _session = session;
        }

        public void Add(T entity)
        {            
            _session.Save(entity);          
        }

        public void Update(T entity)
        {
            _session.Update(entity);          
        }

        public void Delete(T entity)
        {            
            _session.Delete(entity);
        }

        public T GetById(int id)
        {
            return _session.Get<T>(id);
        }

        public IQueryable<T> Query()
        {
            return _session.Query<T>();
        }
    }
}
