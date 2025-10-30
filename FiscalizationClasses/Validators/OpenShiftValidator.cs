using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using System.ComponentModel.DataAnnotations;

namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class OpenShiftValidator : IValidator<BillDTO>
    {
        public bool Validate(BillDTO request, ValidationContext validationContext, out string errorMessage)
        {
            if (!Helpers.ShiftHelper.CheckShiftOpened(validationContext, out errorMessage))
                return false;
            return true;
        }
    }
}
