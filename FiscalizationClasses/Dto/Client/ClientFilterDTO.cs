namespace Fiscalizator.FiscalizationClasses.Dto.Client
{
    public class ClientFilterDTO
    {
        public string? ClientCode { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
