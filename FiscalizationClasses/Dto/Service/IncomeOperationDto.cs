using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.Service
{
    public class IncomeOperationDto : ISerialNumberRequire, IOpenShiftRequire, ICashierNameRequire
    {
        public DateTime OperationDateTime { get; set; }
        public int SerialNumber { get; set; }
        public decimal Amount { get; set; }
        public string CashierName { get; set; }
    }
}
