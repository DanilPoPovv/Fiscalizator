using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using System.ComponentModel.DataAnnotations;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class OpenShiftValidator : IValidator<BillDTO,ValidationContext>
    {
        public bool Validate(BillDTO request, ISession session, out string errorMessage, ValidationContext validationContext)
        {
            if (!Helpers.ShiftHelper.CheckShiftOpened(validationContext, session, out errorMessage))
                return false;
            return true;
        }
    }
}