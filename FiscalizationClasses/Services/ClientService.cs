using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.Mappers;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.Repository.Interfaces;
using Fiscalizator.FiscalizationClasses.Dto.Pagination;

public class ClientService
{
    private readonly ValidatorManager<ClientDTO, IClientDataAccessor, ClientValidationContext> _createValidator;
    private readonly ValidatorManager<ClientChangeDTO, IClientDataAccessor, ClientValidationContext> _updateValidator;
    private readonly ValidatorManager<ClientDeleteDTO, IClientDataAccessor, ClientValidationContext> _deleteValidator;

    private readonly IClientRepository _clientRepository;
    private readonly ClientMapper _clientMapper;
    private readonly ISession _session;
    private readonly IClientDataAccessor _dataAccessor;

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

    public Client AddClient(ClientDTO dto)
    {
        var context = new ClientValidationContext();
        _createValidator.ValidateAll(dto, _dataAccessor, context);

        var client = _clientMapper.Map(dto);
        _clientRepository.Add(client);
        client = _clientRepository.GetByCode(client.ClientCode);
        return client;
    }

    public void DeleteClient(ClientDeleteDTO dto)
    {
        using var transaction = _session.BeginTransaction();

        var context = new ClientValidationContext();
        _deleteValidator.ValidateAll(dto, _dataAccessor, context);

        _clientRepository.Delete(context.Client);

        transaction.Commit();
    }

    public Client UpdateClient(ClientChangeDTO dto)
    {
        ///TODO : добавить валидацию полей, либо самому, либо через modelState
        /// А ЕЩЕ не использовать тут транзакцию напрямую, надо UOW
      
        using var transaction = _session.BeginTransaction();
        var context = new ClientValidationContext();
        _updateValidator.ValidateAll(dto, _dataAccessor, context);

        Client client = _clientRepository.GetById(dto.Id);
        client.ClientCode = dto.ClientCode;
        client.Name = dto.Name;
        client.Address = dto.Address;

        transaction.Commit();

        return client;
    }
    public PagedResult<Client> Search(ClientFilterDTO filter)
    {
        if (filter.Page <= 0)
            filter.Page = 1;
        if (filter.PageSize <= 0)
            filter.PageSize = 10;
        
        var pagedData = _clientRepository.Search(filter);
        return new PagedResult<Client>()
        {
            Items = pagedData.Items,
            Page = filter.Page,
            PageSize = filter.PageSize,
            TotalCount = pagedData.TotalCount
        };
        
    }

}

