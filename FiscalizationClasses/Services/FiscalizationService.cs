using Fiscalizator.FiscalizationClasses.Dto.Bill;
using Fiscalizator.FiscalizationClasses.Dto.Service;
using Fiscalizator.FiscalizationClasses.Dto.Shift;
using Fiscalizator.FiscalizationClasses.OperationHandlers;
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.Logger;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class FiscalizationService
{
    private readonly Logger _logger;
    private readonly OpenShiftHandler _openShiftHandler;
    private readonly CloseShiftHandler _closeShiftHandler;
    private readonly BillHandler _billHandler;
    private readonly IncomeHandler _incomeHandler;
    private readonly OutcomeHandler _outcomeHandler;
    public FiscalizationService(Logger logger,OpenShiftHandler openShiftHandler,
        CloseShiftHandler closeShiftHandler, BillHandler billHandler, IncomeHandler incomeHandler, OutcomeHandler outcomeHandler)
    {
        _logger = logger;
        _openShiftHandler = openShiftHandler;
        _closeShiftHandler = closeShiftHandler;
        _billHandler = billHandler;
        _incomeHandler = incomeHandler;
        _outcomeHandler = outcomeHandler;
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
    public OperationResponse Income(IncomeOperationDto incomeDto)
    {
        OperationResponse operationResponse;
        operationResponse = _incomeHandler.Income(incomeDto);
        return operationResponse;
    }
    public OperationResponse Outcome(OutcomeOperationDto outcomeDto)
    {
        OperationResponse operationResponse;
        operationResponse = _outcomeHandler.Outcome(outcomeDto);
        return operationResponse;
    }
}



