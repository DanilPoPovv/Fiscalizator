using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.ClientCrudValidator
{
    public class ClientUpdateUnique : IValidator<ClientChangeDTO, ClientValidationContext>
    {
        public void Validate(ClientChangeDTO clientDto, ISession session, ClientValidationContext validationContext)
        {
            ClientRepository clientRepository = new ClientRepository(session);
            Client client = clientRepository.GetByCode(clientDto.OldCode);
            if (clientRepository.GetByCode(clientDto.ClientCode) != null)
            {
                throw new ClientException("A client with the same code already exists.");
            }

        }
    }
}
