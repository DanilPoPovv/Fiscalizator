using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Dto.User
{
    public class CreateGlobalAdminDto : BaseCreateUser
    {
        public UserRole Role { get; set; }
    }
}
