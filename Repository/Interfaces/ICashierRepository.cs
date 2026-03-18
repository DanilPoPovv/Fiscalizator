using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Repository
{
    public interface ICashierRepository
    {
        IEnumerable<Cashier> GetAllClientCashier(int ClientCode);
        Cashier GetByName(string name);
    }
}