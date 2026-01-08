using Fiscalizator.FiscalizationClasses.Dto.Service;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.ServiceOperationValidators
{
    public class OutcomeOperationValidator : IValidator<OutcomeOperationDto,BaseOperationDataAccessor,OutcomeCashVContext>
    {
        public void Validate(OutcomeOperationDto request, BaseOperationDataAccessor validationData, OutcomeCashVContext validationContext)
        {
           
        }
    }
}
