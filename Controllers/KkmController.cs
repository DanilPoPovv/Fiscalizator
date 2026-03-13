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
             _kkmService.AddKkm(kkmDTO);
             return Ok();
        }
        [HttpPut("updateKkm")]
        [Consumes("application/json"), Produces("application/json")]
        public ActionResult UpdateKkm(KkmUpdateDTO kkmDTO)
        {
             _kkmService.UpdateKkm(kkmDTO);
             return Ok();
        }
        [HttpDelete("deleteKkm")]
        public ActionResult DeleteKkm(KkmDeleteDTO deleteDTO)
        {
                _kkmService.DeleteKkm(deleteDTO);
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
