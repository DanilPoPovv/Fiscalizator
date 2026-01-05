using Fiscalizator.FiscalizationClasses.Dto.Service;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using Microsoft.AspNetCore.Http.Features;
using NHibernate;
using System.Transactions;
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
        public IncomeHandler(ValidatorManager<IncomeOperationDto, BaseOperationDataAccessor, ValidationContext> incomeValidator)
        {
            _incomeValidator = incomeValidator;
            session = NHibernateHelper.SessionFactory.OpenSession();
            _cashRepository = new CashRepository(session);
            _dataAccessor = new BaseOperationDataAccessor(session);
            _cashOperationRepository = new CashOperationRepository(session);
        }
        public OperationResponse Income(IncomeOperationDto incomeDto)
        {
            ValidationContext validationContext = new ValidationContext();
            try
            {
                Counter counter;
                _incomeValidator.ValidateAll(incomeDto, _dataAccessor, validationContext);
                using (ITransaction transaction = session.BeginTransaction())
                {
                   counter = _cashRepository.GetByKkmId(validationContext.Kkm.Id);
                   counter.CashValue += incomeDto.Amount;
                    CashOperation cashOperation = new CashOperation
                    {
                        Cashier = validationContext.Cashier,
                        Shift = validationContext.Shift,
                        Kkm = validationContext.Kkm,
                        Amount = incomeDto.Amount,
                        OperationType = CashOperationType.Income,
                        OperationDateTime = incomeDto.OperationDateTime
                    };
                    _cashOperationRepository.Add(cashOperation);
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
