using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.ClientCrudValidator
{
    public class ClientUpdateUnique : IValidator<ClientChangeDTO, IClientDataAccessor, ClientValidationContext>
    {
        public void Validate(ClientChangeDTO clientDto, IClientDataAccessor validationData, ClientValidationContext validationContext)
        {
            if (validationData.Clients.GetByCode(clientDto.Code) != null)
            {
                throw new ClientException("A client with the same code already exists.");
            }

        }
    }
}
