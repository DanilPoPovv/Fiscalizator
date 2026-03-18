using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.User
{
    public class CreateClientUserDto : CreateGlobalUserDto, IClientCodeRequire
    {
        public int ClientCode { get; set; }

    }
}
