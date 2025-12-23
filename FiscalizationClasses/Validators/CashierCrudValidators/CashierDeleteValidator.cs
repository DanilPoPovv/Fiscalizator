using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.CashierCrudValidators
{
    public class CashierDeleteValidator : IValidator<ClientDeleteDTO, CashierCrudDataAccessor, CashierValidationContext>
    {
        public void Validate(ClientDeleteDTO request, CashierCrudDataAccessor validationData, CashierValidationContext validationContext)
        {
            
        }
    }
}
