using Fiscalizator.FiscalizationClasses.Validators.GlobalValidators;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using NHibernate.Id.Insert;
using System.Collections.Generic;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class ValidatorManager<TRequest,TContext> where TContext : IValidationContext
    {
        private readonly IEnumerable<IValidator<TRequest,TContext>> _validators;
        private readonly IEnumerable<IGlobalValidator<TContext>> _globalValidators;
        private readonly TContext _validationContext;
        public ValidatorManager(IEnumerable<IValidator<TRequest,TContext>> validators, IEnumerable<IGlobalValidator<TContext>> GlobalValidators)
        {
            _validators = validators;
            _globalValidators = GlobalValidators;
        }

        public void ValidateAll(TRequest request, ISession session, TContext validationContext = null)
        {
            foreach (var globalValidator in _globalValidators)
            {
                globalValidator.Validate(request, session, validationContext);
            }
            foreach (var validator in _validators)
            {
                validator.Validate(request, session, validationContext);
            }
        }
    }
}
