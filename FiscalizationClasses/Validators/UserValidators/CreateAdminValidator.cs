using Fiscalizator.FiscalizationClasses.Dto.User;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using System.ComponentModel.DataAnnotations;

namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class CreateAdminValidator : IValidator<CreateAdminDto, UserDataAccessor, UserValidationContext>
    {
        public void Validate(CreateAdminDto createGlobalUserDto, UserDataAccessor userDataAccessor, UserValidationContext userValidationContext)
        {
            if (userDataAccessor.Users.GetByUserName(createGlobalUserDto.UserName) != null)
            {
                throw new ValidationException("Username is already taken.");
            }
        }
    }
}
