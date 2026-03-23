using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces;
using Fiscalizator.Helpers;
using Fiscalizator.Repository;

namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalClientValidator<TRequest,TData,TContext> : IGlobalValidator<TRequest,TData, TContext>
        where TData : IClientDataAccessor
        where TContext : IValidationContext 
        where TRequest : IClientCodeRequire
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GlobalClientValidator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void Validate(TRequest request, TData validationData, TContext validationContext)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userRole = user.GetRole();
            var userClientId = user.GetClientId();
            var client = validationData.Clients.GetByCode(request.ClientCode);
            if (userRole != UserRole.GlobalAdmin.ToString())
            {
                if (userClientId == null || userClientId != client.Id.ToString())
                {
                    throw new Exception("Your account belongs to another client.");
                }
            }
            if (validationContext is IClientValidationContextRequire validationContextClient)
                validationContextClient.Client = client;
        }
    }
}
