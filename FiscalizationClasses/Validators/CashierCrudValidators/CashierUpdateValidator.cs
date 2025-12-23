using Fiscalizator.FiscalizationClasses.Dto.Cashier;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using FluentNHibernate.Conventions;

namespace Fiscalizator.FiscalizationClasses.Validators.CashierCrudValidators
{
    public class CashierUpdateValidator : IValidator<CashierUpdateDto, CashierCrudDataAccessor, CashierValidationContext>
    {
        public void Validate(CashierUpdateDto request, CashierCrudDataAccessor validationData, CashierValidationContext validationContext)
        {
            Cashier Cashier = validationContext.Cashier;

            if (string.IsNullOrEmpty(request.CashierName) && validationContext.Client.Cashiers.Any(c => c.Name == request.NewCashierName))
                throw new CashierException($"Cashier with name {request.NewCashierName} already exists.");

            if (request.NewSystemId != null && validationContext.Client.Cashiers.Any(c => c.SystemId == request.NewSystemId))
                throw new CashierException($"Cashier with identifier {request.NewSystemId} already exists.");

        }
    }
}
