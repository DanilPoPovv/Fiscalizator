
using Fiscalizator.FiscalizationClasses.Entities;
using NHibernate;
using ISession = NHibernate.ISession;

namespace Fiscalizator.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly ISession _session;
        private readonly ITransaction _transaction;

        public IRepository<Bill> Bills { get; }
        public IRepository<Commodity> Commodities { get; }
        public UnitOfWork(ISessionFactory sessionFactory)
        {
            _session = sessionFactory.OpenSession();
            _transaction = _session.BeginTransaction();
            Bills = new Repository<Bill>(_session);
            Commodities = new Repository<Commodity>(_session);
        }

        public void Commit()
        {
            _transaction.Commit();
        }
        public void Dispose()
        {
            if (_transaction.IsActive)
                _transaction.Rollback();
            _session.Dispose();
        }
    }
}
