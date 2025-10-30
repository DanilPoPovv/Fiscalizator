using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators.Helpers
{
    public static class KkmHelper
    {
        public static bool ValidateSerialNumber(int serialNumber, ValidationContext context, ISession session, out string errorMessage)
        {
            var repo = new KkmRepository(session);
            context.Kkm = repo.GetBySerialNumber(serialNumber);

            if (context.Kkm == null)
            {
                errorMessage = $"There is no KKM with serial number {serialNumber}";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}