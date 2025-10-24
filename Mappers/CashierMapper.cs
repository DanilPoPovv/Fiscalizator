using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Mappers
{
    public class CashierMapper
    {
        public Cashier MapToModel(CashierDTO cashierDTO)
        {
            return new Cashier
            {
                Name = cashierDTO.Name
            };
        }
    }
}
