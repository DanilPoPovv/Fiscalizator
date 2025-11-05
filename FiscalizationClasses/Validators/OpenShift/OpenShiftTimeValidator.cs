using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators.OpenShift
{
    public class OpenShiftTimeValidator : IValidator<OpenShiftDTO>
    {
        public bool Validate(OpenShiftDTO request, ValidationContext validationContext, ISession session, out string errorMessage)
        {
            if (request.OpenShiftTime > DateTime.Now)
            {
                errorMessage = "Opening date and time cannot be in the future.";
                return false;
            }
            if (validationContext.СurrentShift == null)
            {
                Shift lastShift = validationContext.Kkm.Shifts.LastOrDefault();
                if (lastShift == null)
                {
                    errorMessage = string.Empty;
                    return true;
                }
                else if (request.OpenShiftTime < lastShift.ClosureDateTime)
                {
                    errorMessage = "Opening date and time cannot be earlier than the last shift's closing date and time.";
                    return false;
                }
            }
            errorMessage = string.Empty;
            return true;
        }
    
    }
}
