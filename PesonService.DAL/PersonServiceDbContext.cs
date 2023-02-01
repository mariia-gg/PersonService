using Microsoft.EntityFrameworkCore;
using PesonService.DAL.Entity;

namespace PesonService.DAL
{
    public class PersonServiceDbContext : DbContext
    {
        public PersonServiceDbContext() : base()
        {
            Database.EnsureCreated();
        }

        public DbSet<PersonEntity> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=PersonService;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
