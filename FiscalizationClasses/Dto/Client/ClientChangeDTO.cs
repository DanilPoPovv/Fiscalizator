using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.Client
{
    public class ClientChangeDTO 
    {
        public int Id { get; set; }
        public int ClientCode { get; set; }
        public string Address {  get; set; }
        public string Name { get; set; }
    }
}
