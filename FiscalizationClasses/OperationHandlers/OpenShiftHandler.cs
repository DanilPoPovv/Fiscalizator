using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using System.Runtime.CompilerServices;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.OperationHandlers
{
    public class OpenShiftHandler
    {
        private readonly Logger.Logger _logger;
        private readonly ISession _session;
        private readonly ValidatorManager<OpenShiftDTO, ValidationContext> _validatorManager;
        private readonly UnitOfWork _unitOfWork;
        public OpenShiftHandler(Logger.Logger logger, ValidatorManager<OpenShiftDTO, ValidationContext> validatorManager)
        {
            _logger = logger;
            _session = NHibernateHelper.OpenSession();
            _validatorManager = validatorManager;
            _unitOfWork = new UnitOfWork(_session);
        }

        public OpenShiftResponse OpenShift(OpenShiftDTO request)
        {
            try
            {
                ValidationContext validationContext = new ValidationContext();
                _validatorManager.ValidateAll(request, _session, validationContext);
                CreateNewShift(request, validationContext);
                _logger.FileLog($"Shift has been opened at {request.OpenShiftTime}");
                return new OpenShiftResponse { Message = "Shift opened successfully", OpenShiftTime = request.OpenShiftTime };
            }
            catch (Exception ex)
            {
                return new OpenShiftResponse
                {
                    Message = $"Shift opening failed: {ex.Message}"
                };
            }
        }

        private void CreateNewShift(OpenShiftDTO request, ValidationContext validationContext)
        {
            Shift shift = new Shift
            {
                Kkm = validationContext.Kkm,
                OpeningDateTime = request.OpenShiftTime,
                ShiftNumber = validationContext.Kkm.Shifts.LastOrDefault() != null ? validationContext.Kkm.Shifts.Last().ShiftNumber + 1 : 1
            };
            _unitOfWork.shiftRepository.Add(shift);
            _unitOfWork.Commit();
        }
    }
}


