using System.ComponentModel.DataAnnotations;

namespace Fiscalizator.FiscalizationClasses.Validators.Helpers
{
    public static class ShiftHelper
    {
        public static bool CheckShiftOpened(ValidationContext validationContext, out string errorMessage)
        {
            var shift = validationContext.Kkm.Shifts.LastOrDefault(s => s.ClosureDateTime == null);
            validationContext.СurrentShift = shift;
            if (shift == null)
            {
                errorMessage = $"No opened shift for this KKM";
                return false;
            }
            errorMessage = string.Empty;
            return true;

        }
    }
}
