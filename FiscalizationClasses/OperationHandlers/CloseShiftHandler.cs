using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.OperationHandlers
{
    public class CloseShiftHandler
    {
        private readonly Logger.Logger _logger;
        private readonly ValidatorManager<CloseShiftDTO> _validatorManager;
        private readonly UnitOfWork _unitOfWork;
        private ISession _session;
        public CloseShiftHandler(Logger.Logger logger, ValidatorManager<CloseShiftDTO> validator)
        {
            _logger = logger;
            _session = NHibernateHelper.SessionFactory.OpenSession();
            _unitOfWork = new UnitOfWork(_session);
            _validatorManager = validator;
        }

        public CloseShiftResponse ProcessCloseShift(CloseShiftDTO request)
        {
            ///TODO : Add validationContext return from ValidateAll
            if (!_validatorManager.ValidateAll(request,_session, out string errorMessage))
            {
                _logger.FileLog($"Close shift processing failed: {errorMessage}");
                return new CloseShiftResponse
                {
                    Message = $"Close shift processing failed: {errorMessage}"
                };
            }
            _logger.FileLog($"Processing close shift for KKM: {request.SerialNumber}");
            ValidationContext validationContext = _validatorManager.GetValidationContext();
            Shift shift = validationContext.СurrentShift;
            shift.Kkm = validationContext.Kkm;

            shift.ClosureDateTime = shift.Bills.Last().OperationDateTime.AddSeconds(1);
            _unitOfWork.shiftRepository.CloseShift(shift);
            _unitOfWork.Commit();
            return new CloseShiftResponse { Message = $"Close shift processed successfully at {shift.ClosureDateTime} shift number is {shift.ShiftNumber}", CloseShiftTime = (DateTime)shift.ClosureDateTime };

        }
    }
}
