using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Validators.ValidationContexts
{
    public interface ICashierValidationContextRequire
    {
        public Cashier Cashier { get; set; }
    }
}
