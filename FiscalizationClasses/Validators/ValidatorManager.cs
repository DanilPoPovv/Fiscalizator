using NHibernate.Id.Insert;
using System.Collections.Generic;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class ValidatorManager<TRequest>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ValidationContext _validationContext = new ValidationContext();
        public ValidatorManager(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public bool ValidateAll(TRequest request, ISession session,out string errorMessage)
        {
            foreach (var validator in _validators)
            {
                if (!validator.Validate(request, _validationContext, session, out errorMessage))
                    return false;
            }

            errorMessage = string.Empty;
            return true;
        }
        public ValidationContext GetValidationContext() => _validationContext;
    }
}
