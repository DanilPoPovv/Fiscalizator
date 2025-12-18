using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalShiftOpenValidator<TData, TContext> : IGlobalValidator<TData, TContext>
        where TData : IShiftDataAccessor
        where TContext : IValidationContext, IKkmValidationContextRequire, IShiftOpenValidationContextRequire
    {
        public void Validate(object request, TData validationData,TContext validationContext)
        {
            if (request is not IOpenShiftRequire)
                return;

            var lastShift = validationContext.Kkm.Shifts.LastOrDefault();

            if (lastShift == null || lastShift.ClosureDateTime != null)
            {
                throw new ShiftException("This operation requires the current shift to be opened.");
            }

            validationContext.Shift = lastShift;
        }
    }

}
