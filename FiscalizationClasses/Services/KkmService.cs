using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
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
        private readonly ValidatorManager<KkmDTO, KkmValidationContext> _validator;
        private readonly ValidatorManager<KkmUpdateDTO, KkmValidationContext> _validatorUpdate;
        private readonly ValidatorManager<KkmDeleteDTO, KkmValidationContext> _validatorDelete;
        private readonly KkmRepository _kkmRepository;
        private readonly ClientRepository _clientRepository;

        public KkmService(ValidatorManager<KkmDTO, KkmValidationContext> validator, 
            ValidatorManager<KkmUpdateDTO,KkmValidationContext> updateValidator, ValidatorManager<KkmDeleteDTO, KkmValidationContext> validatorDelete)
        {
            _session = NHibernateHelper.OpenSession();
            _validator = validator;
            _validatorUpdate = updateValidator;
            _kkmRepository = new KkmRepository(_session);
            _clientRepository = new ClientRepository(_session);
            _validatorDelete = validatorDelete;
        }

        public void AddKkm(KkmDTO kkmDTO)
        {
            var validationContext = new KkmValidationContext();

            _validator.ValidateAll(kkmDTO, _session, validationContext);

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
            _validatorUpdate.ValidateAll(kkmDTO, _session, validationContext);
            var kkm = validationContext.Client.Kkms.FirstOrDefault(k => k.SerialNumber == kkmDTO.SerialNumber);
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
        public void DeleteKkm(KkmDeleteDTO deleteDTO) 
        {
            var validationContext = new KkmValidationContext();
            _validatorDelete.ValidateAll(deleteDTO, _session, validationContext);
            var kkm = _kkmRepository.GetBySerialNumber(deleteDTO.SerialNumber);
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _kkmRepository.Delete(kkm);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Something went wrong while deleting KKM {ex.Message}");
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
