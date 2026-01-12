using Fiscalizator.FiscalizationClasses.Dto.User;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using System.ComponentModel.DataAnnotations;

namespace Fiscalizator.FiscalizationClasses.Validators.Authorization
{
    public class ClientUserValidator : IValidator<CreateClientUserDto,UserDataAccessor,UserValidationContext>
    {
        public void Validate(CreateClientUserDto createClientUserDto, UserDataAccessor userDataAccessor, UserValidationContext userValidationContext)
        {
            if (userDataAccessor.Users.ExistsInClient(createClientUserDto.Username, userValidationContext.Client.Id))
            {
                throw new ValidationException("Username is already taken.");
            }
            if (createClientUserDto.Role == Entities.UserRole.GlobalAdmin)
            {
                throw new ValidationException("You can not creare a Global Admin for Client.");
            }
        }
    }
}
