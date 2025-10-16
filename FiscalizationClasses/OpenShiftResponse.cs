using System.Xml;
using System.Xml.Serialization;
namespace Fiscalizator.FiscalizationClasses
{
    public class OpenShiftResponse : OperationResponse
    {
        [XmlElement("OpenShiftTime")]
        public DateTime OpenShiftTime { get; set; }
        [XmlElement("Cashier")]
        public string? Cashier { get; set; }
    }
}
