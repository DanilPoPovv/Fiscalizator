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

    }
}
