using System.Xml;
using System.Xml.Serialization;
namespace Fiscalizator.FiscalizationClasses.Responses
{
    public class OpenShiftResponse : OperationResponse
    {
        [XmlElement("OpenShiftTime")]
        public DateTimeOffset OpenShiftTime { get; set; }
        [XmlElement("Cashier")]
        public string? Cashier { get; set; }
    }
}
