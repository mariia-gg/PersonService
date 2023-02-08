using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PesonService.DAL.Entity;

[Index(nameof(UserName), IsUnique = true)]
public class UserEntity : BaseEntity
{
    public string Password { get; set; } = string.Empty;

    [MaxLength(255)]
    public string UserName { get; set; } = string.Empty;

    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    public int Age { get; set; }

    public ICollection<UserAccessPointEntity> UserAccessPoints { get; set; }
}