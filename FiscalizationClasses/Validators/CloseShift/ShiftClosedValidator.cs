using Fiscalizator.FiscalizationClasses.Dto.Shift;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators.CloseShift
{
    public class ShiftClosedValidator : IValidator<CloseShiftDTO, ValidationContext>
    {
        public void Validate(CloseShiftDTO request, ISession session, ValidationContext validationContext)
        {
            Shift shift = validationContext.Kkm.Shifts.LastOrDefault();
            if (shift == null || shift.ClosureDateTime != null) 
                { 
                throw new Exception("There is no opened shift for this KKM.");
                }
            validationContext.CurrentShift = shift;
        }
    }
}
