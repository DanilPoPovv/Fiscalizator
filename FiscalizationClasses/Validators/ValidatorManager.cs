using Fiscalizator.FiscalizationClasses.Dto;
using System.Collections.Generic;

namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class ValidatorManager
    {
        private readonly IEnumerable<IValidator<BillDTO>> _validators;
        private ValidationContext _validationContext = new ValidationContext();
        public ValidatorManager(IEnumerable<IValidator<BillDTO>> validators)
        {
            _validators = validators;
        }

        public bool ValidateAll(BillDTO request, out string errorMessage)
        {
            foreach (var validator in _validators)
            {
                if (!validator.Validate(request, _validationContext, out errorMessage))
                    return false; 
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
