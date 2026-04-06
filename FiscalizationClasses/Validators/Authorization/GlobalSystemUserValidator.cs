using Fiscalizator.FiscalizationClasses.Dto.User;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using System.ComponentModel.DataAnnotations;

namespace Fiscalizator.FiscalizationClasses.Validators.Authorization
{
    public class GlobalSystemUserValidator : IValidator<CreateGlobalAdminDto,UserDataAccessor,UserValidationContext>
    {
        public void Validate(CreateGlobalAdminDto createGlobalUserDto, UserDataAccessor userDataAccessor, UserValidationContext userValidationContext)
        {
            if(userDataAccessor.Users.GetByUserName(createGlobalUserDto.Username) != null)
            {
                throw new ValidationException("Username is already taken.");
            }
        }
    }
}
