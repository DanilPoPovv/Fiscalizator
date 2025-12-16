using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.ClientCrudValidator
{
    public class ClientDeleteValidator : IValidator<ClientDeleteDTO,ClientValidationContext>
    {
        public void Validate(ClientDeleteDTO clientDeleteDTO, ISession session, ClientValidationContext validationContext)
        {
            ClientRepository clientRepository = new ClientRepository(session);
            Client client = clientRepository.GetByCode(clientDeleteDTO.ClientCode);
            if (client.Kkms.Count > 0)
            {
                throw new ClientException("Cannot delete client with associated KKMs.");
            }
            validationContext.Client = client;
        }
    }
}
