using Fiscalizator.FiscalizationClasses.Dto.Service;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using NHibernate;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.OperationHandlers
{
    public class IncomeHandler
    {
        private readonly CashRepository _cashRepository;
        private readonly ValidatorManager<IncomeOperationDto, BaseOperationDataAccessor, ValidationContext> _incomeValidator;
        private readonly ISession session;
        private readonly BaseOperationDataAccessor _dataAccessor;
        private readonly CashOperationRepository _cashOperationRepository;
        private readonly ValidationContext _validationContext;

        public IncomeHandler(ValidatorManager<IncomeOperationDto, BaseOperationDataAccessor, ValidationContext> incomeValidator)
        {
            _incomeValidator = incomeValidator;
            session = NHibernateHelper.SessionFactory.OpenSession();
            _cashRepository = new CashRepository(session);
            _dataAccessor = new BaseOperationDataAccessor(session);
            _cashOperationRepository = new CashOperationRepository(session);
            _validationContext = new ValidationContext();
        }
        public OperationResponse Income(IncomeOperationDto incomeDto)
        {
            try
            {
                Counter counter;
                _incomeValidator.ValidateAll(incomeDto, _dataAccessor, _validationContext);
                using (ITransaction transaction = session.BeginTransaction())
                {
                   counter = _cashRepository.GetByKkmId(_validationContext.Kkm.Id);
                   counter.CashValue += incomeDto.Amount;
                    CashOperation cashOperation = new CashOperation
                    {
                        Cashier = _validationContext.Cashier,
                        Shift = _validationContext.Shift,
                        Kkm = _validationContext.Kkm,
                        Amount = incomeDto.Amount,
                        OperationType = CashOperationType.Income,
                        OperationDateTime = incomeDto.OperationDateTime
                    };
                    _cashOperationRepository.Add(cashOperation);
                    _validationContext.Shift.LastOperationDateTime = incomeDto.OperationDateTime;
                    transaction.Commit();
                }
                return new OperationResponse { Message = $"Income operation processed successfully, current cash {counter.CashValue}" };
            }
            catch(Exception ex)
            {
               return new OperationResponse
               {
                   Message = $"Income operation processing failed: {ex.Message}"
               };
            }
        }
    }
}
