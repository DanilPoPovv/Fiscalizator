using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.Cashier
{
    public class CashierDeleteDTO : IClientCodeRequire, ICashierNameRequire
    {
        public int ClientCode { get; set; }
        public string CashierName { get; set; }
    }
}
