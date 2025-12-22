
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces;

namespace Fiscalizator.FiscalizationClasses.Validators.ValidationContexts
{
    public class CashierValidationContext : ValidationContext, IClientValidationContextRequire
    {
        public Client Client { get; set; }
        public Cashier Cashier { get; set; }
    }
}
