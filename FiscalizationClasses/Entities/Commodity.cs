using System.Xml.Serialization;

namespace Fiscalizator.FiscalizationClasses.Entities
{
    public class Commodity
    {
        public virtual int Id { get; set; }
        public virtual int BillId { get; set; }
        public virtual string Name { get; set; }
        public virtual int Price { get; set; }
        public virtual int Quantity { get; set; }
        public virtual int Sum { get; set; }
        public virtual Tax? Tax { get; set; }
        public virtual string MeasureUnit { get; set; } = "ШТ";
        public virtual Bill Bill { get; set; }
    }
}
