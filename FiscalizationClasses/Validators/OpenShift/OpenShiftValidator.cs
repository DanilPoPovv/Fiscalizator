using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Validators.BaseCheckServices;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using ISession = NHibernate.ISession;
namespace Fiscalizator.FiscalizationClasses.Validators.OpenShift
{
    public class OpenShiftValidator : IValidator<OpenShiftDTO, ValidationContext>
    {
        private readonly KkmCheckService _kkmCheckService;
        private readonly KkmCheckShiftOpenedService _shiftCheckService;
        public OpenShiftValidator()
        {
            _kkmCheckService = new KkmCheckService();
            _shiftCheckService = new KkmCheckShiftOpenedService();
        }
        public void Validate(OpenShiftDTO request, ISession session, ValidationContext validationContext)
        {
            _kkmCheckService.EnsureKkmExists(request.SerialNumber, session, validationContext);
            _shiftCheckService.CheckShiftOpened(validationContext);
        }
    }
}
