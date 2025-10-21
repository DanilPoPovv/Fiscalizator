using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Dto
{
    public class CashierDTO
    {
        [XmlElement("Name")]
        public string Name { get; set; }
    }
}
