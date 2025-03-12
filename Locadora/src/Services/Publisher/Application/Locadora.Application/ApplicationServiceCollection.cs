using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.Application;

public static class ApplicationServiceCollection
{
    public static IServiceCollection AddWriteApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
        
        services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}