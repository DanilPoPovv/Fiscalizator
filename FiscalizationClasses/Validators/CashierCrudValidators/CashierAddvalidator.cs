using Fiscalizator.FiscalizationClasses.Dto.Cashier;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.CashierCrudValidators
{
    public class CashierAddvalidator : IValidator<CashierAddDto, CashierCrudDataAccessor, CashierValidationContext>
    {
        public void Validate(CashierAddDto request, CashierCrudDataAccessor validationData, CashierValidationContext validationContext)
        {
            if (validationContext.Client.Cashiers.Any(c => c.Name == request.Name))
                throw new CashierException($"Cashier with name {request.Name} already exists.");
            if (validationContext.Client.Cashiers.Any(c => c.SystemId == request.SystemId))
                throw new CashierException($"Cashier with identifier {request.SystemId} already exists.");
        }
    }
}
