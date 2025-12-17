using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.ClientCrudValidator
{
    public class ClientDeleteValidator : IValidator<ClientDeleteDTO, ClientCrudDataAccesor,ClientValidationContext>
    {
        public void Validate(ClientDeleteDTO clientDeleteDTO, ClientCrudDataAccesor validationData, ClientValidationContext validationContext)
        {
            Client client = validationData.Clients.GetByCode(clientDeleteDTO.ClientCode);
            if (client.Kkms.Count > 0)
            {
                throw new ClientException("Cannot delete client with associated KKMs.");
            }
            validationContext.Client = client;
        }
    }
}
