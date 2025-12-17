using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalClientValidator : IGlobalValidator<ClientValidationContext, IClientDataAccessor>
    {
        public void Validate(object request, IClientDataAccessor validationData, ClientValidationContext validationContext)
        {
            if (request is not IClientCodeRequire clientRequest)
                return;
            Client client = validationData.Clients.GetByCode(clientRequest.ClientCode);
            if (client == null)
            {
                throw new ClientException("Client with the specified code does not exist.");
            }
            validationContext.Client = client;
        }
    }
}
