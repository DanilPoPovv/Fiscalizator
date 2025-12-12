using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.Mappers;
using Fiscalizator.Repository;
using Fiscalizator.FiscalizationClasses.Entities;
using ISession = NHibernate.ISession;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

namespace Fiscalizator.FiscalizationClasses.OperationHandlers
{
    public class BillHandler
    {
        private readonly Logger.Logger _logger;
        private readonly ValidatorManager<BillDTO, ValidationContext> _validatorManager;
        private readonly BillMapper _mapper = new BillMapper();
        private readonly ISession _session;
        public BillHandler(Logger.Logger logger, ValidatorManager<BillDTO,ValidationContext> validatorManager)
        {
            _logger = logger;
            _validatorManager = validatorManager;
            _session = NHibernateHelper.SessionFactory.OpenSession();
        }

        public OperationResponse ProcessBill(BillDTO request)
        {
            try
            {
                ValidationContext validationContext = new ValidationContext();
                _validatorManager.ValidateAll(request, _session, validationContext);

                _logger.FileLog($"Processing bill for amount: {request.Amount}");

                CreateNewBill(request, validationContext);

                return new BillResponse { Message = "Bill processed successfully" };
            }
            catch (Exception ex)
            {
                return new BillResponse
                {
                    Message = $"Bill processing failed: {ex.Message}"
                };
            }
        }
        private void CreateNewBill(BillDTO request, ValidationContext validationContext)
        {
            Bill bill = _mapper.MapToModel(request);
            bill.Kkm = validationContext.Kkm;
            bill.Shift = validationContext.CurrentShift;
            bill.Cashier = validationContext.Cashier;
            using var uow = new UnitOfWork(_session);
            uow.Bills.Add(bill);
            uow.Commit();
        }

    }
}
