using Microsoft.AspNetCore.Mvc;
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.OperationHandlers;
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
        public ActionResult<OperationResponse> CloseShift(CloseShiftDTO request)
        {
            OperationResponse response;
            response = _closeShiftHandler.ProcessCloseShift(request);
            return Ok(response);
        }
    }
}
