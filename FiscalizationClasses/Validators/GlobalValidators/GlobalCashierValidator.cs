using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalCashierValidator<TContext,TData> : IGlobalValidator<TContext, TData> where TContext : IValidationContext where TData : ICashierDataAccessor
    {
        public void Validate(object request, TData validationData, TContext validationContext)
        {
            if (request is not ICashierNameRequire cashierRequest)
               return; 
            var cashier = validationData.Cashiers.GetByName(cashierRequest.CashierName);
            if (cashier == null)
            {
                throw new CashierException($"Cashier with name {cashierRequest.CashierName} does not exist.");
            }
            if (validationContext is ICashierValidationContextRequire cashierValidationContext)
                cashierValidationContext.Cashier = cashier;
        }
    }
}
