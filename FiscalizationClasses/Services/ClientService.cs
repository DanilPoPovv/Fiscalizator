using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.Mappers;
using Fiscalizator.Repository;
using FluentNHibernate.Data;

namespace Fiscalizator.FiscalizationClasses.Services
{
    public class ClientService 
    {
        private readonly ClientRepository _clientRepository;
        private readonly ClientMapper _clientMapper = new ClientMapper();
        public ClientService()
        {
            _clientRepository = new ClientRepository(NHibernateHelper.OpenSession());
        }
        public Client GetClientByName(string name)
        {
            return _clientRepository.GetByName(name);
        }
        public void AddClient(ClientDTO clientDTO)
        {
            Client client = MapToModel(clientDTO);
            _clientRepository.Add(client);
        }
        public void DeleteClient(int code)
        {
            _clientRepository.DeleteByCode(code);
        }
        public void UpdateClient(ClientChangeDTO dto)
        {
            UnitOfWork uow = new UnitOfWork(NHibernateHelper.OpenSession());
            Client client = uow.clientRepository.GetByCode(dto.OldCode);
            client.Address = dto.Address;
            client.Name = dto.Name;
            client.Code = dto.Code;
            uow.clientRepository.Update(client);
            uow.Commit();
        }
        private Client MapToModel(ClientDTO clientDTO)
        {
            return _clientMapper.Map(clientDTO);
        }
        public List<Client> GetAllClients()
        {

            return _clientRepository.GetAll();
        }
    }
}
