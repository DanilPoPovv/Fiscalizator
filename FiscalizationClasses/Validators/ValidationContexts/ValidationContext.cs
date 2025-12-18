using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Validators.ValidationContexts
{
    public class ValidationContext : IValidationContext, IKkmValidationContextRequire, ICashierValidationContextRequire, IShiftOpenValidationContextRequire
    {
        public Kkm Kkm { get; set; }
        public Shift Shift { get; set; }
        public Cashier Cashier { get; set; }
    }
}
