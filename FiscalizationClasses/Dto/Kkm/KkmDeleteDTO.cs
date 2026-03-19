using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.Kkm
{
    public class KkmDeleteDTO : ISerialNumberRequire, IClientCodeRequire
    {
        public int SerialNumber { get; set; }
        public int ClientCode { get; set; }
    }
}
