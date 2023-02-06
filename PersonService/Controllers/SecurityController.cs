using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonService.Attributes;
using PersonService.BLL.Contract;
using PersonService.Common.Security;
using PersonService.Helpers;
using PersonService.Model;

namespace PersonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequiredAccessPoints(AccessPoint.SecurityController)]
    public class SecurityController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ISecurityHelper _securityHelper;

        public SecurityController(IUserService userService,
            ISecurityHelper securityHelper)
        {
            _userService = userService;
            _securityHelper = securityHelper;
        }

        [AllowAnonymous]
        [HttpPost("createToken")]
        public IResult GenerateToken(TokenRequestViewModel user)
        {
            if (_userService.IsValidUser(user.UserName, user.Password))
            {
                var token = _securityHelper.GetJwtToken(user.UserName);

                return Results.Ok(token);
            }

            return Results.Unauthorized();
        }
    }
}
