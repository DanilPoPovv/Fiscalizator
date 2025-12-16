using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Validators.ValidationContexts
{
    public class ClientValidationContext : IValidationContext
    {
        public Client Client { get; set; }
    }
}
