using Fiscalizator.FiscalizationClasses.Dto.Cashier;
using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Services;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Fiscalizator.Controllers
{
    [ApiController]
    [Route("Cashiers")]
    public class CashiersController : ControllerBase
    {
        private readonly CashierService _cashierService;

        public CashiersController(CashierService cashierService)
        {
            _cashierService = cashierService;
        }

        [HttpPost("Add")]
        [Produces("application/json"), Consumes("application/json")]
        public ActionResult AddCashier(CashierAddDto request)
        {
            try
            {
                _cashierService.AddCashier(request);
                return Ok();
            }
            catch (CashierException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
        }

        [HttpPut("Change")]
        [Produces("application/json"), Consumes("application/json")]
        public ActionResult UpdateCashier(CashierUpdateDto request)
        {
            try
            {
                _cashierService.UpdateCashier(request);
                return Ok();
            }
            catch (CashierException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);            
            }
        }

        [HttpDelete("Delete")]
        [Produces("application/json")]
        public ActionResult DeleteCashier(CashierDeleteDTO cashierDeleteDTO)
        {
            try
            {
                _cashierService.DeleteCashier(cashierDeleteDTO);
                return Ok();
            }
            catch (CashierException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
        }

        [HttpGet("GetAllClientCashier")]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Client>> GetAllClientCashier(int ClientCode)
        {
            try
            {
                var cashiers = _cashierService.GetAllClientCashiers(ClientCode);
                return Ok(cashiers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
