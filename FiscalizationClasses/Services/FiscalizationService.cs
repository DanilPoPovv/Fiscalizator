using Fiscalizator.FiscalizationClasses.Dto.Bill;
using Fiscalizator.FiscalizationClasses.Dto.Shift;
using Fiscalizator.FiscalizationClasses.OperationHandlers;
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.Logger;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class FiscalizationService
{
    public readonly Logger _logger;
    public readonly OpenShiftHandler _openShiftHandler;
    public readonly CloseShiftHandler _closeShiftHandler;
    public readonly BillHandler _billHandler;
    public FiscalizationService(Logger logger,OpenShiftHandler openShiftHandler,CloseShiftHandler closeShiftHandler, BillHandler billHandler)
    {
        _logger = logger;
        _openShiftHandler = openShiftHandler;
        _closeShiftHandler = closeShiftHandler;
        _billHandler = billHandler;
    }
    public OperationResponse Sell(BillDTO bill)
    {
        OperationResponse operationResponse;
        operationResponse = _billHandler.ProcessBill(bill);
        return operationResponse;
    }
    public OperationResponse OpenShift(OpenShiftDTO openShiftRequest)
    {
        OperationResponse operationResponse;
        operationResponse = _openShiftHandler.OpenShift(openShiftRequest);
        return operationResponse;
    }
    public OperationResponse CloseShift(CloseShiftDTO closeShiftRequest)
    {
        OperationResponse operationResponse;
        operationResponse = _closeShiftHandler.ProcessCloseShift(closeShiftRequest);
        return operationResponse;
    }
    }



