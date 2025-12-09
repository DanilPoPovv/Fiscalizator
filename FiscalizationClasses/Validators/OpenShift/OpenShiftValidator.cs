using Fiscalizator.FiscalizationClasses.Dto;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators.OpenShift
{
    public class OpenShiftValidator : IValidator<OpenShiftDTO, ValidationContext>
    {
        public bool Validate(OpenShiftDTO request, ISession session, out string errorMessage, ValidationContext validationContext)
        {
            if (!Helpers.KkmHelper.ValidateSerialNumber(request.SerialNumber, validationContext, session, out errorMessage))
                return false;
            if (Helpers.ShiftHelper.CheckShiftOpened(validationContext, session, out errorMessage))
            {
                errorMessage = "There is already an opened shift for this KKM.";
                return false;
            }
                return true;
        }
    }
}
