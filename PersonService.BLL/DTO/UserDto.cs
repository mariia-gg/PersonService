namespace PersonService.BLL.DTO;

public class UserDto
{
    public string Password { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int Age { get; set; }
}