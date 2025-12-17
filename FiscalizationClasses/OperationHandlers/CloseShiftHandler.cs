using Fiscalizator.FiscalizationClasses.Dto.Shift;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.OperationHandlers
{
    public class CloseShiftHandler
    {
        private readonly Logger.Logger _logger;
        private readonly ValidatorManager<CloseShiftDTO, BaseOperationDataAccessor, ValidationContext> _validatorManager;
        private readonly UnitOfWork _unitOfWork;
        private ISession _session;
        private readonly BaseOperationDataAccessor _dataAccessor;
        public CloseShiftHandler(Logger.Logger logger, ValidatorManager<CloseShiftDTO, BaseOperationDataAccessor, ValidationContext> validator)
        {
            _logger = logger;
            _session = NHibernateHelper.SessionFactory.OpenSession();
            _unitOfWork = new UnitOfWork(_session);
            _validatorManager = validator;
            _dataAccessor = new BaseOperationDataAccessor(_session);
        }

        public CloseShiftResponse ProcessCloseShift(CloseShiftDTO request)
        {
            ValidationContext validationContext = new ValidationContext();

            try
            {
                _validatorManager.ValidateAll(request, _dataAccessor, validationContext);

                _logger.FileLog($"Processing close shift for KKM: {request.SerialNumber}");

                Shift shift = validationContext.CurrentShift;
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

                _unitOfWork.shiftRepository.CloseShift(shift);
                _unitOfWork.Commit();

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
