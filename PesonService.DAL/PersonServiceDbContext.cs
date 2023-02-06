using Microsoft.EntityFrameworkCore;
using PersonService.Common.Security;
using PesonService.DAL.Entity;

namespace PesonService.DAL
{
    public class PersonServiceDbContext : DbContext
    {
        public PersonServiceDbContext() : base()
        {
            Database.Migrate();
        }

        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AccessPointEntity> AccessPoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccessPointEntity>().HasData(new[]
            {
                new AccessPointEntity {
                    Id = AccessPointDictionary.GetAccesPointId(AccessPoint.PersonController),
                    ControllerName = "PersonController"
                },
                new AccessPointEntity
                {
                    Id = AccessPointDictionary.GetAccesPointId(AccessPoint.SecurityController),
                    ControllerName = "SecurityController"
                },
                new AccessPointEntity
                {
                    Id = AccessPointDictionary.GetAccesPointId(AccessPoint.UserController),
                    ControllerName = "UserController"
                }
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=PersonService;Trusted_Connection=True;TrustServerCertificate=True");

#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.EnableSensitiveDataLogging();
#endif
        }
    }
}
