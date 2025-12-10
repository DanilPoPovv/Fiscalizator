using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators.BaseCheckServices

{
    public class KkmCheckService 
    {
        public void EnsureKkmExists(int serialNumber, ISession session, ValidationContext validationContext)
        {
            KkmRepository kkmRepository = new KkmRepository(session);
            Kkm kkm = kkmRepository.GetBySerialNumber(serialNumber);
            if (kkm == null)
            {
                throw new KkmException($"There is no KKM with serial number {serialNumber}");
            }
            validationContext.Kkm = kkm;
            return;
        }
    }
}
