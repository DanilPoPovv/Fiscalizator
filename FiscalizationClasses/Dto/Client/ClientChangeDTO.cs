using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.Client
{
    public class ClientChangeDTO 
    {
        public int ClientId { get; set; }
        public int Code { get; set; }
        public string Location {  get; set; }
        public string Name { get; set; }
    }
}
