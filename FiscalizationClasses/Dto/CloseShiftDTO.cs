using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;
using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Dto
{
    public class CloseShiftDTO : ISerialNumberRequire, ICashierNameRequire, IOpenShiftRequire
    {
        [XmlElement("SerialNumber")]
        public int SerialNumber { get; set; }
        [XmlElement("CashierName")]
        public string CashierName { get; set; }
    }
}
