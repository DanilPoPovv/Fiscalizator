using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces
{
    public interface IClientValidationContextRequire 
    {
        public Client Client { get; set; }
    }
}
