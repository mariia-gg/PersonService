using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonService.Attributes;
using PersonService.BLL.Contract;
using PersonService.BLL.DTO;
using PersonService.Common.Security;
using PersonService.Model;

namespace PersonService.Controllers;

[Route("api/[controller]")]
[ApiController]
[RequiredAccessPoints(AccessPoint.UserController)]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    //[HttpGet]
    //public ActionResult<IEnumerable<UserDto>> GetUsers()
    //{
    //    var users = _userService.GetUsers();

    //    return Ok(users);
    //}

    [HttpPost]
    public async Task<IActionResult> Create(UserCreationViewModel user, CancellationToken cancellationToken)
    {
        var userId = await _userService.Create(_mapper.Map<UserDto>(user), cancellationToken);

        return Ok(userId);
    }

    [HttpGet]
    [RequiredAccessPoints(AccessPoint.PersonController)]
    public async Task<IEnumerable<UserCreationViewModel>> GetAll(CancellationToken cancellationToken) =>
        _mapper.Map<IEnumerable<UserCreationViewModel>>(await _userService.GetAllAsync(cancellationToken));


    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, UserDto user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }

        _userService.UpdateUser(user);

        return NoContent();
    }
} 