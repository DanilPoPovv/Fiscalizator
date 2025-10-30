using Fiscalizator.FiscalizationClasses.Dto;
using FluentNHibernate;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public interface IValidator <T>
    {
        public bool Validate(T validate, ValidationContext validationContext, ISession session, out string errorMessage);
    }
}
