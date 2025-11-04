using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Mappers
{
    public class ClientMapper
    {
        public Client Map(ClientDTO dto)
        {
            return new Client
            {
                Code = dto.Code,
                Name = dto.Name,
                Address = dto.Address
            };
        }
        public void Map(ClientDTO dto, Client existingClient)
        {
            existingClient.Code = dto.Code;
            existingClient.Name = dto.Name;
            existingClient.Address = dto.Address;
        }
    }
}
