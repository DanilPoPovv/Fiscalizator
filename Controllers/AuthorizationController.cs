using Fiscalizator.FiscalizationClasses.Dto.Authorize;
using Fiscalizator.FiscalizationClasses.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fiscalizator.Controllers
{
    [ApiController]
    public class AuthorizationController : ControllerBase 
    {
        private readonly AuthorizationService _authorizationService;
        public AuthorizationController(AuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        [HttpPost("Authorize")]
        public IActionResult Authorize(AuthorizeDto authorizeDto)
        {
            try
            {
                _authorizationService.Login(authorizeDto);
            }
            catch(UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
            return Ok();
        }
        [HttpPost("CreateUser")]
        public IActionResult CreateUser(CreateUserDto createUserDto)
        {
            try
            {
                _authorizationService.CreateUser(createUserDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
            return Ok();
        }
    }
}
