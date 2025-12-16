using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto
{
    public class KkmUpdateDTO  : ISerialNumberRequire
    {
        public int ClientCode { get; set; }
        public int SerialNumber { get; set; }
        public int NewSerialNumber { get; set; }
        public string? Location { get; set; }
    }
}
