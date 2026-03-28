using Fiscalizator.FiscalizationClasses.Dto.Kkm;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.Validators.KkmCrudValidators
{
    public class KkmUpdateValidator : IValidator<KkmUpdateDTO, KkmCrudDataAccessor,KkmValidationContext>
    {
        public void Validate(KkmUpdateDTO request, KkmCrudDataAccessor validationData, KkmValidationContext validationContext)
        {
            var kkm = validationData.Kkms.GetById(request.KkmId);
            if (kkm == null)
            {
                throw new KkmException($"Kkm with id - {request.KkmId} doesn't exists in system");
            }
            var isNewSerialNumberExists = validationData.Kkms.GetBySerialNumber(request.NewSerialNumber) != null;
            if (isNewSerialNumberExists)
            {
                throw new KkmException($"Kkm with serial number {request.NewSerialNumber} already exists in system");
            }
            validationContext.Kkm = kkm;
        }
    }
}
