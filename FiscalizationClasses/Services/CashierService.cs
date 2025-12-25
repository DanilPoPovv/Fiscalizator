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
        private readonly ValidatorManager<CashierUpdateDto, CashierCrudDataAccessor, CashierValidationContext> _updateCashierValidator;
        private readonly ValidatorManager<CashierDeleteDTO, CashierCrudDataAccessor, CashierValidationContext> _deleteCashierValidator;
        private readonly CashierCrudDataAccessor _cashierCrudDataValidator;
        public CashierService(ValidatorManager<CashierAddDto, CashierCrudDataAccessor, CashierValidationContext> addValidator,
            ValidatorManager<CashierUpdateDto, CashierCrudDataAccessor, CashierValidationContext> updateCashierValidator,
            ValidatorManager<CashierDeleteDTO, CashierCrudDataAccessor, CashierValidationContext> deleteCashierValidator)
        {
            _session = NHibernateHelper.OpenSession();
            _cashierRepository = new CashierRepository(_session);
            _addCashierValidator = addValidator;
            _cashierCrudDataValidator = new CashierCrudDataAccessor(_session);
            _updateCashierValidator = updateCashierValidator;
            _deleteCashierValidator = deleteCashierValidator;
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
        public void UpdateCashier(CashierUpdateDto cashierUpdateDto)
        {
            CashierValidationContext validationContext = new CashierValidationContext();
            _updateCashierValidator.ValidateAll(cashierUpdateDto, _cashierCrudDataValidator, validationContext);
            Cashier cashier = validationContext.Cashier;
            if (!string.IsNullOrEmpty(cashierUpdateDto.NewCashierName))
            {
                cashier.Name = cashierUpdateDto.NewCashierName;
            }
            if (cashierUpdateDto.NewSystemId != null)
            {
                cashier.SystemId = (int)cashierUpdateDto.NewSystemId;
            }

            using (var transaction = _session.BeginTransaction())
            {
                _cashierRepository.Update(cashier);
                transaction.Commit();
            }
        }
        public void DeleteCashier(CashierDeleteDTO deleteDto)
        {
            CashierValidationContext validationContext = new CashierValidationContext();
            _deleteCashierValidator.ValidateAll(deleteDto, _cashierCrudDataValidator, validationContext);
            Cashier cashier = validationContext.Cashier;
            using (var transaction = _session.BeginTransaction())
            {
                _cashierRepository.Delete(cashier);
                transaction.Commit();
            }
        }
        public IEnumerable<Cashier> GetAllClientCashiers(int ClientCode)
        {
            return _cashierRepository.GetAllClientCashier(ClientCode);
        }
    }
}
