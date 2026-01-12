using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces;
using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalClientValidator<TData,TContext> : IGlobalValidator<TData, TContext> where TData : IClientDataAccessor
        where TContext : IValidationContext 
    {
        public void Validate(object request, TData validationData, TContext validationContext)
        {
            if (request is not IClientCodeRequire clientRequest)
                return;
            Client client = validationData.Clients.GetByCode(clientRequest.ClientCode);
            if (client == null)
            {
                throw new ClientException("Client with the specified code does not exist.");
            }
            if (validationContext is IClientValidationContextRequire validationContextClient)
                validationContextClient.Client = client;
        }
    }
}
