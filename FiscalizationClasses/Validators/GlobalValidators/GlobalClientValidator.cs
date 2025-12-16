using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalClientValidator : IGlobalValidator<ClientValidationContext>
    {
        public void Validate(object request, ISession session, ClientValidationContext validationContext)
        {
            if (request is not IClientCodeRequire clientRequest)
                return;
            ClientRepository clientRepository = new ClientRepository(session);
            Client client = clientRepository.GetByCode(clientRequest.ClientCode);
            if (client == null)
            {
                throw new ClientException("Client with the specified code does not exist.");
            }
        }
    }
}
