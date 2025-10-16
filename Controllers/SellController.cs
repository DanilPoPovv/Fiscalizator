using Fiscalizator.FiscalizationClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("Route(\"api/Sell\")")]
public class SellController : Controller
{
    private readonly FiscalizationService _fiscalizationService;

    public SellController(FiscalizationService fiscalizationService)
    {
        _fiscalizationService = fiscalizationService;
    }

    [HttpPost]
    [Produces("application/xml"), Consumes("application/xml")]
    public ActionResult<OperationResponse> Fiscalize([FromBody] BillRequest request)
    {
        var response = _fiscalizationService.Sell(request);
        return Ok(response);
    }
}

