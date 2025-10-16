using System.Xml.Serialization;
namespace Fiscalizator.FiscalizationClasses
{
    [XmlRoot("Response")]
    public class OperationResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }

    }
}
