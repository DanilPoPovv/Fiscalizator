using Fiscalizator.FiscalizationClasses.Dto.Kkm;
using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Mappers
{
    public class KkmMapper
    {
        public Kkm Map(KkmDTO dto)
        {
            return new Kkm
            {
                SerialNumber = dto.SerialNumber,
                Location = dto.Location
            };
        }
    }
    }
