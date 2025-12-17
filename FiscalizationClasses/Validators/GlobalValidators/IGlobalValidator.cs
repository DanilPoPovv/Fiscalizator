using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public interface IGlobalValidator<TContext,TData> where TContext : IValidationContext
    {
        public void Validate(object request, TData validationData, TContext validationContext);
    }
}
