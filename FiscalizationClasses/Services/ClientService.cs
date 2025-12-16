using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.Mappers;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Dto.Client;

public class ClientService
{
    private readonly ValidatorManager<ClientDTO, ClientValidationContext> _createValidator;
    private readonly ValidatorManager<ClientChangeDTO, ClientValidationContext> _updateValidator;
    private readonly ValidatorManager<ClientDeleteDTO, ClientValidationContext> _deleteValidator;

    private readonly ClientRepository _clientRepository;
    private readonly ClientMapper _clientMapper;
    private readonly ISession _session;

    public ClientService(
        ValidatorManager<ClientDTO, ClientValidationContext> createValidator,
        ValidatorManager<ClientChangeDTO, ClientValidationContext> updateValidator,
        ValidatorManager<ClientDeleteDTO, ClientValidationContext> deleteValidator
    )
    {
        _session = NHibernateHelper.OpenSession();
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        _deleteValidator = deleteValidator;
        _clientRepository = new ClientRepository(_session);
        _clientMapper = new ClientMapper();
    }

    public void AddClient(ClientDTO dto)
    {
        var context = new ClientValidationContext();
        _createValidator.ValidateAll(dto, _session, context);

        var client = _clientMapper.Map(dto);
        _clientRepository.Add(client);
    }

    public void DeleteClient(ClientDeleteDTO dto)
    {
        var context = new ClientValidationContext();
        _deleteValidator.ValidateAll(dto, _session, context);

        _clientRepository.Delete(context.Client);
    }

    public void UpdateClient(ClientChangeDTO dto)
    {
        var context = new ClientValidationContext();
        _updateValidator.ValidateAll(dto, _session, context);

        var client = context.Client;
        client.Name = dto.Name;
        client.Address = dto.Address;
        client.Code = dto.ClientCode;

        _clientRepository.Update(client);
    }
    public List<Client> GetAllClients()
    {
    return _clientRepository.GetAll();
    }
}

