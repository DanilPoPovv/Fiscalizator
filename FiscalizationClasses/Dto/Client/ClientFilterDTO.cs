using Fiscalizator.FiscalizationClasses.Dto.BaseDtoClasses;

namespace Fiscalizator.FiscalizationClasses.Dto.Client
{
    public class ClientFilterDTO : BasePaginationDto
    {
        public string? ClientCode { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}
