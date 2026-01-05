using Fiscalizator.FiscalizationClasses.Dto.Service;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.ServiceOperationValidators
{
    public class IncomeOperationValidator : IValidator<IncomeOperationDto, BaseOperationDataAccessor, ValidationContext>
    {
        public void Validate(IncomeOperationDto request, BaseOperationDataAccessor validationData, ValidationContext validationContext)
        {

        }
    }
}
