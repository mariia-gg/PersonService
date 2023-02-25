using Microsoft.EntityFrameworkCore;
using PesonService.DAL;
using PesonService.DAL.Entity;
using PesonService.DAL.Repository;

namespace PersonService.DAL.Repository;

public class UserRepository : DefaultRepository<UserEntity>
{
    public UserRepository(PersonServiceDbContext dbContext) : base(dbContext)
    {
    }

    public override IQueryable<UserEntity> GetAll()
    {
        return base.GetAll()
            .Include(u => u.UserAccessPoints)
            .ThenInclude(uap => uap.AccessPoint);
    }
}