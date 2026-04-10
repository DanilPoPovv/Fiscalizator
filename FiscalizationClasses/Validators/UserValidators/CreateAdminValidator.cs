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
            if (userDataAccessor.Users.GetByUserName(createGlobalUserDto.Name) != null)
            {
                throw new ValidationException("Name is already taken.");
            }
        }
    }
}
