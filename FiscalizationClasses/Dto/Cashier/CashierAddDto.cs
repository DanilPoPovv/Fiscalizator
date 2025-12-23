using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.Cashier
{
    public class CashierAddDto : IClientCodeRequire
    {
        public int ClientCode { get; set; }
        public string Name { get; set; }
        public int SystemId { get; set; }
    }
}
