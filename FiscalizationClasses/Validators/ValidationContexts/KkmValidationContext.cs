using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces;

namespace Fiscalizator.FiscalizationClasses.Validators.ValidationContexts
{
    public class KkmValidationContext : IValidationContext, IKkmValidationContextRequire, IClientValidationContextRequire
    {
        public Client Client { get; set; }
        public Kkm Kkm { get; set; }
    }
}
