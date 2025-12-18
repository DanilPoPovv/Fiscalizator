using Microsoft.AspNetCore.Mvc;
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.OperationHandlers;
using Fiscalizator.FiscalizationClasses.Dto.Shift;
namespace Fiscalizator.Controllers
{
    [ApiController]
    [Route("CloseShift")]
    public class CloseShiftController : ControllerBase
    {
        private readonly CloseShiftHandler _closeShiftHandler;

        public CloseShiftController(CloseShiftHandler closeShiftHandler)
        {
            _closeShiftHandler = closeShiftHandler;
        }
        [HttpPost]
        [Produces("application/xml"), Consumes("application/xml")]
        public ActionResult<OperationResponse> CloseShift(CloseShiftDTO request)
        {
            OperationResponse response;
            response = _closeShiftHandler.ProcessCloseShift(request);
            return Ok(response);
        }
    }
}
