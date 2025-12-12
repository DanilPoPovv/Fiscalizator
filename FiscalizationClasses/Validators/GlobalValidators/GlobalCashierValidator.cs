using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalCashierValidator : IGlobalValidator<ValidationContext>
    {
        CashierRepository _cashierRepository;
        public void Validate(object request, ISession session, ValidationContext validationContext)
        {
            if (request is not ICashierRequest cashierRequest)
               return;
            _cashierRepository = new CashierRepository(session);
            var cashier = _cashierRepository.GetByName(cashierRequest.CashierName);
            if (cashier == null)
            {
                throw new CashierException($"Cashier with name {cashierRequest.CashierName} does not exist.");
            }
            validationContext.Cashier = cashier;
        }
    }
}
