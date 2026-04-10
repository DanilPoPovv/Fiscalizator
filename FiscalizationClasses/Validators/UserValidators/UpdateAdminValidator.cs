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
            if(updateAdminDto.Name!= null && userDataAccessor.Users.GetAdminByName(updateAdminDto.Name) != null)
            {
                throw new Exception($"Admin with name {updateAdminDto.Name} is already exists among admins");
            }
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
        }

