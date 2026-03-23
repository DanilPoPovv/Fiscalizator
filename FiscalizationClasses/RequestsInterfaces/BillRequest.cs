using Fiscalizator.FiscalizationClasses.Dto.Bill;
using System.Xml.Serialization;

public class BillRequest 
    {
    [XmlElement("Bill")]
    public BillDTO Bill { get; set; }
}

