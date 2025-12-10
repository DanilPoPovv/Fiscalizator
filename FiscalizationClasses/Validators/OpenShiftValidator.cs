using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.BaseCheckServices;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using System.ComponentModel.DataAnnotations;
using ISession = NHibernate.ISession;
using ValidationContext = Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.ValidationContext;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class OpenShiftValidator : IValidator<BillDTO,ValidationContext>
    {
        private readonly KkmCheckShiftOpenedService _kkmCheckShiftOpenedService;
        public OpenShiftValidator()
        {
            _kkmCheckShiftOpenedService = new KkmCheckShiftOpenedService();
        }
        public void Validate(BillDTO request, ISession session, ValidationContext validationContext)
        {
            _kkmCheckShiftOpenedService.CheckShiftOpened(validationContext);
        }
    }
}