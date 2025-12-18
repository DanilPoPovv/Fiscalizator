using Fiscalizator.FiscalizationClasses.Dto.Shift;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators.OpenShift
{
    public class OpenShiftTimeValidator : IValidator<OpenShiftDTO, BaseOperationDataAccessor, ValidationContext>
    {
        public void Validate(OpenShiftDTO request, BaseOperationDataAccessor validationData, ValidationContext validationContext)
        {
            Shift lastShift = validationContext.Kkm.Shifts.LastOrDefault();
            if (lastShift == null && validationContext.Kkm.Shifts.Count == 0)
            {
                return;
            }
            else if (request.OpenShiftTime > DateTime.Now)
            {
                throw new ShiftException("Opening date and time cannot be in the future.");
            }
            else if (request.OpenShiftTime <= lastShift.ClosureDateTime)
            {
                throw new ShiftException("Opening date and time cannot be earlier or equal than the last shift's closing date and time.");
            }
        }
    
    }
}
