using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto
{
    public class KkmDeleteDTO : ISerialNumberRequire
    {
        public int SerialNumber { get; set; }
    }
}
