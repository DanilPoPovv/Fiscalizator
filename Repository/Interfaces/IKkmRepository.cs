using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Repository
{
    public interface IKkmRepository
    {
        Kkm GetBySerialNumber(int serialNumber);
    }
}