using Fiscalizator.FiscalizationClasses.Dto;
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
            errorMessage = string.Empty;
            return true;
        }
    
    }
}
