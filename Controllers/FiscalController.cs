using Fiscalizator.FiscalizationClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("Route(\"api/fiscalize\")")]
public class FiscalController : Controller
{
    private readonly FiscalizationService _fiscalizationService;

    public FiscalController(FiscalizationService fiscalizationService)
    {
        _fiscalizationService = fiscalizationService;
    }

    [HttpPost]
    [Produces("application/xml"), Consumes("application/xml")]
    public ActionResult<BillResponse> Fiscalize([FromBody] BillRequest request)
    {
        var response = _fiscalizationService.ProcessOperation(request);
        return Ok(response);
    }
}

