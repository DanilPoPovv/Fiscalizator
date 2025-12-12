using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Mappers
{
    public class BillMapper
    {
        private readonly CommodityMapper _commodityMapper = new CommodityMapper();

        public Bill MapToModel(BillDTO billDto)
        {
            var bill = new Bill
            {
                Amount = billDto.Amount,
                OperationDateTime = billDto.OperationDateTime,
                Kkm = new Kkm
                {
                    SerialNumber = billDto.SerialNumber
                },
                Payment = new Payment
                {
                    PaymentType = billDto.Payment.PaymentType
                },
                Cashier = new Cashier
                {
                    Name = billDto.Cashier.Name
                },
                
                Commodities = new List<Commodity>(),
            };

            foreach (var item in billDto.Commodity)
            {
                var commodity = _commodityMapper.MapToModel(item, bill);
                bill.Commodities.Add(commodity);
            }

            return bill;
        }
    }

}
