
using Fiscalizator.FiscalizationClasses.Entities;
using NHibernate;
using ISession = NHibernate.ISession;

namespace Fiscalizator.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly ISession _session;
        private readonly ITransaction _transaction;
        public KkmRepository kkmRepository {  get; }
        public ShiftRepository shiftRepository { get; }
        public CashierRepository cashierRepository { get; }
        public ClientRepository clientRepository { get; }   
        public IRepository<Bill> Bills { get; }
        public IRepository<Commodity> Commodities { get; }

        public UnitOfWork(ISession session)
        {
            _session = session;
            _transaction = _session.BeginTransaction();
            Bills = new Repository<Bill>(_session);
            Commodities = new Repository<Commodity>(_session);
            kkmRepository = new KkmRepository(_session);
            shiftRepository = new ShiftRepository(_session);
            cashierRepository = new CashierRepository(_session);
            clientRepository = new ClientRepository(_session);
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
