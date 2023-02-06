using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PersonService.Common.Security;
using PersonService.BLL.Contract;
using PersonService.Helpers;

namespace PersonService.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequiredAccessPointsAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<AccessPoint> _requiredAccessPoints;

        public RequiredAccessPointsAttribute(params AccessPoint[] roles)
        {
            _requiredAccessPoints = roles ?? new AccessPoint[] { };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

            if (allowAnonymous)
                return;

            var userService = context.HttpContext.RequestServices.GetService<IUserService>();
            var securityHelper = context.HttpContext.RequestServices.GetService<ISecurityHelper>();

            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ")[1];

            if (string.IsNullOrEmpty(token))
            {
                goto Unauthorized;
            }

            if (userService == null || securityHelper == null)
            {
                throw new Exception("IUserService or ISecurityHelper wasn't registered in DI.");
            }

            var userName = securityHelper.GetUserName(token);

            if (_requiredAccessPoints.All(rap => userService.HasAccessPoint(userName, rap)))
            {
                return;
            }

            Unauthorized:
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
