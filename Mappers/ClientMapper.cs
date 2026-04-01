using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Mappers
{
    public class ClientMapper
    {
        public Client Map(ClientDTO dto)
        {
            return new Client
            {
                ClientCode = dto.ClientCode,
                Name = dto.Name,
                Address = dto.Address
            };
        }
        public void Map(ClientDTO dto, Client existingClient)
        {
            existingClient.ClientCode = dto.ClientCode;
            existingClient.Name = dto.Name;
            existingClient.Address = dto.Address;
        }
    }
}
