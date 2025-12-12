using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.Helpers;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.BillValidators
{
    public class BillTimeValidator : IValidator<BillDTO, ValidationContext>
    {
        public void Validate(BillDTO request, ISession session, ValidationContext validationContext)
        {
            ValidateLaterThanShiftOutOfTime(request.OperationDateTime, validationContext.CurrentShift);
            ValidateEarlierThanLastBill(request.OperationDateTime, validationContext.CurrentShift);
        }

        private void ValidateEarlierThanLastBill(DateTime billTime, Shift shift)
        {
            var lastBill = shift.Bills.LastOrDefault();
            if (lastBill != null && billTime <= lastBill.OperationDateTime)
            {
                throw new BillException($"Bill time {billTime} is earlier than last bill time {lastBill.OperationDateTime}.");
            }

            if (lastBill == null && billTime < shift.OpeningDateTime)
            {
                throw new BillException($"Bill time {billTime} is earlier than shift opening time {shift.OpeningDateTime}.");
            }
        }

        private void ValidateLaterThanShiftOutOfTime(DateTime billTime, Shift shift)
        {
            var shiftEndTime = shift.OpeningDateTime.AddHours(24);
            if (billTime > shiftEndTime)
            {
                throw new BillException($"Bill time {billTime} is later than shift out of time {shiftEndTime}.");
            }
        }
    }
}
