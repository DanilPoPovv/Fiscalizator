using System.Xml.Serialization;
namespace Fiscalizator.FiscalizationClasses
{
    [XmlRoot("response")]
    public class BillResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }

    }
}
