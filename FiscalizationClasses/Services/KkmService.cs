using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.Mappers;
using Fiscalizator.NHibernate;
using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Services
{
    public class KkmService 
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly KkmMapper _kkmMapper = new KkmMapper();
        public KkmService()
        {
            _unitOfWork = new UnitOfWork(NHibernateHelper.OpenSession());   
            _kkmMapper = new KkmMapper();   
        }
        public void AddKKm(int ClientCode, KkmDTO kkmDTO)
        {
            Kkm kkm = _kkmMapper.Map(kkmDTO);
            kkm.Client = _unitOfWork.clientRepository.GetByCode(ClientCode);
            _unitOfWork.kkmRepository.Add(kkm);
            _unitOfWork.Commit();
        }
        public void UpdateKkm(KkmDTO kkmDTO)
        {
            var kkm = _unitOfWork.kkmRepository.GetBySerialNumber(kkmDTO.SerialNumber);
            kkm.Location = kkmDTO.Location;
            _unitOfWork.kkmRepository.Update(kkm);
            _unitOfWork.Commit();
        }
        public void DeleteKkm(KkmDTO kkmDTO) 
        {
            var kkm = _unitOfWork.kkmRepository.GetBySerialNumber(kkmDTO.SerialNumber);
            _unitOfWork.kkmRepository.Delete(kkm);
            _unitOfWork.Commit();   
        }
        public List<Kkm> GetAllClientKkm(int Clientcode)
        {
            List<Kkm> kkms = _unitOfWork.clientRepository.GetAllClientKkm(Clientcode);
            return kkms;
        }
    }
}
