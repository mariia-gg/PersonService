using PesonService.DAL.Entity;
using System.ComponentModel.DataAnnotations;

namespace PersonService.Model
{
    public class UserCreationViewModel : BaseEntity
    {
        [Required]
        public string? Password { get; set; }

        [Required]
        public string? UserName { get; set; }
    }
}
