﻿using Microsoft.Extensions.DependencyInjection;
using PersonService.DAL.Repository;
using PesonService.DAL;
using PesonService.DAL.Contract;
using PesonService.DAL.Entity;
using PesonService.DAL.Repository;

namespace PersonService;

public static class DependecyInjectionDAL
{
    public static void AddDalServices(this IServiceCollection services)
    {
        services.AddDbContext<PersonServiceDbContext>();
        services.AddScoped<IRepository<PersonEntity>, DefaultRepository<PersonEntity>>();
        services.AddScoped<IRepository<UserEntity>, UserRepository>();
    }
}