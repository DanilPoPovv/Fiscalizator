using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.Mappers;
using Fiscalizator.Repository;
using Fiscalizator.FiscalizationClasses.Entities;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.OperationHandlers
{
    public class BillHandler
    {
        private readonly Logger.Logger _logger;
        private readonly ValidatorManager<BillDTO> _validatorManager;
        private readonly BillMapper _mapper = new BillMapper();
        private readonly ISession _session;
        public BillHandler(Logger.Logger logger, ValidatorManager<BillDTO> validatorManager)
        {
            _logger = logger;
            _validatorManager = validatorManager;
            _session = NHibernateHelper.SessionFactory.OpenSession();
        }

        public OperationResponse ProcessBill(BillDTO request)
        {
            bool isBillValid = _validatorManager.ValidateAll(request, _session, out string errorMessage);
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


            using var uow = new UnitOfWork(_session);
            billEntity.Kkm = uow.kkmRepository.GetBySerialNumber(request.SerialNumber);
            billEntity.Shift = uow.shiftRepository.GetCurrentKkmShift(billEntity.Kkm);
            billEntity.Cashier = uow.cashierRepository.GetByName(request.Cashier.Name);
            uow.Bills.Add(billEntity);
            uow.Commit();

            return new BillResponse { Message = "Bill processed successfully" };
        }

    }
}
