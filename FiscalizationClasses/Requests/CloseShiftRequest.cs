using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Requests
{
    public class CloseShiftRequest
    {
        [XmlElement("CloseShiftTime")]
        public DateTime CloseShiftTime { get; set; }
        [XmlElement("Cashier")]
        public string? Cashier { get; set; }
    }
}
