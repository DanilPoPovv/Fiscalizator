using Fiscalizator.FiscalizationClasses.Dto.Shift;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using Fiscalizator.Repository.Interfaces;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.OperationHandlers
{
    public class CloseShiftHandler
    {
        private readonly Logger.Logger _logger;
        private readonly ValidatorManager<CloseShiftDTO, BaseOperationDataAccessor, ValidationContext> _validatorManager;
        private readonly IShiftRepository _shiftRepository;
        private readonly ISession _session;
        public CloseShiftHandler(Logger.Logger logger, ValidatorManager<CloseShiftDTO, BaseOperationDataAccessor, ValidationContext> validator)
        {
            _logger = logger;
            _validatorManager = validator;
            _session = NHibernateHelper.OpenSession();
            _shiftRepository = new ShiftRepository(_session);
        }

        public CloseShiftResponse ProcessCloseShift(CloseShiftDTO request)
        {
            ValidationContext validationContext = new ValidationContext();

            try
            {
                using var session = NHibernateHelper.OpenSession();
                var dataAccessor = new BaseOperationDataAccessor(session);
                _validatorManager.ValidateAll(request, dataAccessor, validationContext);

                _logger.FileLog($"Processing close shift for KKM: {request.SerialNumber}");

                Shift shift = validationContext.Shift;
                shift.Kkm = validationContext.Kkm;

                var lastBill = shift.Bills.LastOrDefault();
                if (lastBill == null)
                {
                    shift.ClosureDateTime = shift.OpeningDateTime.AddSeconds(1);
                }
                else
                {
                    shift.ClosureDateTime = lastBill.OperationDateTime.AddSeconds(1);
                }
                var shiftRepository = new ShiftRepository(session);
                _shiftRepository.CloseShift(shift);
                ///TODO : Убрать это, как в коде так и как поле сущности в базе.
                validationContext.Shift.LastOperationDateTime = (DateTime)shift.ClosureDateTime;

                return new CloseShiftResponse
                {
                    Message = $"Close shift processed successfully at {shift.ClosureDateTime} shift number is {shift.ShiftNumber}",                   
                };
            }
            catch (Exception ex)
            {
                _logger.FileLog($"Close shift processing failed: {ex.Message}");

                return new CloseShiftResponse
                {
                    Message = $"Close shift processing failed: {ex.Message}"
                };
            }
        }

    }
}
