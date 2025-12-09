using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class KkmValidationContext : IValidationContext
    {
        public Client Client { get; set; }
        public Kkm Kkm { get; set; }
    }
}
