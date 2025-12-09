using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Services;
using Fiscalizator.FiscalizationClasses.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Fiscalizator.Controllers
{
    [Route("Client/Kkm")]
    [ApiController]
    public class KkmController : ControllerBase
    {
        KkmService _kkmService;
        public KkmController (KkmService kkmService)
        {
            _kkmService = kkmService;
        }
        [HttpPost("createKkm")]
        public ActionResult CreateKkm(int clientCode, KkmDTO kkmDTO)
        {
            try
            {
                _kkmService.AddKkm(clientCode, kkmDTO);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
        }
        [HttpPut("updateKkm")]
        [Consumes("application/json"), Produces("application/json")]
        public ActionResult UpdateKkm(KkmUpdateDTO kkmDTO)
        {
            try
            {
                _kkmService.UpdateKkm(kkmDTO);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
        }
        [HttpDelete("deleteKkm")]
        public ActionResult DeleteKkm(int serialNumber)
        {
            _kkmService.DeleteKkm(serialNumber);
            return Ok();
        }
        [HttpGet("getKkms")]
        public ActionResult GetAllClientKkms(int clientCode)
        {
            var kkms = _kkmService.GetAllClientKkm(clientCode);
            return Ok(kkms);
        }
    }

}
