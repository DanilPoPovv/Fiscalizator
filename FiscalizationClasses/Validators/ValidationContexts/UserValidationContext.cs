using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces;

namespace Fiscalizator.FiscalizationClasses.Validators.ValidationContexts
{
    public class UserValidationContext : IValidationContext
    {
        public User User { get; set; }
        public Client Client { get; set; }
    }
}
