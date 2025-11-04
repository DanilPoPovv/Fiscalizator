using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Fiscalizator.Controllers
{
    [Route("Client/{clientCode}/Kkm")]
    public class KkmController : ControllerBase
    {
        private readonly KkmService _kkmService = new KkmService();
        [HttpPost("createKkm")]
        public ActionResult CreateKkm(int clientCode, KkmDTO kkmDTO)
        {
            _kkmService.AddKKm(clientCode, kkmDTO);
            return Ok();
        }
        [HttpPut("updateKkm")]
        public ActionResult UpdateKkm(int clientCode, KkmDTO kkmDTO)
        {
            _kkmService.UpdateKkm(kkmDTO);
            return Ok();
        }
        [HttpDelete("deleteKkm")]
        public ActionResult DeleteKkm(KkmDTO kkmDTO)
        {
            _kkmService.DeleteKkm(kkmDTO);
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
