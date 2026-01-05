using Fiscalizator.FiscalizationClasses.Requests;
using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Dto.Shift
{
    public class OpenShiftDTO : ISerialNumberRequire, ICashierNameRequire, IHasOperationTime
    {
        [XmlElement("CashierName")]
        public string CashierName { get; set; }
        [XmlElement("SerialNumber")]
        public int SerialNumber { get; set; }
        [XmlElement("OperationDateTime")]
        public DateTime OperationDateTime { get; set; }

    }
}
