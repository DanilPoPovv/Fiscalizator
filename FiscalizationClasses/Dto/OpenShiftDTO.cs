using Fiscalizator.FiscalizationClasses.Requests;
using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Dto
{
    public class OpenShiftDTO : ISerialNumberRequire, ICashierNameRequire
    {
        [XmlElement("CashierName")]
        public string CashierName { get; set; }
        [XmlElement("SerialNumber")]
        public int SerialNumber { get; set; }
        [XmlElement("OpenShiftTime")]
        public DateTime OpenShiftTime { get; set; } = DateTime.Now;

    }
}
