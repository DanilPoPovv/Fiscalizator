
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalOperationTimeValidator<TRequest,TData, TContext> : IGlobalValidator<TRequest,TData,TContext> 
        where TContext : ValidationContext 
        where TData : IShiftDataAccessor
        where TRequest : IHasOperationTime
    {
        public void Validate(TRequest request, TData validationData, TContext validationContext)
        {
            if (validationContext.Kkm.Bills.Count > 0 && validationContext.Kkm.Shifts.Count > 0 && validationContext.Kkm.Bills.Last().OperationDateTime >= request.OperationDateTime)
            {
               throw new Exception("Operation time cannot be earlier than the last operation time in the current shift.");
            }
        }
    }
}
