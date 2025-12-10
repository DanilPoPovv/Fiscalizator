using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.BaseCheckServices
{
    public class KkmCheckShiftOpenedService
    {
        public void CheckShiftOpened(ValidationContext context)
        {
            Shift shift = context.Kkm.Shifts.LastOrDefault(s => s.ClosureDateTime == null);
            if (shift == null)
            {
                throw new ShiftException("No opened shift for this KKM");
            }
        }
    }
}
