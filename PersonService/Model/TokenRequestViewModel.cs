using System.ComponentModel.DataAnnotations;

namespace PersonService.Model;

public class TokenRequestViewModel
{
    [Required]
    public string? Password { get; set; }

    [Required]
    public string? UserName { get; set; }

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public int Age { get; set; }
}