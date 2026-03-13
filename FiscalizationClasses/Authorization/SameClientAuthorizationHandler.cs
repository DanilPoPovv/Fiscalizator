using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Fiscalizator.FiscalizationClasses.Authorization
{
    public class SameClientAuthorizationHandler : AuthorizationHandler<SameClientRequirement>
    {
        private readonly ClientRepository _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SameClientAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
        {
            _client = new ClientRepository(NHibernateHelper.OpenSession());
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameClientRequirement requirement)
        {
            ClaimsPrincipal user = context.User;

            if (user.IsInRole(UserRole.GlobalAdmin.ToString()))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            int? userClientId = user.GetClientId();

            if(userClientId == null)
            {
                return Task.CompletedTask;
            }

            var routeValues = _httpContextAccessor.HttpContext?.Request.RouteValues;

            if (!routeValues.TryGetValue("inn", out var innObj))
                return Task.CompletedTask;

            if (!int.TryParse(innObj?.ToString(), out var inn))
                return Task.CompletedTask;
            Client client = _client.GetByCode(inn);
            if (client == null)
            {
                return Task.CompletedTask;
            }
            if (client.Id == userClientId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
