using Fiscalizator.FiscalizationClasses;
using Fiscalizator.Logger;
using System.Security.Cryptography.X509Certificates;

namespace Fiscalizator.OperationHandlers
{
    public class CloseShiftHandler
    {
        private readonly Logger.Logger _logger;

        public CloseShiftHandler(Logger.Logger logger)
        {
            _logger = logger;
        }

        public CloseShiftResponse ProcessCloseShift(CloseShiftRequest request)
        {
            _logger.FileLog($"Shift has been closed at {request.CloseShiftTime}");

            return new CloseShiftResponse { Message = "Shift closed successfully", CloseShiftTime = request.CloseShiftTime, };
        }
    }
}
