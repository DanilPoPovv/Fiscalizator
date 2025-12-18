using Fiscalizator.FiscalizationClasses.Dto.Kkm;
using Fiscalizator.FiscalizationClasses.Services;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
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
        public ActionResult CreateKkm(KkmDTO kkmDTO)
        {
            try
            {
                _kkmService.AddKkm(kkmDTO);
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
        public ActionResult DeleteKkm(KkmDeleteDTO deleteDTO)
        {
            try
            {
                _kkmService.DeleteKkm(deleteDTO);
                return Ok();
            }
            catch (KkmException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
            
        }
        [HttpGet("getKkms")]
        public ActionResult GetAllClientKkms(int clientCode)
        {
            var kkms = _kkmService.GetAllClientKkm(clientCode);
            return Ok(kkms);
        }
    }

}
