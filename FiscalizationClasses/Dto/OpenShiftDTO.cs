using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Dto
{
    public class OpenShiftDTO
    {
        [XmlElement("Cashier")]
        public string? Cashier { get; set; }
        [XmlElement("CloseDateTime")]
        public DateTime OpenShiftTime { get; set; }

    }
}
