using Fiscalizator.Repository;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Dto;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class KkmValidator : IValidator<BillDTO>
    {
        public bool Validate(BillDTO request, ValidationContext validationContext, ISession session, out string errorMessage)
        {
            if (!Helpers.KkmHelper.ValidateSerialNumber(request.SerialNumber, validationContext, session ,out errorMessage))
                return false;
            return true;
        }

    }
}