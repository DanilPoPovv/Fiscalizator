using Fiscalizator.FiscalizationClasses.Dto.Pagination;
using Fiscalizator.FiscalizationClasses.Dto.User;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using ISession = NHibernate.ISession;

namespace Fiscalizator.FiscalizationClasses.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ValidatorManager<CreateAdminDto, UserDataAccessor, UserValidationContext> _createAdminValidator;
        private readonly ValidatorManager<CreateClientUserDto, UserDataAccessor, UserValidationContext> _createClientUserValidator;
        private readonly ValidatorManager<UpdateAdminDto, UserDataAccessor, UserValidationContext> _updateAdminValidator;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly UserDataAccessor _userDataAccessor;
        private readonly UserValidationContext _userValidationContext;
        private readonly ISession _session;
        public UserService(
            IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher,
            ValidatorManager<CreateAdminDto, UserDataAccessor, UserValidationContext> createAdminValidator,
            ValidatorManager<CreateClientUserDto, UserDataAccessor, UserValidationContext> createClientUserValidator,
            ValidatorManager<UpdateAdminDto, UserDataAccessor, UserValidationContext> updateAdminValidator,
            UserDataAccessor userDataAccessor,
            UserValidationContext userValidationContext,
            ISession session
            )
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _createAdminValidator = createAdminValidator;
            _createClientUserValidator = createClientUserValidator;
            _userDataAccessor = userDataAccessor;
            _userValidationContext = userValidationContext;
            _session = session;
            _updateAdminValidator = updateAdminValidator;
        }
        public PagedResult<User> SearchAdmins(UserSearchFilterDto userSearchDto)
        {
            var users = _userRepository.SearchAdmins(userSearchDto);
            return new PagedResult<User>
            {
                Items = users.Items,
                TotalCount = users.TotalCount,
                Page = userSearchDto.Page,
                PageSize = userSearchDto.PageSize
            };

        }
        public User CreateAdmin(CreateAdminDto createUserDto)
        {
            _createAdminValidator.ValidateAll(createUserDto, _userDataAccessor, _userValidationContext);
            var user = CreateUser(createUserDto);
            _userRepository.Add(user);
            user = _userRepository.GetByUserName(user.Name);
            return user;
        }
        public User UpdateAdmin(UpdateAdminDto updateAdminDto)
        {
            _updateAdminValidator.ValidateAll(updateAdminDto, _userDataAccessor, _userValidationContext);

            var user = _userValidationContext.User;
            using var transaction = _session.BeginTransaction();
            if (!string.IsNullOrWhiteSpace(updateAdminDto.UserName))
                user.Name = updateAdminDto.UserName;

            if (!string.IsNullOrEmpty(updateAdminDto.UserEmail))
                user.Email = updateAdminDto.UserEmail;

            if (!string.IsNullOrEmpty(updateAdminDto.NewPassword))
                user.PasswordHash = _passwordHasher.HashPassword(user, updateAdminDto.NewPassword);

            _userRepository.Update(user);
            transaction.Commit();
            return user;
        }
        public void DeleteUser(UserDeleteDto userDeleteDto)
        {
            using var transaction = _session.BeginTransaction();
            var user = _userRepository.GetById(userDeleteDto.Id);
            if (user == null)
                throw new Exception("User not found");
            _userRepository.Delete(user);

            transaction.Commit();
        }
        private User CreateUser(BaseCreateUser request)
        {   
            User newUser = new User
            {
                Name = request.UserName,
                PasswordHash = _passwordHasher.HashPassword(null, request.Password),
                Email = request.Email
            };

            return newUser;
        }
    }
}
