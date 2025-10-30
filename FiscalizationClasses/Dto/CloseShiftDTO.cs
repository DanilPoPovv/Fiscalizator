using Fiscalizator.FiscalizationClasses.Entities;
using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Dto
{
    public class CloseShiftDTO 
    {
        [XmlElement("SerialNumber")]
        public int SerialNumber { get; set; }
        [XmlElement("Cashier")]
        public string? Cashier { get; set; }
    }
}
