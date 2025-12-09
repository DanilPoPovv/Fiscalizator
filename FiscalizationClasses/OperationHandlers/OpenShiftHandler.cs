using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.OperationHandlers
{
    public class OpenShiftHandler
    {
        private readonly Logger.Logger _logger;
        private readonly ISession _session;
        private readonly ValidatorManager<OpenShiftDTO,ValidationContext> _validatorManager;
        private readonly UnitOfWork _unitOfWork;
        public OpenShiftHandler(Logger.Logger logger, ValidatorManager<OpenShiftDTO,ValidationContext> validatorManager)
        {
            _logger = logger;
            _session = NHibernateHelper.OpenSession();
            _validatorManager = validatorManager;
            _unitOfWork = new UnitOfWork(_session);
        }

        public OpenShiftResponse OpenShift(OpenShiftDTO request)
        {
            ValidationContext validationContext = new ValidationContext();
            if (!_validatorManager.ValidateAll(request, _session, out string errorMessage, validationContext))
            {
                _logger.FileLog($"Open shift processing failed: {errorMessage}");
                return new OpenShiftResponse
                {
                    Message = $"Open shift processing failed: {errorMessage}"
                };
            }
            Shift shift = new Shift();
            shift.Kkm = validationContext.Kkm;
            shift.OpeningDateTime = request.OpenShiftTime;
            shift.ShiftNumber = validationContext.Kkm.Shifts.LastOrDefault() != null ? validationContext.Kkm.Shifts.Last().ShiftNumber + 1 : 1;
            _unitOfWork.shiftRepository.Add(shift);
            _unitOfWork.Commit();
            _logger.FileLog($"Shift has been opened at {request.OpenShiftTime}");
            return new OpenShiftResponse { Message = "Shift opened successfully", OpenShiftTime = request.OpenShiftTime };
        }
    }
}


