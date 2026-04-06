using Fiscalizator.FiscalizationClasses.Dto.Authorize;
using Fiscalizator.FiscalizationClasses.Dto.User;
using Fiscalizator.FiscalizationClasses.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Fiscalizator.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthorizationController : ControllerBase 
    {
        private readonly AuthorizationService _authorizationService;
        public AuthorizationController(AuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        [HttpPost("login")]
        public IActionResult Authorize(AuthorizeDto authorizeDto)
        {
            var token = _authorizationService.Login(authorizeDto);
            return Ok(token);
        }
        [HttpPost("CreateGlobalUser")]
        public IActionResult CreateGlobalUser(CreateGlobalAdminDto createUserDto)
        {
            _authorizationService.CreateGlobalUser(createUserDto);
            return Ok();
        }
        [HttpPost("CreateClientUser")]
        public IActionResult CreateClientUser(CreateClientUserDto createClientUserDto)
        {
            _authorizationService.CreateClientUser(createClientUserDto);
            return Ok();
        }
    }
}
