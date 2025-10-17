using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.Logger;
using Fiscalizator.FiscalizationClasses.Validators;
using System.ComponentModel.DataAnnotations;

namespace Fiscalizator.OperationHandlers
{
    public class BillHandler
    {
        private readonly Logger.Logger _logger;
        private readonly BillValidator _validator;

        public BillHandler(Logger.Logger logger, BillValidator validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public OperationResponse ProcessBill(BillRequest request)
        {
            bool isBillValid = _validator.ValidateBill(request, out string errorMessage);
            if (isBillValid)
            {
                _logger.FileLog($"Processing bill for amount: {request.Amount}");
                return new BillResponse { Message = "Bill processed successfully" };
            }
            _logger.FileLog($"Bill processing failed: {errorMessage}");
            return new BillResponse
            {
                Message = $"Bill processing failed: {errorMessage}"
            };

        }
    }
}
