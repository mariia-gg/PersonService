using Microsoft.Extensions.DependencyInjection;
using PesonService.DAL;
using PesonService.DAL.Contract;
using PesonService.DAL.Entity;
using PesonService.DAL.Repository;

namespace PersonService
{
    public static class DependecyInjection
    {
        public static void AddDalServices(this IServiceCollection services)
        {
            services.AddDbContext<PersonServiceDbContext>();
            services.AddScoped<IRepository<PersonEntity>, DefaultRepository<PersonEntity>>();
        }
    }
}
