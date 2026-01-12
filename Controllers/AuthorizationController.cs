using Fiscalizator.FiscalizationClasses.Dto.Authorize;
using Fiscalizator.FiscalizationClasses.Dto.User;
using Fiscalizator.FiscalizationClasses.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        [HttpPost("CreateGlobalUser")]
        public IActionResult CreateGlobalUser(CreateGlobalUserDto createUserDto)
        {
            try
            {
                _authorizationService.CreateGlobalUser(createUserDto);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
            return Ok();
        }
        [HttpPost("CreateClientUser")]
        public IActionResult CreateClientUser(CreateClientUserDto createClientUserDto)
        {
            try
            {
                _authorizationService.CreateClientUser(createClientUserDto);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
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
