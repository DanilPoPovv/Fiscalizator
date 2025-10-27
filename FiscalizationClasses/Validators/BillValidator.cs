using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.Helpers;
using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class BillValidator : IBillValidator
    {
        private readonly KkmValidator _kmkValidator = new KkmValidator();
        public bool ValidateBill(BillDTO request, out string errorMessage)
        {
            if (!_kmkValidator.ValidateKkm(request.SerialNumber,request.OperationDateTime,out errorMessage))
                return false;
            if (!ValidateKkm(request.SerialNumber, out errorMessage))
                return false;    
            if (!ValidAmount(request.Amount, out errorMessage))
                return false;
            if (!ValidateCommodity(request.Amount, request.Commodity, out errorMessage))
                return false;
            if (!ValidatePayment(request.Payment, request.Amount, out errorMessage)) 
                return false;
            return true;
        }
        private bool ValidAmount(decimal amount, out string errorMessage)
        {
            bool isValid = amount > 0;
            errorMessage = isValid ? string.Empty : "Amount must be greater than zero.";
            return isValid;
        }
        private bool ValidateCommodity(decimal amount,CommodityDTO[] commodities, out string errorMessage)
        {
            if (commodities == null || commodities.Length == 0)
            {
                errorMessage = "At least one commodity is required.";
                return false;
            }
            int commoditiesSum = 0;
            foreach (var commodity in commodities)
            {
                if (commodity.Price * commodity.Quantity != commodity.Sum)
                {
                    errorMessage = $"Commodity sum for {commodity.Name} is incorrect.";
                    return false;
                }
                commoditiesSum += commodity.Price * commodity.Quantity;
                if (commodity.Tax != null)
                {
                    bool isValidTax = ValidateTax(commodity.Tax, commoditiesSum, out string taxErrorMessage);
                    if (!isValidTax)
                    {
                        errorMessage = taxErrorMessage;
                        return false;
                    }
                }
            }
            bool isValid = commoditiesSum == amount;
            errorMessage = isValid ? string.Empty : "Sum of commodities does not match the amount.";
            return isValid;
        }
        private bool ValidateTax(TaxDTO tax, int commoditySum, out string errorMessage)
        {
            if (tax.Percent >= 100)
            {
                errorMessage = "Tax percent cannot be greater than 100.";
                return false;
            }
            if (tax.Percent < 0)
            {
                errorMessage = "Tax percent cannot be negative.";
                return false;
            }
            if (tax.Sum != (commoditySum * tax.Percent) / 100)
            {
                errorMessage = "Tax sum does not match the calculated value.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
        private bool ValidatePayment(PaymentDTO payment, decimal billAmount, out string errorMessage)
        {
            if (!EnumHelper.IsDefined<PaymentType>(payment.PaymentType))
            {
                errorMessage = $"Invalid payment type: {payment.PaymentType}";
                return false;
            }
            var paymentType = Enum.Parse<PaymentType>(payment.PaymentType, true);

            if (payment.Amount < 0)
            {
                errorMessage = "Payment amount cannot be negative.";
                return false;
            }

            if (payment.Amount > billAmount && paymentType != PaymentType.CASH)
            {
                errorMessage = "Payment amount cannot exceed bill amount for non-cash payments.";
                return false;
            }

            if (payment.Amount < billAmount)
            {
                errorMessage = "Payment amount cannot be less than bill amount.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
        private bool ValidateKkm(int serialNumber,out string errorMessage)
        {
            KkmRepository kkmRepository = new KkmRepository(NHibernateHelper.OpenSession());
            Kkm kkm = kkmRepository.GetBySerialNumber(serialNumber);
            if (kkm == null)
            {
                errorMessage = $"There is no kkm with {serialNumber} serialNumber";
                return false ;
            }
            errorMessage = string.Empty;
            return true;
        }
    }
}
