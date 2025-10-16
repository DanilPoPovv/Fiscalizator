using Fiscalizator.FiscalizationClasses;
using Fiscalizator.Logger;
using Fiscalizator.OperationHandlers;
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
    public OperationResponse Sell(BillRequest bill)
    {
        OperationResponse operationResponse;
        operationResponse = _billHandler.ProcessBill(bill);
        return operationResponse;
    }
    public OperationResponse OpenShift(OpenShiftRequest openShiftRequest)
    {
        OperationResponse operationResponse;
        operationResponse = _openShiftHandler.OpenShift(openShiftRequest);
        return operationResponse;
    }
    public OperationResponse CloseShift(CloseShiftRequest closeShiftRequest)
    {
        OperationResponse operationResponse;
        operationResponse = _closeShiftHandler.ProcessCloseShift(closeShiftRequest);
        return operationResponse;
    }

    //public OperationResponse ProcessOperation(OperationRequest request)
    //{
    //    _logger.FileLog($"Processing operation of type: {request.Type}");

    //    OperationResponse operationResponse;
    //    switch (request.Type)
    //    {
    //        case OperationType.Sale:
    //            operationResponse = _billHandler.ProcessBill(request.BillRequest);
    //            break;
    //        case OperationType.OpenShift:
    //            operationResponse = _openShiftHandler.OpenShift(request.OpenShiftRequest);
    //            break;
    //        case OperationType.CloseShift:
    //            operationResponse = _closeShiftHandler.ProcessCloseShift(request.CloseShiftRequest);
    //            break;
    //        default:
    //            operationResponse = new OperationResponse { Message = "Что то пошло не так", Status = "Error" };
    //            break;

    //    }
    //    return operationResponse;

    }



