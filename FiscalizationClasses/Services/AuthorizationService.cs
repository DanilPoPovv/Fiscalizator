using Fiscalizator.FiscalizationClasses.Dto.Authorize;
using Fiscalizator.FiscalizationClasses.Dto.User;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.OtherClassess;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.Repository;
using ISession = NHibernate.ISession;
using Microsoft.AspNetCore.Identity;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.Repository.Interfaces;

namespace Fiscalizator.FiscalizationClasses.Services
{
    public class AuthorizationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly ValidatorManager<CreateClientUserDto, UserDataAccessor, UserValidationContext> _clientUserValidator;
        private readonly ValidatorManager<CreateGlobalAdminDto, UserDataAccessor, UserValidationContext> _globalUserValidator;
        private readonly UserDataAccessor _userDataAccessor;
        private readonly ISession _session;

        public AuthorizationService(
            IPasswordHasher<User> passwordHasher,
            JwtTokenGenerator jwtTokenGenerator,
            ValidatorManager<CreateClientUserDto, UserDataAccessor, UserValidationContext> clientUserValidator,
            ValidatorManager<CreateGlobalAdminDto, UserDataAccessor, UserValidationContext> globalUserValidator)
        {
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _session = NHibernateHelper.OpenSession();
            _userRepository = new UserRepository(_session);
            _userDataAccessor = new UserDataAccessor(_session);
            _clientUserValidator = clientUserValidator;
            _globalUserValidator = globalUserValidator;
        }

        public string Login(AuthorizeDto authorizeDto)
        {
            User user = _userRepository.GetByUserName(authorizeDto.Username);
            CheckUserPassword(user, authorizeDto.Password);
            return _jwtTokenGenerator.Generate(user);
        }

        ///TODO : Separate to helper because the same logic have in validators    
        private void CheckUserPassword(User user, string requestPassword)
        {
            if (user == null ||
                _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, requestPassword) != PasswordVerificationResult.Success)
            {
                throw new UnauthorizedAccessException("Password or username is incorrect");
            }
        }
    }
}