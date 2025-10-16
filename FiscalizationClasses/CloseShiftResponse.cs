namespace Fiscalizator.FiscalizationClasses
{
    public class CloseShiftResponse : OperationResponse
    {
        public DateTime CloseShiftTime { get; set; }
        public string? Cashier {  get; set; }
    }
}
