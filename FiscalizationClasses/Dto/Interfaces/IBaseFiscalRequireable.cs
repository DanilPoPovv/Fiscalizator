using Fiscalizator.FiscalizationClasses.Requests;

namespace Fiscalizator.FiscalizationClasses.Dto.Interfaces
{
    public interface IFiscalOperation: ICashierNameRequire, ISerialNumberRequire, IOpenShiftRequire, IHasOperationTime, IClientCodeRequire
    {
    }
}
