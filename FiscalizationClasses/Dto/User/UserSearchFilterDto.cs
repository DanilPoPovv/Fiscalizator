using Fiscalizator.FiscalizationClasses.Dto.BaseDtoClasses;

namespace Fiscalizator.FiscalizationClasses.Dto.User
{
    public class UserSearchFilterDto : BasePaginationDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
