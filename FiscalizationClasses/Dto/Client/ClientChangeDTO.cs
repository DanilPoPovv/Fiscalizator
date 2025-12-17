using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.Client
{
    public class ClientChangeDTO : IClientCodeRequire
    {
        public int ClientCode { get; set; }
        public int OldCode { get; set; }
        public string Location {  get; set; }
        public string Name { get; set; }
    }
}
