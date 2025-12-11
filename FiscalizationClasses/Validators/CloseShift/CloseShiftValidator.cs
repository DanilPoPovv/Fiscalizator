using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.BaseCheckServices;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators.CloseShift
{
    public class CloseShiftValidator : IValidator<CloseShiftDTO,ValidationContext>
    {
        private readonly KkmCheckService _kkmCheckService;
        public CloseShiftValidator()
        {
            _kkmCheckService = new KkmCheckService();
        }
        public void Validate(CloseShiftDTO request, ISession session, ValidationContext validationContext)
        {
            _kkmCheckService.EnsureKkmExists(request.SerialNumber, session, validationContext);
        }
    }
}
