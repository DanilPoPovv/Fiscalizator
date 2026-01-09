using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Dto.Authorize
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
