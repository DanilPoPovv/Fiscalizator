using System.Text.Json.Serialization;

namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        [JsonIgnore]
        public virtual int ClientId { get; set; }
        public virtual string Username { get; set; }
        public virtual UserRole Role { get; set; }
        [JsonIgnore]
        public virtual string PasswordHash { get; set; }
        public virtual string Email { get; set; }
    }
}
