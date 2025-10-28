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
        private readonly ValidatorManager _validatorManager;
        private readonly BillMapper _mapper = new BillMapper();
        public BillHandler(Logger.Logger logger, ValidatorManager validatorManager)
        {
            _logger = logger;
            _validatorManager = validatorManager;
        }

        public OperationResponse ProcessBill(BillDTO request)
        {
            bool isBillValid = _validatorManager.ValidateAll(request, out string errorMessage);
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
            billEntity.Kkm = uow.kkmRepository.GetBySerialNumber(request.SerialNumber);
            billEntity.Shift = uow.shiftRepository.GetCurrentKkmShift(billEntity.Kkm);
            uow.Bills.Add(billEntity);
            uow.Commit();

            return new BillResponse { Message = "Bill processed successfully" };
        }

    }
}
