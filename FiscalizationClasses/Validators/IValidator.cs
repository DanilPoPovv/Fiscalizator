using Fiscalizator.FiscalizationClasses.Dto;
using FluentNHibernate;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public interface IValidator <T,V> where V : IValidationContext
    {
        public bool Validate(T validate, ISession session, out string errorMessage, V validationContext = null!);
    }
}
