using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Validators.ValidationContexts
{
    public class ValidationContext : IValidationContext, IKkmValidationContextRequire, ICashierValidationContextRequire
    {
        public Kkm Kkm { get; set; }
        public Shift CurrentShift { get; set; }
        public Cashier Cashier { get; set; }
    }
}
