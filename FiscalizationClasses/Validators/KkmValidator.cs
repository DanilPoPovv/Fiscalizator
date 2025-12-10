using Fiscalizator.Repository;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Dto;
using ISession = NHibernate.ISession;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.BaseCheckServices;
namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class KkmValidator : IValidator<BillDTO,ValidationContext>
    {
        private readonly KkmCheckService _kkmCheckService;
        public KkmValidator()
        {
            _kkmCheckService = new KkmCheckService();
        }
        public void Validate(BillDTO request, ISession session, ValidationContext validationContext)
        {
            _kkmCheckService.EnsureKkmExists(request.SerialNumber, session, validationContext);
        }
    }
}