using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Repository.Interfaces
{
    public interface ICounterRepository : IBaseRepository<Counter>
    {
        Counter GetByKkmId(int kkmId);
    }
}