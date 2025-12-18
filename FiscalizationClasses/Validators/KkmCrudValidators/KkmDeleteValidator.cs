using Fiscalizator.FiscalizationClasses.Dto.Kkm;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Validators.KkmCrudValidators
{
    public class KkmDeleteValidator : IValidator<KkmDeleteDTO,KkmCrudDataAccessor, KkmValidationContext>
    {
        public void Validate(KkmDeleteDTO request, KkmCrudDataAccessor validationData, KkmValidationContext validationContext)
        {
        }
    }
}
