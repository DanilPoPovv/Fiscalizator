using Fiscalizator.FiscalizationClasses;
using System.Xml.Serialization;

public class BillRequest 
    {
    [XmlElement("Amount")]
    public decimal Amount { get; set; }
}

