using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.KkmCrudValidators
{
    public class KkmUniqueSerialNumberUpdateValidator : IValidator<KkmUpdateDTO,KkmValidationContext>
    {
        public void Validate(KkmUpdateDTO request, ISession session,KkmValidationContext validationContext)
        {
            ClientRepository clientRepository = new ClientRepository(session);
            Client client = clientRepository.GetByCode(request.ClientCode);
            Kkm kkm = client.Kkms.FirstOrDefault(k => k.SerialNumber == request.NewSerialNumber)!;
            if (kkm != null)
            {
                throw new KkmException("you can't update to this serial number, because another kkm with the same serial number already exists.");
            }
            validationContext.Client = client;
        }
    }
}
