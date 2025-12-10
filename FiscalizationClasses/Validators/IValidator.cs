using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using FluentNHibernate;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public interface IValidator <T,V> where V : IValidationContext
    {
        public void Validate(T validate, ISession session, V validationContext = null!);
    }
}
