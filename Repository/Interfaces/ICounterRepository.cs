using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Repository
{
    public interface ICounterRepository
    {
        Counter GetByKkmId(int kkmId);
    }
}