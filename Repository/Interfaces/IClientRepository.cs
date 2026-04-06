using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Dto.Pagination;
using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Repository.Interfaces
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        void DeleteByCode(int code);
        List<Kkm> GetAllClientKkm(int ClientCode);
        Client GetByCode(int Code);
        Client GetByName(string name);
        PagedData<Client> Search(ClientFilterDTO filter);
    }
}