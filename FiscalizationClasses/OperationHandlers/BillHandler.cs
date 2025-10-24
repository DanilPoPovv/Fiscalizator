using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.Mappers;
using Fiscalizator.Repository;
using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.OperationHandlers
{
    public class BillHandler
    {
        private readonly Logger.Logger _logger;
        private readonly BillValidator _validator;
        private readonly BillMapper _mapper = new BillMapper();
        private readonly UnitOfWork _unitOfWork;

        public BillHandler(Logger.Logger logger, BillValidator validator)
        {
            _logger = logger;
            _validator = validator;
            _unitOfWork = new UnitOfWork(NHibernateHelper.SessionFactory);
        }

        public OperationResponse ProcessBill(BillDTO request)
        {
            bool isBillValid = _validator.ValidateBill(request, out string errorMessage);
            if (!isBillValid)
            {
                _logger.FileLog($"Bill processing failed: {errorMessage}");
                return new BillResponse
                {
                    Message = $"Bill processing failed: {errorMessage}"
                };
            }

            _logger.FileLog($"Processing bill for amount: {request.Amount}");

            Bill billEntity = _mapper.MapToModel(request);

            using var uow = new UnitOfWork(NHibernateHelper.SessionFactory);
            uow.Bills.Add(billEntity);
            uow.Commit();

            return new BillResponse { Message = "Bill processed successfully" };
        }

    }
}
