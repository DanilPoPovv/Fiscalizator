using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class BillTimeValidator : IValidator<DateTime>
    {
        private readonly DateTime ShiftDuration = new DateTime(0, 0, 0, 24, 0, 0);
        public bool Validate(DateTime billTime, ValidationContext validationContext, out string errorMessage)
        {
            if (!ValidateLaterThanShiftOutOfTime(billTime, out errorMessage, validationContext.currentShift))
                return false;
            if (!ValidateEarlierThanLastBill(billTime, out errorMessage, validationContext.currentShift))
                return false;
            return true;
        }
        public bool ValidateEarlierThanLastBill(DateTime billTime, out string errorMessage, Shift shift)
        {
            var lastBill = shift.Bills.Last();
            if (lastBill != null && billTime <= lastBill.OperationDateTime)
            {
                errorMessage = $"Bill time {billTime} is earlier than last bill time {lastBill.OperationDateTime}";
                return false;
            }
            else if (lastBill == null && billTime < shift.OpeningDateTime)
            {
                errorMessage = $"Bill time {billTime} is earlier than shift opening time {shift.OpeningDateTime}";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
        public bool ValidateLaterThanShiftOutOfTime(DateTime billTime, out string errorMessage, Shift shift)
        {
            if (billTime > shift.OpeningDateTime.AddHours(24))
            {
                errorMessage = $"Bill time {billTime} is later than shift out of time {shift.OpeningDateTime.AddHours(24)}";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
    }
}
