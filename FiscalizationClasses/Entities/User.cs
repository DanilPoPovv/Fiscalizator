namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual int ClientId { get; set; }
        public virtual string Username { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string Email { get; set; }
    }
}
