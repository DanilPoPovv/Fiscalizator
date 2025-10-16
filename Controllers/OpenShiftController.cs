using Fiscalizator.FiscalizationClasses;
using Microsoft.AspNetCore.Mvc;
using Fiscalizator.OperationHandlers;
namespace Fiscalizator.Controllers
{
    [ApiController]
    [Route("Route(\"api/ShiftOpen\")")]
    public class OpenShiftController : Controller
    {
        private readonly OpenShiftHandler _openShiftHandler;

        public OpenShiftController(OpenShiftHandler openShiftHandler)
        {
            _openShiftHandler = openShiftHandler;
        }
        [HttpPost]
        [Produces("application/xml"), Consumes("application/xml")]
        public ActionResult<OperationResponse> OpenShift(OpenShiftRequest request)
        {
            OperationResponse response;
            response = _openShiftHandler.OpenShift(request);
            return Ok(response);
        }
    }
}
