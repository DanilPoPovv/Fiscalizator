using Fiscalizator.FiscalizationClasses.Entities;
using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Dto
{
    public class CloseShiftDTO 
    {
        [XmlElement("CloseShiftTime")]
        public DateTime CloseShiftTime { get; set; }
        [XmlElement("SerialNumber")]
        public int KkmSerialNumber { get; set; }
        [XmlElement("Cashier")]
        public string? Cashier { get; set; }
    }
}
