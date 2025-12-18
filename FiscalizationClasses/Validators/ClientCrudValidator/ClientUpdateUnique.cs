using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.ClientCrudValidator
{
    public class ClientUpdateUnique : IValidator<ClientChangeDTO, ClientCrudDataAccesor, ClientValidationContext>
    {
        public void Validate(ClientChangeDTO clientDto, ClientCrudDataAccesor validationData, ClientValidationContext validationContext)
        {
            if (validationData.Clients.GetByCode(clientDto.NewCode) != null)
            {
                throw new ClientException("A client with the same code already exists.");
            }

        }
    }
}
