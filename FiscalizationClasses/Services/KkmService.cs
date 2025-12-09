using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.Mappers;
using Fiscalizator.NHibernate;
using Fiscalizator.Repository;
using NHibernate;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Services
{
    public class KkmService
    {
        private readonly ISession _session;
        private readonly KkmMapper _kkmMapper = new KkmMapper();
        private readonly IValidator<KkmDTO, KkmValidationContext> _validator;
        private readonly IValidator<KkmUpdateDTO,KkmValidationContext> _validatorUpdate;
        private readonly KkmRepository _kkmRepository;
        private readonly ClientRepository _clientRepository;

        public KkmService(IValidator<KkmDTO, KkmValidationContext> validator)
        {
            _session = NHibernateHelper.OpenSession();
            _validator = validator;
            _kkmRepository = new KkmRepository(_session);
            _clientRepository = new ClientRepository(_session);
        }

        public void AddKkm(int clientCode, KkmDTO kkmDTO)
        {
            var validationContext = new KkmValidationContext();

            if (!_validator.Validate(kkmDTO, _session, out var errorMessage, validationContext))
            {
                throw new Exception(errorMessage);
            }

            var kkm = _kkmMapper.Map(kkmDTO);
            kkm.Client = validationContext.Client;

            using (var transaction = _session.BeginTransaction())
            {
                _kkmRepository.Add(kkm);
                transaction.Commit();
            }
        }
        public void UpdateKkm(KkmUpdateDTO kkmDTO)
        {
            var validationContext = new KkmValidationContext();
            if (!_validatorUpdate.Validate(kkmDTO, _session, out var errorMessage, validationContext))
            {
                throw new Exception(errorMessage);
            }
            Kkm kkm = validationContext.Kkm;
            kkm.SerialNumber = kkmDTO.NewSerialNumber;
            kkm.Location = kkmDTO.Location;
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _kkmRepository.Update(kkm);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new Exception("Something went wrong while adding KKM");
                }
            }
        }
        public void DeleteKkm(int serialNumber) 
        {
            var kkm = _kkmRepository.GetBySerialNumber(serialNumber);
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _kkmRepository.Delete(kkm);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new Exception("Something went wrong while deleting KKM");
                }
            }
        }
        public List<Kkm> GetAllClientKkm(int Clientcode)
        {
            List<Kkm> kkms = _clientRepository.GetAllClientKkm(Clientcode);
            return kkms;
        }
    }
}
