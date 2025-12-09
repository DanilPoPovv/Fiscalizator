using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.KkmCrudValidators
{
    public class KkmUniqueSerialNumberCreateValidator : IValidator<KkmDTO,KkmValidationContext>
    {
        public bool Validate(KkmDTO request, ISession session, out string errorMessage, KkmValidationContext validationContext)
        {
            var clientRepository = new ClientRepository(session);
            var client = clientRepository.GetByCode(request.ClientCode);
            Kkm existingKkm = client.Kkms.FirstOrDefault(k => k.SerialNumber == request.SerialNumber)!;
            if (existingKkm != null)
            {
                errorMessage = "A KKM with the same serial number already exists.";
                return false;
            }
            validationContext.Client = client;
            errorMessage = null;
            return true;
        }
    }
}
