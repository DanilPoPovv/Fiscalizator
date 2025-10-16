using Fiscalizator.FiscalizationClasses;
using Fiscalizator.Logger;

namespace Fiscalizator.OperationHandlers
{
    public class BillHandler
    {
        private readonly Logger.Logger _logger;

        public BillHandler(Logger.Logger logger)
        {
            _logger = logger;
        }

        public OperationResponse ProcessBill(BillRequest request)
        {
            _logger.FileLog($"Processing bill for amount: {request.Amount}");
            return new BillResponse { Message = "Bill processed successfully" };
        }
    }
}
