using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces;

namespace Fiscalizator.FiscalizationClasses.Validators.ValidationContexts
{
    public class ClientValidationContext : IValidationContext, IClientValidationContextRequire
    {
        public Client Client { get; set; }
    }
}
