using Fiscalizator.FiscalizationClasses;
using Fiscalizator.Logger;
using System.Runtime.CompilerServices;

public class FiscalizationService
{
    public readonly Logger _logger;

    public FiscalizationService(Logger logger)
    {
        _logger = logger;
    }

    public BillResponse ProcessOperation(BillRequest request)
    {
        _logger.FileLog($"Processing bill with ID: {request.Id} and Amount: {request.Amount}");
        var response = new BillResponse
        {
            Status = "OK",
            Message = $"Чек {request.Id} на сумму {request.Amount} успешно обработан."
        };
        _logger.FileLog($"Response: Status= {response.Status}, Message= {response.Message}, BillId = {request.Id}");

        return response;
    }

}

