using LuniShop.Module.Products.Core.Domain.Models;
using LuniShop.Module.Products.Core.Infrastructure.Context;
using LuniShop.Module.Products.Core.Infrastructure.Implementations;
using LuniShop.Shared.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LuniShop.Module.Products.Core.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, string databaseConnectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(databaseConnectionString));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IRepository<Product>, ProductRepository>();
        services.AddTransient<IRepository<Category>, CategoryRepository>();

        return services;
    }
}
