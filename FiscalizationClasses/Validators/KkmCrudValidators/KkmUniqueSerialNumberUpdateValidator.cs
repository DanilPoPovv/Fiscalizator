using Fiscalizator.FiscalizationClasses.Dto.Kkm;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.KkmCrudValidators
{
    public class KkmUniqueSerialNumberUpdateValidator : IValidator<KkmUpdateDTO, KkmCrudDataAccessor,KkmValidationContext>
    {
        public void Validate(KkmUpdateDTO request, KkmCrudDataAccessor validationData, KkmValidationContext validationContext)
        {
            Kkm kkm = validationData.Kkms.GetBySerialNumber(request.NewSerialNumber);
            if (kkm != null && kkm.SerialNumber != request.NewSerialNumber)
            {
                throw new KkmException("you can't update to this serial number, because another kkm with the same serial number already exists.");
            }
        }
    }
}
