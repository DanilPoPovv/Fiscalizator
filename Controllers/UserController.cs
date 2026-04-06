using Fiscalizator.FiscalizationClasses.Dto.User;
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
        public class UserSearchFilterDto
        {
            public string? Name { get; set; }
            public string? Email { get; set; }
        }
       
        [HttpPost("SearchAdmin")]
        public ActionResult SearchGlobalAdmins(UserSearchFilterDto userSearchFilterDto)
        {
            
        }
        [HttpPost("SearchUsers")]
        public ActionResult SearchUsers(UserSearchFilterDto userSearchFilterDto)
        {

        }
        /// У меня в системе есть глобальные админы, чья область видимости не ограничена и локальные пользователи и админы, их область ограничена страницей 
        // клиента стоит ли разделять эндпоинты?
        [HttpPost]
        public ActionResult CreateUser(CreateUserDto createUserDto)
        {

        }
        [HttpPut]
        public ActionResult UpdateUser(UpdateUserDto updateUserDto)
        {

        }
        [HttpDelete]
        public ActionResult DeleteUser(UserDeleteDto userDeleteDto)
        {

        }
    }
}
