namespace Fiscalizator.FiscalizationClasses
{
    public class CloseShiftRequest 
    {
        public DateTime CloseShiftTime { get; set; }

        public string? Cashier { get; set; }
    }
}
