using Fiscalizator.FiscalizationClasses.Dto.Kkm;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;


namespace Fiscalizator.FiscalizationClasses.Validators.KkmCrudValidators
{
    public class KkmUniqueSerialNumberCreateValidator : IValidator<KkmDTO, KkmCrudDataAccessor,KkmValidationContext>
    {
        public void Validate(KkmDTO request, KkmCrudDataAccessor validationData, KkmValidationContext validationContext)
        {
            Kkm kkm = validationData.Kkms.GetBySerialNumber(request.SerialNumber);
            if (kkm != null)
            {
                throw new KkmException("A KKM with the same serial number already exists.");
            }
            validationContext.Kkm = kkm;
        }
    }
}
