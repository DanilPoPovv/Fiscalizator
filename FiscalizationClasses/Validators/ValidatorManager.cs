using NHibernate.Id.Insert;
using System.Collections.Generic;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class ValidatorManager<TRequest,TContext> where TContext : IValidationContext
    {
        private readonly IEnumerable<IValidator<TRequest,TContext>> _validators;
        private readonly TContext _validationContext;
        public ValidatorManager(IEnumerable<IValidator<TRequest,TContext>> validators)
        {
            _validators = validators;
        }

        public bool ValidateAll(TRequest request, ISession session,out string errorMessage, TContext validationContext = null)
        {
            foreach (var validator in _validators)
            {
                if (!validator.Validate(request, session, out errorMessage, validationContext))
                    return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
