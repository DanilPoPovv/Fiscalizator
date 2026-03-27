using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.ClientCrudValidator
{
    public class ClientCreateUniqueValidator : IValidator<ClientDTO, IClientDataAccessor, ClientValidationContext>
    {
        public void Validate(ClientDTO clientDto, IClientDataAccessor validationData, ClientValidationContext validationContext)
        {
            Client client = validationData.Clients.GetByCode(clientDto.ClientCode);
            if (client != null)
            {
                throw new ClientException("A client with the same code already exists.");
            } 
        }
    }
}
