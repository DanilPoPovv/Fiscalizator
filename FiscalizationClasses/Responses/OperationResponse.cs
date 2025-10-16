using System.Xml.Serialization;
namespace Fiscalizator.FiscalizationClasses.Responses
{
    [XmlRoot("Response")]
    public class OperationResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }

    }
}
