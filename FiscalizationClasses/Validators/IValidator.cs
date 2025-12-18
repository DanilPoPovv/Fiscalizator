using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators
{
    public interface IValidator <Validatable,Data,ValidationContext> where ValidationContext : IValidationContext
    {
        public void Validate(Validatable validate, Data validationData, ValidationContext validationContext = null!);
    }
}
