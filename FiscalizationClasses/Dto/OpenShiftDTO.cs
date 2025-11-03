using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Dto
{
    public class OpenShiftDTO
    {
        [XmlElement("Cashier")]
        public string? Cashier { get; set; }
        [XmlElement("SerialNumber")]
        public int SerialNumber { get; set; }
        [XmlElement("OpenShiftTime")]
        public DateTime OpenShiftTime { get; set; } = DateTime.Now;

    }
}
