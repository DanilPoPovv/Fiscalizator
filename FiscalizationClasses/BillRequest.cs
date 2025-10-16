using System.Xml.Serialization;

public class BillRequest
    {
    [XmlElement("id")]
    public string Id { get; set; }

    [XmlElement("amount")]
    public decimal Amount { get; set; }
}

