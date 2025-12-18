using Fiscalizator.FiscalizationClasses.Dto.Shift;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
namespace Fiscalizator.FiscalizationClasses.Validators.CloseShift
{
    public class ShiftClosedValidator : IValidator<CloseShiftDTO, BaseOperationDataAccessor, ValidationContext>
    {
        public void Validate(CloseShiftDTO request, BaseOperationDataAccessor validationData, ValidationContext validationContext)
        {
            Shift shift = validationContext.Kkm.Shifts.LastOrDefault();
            if (shift == null || shift.ClosureDateTime != null) 
                { 
                throw new Exception("There is no opened shift for this KKM.");
                }
            validationContext.Shift = shift;
        }
    }
}
