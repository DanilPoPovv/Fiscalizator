using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.Logger;
namespace Fiscalizator.OperationHandlers
{
    public class OpenShiftHandler
    {
        private readonly Logger.Logger _logger;

        public OpenShiftHandler(Logger.Logger logger)
        {
            _logger = logger;
        }

        public OpenShiftResponse OpenShift(OpenShiftRequest request)
        {
            _logger.FileLog($"Shift has been opened at {request.OpenShiftTime}");
            return new OpenShiftResponse { Message = "Shift opened successfully", OpenShiftTime = request.OpenShiftTime, Cashier = request.Cashier };
        }
    }
}


