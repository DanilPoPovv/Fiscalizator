using Microsoft.AspNetCore.Mvc;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.OperationHandlers;
namespace Fiscalizator.Controllers
{
    [ApiController]
    [Route("Route(\"api/ShiftOpen\")")]
    public class OpenShiftController : ControllerBase
    {
        private readonly OpenShiftHandler _openShiftHandler;

        public OpenShiftController(OpenShiftHandler openShiftHandler)
        {
            _openShiftHandler = openShiftHandler;
        }
        [HttpPost]
        [Produces("application/xml"), Consumes("application/xml")]
        public ActionResult<OperationResponse> OpenShift(OpenShiftDTO request)
        {
            OperationResponse response;
            response = _openShiftHandler.OpenShift(request);
            return Ok(response);
        }
    }
}
