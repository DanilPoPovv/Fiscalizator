using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.Client
{
    public class ClientDTO : IClientCodeRequire
    {
        public int ClientCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
