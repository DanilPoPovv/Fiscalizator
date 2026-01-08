using Fiscalizator.FiscalizationClasses.Dto.Service;
using Fiscalizator.FiscalizationClasses.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fiscalizator.Controllers
{
    [ApiController]
    [Route("Cash")]
    public class CashController : ControllerBase
    {
        private readonly FiscalizationService _fiscalizationService;
        public CashController(FiscalizationService fiscalizationService)
        {
            _fiscalizationService = fiscalizationService;
        }
        [HttpPost("Income")]
        public ActionResult<OperationResponse> Income(IncomeOperationDto incomeDto)
        {
            OperationResponse response = _fiscalizationService.Income(incomeDto);
            return Ok(response);
        }
        [HttpPost("Outcome")]
        public ActionResult Outcome(OutcomeOperationDto outcomeDto) 
        {
            OperationResponse response = _fiscalizationService.Outcome(outcomeDto);
            return Ok(response);
        }
    }
}
