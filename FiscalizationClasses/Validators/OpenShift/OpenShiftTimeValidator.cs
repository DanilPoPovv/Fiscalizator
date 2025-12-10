using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators.OpenShift
{
    public class OpenShiftTimeValidator : IValidator<OpenShiftDTO, ValidationContext>
    {
        public void Validate(OpenShiftDTO request, ISession session, ValidationContext validationContext)
        {
            if (request.OpenShiftTime > DateTimeOffset.Now)
            {
                throw new ShiftException("Opening date and time cannot be in the future.");
            }
            if (validationContext.CurrentShift == null)
            {
                Shift lastShift = validationContext.Kkm.Shifts.LastOrDefault();
                if (lastShift == null)
                {
                    return;
                }
                else if (request.OpenShiftTime < lastShift.ClosureDateTime)
                {
                    throw new ShiftException("Opening date and time cannot be earlier than the last shift's closing date and time.");
                }
            }
        }
    
    }
}
