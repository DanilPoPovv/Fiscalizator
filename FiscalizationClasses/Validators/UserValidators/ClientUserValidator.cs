using Fiscalizator.FiscalizationClasses.Dto.User;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using System.ComponentModel.DataAnnotations;

namespace Fiscalizator.FiscalizationClasses.Validators
{
    public class ClientUserValidator : IValidator<CreateClientUserDto, UserDataAccessor, UserValidationContext>
    {
        public void Validate(CreateClientUserDto createClientUserDto, UserDataAccessor userDataAccessor, UserValidationContext userValidationContext)
        {
            if (userDataAccessor.Users.ExistsInClient(createClientUserDto.UserName, userValidationContext.Client.Id))
            {
                throw new ValidationException("Name is already taken.");
            }
            if (createClientUserDto.Role == Entities.UserRole.GlobalAdmin)
            {
                throw new ValidationException("You can not create a Global Admin for Client.");
            }
        }
    }
}
