using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Repository.Interfaces
{
    public interface ICashierRepository : IBaseRepository<Cashier>
    {
        IEnumerable<Cashier> GetAllClientCashier(int ClientCode);
        Cashier GetByName(string name);
    }
}