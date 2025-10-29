using Fiscalizator.FiscalizationClasses.Dto;
using FluentNHibernate;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public interface IValidator <T>
    {
        public bool Validate(T validate, ValidationContext validationContext, out string errorMessage);
    }
}
