//using Microsoft.AspNetCore.Authorization;

//namespace Fiscalizator.FiscalizationClasses.Authorization
//{
//    public class GlobalAdminHandler : AuthorizationHandler<GlobalAdminRequirement>
//    {
//        protected override Task HandleRequirementAsync(
//    AuthorizationHandlerContext context,
//    GlobalAdminRequirement requirement)
//        {
//            if (context.User.IsInRole("GlobalAdmin"))
//            {
//                context.Succeed(requirement);
//            }

//            return Task.CompletedTask;
//        }
//    }
//}
