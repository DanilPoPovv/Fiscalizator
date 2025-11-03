using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class BillTimeValidator : IValidator<BillDTO>
    {
        public bool Validate(BillDTO request, ValidationContext validationContext, ISession session, out string errorMessage)
        {
            if (!ValidateLaterThanShiftOutOfTime(request.OperationDateTime, out errorMessage, validationContext.СurrentShift))
                return false;
            if (!ValidateEarlierThanLastBill(request.OperationDateTime, out errorMessage, validationContext.СurrentShift))
                return false;
            return true;
        }
        public bool ValidateEarlierThanLastBill(DateTime billTime, out string errorMessage, Shift shift)
        {
            var lastBill = shift.Bills.LastOrDefault();
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
