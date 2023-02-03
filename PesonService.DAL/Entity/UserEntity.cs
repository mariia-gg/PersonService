using System.ComponentModel.DataAnnotations;

namespace PesonService.DAL.Entity
{
    public class UserEntity : BaseEntity
    {
        public string Password { get; set; } = string.Empty;
        [MaxLength(255)]
        public string UserName { get; set; } = string.Empty;

        public ICollection<UserAccessPointEntity> UserAccessPoints { get; set; }
    }
}
