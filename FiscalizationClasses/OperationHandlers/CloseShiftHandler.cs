using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Responses;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.OperationHandlers
{
    public class CloseShiftHandler
    {
        private readonly Logger.Logger _logger;
        private readonly ValidatorManager<CloseShiftDTO> _validatorManager;
        private readonly UnitOfWork _unitOfWork;
        public CloseShiftHandler(Logger.Logger logger, ValidatorManager<CloseShiftDTO> validator)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(NHibernateHelper.SessionFactory);
            _validatorManager = validator;
        }

        public CloseShiftResponse ProcessCloseShift(CloseShiftDTO request)
        {
            ///TODO : Add validationContext return from ValidateAll
            if (!_validatorManager.ValidateAll(request, out string errorMessage))
            {
                _logger.FileLog($"Close shift processing failed: {errorMessage}");
                return new CloseShiftResponse
                {
                    Message = $"Close shift processing failed: {errorMessage}"
                };
            }
            _logger.FileLog($"Processing close shift for KKM: {request.SerialNumber}");
            Kkm kkm = _unitOfWork.kkmRepository.GetBySerialNumber(request.SerialNumber);
            Shift shift = _unitOfWork.shiftRepository.GetCurrentKkmShift(kkm);
            ///TODO : Add validation if 0 bills in shift
            shift.ClosureDateTime = shift.Bills.Last().OperationDateTime.AddSeconds(1);
            _unitOfWork.shiftRepository.CloseShift(shift);
            _unitOfWork.Commit();
            return new CloseShiftResponse { Message = $"Close shift processed successfully at {shift.ClosureDateTime} shift number is {shift.ShiftNumber}" };

        }
    }
}
