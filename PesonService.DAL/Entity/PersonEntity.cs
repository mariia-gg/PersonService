using System.ComponentModel.DataAnnotations;

namespace PesonService.DAL.Entity
{
    public class PersonEntity : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }
    }
}
