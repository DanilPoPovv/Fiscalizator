using Microsoft.AspNetCore.Mvc;

namespace Fiscalizator.Controllers
{
    public class AuthorizationController : ControllerBase 
    {
        [HttpGet]
        [Route("api/authorize")]
        public IActionResult Authorize()
        {
            // Dummy authorization logic
            return Ok(new { message = "Authorization successful" });
        }
    }
}
