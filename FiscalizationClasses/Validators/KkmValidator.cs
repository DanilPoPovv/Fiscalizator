using Fiscalizator.Repository;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Dto;
using System.ComponentModel.DataAnnotations;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class KkmValidator : IValidator<BillDTO>
    {
        public bool Validate(BillDTO billDTO, ValidationContext validationContext, out string errorMessage)
        {
            if (!ValidateSerialNumber(billDTO.SerialNumber, validationContext, out errorMessage))
                return false;
            if (!ValidateShiftOpen(validationContext, out errorMessage))
                return false; 
            return true;
        }
        private bool ValidateSerialNumber(int serialNumber, ValidationContext validationContext, out string errorMessage) 
        {
            KkmRepository kkmRepo = new KkmRepository(NHibernateHelper.OpenSession());
            validationContext.kkm = kkmRepo.GetBySerialNumber(serialNumber);
            if (validationContext.kkm == null)
            {
                errorMessage = $"There is no kkm with {serialNumber} serialNumber";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
        private bool ValidateShiftOpen(ValidationContext validationContext, out string errorMessage)
        {
            validationContext.currentShift = validationContext.kkm.Shifts.LastOrDefault(s => s.ClosureDateTime == null);
            if (validationContext.currentShift == null)
            {
                errorMessage = $"No opened shift for this KKM";
                return false ;
            }
            errorMessage = string.Empty;
            return true;
        }     
    }
}
