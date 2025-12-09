using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class ValidationContext : IValidationContext
    {
        public Kkm Kkm { get; set; }    
        public Shift СurrentShift { get; set; }
    }
}
