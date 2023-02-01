using PesonService.DAL.Contract;
using System.ComponentModel.DataAnnotations;

namespace PesonService.DAL.Entity
{
    public class PersonEntity : IEntity
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
