using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Requests
{
    public class OpenShiftRequest
    {
        [XmlElement("Cashier")]
        public string? Cashier { get; set; }
        [XmlElement("CloseDateTime")]
        public DateTime OpenShiftTime { get; set; }

    }
}
