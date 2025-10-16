namespace Fiscalizator.FiscalizationClasses.Validators
{
    public interface IBillValidator
    {
        public bool ValidateBill(BillRequest request,out string errorMessage);
    }
}
