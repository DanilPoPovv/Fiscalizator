using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.Kkm
{
    public class KkmUpdateDTO : IClientCodeRequire
    {
        public int ClientCode { get; set; }
        public int KkmId { get; set; }
        public int NewSerialNumber { get; set; }
        public string? Location { get; set; }
    }
}
