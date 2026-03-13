using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalCashierValidator<TRequest,TData,TContext> : IGlobalValidator<TRequest, TData,TContext> 
        where TContext : IValidationContext 
        where TData : ICashierDataAccessor
        where TRequest : ICashierNameRequire
    {
        public void Validate(TRequest request, TData validationData, TContext validationContext)
        {
            var cashier = validationData.Cashiers.GetByName(request.CashierName);
            if (cashier == null)
            {
                throw new CashierException($"Cashier with name {request.CashierName} does not exist.");
            }
            if (validationContext is ICashierValidationContextRequire cashierValidationContext)
                cashierValidationContext.Cashier = cashier;
        }
    }
}
