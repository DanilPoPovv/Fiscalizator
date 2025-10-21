using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Responses;

namespace Fiscalizator.OperationHandlers
{
    public class CloseShiftHandler
    {
        private readonly Logger.Logger _logger;

        public CloseShiftHandler(Logger.Logger logger)
        {
            _logger = logger;
        }

        public CloseShiftResponse ProcessCloseShift(CloseShiftDTO request)
        {
            _logger.FileLog($"Shift has been closed at {request.CloseShiftTime}");

            return new CloseShiftResponse { Message = "Shift closed successfully", CloseShiftTime = request.CloseShiftTime, };
        }
    }
}
