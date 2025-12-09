using Fiscalizator.Repository;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Dto;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class KkmValidator : IValidator<BillDTO,ValidationContext>
    {
        public bool Validate(BillDTO request, ISession session, out string errorMessage, ValidationContext validationContext)
        {
            if (!Helpers.KkmHelper.ValidateSerialNumber(request.SerialNumber, validationContext, session ,out errorMessage))
                return false;
            return true;
        }

    }
}