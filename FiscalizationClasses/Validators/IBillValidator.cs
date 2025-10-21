using Fiscalizator.FiscalizationClasses.Dto;

namespace Fiscalizator.FiscalizationClasses.Validators
{
    public interface IBillValidator
    {
        public bool ValidateBill(BillDTO request,out string errorMessage);
    }
}
