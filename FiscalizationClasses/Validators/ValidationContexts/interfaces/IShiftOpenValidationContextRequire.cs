using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces
{
    public interface IShiftOpenValidationContextRequire
    {
        public Shift Shift { get; set; }
    }
}
