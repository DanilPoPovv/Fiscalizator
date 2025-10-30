using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators.Helpers
{
    public static class KkmHelper
    {
        public static bool ValidateSerialNumber(int serialNumber, ValidationContext context, out string errorMessage)
        {
            NHibernateHelper.OpenSession();
            var repo = new KkmRepository(NHibernateHelper.OpenSession());
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
