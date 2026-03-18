using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.Repository.Interfaces;
using NHibernate;
using ISession = NHibernate.ISession;

namespace Fiscalizator.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly ISession _session;
        private readonly ITransaction _transaction;
        public IKkmRepository kkmRepository {  get; }
        public IShiftRepository shiftRepository { get; }
        public ICashierRepository cashierRepository { get; }
        public IClientRepository clientRepository { get; }   
        public ICounterRepository counterRepository { get; }
        public ICashOperationRepository cashOperationRepository { get; }
        public IBaseRepository<Bill> Bills { get; }
        public IBaseRepository<Commodity> Commodities { get; }

        public UnitOfWork(ISession session)
        {
            _session = session;
            _transaction = _session.BeginTransaction();
            Bills = new BaseRepository<Bill>(_session);
            Commodities = new BaseRepository<Commodity>(_session);
            kkmRepository = new KkmRepository(_session);
            shiftRepository = new ShiftRepository(_session);
            cashierRepository = new CashierRepository(_session);
            clientRepository = new ClientRepository(_session);
            counterRepository = new CounterRepository(_session);
            cashOperationRepository = new CashOperationRepository(_session);
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
