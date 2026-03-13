using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces;


namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalCashValidator<TRequest, TData,TContext> : IGlobalValidator<TRequest,TData, TContext> 
        where TData : ICashDataAccessor
        where TContext : OutcomeCashVContext
        where TRequest : IEnoughCashRequire
    {
        public void Validate(TRequest request, TData validationData, TContext validationContext)
        {
            Counter counter = validationData.GetCounter(validationContext.Kkm.Id);
            if (counter.CashValue < request.Amount)
            {
                throw new NotEnoughCashException("Not enough cash in the cash register.");
            }
            validationContext.Cash = counter;
        }
    }
}
