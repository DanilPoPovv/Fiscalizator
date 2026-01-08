using Fiscalizator.FiscalizationClasses.Dto.Service;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.Repository;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using ISession = NHibernate.ISession;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.OperationHandlers
{
    public class OutcomeHandler
    {
        private readonly CashRepository _cashRepository;
        private readonly ValidatorManager<OutcomeOperationDto, BaseOperationDataAccessor, OutcomeCashVContext> _outcomeValidator;
        private readonly ISession session;
        private readonly BaseOperationDataAccessor _dataAccessor;
        private readonly CashOperationRepository _cashOperationRepository;
        private readonly OutcomeCashVContext _validationContext;
        public OutcomeHandler(ValidatorManager<OutcomeOperationDto, BaseOperationDataAccessor, OutcomeCashVContext> outcomeValidator)
        {
            session = NHibernateHelper.SessionFactory.OpenSession();
            _cashRepository = new CashRepository(session);
            _outcomeValidator = outcomeValidator;
            _dataAccessor = new BaseOperationDataAccessor(session);
            _cashOperationRepository = new CashOperationRepository(session);
            _validationContext = new OutcomeCashVContext();
        }
        public OperationResponse Outcome(OutcomeOperationDto outcomeOperationDto)
        {
            try
            {
                _outcomeValidator.ValidateAll(outcomeOperationDto, _dataAccessor, _validationContext);
                Counter counter = _validationContext.Cash;
                CashOperation cashOperation = new CashOperation
                {
                    Cashier = _validationContext.Cashier,
                    Shift = _validationContext.Shift,
                    Kkm = _validationContext.Kkm,
                    Amount = outcomeOperationDto.Amount,
                    OperationType = CashOperationType.Outcome,
                    OperationDateTime = outcomeOperationDto.OperationDateTime
                };
                using (var transaction = session.BeginTransaction())
                {
                    counter.CashValue -= outcomeOperationDto.Amount;
                    _cashOperationRepository.Add(cashOperation);
                    _validationContext.Shift.LastOperationDateTime = outcomeOperationDto.OperationDateTime;
                    transaction.Commit();
                }
                return new OperationResponse { Message = $"Outcome operation processed successfully, current cash {counter.CashValue}" };
            }
            catch (Exception ex)
            {
                return new OperationResponse
                {
                    Message = $"Outcome operation processing failed: {ex.Message}"
                };
            }
        }
    }
}
