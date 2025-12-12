using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public interface IGlobalValidator<TContext> where TContext : IValidationContext
    {
        public void Validate(object request, ISession session, TContext validationContext);
    }
}
