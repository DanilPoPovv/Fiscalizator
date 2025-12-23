using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces;
namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public interface IGlobalValidator<TData, TContext> where TContext : IValidationContext
    {
        public void Validate(object request, TData validationData, TContext validationContext);
    }
}
