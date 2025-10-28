using Fiscalizator.FiscalizationClasses.Dto;
using FluentNHibernate;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public interface IValidator <T> where T : class
    {
        public bool Validate(BillDTO request, ValidationContext validationContext, out string errorMessage);
    }
}
