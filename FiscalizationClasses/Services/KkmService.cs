using Fiscalizator.FiscalizationClasses.Dto.Kkm;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
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
        private readonly ValidatorManager<KkmDTO,KkmCrudDataAccessor, KkmValidationContext> _validator;
        private readonly ValidatorManager<KkmUpdateDTO, KkmCrudDataAccessor, KkmValidationContext> _validatorUpdate;
        private readonly ValidatorManager<KkmDeleteDTO, KkmCrudDataAccessor, KkmValidationContext> _validatorDelete;
        private readonly KkmRepository _kkmRepository;
        private readonly ClientRepository _clientRepository;
        private readonly KkmCrudDataAccessor _dataAccessor;

        public KkmService(ValidatorManager<KkmDTO, KkmCrudDataAccessor, KkmValidationContext> validator, 
            ValidatorManager<KkmUpdateDTO, KkmCrudDataAccessor, KkmValidationContext> updateValidator, ValidatorManager<KkmDeleteDTO, KkmCrudDataAccessor, KkmValidationContext> validatorDelete)
        {
            _session = NHibernateHelper.OpenSession();
            _validator = validator;
            _validatorUpdate = updateValidator;
            _kkmRepository = new KkmRepository(_session);
            _clientRepository = new ClientRepository(_session);
            _validatorDelete = validatorDelete;
            _dataAccessor = new KkmCrudDataAccessor(_session);
        }

        public void AddKkm(KkmDTO kkmDTO)
        {
            var validationContext = new KkmValidationContext();

            _validator.ValidateAll(kkmDTO, _dataAccessor, validationContext);
            var kkm = _kkmMapper.Map(kkmDTO);
            kkm.Client = _clientRepository.GetByCode(kkmDTO.ClientCode);
            using (var transaction = _session.BeginTransaction())
            {
                _kkmRepository.Add(kkm);
                _session.Flush();

                Counter counter = new Counter(kkm);
                _session.Save(counter);

                transaction.Commit();
            }
        }
        public void UpdateKkm(KkmUpdateDTO kkmDTO)
        {
            var validationContext = new KkmValidationContext();
            _validatorUpdate.ValidateAll(kkmDTO, _dataAccessor, validationContext);
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
        public void DeleteKkm(KkmDeleteDTO deleteDTO) 
        {
            var validationContext = new KkmValidationContext();
            _validatorDelete.ValidateAll(deleteDTO, _dataAccessor, validationContext);
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
