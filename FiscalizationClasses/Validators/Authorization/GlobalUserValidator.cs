using Fiscalizator.FiscalizationClasses.Dto.User;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using System.ComponentModel.DataAnnotations;

namespace Fiscalizator.FiscalizationClasses.Validators.Authorization
{
    public class GlobalUserValidator : IValidator<CreateGlobalUserDto,UserDataAccessor,UserValidationContext>
    {
        public void Validate(CreateGlobalUserDto createGlobalUserDto, UserDataAccessor userDataAccessor, UserValidationContext userValidationContext)
        {
            if(userDataAccessor.Users.GetByUserName(createGlobalUserDto.Username) != null)
            {
                throw new ValidationException("Username is already taken.");
            }
        }
    }
}
