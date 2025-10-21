using Fiscalizator.FiscalizationClasses.Dto;
using System.Xml.Serialization;

public class BillRequest 
    {
    [XmlElement("Bill")]
    public BillDTO Bill { get; set; }
}

