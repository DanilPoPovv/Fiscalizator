using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class BillValidator : IBillValidator
    {
        public bool ValidateBill(BillRequest request, out string errorMessage)
        {
            if (!ValidAmount(request.Amount, out errorMessage))
                return false;

            if (!ValidCommodity(request.Amount, request.Commodity, out errorMessage))
                return false;
            return true;
        }
        private bool ValidAmount(decimal amount, out string errorMessage)
        {
            bool isValid = amount > 0;
            errorMessage = isValid ? string.Empty : "Amount must be greater than zero.";
            return isValid;
        }
        private bool ValidCommodity(decimal amount,Commodity[] commodities, out string errorMessage)
        {
            if (commodities == null || commodities.Length == 0)
            {
                errorMessage = "At least one commodity is required.";
                return false;
            }
            int commoditiesSum = 0;
            foreach (var commodity in commodities)
            {
                commoditiesSum += commodity.Price * commodity.Quantity;
            }
            bool isValid = commoditiesSum == amount;
            errorMessage = isValid ? string.Empty : "Sum of commodities does not match the amount.";
            return isValid;
        }
        private bool ValidateTax(Tax tax,int commoditySum, out string errorMessage)
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
    }
}
