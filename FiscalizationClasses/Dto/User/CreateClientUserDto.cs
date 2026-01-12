using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.User
{
    public class CreateClientUserDto : IClientCodeRequire
    {
        public int ClientCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
