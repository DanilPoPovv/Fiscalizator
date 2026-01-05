using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces;


namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalCashValidator<TData,TContext> : IGlobalValidator<TData,TContext> where TData : ICashDataAccessor where TContext : OutcomeCashVContext
    {
        public void Validate(object request, TData validationData, TContext validationContext)
        {
            if (request is not IEnoughCashRequire cashRegisterRequest)
            {
                return;
            }
            Counter counter = validationData.GetCounter(validationContext.Kkm.Id);
            if (counter.CashValue < cashRegisterRequest.Amount)
            {
                throw new NotEnoughCashException("Not enough cash in the cash register.");
            }
            validationContext.Cash = counter;
        }
    }
}
