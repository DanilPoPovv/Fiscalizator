using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Repository.Interfaces
{
    public interface IKkmRepository : IBaseRepository<Kkm>
    {
        Kkm GetBySerialNumber(int serialNumber);
    }
}