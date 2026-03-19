using Fiscalizator.FiscalizationClasses.Dto.Authorize;
using Fiscalizator.FiscalizationClasses.Dto.User;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.OtherClassess;
using Fiscalizator.FiscalizationClasses.Validators.Authorization;
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
        private readonly ValidatorManager<CreateGlobalUserDto, UserDataAccessor, UserValidationContext> _globalUserValidator;
        private readonly UserDataAccessor _userDataAccessor;
        private readonly ISession _session;

        public AuthorizationService(
            IPasswordHasher<User> passwordHasher,
            JwtTokenGenerator jwtTokenGenerator,
            ValidatorManager<CreateClientUserDto, UserDataAccessor, UserValidationContext> clientUserValidator,
            ValidatorManager<CreateGlobalUserDto, UserDataAccessor, UserValidationContext> globalUserValidator)
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

        public User CreateGlobalUser(CreateGlobalUserDto createUserDto)
        {
            UserValidationContext validationContext = new UserValidationContext();
            _globalUserValidator.ValidateAll(createUserDto, _userDataAccessor, validationContext);

            var user = CreateUser(createUserDto);
            _userRepository.Add(user);

            return user;
        }

        public User CreateClientUser(CreateClientUserDto createClientUserDto)
        {
            UserValidationContext validationContext = new UserValidationContext();
            _clientUserValidator.ValidateAll(createClientUserDto, _userDataAccessor, validationContext);

            User user = CreateUser(createClientUserDto);
            user.ClientId = validationContext.Client.Id;

            _userRepository.Add(user);
            return user;
        }

        private User CreateUser(CreateGlobalUserDto request)
        {
            User newUser = new User
            {
                Username = request.Username,
                PasswordHash = _passwordHasher.HashPassword(null, request.Password),
                Role = request.Role,
            };

            return newUser;
        }

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