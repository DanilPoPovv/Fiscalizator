using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class Tax
    {
        public virtual string TaxType { get; set; }
        public virtual decimal TaxPercent { get; set; }
        public virtual decimal TaxSum { get; set; }

    }
}
