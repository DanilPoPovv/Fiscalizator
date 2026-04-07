using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.User
{
    public class CreateClientUserDto : BaseCreateUser, IClientCodeRequire
    {
        public UserRole Role { get; set; }
        public int ClientCode { get; set; }

    }
}
