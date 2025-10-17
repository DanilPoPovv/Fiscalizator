using Fiscalizator.FiscalizationClasses;
using Fiscalizator.FiscalizationClasses.Requests;
using System.Xml.Serialization;

public class BillRequest 
    {
    [XmlElement("Amount")]
    public decimal Amount { get; set; }
    [XmlElement("Commodity")]
    public Commodity[] Commodity { get; set; }
}

