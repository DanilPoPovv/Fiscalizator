using Fiscalizator.FiscalizationClasses.Dto.Cashier;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Services
{
    public class CashierService
    {
        private readonly CashierRepository _cashierRepository;
        private readonly ISession _session;
        private readonly ValidatorManager<CashierAddDto, CashierCrudDataAccessor, CashierValidationContext> _addCashierValidator;
        private readonly CashierCrudDataAccessor _cashierCrudDataValidator;
        public CashierService(ValidatorManager<CashierAddDto, CashierCrudDataAccessor, CashierValidationContext> addValidator)
        {
            _session = NHibernateHelper.OpenSession();
            _cashierRepository = new CashierRepository(_session);
            _addCashierValidator = addValidator;
            _cashierCrudDataValidator = new CashierCrudDataAccessor(_session);
        }
        public void AddCashier(CashierAddDto addDto)
        {
            CashierValidationContext validationContext = new CashierValidationContext();
            _addCashierValidator.ValidateAll(addDto, _cashierCrudDataValidator, validationContext);
            Cashier cashier = new Cashier
            {
                Name = addDto.Name,
                SystemId = addDto.SystemId,
                Client = validationContext.Client
            };
            using (var transaction = _session.BeginTransaction())
            {
                _cashierRepository.Add(cashier);
                transaction.Commit();
            }
        }
        public void UpdateCashier()
        {

        }
        public void DeleteCashier()
        {

        }
        public IEnumerable<Cashier> GetAllClientCashiers(int ClientCode)
        {
            return _cashierRepository.GetAllClientCashier(ClientCode);
        }
    }
}
