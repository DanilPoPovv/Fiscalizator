using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.Logger;
using Fiscalizator.FiscalizationClasses.Validators;
using System.ComponentModel.DataAnnotations;
using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.Mappers;

namespace Fiscalizator.FiscalizationClasses.OperationHandlers
{
    public class BillHandler
    {
        private readonly Logger.Logger _logger;
        private readonly BillValidator _validator;
        private readonly BillMapper _mapper = new BillMapper();

        public BillHandler(Logger.Logger logger, BillValidator validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public OperationResponse ProcessBill(BillDTO request)
        {
            bool isBillValid = _validator.ValidateBill(request, out string errorMessage);
            if (isBillValid)
            {
                var session = NHibernateHelper.SessionFactory.OpenSession();
                session.Save(_mapper.MapToModel(request, _validator.MapCommodities(request.Commodity)));
                _logger.FileLog($"Processing bill for amount: {request.Amount}");
                return new BillResponse { Message = "Bill processed successfully" };
            }
            _logger.FileLog($"Bill processing failed: {errorMessage}");
            return new BillResponse
            {
                Message = $"Bill processing failed: {errorMessage}"
            };

        }
    }
}
