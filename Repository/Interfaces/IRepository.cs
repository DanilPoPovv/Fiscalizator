namespace Fiscalizator.Repository
{
    public interface IRepository<T> where T : class 
    {
        public void Add(T entity);
        public T GetById(int id);
        public void Delete(T entity);
        public void Update(T entity);
    }
}
