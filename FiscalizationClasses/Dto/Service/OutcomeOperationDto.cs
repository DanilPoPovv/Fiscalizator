using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.Service
{
    public class OutcomeOperationDto : ISerialNumberRequire, IOpenShiftRequire, ICashierNameRequire, IEnoughCashRequire, IHasOperationTime
    {
        public DateTime OperationDateTime { get; set; }
        public int SerialNumber { get; set; }
        public decimal Amount { get; set; }
        public string CashierName { get; set; }
    }
}
