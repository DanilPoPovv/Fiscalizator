using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.KkmCrudValidators
{
    public class KkmDeleteValidator : IValidator<KkmDeleteDTO, KkmValidationContext>
    {
        public void Validate(KkmDeleteDTO request, ISession session, KkmValidationContext validationContext)
        {
        }
    }
}
