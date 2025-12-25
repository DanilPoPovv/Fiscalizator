using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.Cashier
{
    public class CashierUpdateDto : IClientCodeRequire, ICashierNameRequire 
    {
        public int ClientCode { get; set; }
        public string CashierName { get; set; }
        public string? NewCashierName { get; set; }
        public int? NewSystemId { get; set; }
    }
}
