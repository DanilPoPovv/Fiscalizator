using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces;
namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public interface IGlobalValidator<TRequest,TData, TContext> where TContext : IValidationContext
    {
        public void Validate(TRequest request, TData validationData, TContext validationContext);
    }
}
