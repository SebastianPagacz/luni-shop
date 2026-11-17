using LuniShop.Module.Products.Core.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LuniShop.Module.Products.Core.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string databaseConnectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(databaseConnectionString));

        return services;
    }
}
