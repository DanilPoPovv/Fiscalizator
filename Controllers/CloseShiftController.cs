using Microsoft.AspNetCore.Mvc;
using Fiscalizator.OperationHandlers;
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Responses;
namespace Fiscalizator.Controllers
{
    [ApiController]
    [Route("Route(\"api/CloseShift\")")]
    public class CloseShiftController : Controller
    {
        private readonly CloseShiftHandler _closeShiftHandler;

        public CloseShiftController(CloseShiftHandler closeShiftHandler)
        {
            _closeShiftHandler = closeShiftHandler;
        }
        [HttpPost]
        [Produces("application/xml"), Consumes("application/xml")]
        public ActionResult<OperationResponse> CloseShift(CloseShiftRequest request)
        {
            OperationResponse response;
            response = _closeShiftHandler.ProcessCloseShift(request);
            return Ok(response);
        }
    }
}
