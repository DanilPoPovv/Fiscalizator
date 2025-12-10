using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Validators.ValidationContexts
{
    public class ValidationContext : IValidationContext
    {
        public Kkm Kkm { get; set; }
        public Shift CurrentShift { get; set; }
    }
}
