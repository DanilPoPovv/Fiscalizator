using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Validators.ValidationContexts
{
    public interface IShiftOpenValidationContextRequire
    {
        public Shift Shift { get; set; }
    }
}
