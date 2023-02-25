using PersonService.BLL.DTO;
using PersonService.Common.Security;

namespace PersonService.BLL.Contract;

public interface IUserService
{
    bool IsValidUser(string userName, string password, string email, int age);

    bool HasAccessPoint(string userName, AccessPoint accessPoint);

    Task<Guid> Create(UserDto user, CancellationToken cancellationToken);

    Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken);

    Task<IEnumerable<UserDto>> UpdateUser(CancellationToken cancellationToken);

    object GetUsers();

    void UpdateUser(UserDto user);
} 