using Fiscalizator.FiscalizationClasses.Dto.Kkm;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.KkmCrudValidators
{
    public class KkmDeleteValidator : IValidator<KkmDeleteDTO,KkmCrudDataAccessor, KkmValidationContext>
    {
        public void Validate(KkmDeleteDTO request, KkmCrudDataAccessor validationData, KkmValidationContext validationContext)
        {
            if (validationContext.Kkm.Bills.Count > 0) 
            {
                throw new KkmException("Cannot delete KKM with associated bills.");
            }

        }
    }
}
