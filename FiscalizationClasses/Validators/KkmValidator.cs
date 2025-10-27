using Fiscalizator.Repository;
using Fiscalizator.FiscalizationClasses.Entities;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class KkmValidator 
    {
        private Kkm kkm;
        public bool ValidateKkm(int serialNumber,DateTime billTime, out string errorMessage)
        {
            if (!ValidateSerialNumber(serialNumber,out errorMessage))
                return false;
            if (!ValidateShiftOpen(out errorMessage))
                return false; 
            if (!ValidateBillTime(billTime,out errorMessage))
                return false;
            return true;
        }
        private bool ValidateSerialNumber(int serialNumber, out string errorMessage) 
        {
            KkmRepository kkmRepo = new KkmRepository(NHibernateHelper.OpenSession());
            kkm = kkmRepo.GetBySerialNumber(serialNumber);
            if (kkm == null)
            {
                errorMessage = $"There is no kkm with {serialNumber} serialNumber";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
        private bool ValidateShiftOpen(out string errorMessage)
        {
            Shift curentShift = kkm.Shifts.LastOrDefault(s => s.ClosureDateTime == null);
            if (curentShift == null)
            {
                errorMessage = $"No opened shift for this KKM";
                return false ;
            }
            errorMessage = string.Empty;
            return true;
        }
        private bool ValidateBillTime(DateTime billTime, out string errorMessage)
        {
            var lastBill = kkm.Bills.OrderByDescending(b => b.OperationDateTime).First();
            if (lastBill.OperationDateTime > billTime)
            {
                errorMessage = "Current check is earlier than last";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
    }
}
