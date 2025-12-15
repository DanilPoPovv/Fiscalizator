using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalShiftOpenValidator : IGlobalValidator<ValidationContext>
    {
        public void Validate(object request, ISession session, ValidationContext validationContext)
        {
            if (request is not IOpenShiftRequire shiftOpenRequest)
                return;
            if (validationContext.Kkm.Shifts.LastOrDefault().ClosureDateTime != null)
            {
                throw new ShiftException("This operation requires the current shift to be opened.");
            }
        }
    }
}
