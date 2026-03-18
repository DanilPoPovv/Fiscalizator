using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.Mappers;
using Fiscalizator.Repository;
using Fiscalizator.FiscalizationClasses.Entities;
using ISession = NHibernate.ISession;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.FiscalizationClasses.Dto.Bill;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.Repository.Interfaces;

namespace Fiscalizator.FiscalizationClasses.OperationHandlers
{
    public class BillHandler
    {
        private readonly Logger.Logger _logger;
        private readonly ValidatorManager<BillDTO, BaseOperationDataAccessor,ValidationContext> _validatorManager;
        private readonly BillMapper _mapper = new BillMapper();
        private readonly IBillRepository BillRepository;
        private readonly ISession _session;
        public BillHandler(Logger.Logger logger, ValidatorManager<BillDTO, BaseOperationDataAccessor,ValidationContext> validatorManager)
        {
            _logger = logger;
            _validatorManager = validatorManager;
            _session = NHibernateHelper.OpenSession();
            BillRepository = new BillRepository(_session);
        }

        public OperationResponse ProcessBill(BillDTO request)
        {
            try
            {
                using var session = NHibernateHelper.SessionFactory.OpenSession();

                ValidationContext validationContext = new ValidationContext();
                var dataAccessor = new BaseOperationDataAccessor(session);
                _validatorManager.ValidateAll(request, dataAccessor, validationContext);

                _logger.FileLog($"Processing bill for amount: {request.Amount}");

                Bill bill = CreateNewBill(request, validationContext);
                var repository = new BaseRepository<Bill>(session);
                repository.Add(bill);
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
        private Bill CreateNewBill(BillDTO request, ValidationContext validationContext)
        {
            Bill bill = _mapper.MapToModel(request);
            bill.Kkm = validationContext.Kkm;
            bill.Shift = validationContext.Shift;
            bill.Cashier = validationContext.Cashier;
            return bill;
        }

    }
}
