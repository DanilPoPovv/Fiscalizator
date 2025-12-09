using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.Repository;
using NHibernate.Mapping.ByCode.Impl;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.KkmCrudValidators
{
    public class KkmUniqueSerialNumberUpdateValidator : IValidator<KkmUpdateDTO,KkmValidationContext>
    {
        public bool Validate(KkmUpdateDTO request, ISession session, out string errorMessage, KkmValidationContext validationContext)
        {
            ClientRepository clientRepository = new ClientRepository(session);
            Client client = clientRepository.GetByCode(request.ClientCode);
            Kkm kkm = client.Kkms.FirstOrDefault(k => k.SerialNumber == request.NewSerialNumber)!;
            if (kkm != null)
            {
                errorMessage = "you can't update to this serial number, because another kkm with the same serial number already exists.";
                return false;
            }
            validationContext.Client = client;
            validationContext.Kkm = kkm;
            errorMessage = null;
            return true;
        }
    }
}
