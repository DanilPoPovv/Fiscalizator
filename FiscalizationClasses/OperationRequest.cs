using System.Xml;
using System.Xml.Serialization;
namespace Fiscalizator.FiscalizationClasses
{
    [XmlRoot("Operation")]
    public class OperationRequest
    {
        [XmlElement("Type")]
        public OperationType Type { get; set; }
        [XmlElement("Bill")]
        public BillRequest? BillRequest { get; set; }
        [XmlElement("OpenShift")]
        public OpenShiftRequest? OpenShiftRequest { get; set; }
        [XmlElement("CloseShift")]
        public CloseShiftRequest? CloseShiftRequest { get; set; }

    }
}
