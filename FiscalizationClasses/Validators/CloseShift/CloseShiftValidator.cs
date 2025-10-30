using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.Helpers;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators.CloseShift
{
    public class CloseShiftValidator : IValidator<CloseShiftDTO>
    {
        public bool Validate(CloseShiftDTO request, ValidationContext validationContext, ISession session, out string errorMessage)
        {
            if (!KkmHelper.ValidateSerialNumber(request.SerialNumber, validationContext,session, out errorMessage))
                return false;
            if (!ShiftHelper.CheckShiftOpened(validationContext,session, out errorMessage))
                return false;
            return true;
        }
    }
}
