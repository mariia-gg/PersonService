using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonService.BLL.Contract;
using PersonService.Configuration;
using PersonService.Helpers;
using PersonService.Model;

namespace PersonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly IUserService _userService;
        private readonly ISecurityHelper _securityHelper;

        public SecurityController(JwtConfiguration jwtConfiguration, 
            IUserService userService,
            ISecurityHelper securityHelper)
        {
            _jwtConfiguration = jwtConfiguration;
            _userService = userService;
            _securityHelper = securityHelper;
        }

        [AllowAnonymous]
        [HttpPost("createToken")]
        public async Task<IResult> GenerateToken(TokenRequestViewModel user, CancellationToken cancellationToken)
        {
            if (await _userService.IsValidUser(user.UserName, user.Password, cancellationToken))
            {
                var token = _securityHelper.GetJwtToken(user.UserName);

                return Results.Ok(token);
            }

            return Results.Unauthorized();
        }
    }
}
