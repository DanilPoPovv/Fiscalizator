using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.User
{
    public class CreateClientUserDto : CreateGlobalAdminDto, IClientCodeRequire
    {
        public int ClientCode { get; set; }

    }
}
