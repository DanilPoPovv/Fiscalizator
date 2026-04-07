namespace Fiscalizator.FiscalizationClasses.Dto.User
{
    public class BaseUpdateDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
