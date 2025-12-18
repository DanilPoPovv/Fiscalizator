using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.Mappers;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;

public class ClientService
{
    private readonly ValidatorManager<ClientDTO, IClientDataAccessor, ClientValidationContext> _createValidator;
    private readonly ValidatorManager<ClientChangeDTO, IClientDataAccessor, ClientValidationContext> _updateValidator;
    private readonly ValidatorManager<ClientDeleteDTO, IClientDataAccessor, ClientValidationContext> _deleteValidator;

    private readonly ClientRepository _clientRepository;
    private readonly ClientMapper _clientMapper;
    private readonly ISession _session;
    private readonly ClientCrudDataAccesor _dataAccessor;

    public ClientService(
        ValidatorManager<ClientDTO, IClientDataAccessor, ClientValidationContext> createValidator,
        ValidatorManager<ClientChangeDTO, IClientDataAccessor, ClientValidationContext> updateValidator,
        ValidatorManager<ClientDeleteDTO, IClientDataAccessor, ClientValidationContext> deleteValidator
    )
    {
        _session = NHibernateHelper.OpenSession();
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        _deleteValidator = deleteValidator;
        _clientRepository = new ClientRepository(_session);
        _clientMapper = new ClientMapper();
        _dataAccessor = new ClientCrudDataAccesor(_session);
    }

    public void AddClient(ClientDTO dto)
    {
        var context = new ClientValidationContext();
        _createValidator.ValidateAll(dto, _dataAccessor, context);

        var client = _clientMapper.Map(dto);
        _clientRepository.Add(client);
    }

    public void DeleteClient(ClientDeleteDTO dto)
    {
        using var transaction = _session.BeginTransaction();

        var context = new ClientValidationContext();
        _deleteValidator.ValidateAll(dto, _dataAccessor, context);

        _clientRepository.Delete(context.Client);

        transaction.Commit();
    }

    public void UpdateClient(ClientChangeDTO dto)
    {
        using var transaction = _session.BeginTransaction();

        var context = new ClientValidationContext();
        _updateValidator.ValidateAll(dto, _dataAccessor, context);

        Client client = context.Client;
        client.Name = dto.Name;
        client.Address = dto.Location;
        client.Code = dto.NewCode;

        _clientRepository.Update(client);

        transaction.Commit();
    }

    public List<Client> GetAllClients()
    {
    return _clientRepository.GetAll();
    }
}

