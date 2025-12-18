using Fiscalizator.FiscalizationClasses.Dto.Bill;
using Fiscalizator.FiscalizationClasses.Entities;
using System.Diagnostics.Metrics;

namespace Fiscalizator.Mappers
{
    public class CommodityMapper
    {
        public Commodity MapToModel(CommodityDTO commodityDto,Bill bill)
        {
            return new Commodity
            {
                Name = commodityDto.Name,
                Price = commodityDto.Price,
                Quantity = commodityDto.Quantity,
                Sum = commodityDto.Sum,
                Tax = commodityDto.Tax == null
                ? null
                : new Tax
                 {
                TaxPercent = commodityDto.Tax.Percent,
                TaxType = commodityDto.Tax.TaxType,
                TaxSum = commodityDto.Tax.Sum
                },
                MeasureUnit = commodityDto.MeasureUnit,
                Bill = bill
            };


        }
    }
}
