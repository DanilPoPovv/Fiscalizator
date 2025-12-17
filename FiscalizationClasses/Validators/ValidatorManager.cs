using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.GlobalValidators;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class ValidatorManager<TRequest,TData,TContext> where TContext : IValidationContext
    {
        private readonly IEnumerable<IValidator<TRequest,TData,TContext>> _validators;
        private readonly IEnumerable<IGlobalValidator<TContext,TData>> _globalValidators;
        public ValidatorManager(IEnumerable<IValidator<TRequest, TData, TContext>> validators, IEnumerable<IGlobalValidator<TContext, TData>> GlobalValidators)
        {
            _validators = validators;
            _globalValidators = GlobalValidators;
        }

        public void ValidateAll(TRequest request, TData validationData, TContext validationContext = null)
        {
            foreach (var globalValidator in _globalValidators)
            {
                globalValidator.Validate(request, validationData, validationContext);
            }
            foreach (var validator in _validators)
            {
                validator.Validate(request, validationData, validationContext);
            }
        }
    }
}
