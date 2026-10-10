using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductModule.Domain.Abstractions;
using ProductModule.Domain.Models;
using ProductModule.Infrastructure.Context;
using ProductModule.Infrastructure.Repository;

namespace ProductModule.Infrastructure;

public static class InfrastrucutreDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string dbConnectionString)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(dbConnectionString));

        services.AddScoped<IRepository<Product>, ProductRepository>();
        services.AddScoped<IRepository<Category>, CategoryRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}