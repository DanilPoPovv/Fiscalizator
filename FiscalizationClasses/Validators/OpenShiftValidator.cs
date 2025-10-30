using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using System.ComponentModel.DataAnnotations;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class OpenShiftValidator : IValidator<BillDTO>
    {
        public bool Validate(BillDTO request, ValidationContext validationContext, ISession session, out string errorMessage)
        {
            if (!Helpers.ShiftHelper.CheckShiftOpened(validationContext, session, out errorMessage))
                return false;
            return true;
        }
    }
}