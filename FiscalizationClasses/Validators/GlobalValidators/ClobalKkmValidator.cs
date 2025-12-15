using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalKkmValidator : IGlobalValidator<ValidationContext>
    {
        public void Validate(object request, ISession session, ValidationContext validationContext)
        {
            if (request is not ISerialNumberRequire kkmRequest)
            {
                return;
            }
            KkmRepository kkmRepository = new KkmRepository(session);
            Kkm kkm = kkmRepository.GetBySerialNumber(kkmRequest.SerialNumber);
            if (kkm == null)
            {
                throw new KkmException($"Kkm with serial number {kkmRequest.SerialNumber} does not exist.123");
            }
            validationContext.Kkm = kkm;
        }
    }
}
