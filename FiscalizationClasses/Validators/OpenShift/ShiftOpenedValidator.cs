using Fiscalizator.FiscalizationClasses.Dto.Shift;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.OpenShift
{
    public class ShiftOpenedValidator : IValidator<OpenShiftDTO, BaseOperationDataAccessor, ValidationContext>
    {
        public void Validate(OpenShiftDTO closeShiftDTO, BaseOperationDataAccessor validationData, ValidationContext validationContext)
        {
            Shift shift = validationContext.Kkm.Shifts.LastOrDefault()!;
            if (shift?.ClosureDateTime == null && shift != null)
            {
                throw new ShiftException("There is already an opened shift for this KKM.");
            }            
            validationContext.CurrentShift = shift;
        }
    }
}
