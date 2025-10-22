using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class Payment
    {
        public virtual string PaymentType { get; set; }
        public virtual decimal Amount { get; set; }

    }
}
