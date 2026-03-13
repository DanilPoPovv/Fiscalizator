using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces;

namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalShiftOpenValidator<TRequest,TData, TContext> : IGlobalValidator<TRequest,TData, TContext>
        where TData : IShiftDataAccessor
        where TContext : IValidationContext, IKkmValidationContextRequire, IShiftOpenValidationContextRequire
        where TRequest : IOpenShiftRequire
    {
        public void Validate(TRequest request, TData validationData,TContext validationContext)
        {
            var lastShift = validationContext.Kkm.Shifts.LastOrDefault();

            if (lastShift == null || lastShift.ClosureDateTime != null)
            {
                throw new ShiftException("This operation requires the current shift to be opened.");
            }

            validationContext.Shift = lastShift;
        }
    }

}
