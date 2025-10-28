using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class ValidationContext
    {
        public Kkm kkm { get; set; }    
        public Shift currentShift { get; set; }
    }
}
