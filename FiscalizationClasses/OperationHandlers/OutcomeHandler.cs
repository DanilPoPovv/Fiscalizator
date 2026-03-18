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
        private readonly ValidatorManager<OutcomeOperationDto, BaseOperationDataAccessor, OutcomeCashVContext> _outcomeValidator;
        private readonly ISession _session;
        private readonly BaseOperationDataAccessor _dataAccessor;
        private readonly CashOperationRepository _cashOperationRepository;
        private readonly OutcomeCashVContext _validationContext;
        private readonly UnitOfWork _unitOfWork;
        public OutcomeHandler(ValidatorManager<OutcomeOperationDto, BaseOperationDataAccessor, OutcomeCashVContext> outcomeValidator)
        {
            _session = NHibernateHelper.SessionFactory.OpenSession();
            _outcomeValidator = outcomeValidator;
            _dataAccessor = new BaseOperationDataAccessor(_session);
            _cashOperationRepository = new CashOperationRepository(_session);
            _validationContext = new OutcomeCashVContext();
            _unitOfWork = new UnitOfWork(_session);
        }
        public OperationResponse Outcome(OutcomeOperationDto outcomeOperationDto)
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
                using (_unitOfWork)
                {
                    counter.CashValue -= outcomeOperationDto.Amount;
                    _unitOfWork.cashOperationRepository.Add(cashOperation);
                    _validationContext.Shift.LastOperationDateTime = outcomeOperationDto.OperationDateTime;
                    _unitOfWork.Commit();
                }
                return new OperationResponse { Message = $"Outcome operation processed successfully, current cash {counter.CashValue}" };
        }
    }
}
