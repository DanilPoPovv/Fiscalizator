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
        private readonly IValidator<KkmDTO, KkmValidationContext> _validator;
        private readonly IValidator<KkmUpdateDTO,KkmValidationContext> _validatorUpdate;
        private readonly KkmRepository _kkmRepository;
        private readonly ClientRepository _clientRepository;

        public KkmService(IValidator<KkmDTO, KkmValidationContext> validator, IValidator<KkmUpdateDTO,KkmValidationContext> updateValidator)
        {
            _session = NHibernateHelper.OpenSession();
            _validator = validator;
            _validatorUpdate = updateValidator;
            _kkmRepository = new KkmRepository(_session);
            _clientRepository = new ClientRepository(_session);
        }

        public void AddKkm(int clientCode, KkmDTO kkmDTO)
        {
            var validationContext = new KkmValidationContext();

            _validator.Validate(kkmDTO, _session, validationContext);

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
            _validatorUpdate.Validate(kkmDTO, _session, validationContext);
            var kkm = validationContext.Client.Kkms.FirstOrDefault(k => k.SerialNumber == kkmDTO.OldSerialNumber);
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
