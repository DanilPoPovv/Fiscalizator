using Fiscalizator.FiscalizationClasses.Dto.Bill;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Helpers;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.BillValidators
{
    /// <summary>
    /// TODO : In the future need to separete all these validations into smaller validators
    /// </summary>
    public class BillValidator : IValidator<BillDTO, ValidationContext>
    {
        public void Validate(BillDTO request, ISession session, ValidationContext validationContext)
        {
            ValidateAmount(request.Amount);
            ValidateCommodity(request.Amount, request.Commodity);
            ValidatePayment(request.Payment, request.Amount);
        }

        private void ValidateAmount(decimal amount)
        {
            if (amount <= 0)
                throw new BillException("Amount must be greater than zero.");
        }

        private void ValidateCommodity(decimal amount, CommodityDTO[] commodities)
        {
            if (commodities == null || commodities.Length == 0)
                throw new BillException("At least one commodity is required.");

            int commoditiesSum = 0;

            foreach (var commodity in commodities)
            {
                if (commodity.Price * commodity.Quantity != commodity.Sum)
                    throw new BillException($"Commodity sum for '{commodity.Name}' is incorrect.");

                commoditiesSum += commodity.Price * commodity.Quantity;

                if (commodity.Tax != null)
                    ValidateTax(commodity.Tax, commoditiesSum);
            }

            if (commoditiesSum != amount)
                throw new BillException("Sum of commodities does not match the bill amount.");
        }

        private void ValidateTax(TaxDTO tax, int commoditySum)
        {
            if (tax.Percent >= 100)
                throw new BillException("Tax percent cannot be greater than or equal to 100.");

            if (tax.Percent < 0)
                throw new BillException("Tax percent cannot be negative.");

            if (tax.Sum != commoditySum * tax.Percent / 100)
                throw new BillException("Tax sum does not match the calculated value.");
        }

        private void ValidatePayment(PaymentDTO payment, decimal billAmount)
        {
            if (!EnumHelper.IsDefined<PaymentType>(payment.PaymentType))
                throw new BillException($"Invalid payment type: {payment.PaymentType}");

            var paymentType = Enum.Parse<PaymentType>(payment.PaymentType, true);

            if (payment.Amount < 0)
                throw new BillException("Payment amount cannot be negative.");

            if (payment.Amount > billAmount && paymentType != PaymentType.CASH)
                throw new BillException("Payment amount cannot exceed bill amount for non-cash payments.");

            if (payment.Amount < billAmount)
                throw new BillException("Payment amount cannot be less than bill amount.");
        }
    }
}
