using Microsoft.Extensions.DependencyInjection;

namespace ProductModule.Application;

public static class ApplicationDpenedencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationDpenedencyInjection).Assembly));

        return services;
    }
}
