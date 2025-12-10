using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.KkmCrudValidators
{
    public class KkmUniqueSerialNumberCreateValidator : IValidator<KkmDTO,KkmValidationContext>
    {
        public void Validate(KkmDTO request, ISession session, KkmValidationContext validationContext)
        {
            var clientRepository = new ClientRepository(session);
            var client = clientRepository.GetByCode(request.ClientCode);
            Kkm existingKkm = client.Kkms.FirstOrDefault(k => k.SerialNumber == request.SerialNumber)!;
            if (existingKkm != null)
            {
                throw new KkmException("A KKM with the same serial number already exists.");
            }
            validationContext.Client = client;
            validationContext.Kkm = existingKkm;
        }
    }
}
