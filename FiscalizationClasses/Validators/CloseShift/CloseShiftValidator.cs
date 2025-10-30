using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.Helpers;
using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators.CloseShift
{
    public class CloseShiftValidator : IValidator<CloseShiftDTO>
    {
        public bool Validate(CloseShiftDTO request, ValidationContext validationContext, out string errorMessage)
        {
            if (!KkmHelper.ValidateSerialNumber(request.SerialNumber, validationContext, out errorMessage))
                return false;
            if (!ShiftHelper.CheckShiftOpened(validationContext, out errorMessage))
                return false;
            return true;
        }

            
    }
}
