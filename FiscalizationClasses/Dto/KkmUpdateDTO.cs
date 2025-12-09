namespace Fiscalizator.FiscalizationClasses.Dto
{
    public class KkmUpdateDTO 
    {
        public int ClientCode { get; set; }
        public int OldSerialNumber { get; set; }
        public int NewSerialNumber { get; set; }
        public string? Location { get; set; }
    }
}
