using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("Sell")]
public class SellController : ControllerBase
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
        var response = _fiscalizationService.Sell(request.Bill);
        return Ok(response);
    }
}

