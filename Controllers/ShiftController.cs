using Fiscalizator.FiscalizationClasses.Dto.Shift;
using Fiscalizator.FiscalizationClasses.OperationHandlers;
using Fiscalizator.FiscalizationClasses.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fiscalizator.Controllers
{
    [ApiController]
    public class ShiftController : ControllerBase 
    {
        private readonly OpenShiftHandler _openShiftHandler;
        private readonly CloseShiftHandler _closeShiftHandler;

        public ShiftController(OpenShiftHandler openShiftHandler, CloseShiftHandler closeShiftHandler)
        {
            _openShiftHandler = openShiftHandler;
            _closeShiftHandler = closeShiftHandler;
        }
        [HttpPost("open")]
        [Produces("application/xml"), Consumes("application/xml")]
        public ActionResult<OperationResponse> OpenShift(OpenShiftDTO request)
        {
            OperationResponse response;
            response = _openShiftHandler.OpenShift(request);
            return Ok(response);
        }
        [HttpPost("close")]
        [Produces("application/xml"), Consumes("application/xml")]
        public ActionResult<OperationResponse> CloseShift(CloseShiftDTO request)
        {
            OperationResponse response;
            response = _closeShiftHandler.ProcessCloseShift(request);
            return Ok(response);
        }
    }
}
