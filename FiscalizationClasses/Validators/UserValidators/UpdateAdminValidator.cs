using Fiscalizator.FiscalizationClasses.Dto.User;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Microsoft.AspNetCore.Identity;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators;


    public class UpdateAdminValidator : IValidator<UpdateAdminDto,UserDataAccessor, UserValidationContext>
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        public UpdateAdminValidator(IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public void Validate(UpdateAdminDto updateAdminDto, UserDataAccessor userDataAccessor, UserValidationContext userValidationContext)
        {
            IsAdminNameAlreadyTaken(updateAdminDto.Name, userDataAccessor);

            if(!string.IsNullOrWhiteSpace(updateAdminDto.OldPassword) && !string.IsNullOrWhiteSpace(updateAdminDto.NewPassword))
                {
                var user = userDataAccessor.Users.GetById(updateAdminDto.Id);
                    if(user == null || _passwordHasher.VerifyHashedPassword(user,user.PasswordHash, updateAdminDto.OldPassword) != PasswordVerificationResult.Success)
                    {
                        throw new Exception("password is incorrect");
                    }
            userValidationContext.User = user;
                }
            }
    private void IsAdminNameAlreadyTaken(string adminName, UserDataAccessor userDataAccessor)
    {
        if (adminName!= null && userDataAccessor.Users.GetAdminByName(adminName) != null)
        {
            throw new Exception($"Admin with name {adminName} is already exists among admins");
        }
    }
    private bool IsAdminNameModified(int userId, string requestAdminName, UserDataAccessor userDataAccessor, ValidationContext valContext)
    {
        if(userDataAccessor.Clients.GetById(userId))
    }
        }


