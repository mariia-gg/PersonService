using System.ComponentModel.DataAnnotations;
using PesonService.DAL.Entity;

namespace PersonService.Model;

public class UserCreationViewModel : BaseEntity
{
    [Required]
    public string? Password { get; set; }

    [Required]
    public string? UserName { get; set; }

    [Required]
    public string? Email { get; set; }


    public int Age { get; set; }
}