using Fiscalizator.FiscalizationClasses.Dto.User;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fiscalizator.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("SearchAdmin")]
        public ActionResult SearchGlobalAdmins(UserSearchFilterDto userSearchFilterDto)
        {
            var globalAdmins = _userService.SearchAdmins(userSearchFilterDto);
            return Ok(globalAdmins);
        }
        [HttpPost("SearchUsers")]
        public ActionResult SearchClientUsers(UserSearchFilterDto userSearchFilterDto)
        {
            return Ok();
        }
        [HttpPost("CreateClientUser")]
        public ActionResult CreateClientUser(CreateClientUserDto createUserDto)
        {
            return Ok();
        }
        [HttpPost("CreateGlobalAdmin")]
        public ActionResult CreateGlobalAdmin(CreateAdminDto createAdminDto)
        {
            var admin = _userService.CreateAdmin(createAdminDto);
            return Ok(admin);
        }
        [HttpPut("UpdateAdmin")]
        public ActionResult UpdateAdmin(UpdateAdminDto updateUserDto)
        {
            var updatedAdmin = _userService.UpdateAdmin(updateUserDto);
            return Ok(updatedAdmin);
        }
        [HttpPut("UpdateUser")]
        public ActionResult UpdateClientUser(UpdateClientUserDto updateUserDto)
        {
            return Ok();
        }
        [HttpDelete("Delete")]
        public ActionResult DeleteUser(UserDeleteDto userDeleteDto)
        {
            _userService.DeleteUser(userDeleteDto);
            return Ok();
        }
    }
}
