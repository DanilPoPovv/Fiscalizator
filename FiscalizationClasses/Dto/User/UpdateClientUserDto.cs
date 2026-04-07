using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Dto.User
{
    public class UpdateClientUserDto : BaseUpdateDto
    {
        public UserRole Role { get; set; }
    }
}
