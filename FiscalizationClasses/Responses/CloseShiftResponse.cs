namespace Fiscalizator.FiscalizationClasses.Responses
{
    public class CloseShiftResponse : OperationResponse
    {
        public DateTime CloseShiftTime { get; set; }
        public string? Cashier { get; set; }
    }
}
