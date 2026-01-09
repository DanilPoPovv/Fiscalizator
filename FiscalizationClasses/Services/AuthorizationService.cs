using Fiscalizator.FiscalizationClasses.Dto.Authorize;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.OtherClassess;
using Fiscalizator.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

namespace Fiscalizator.FiscalizationClasses.Services
{
    public class AuthorizationService
    {
        private readonly UserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        public AuthorizationService(IPasswordHasher<User> passwordHasher,JwtTokenGenerator jwtTokenGenerator)
        {
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = new UserRepository(NHibernateHelper.OpenSession());
        }
        public string Login(AuthorizeDto authorizeDto)
        {
            User user = _userRepository.GetByLogin(authorizeDto.Username);
            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, authorizeDto.Password) != PasswordVerificationResult.Success) 
            {
                throw new UnauthorizedAccessException();
            }
            return _jwtTokenGenerator.Generate(user);
        }
        public User CreateUser(CreateUserDto createUserDto)
        {
            User user = new User
            {
                Username = createUserDto.Username,
                PasswordHash = _passwordHasher.HashPassword(null, createUserDto.Password),
                Role = createUserDto.Role,
            };
            _userRepository.Add(user);
            return user;
        }
    }
}
