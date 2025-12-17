using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.ClientCrudValidator
{
    public class ClientCreateUniqueValidator : IValidator<ClientDTO, ClientCrudDataAccesor, ClientValidationContext>
    {
        public void Validate(ClientDTO clientDto, ClientCrudDataAccesor validationData, ClientValidationContext validationContext)
        {
            Client client = validationData.Clients.GetByCode(clientDto.ClientCode);
            if (client != null)
            {
                throw new ClientException("A client with the same code already exists.");
            } 
        }
    }
}
