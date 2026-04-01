using Fiscalizator.FiscalizationClasses.Requests;
using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Dto.Client
{
    public class ClientDeleteDTO : IClientCodeRequire
    {
        public int ClientCode { get; set; }
    }
}
