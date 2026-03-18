using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Repository
{
    public interface IClientRepository
    {
        void DeleteByCode(int code);
        List<Client> GetAll();
        List<Kkm> GetAllClientKkm(int ClientCode);
        Client GetByCode(int Code);
        Client GetByName(string name);
    }
}