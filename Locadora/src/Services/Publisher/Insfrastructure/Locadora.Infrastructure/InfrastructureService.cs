using Locadora.Application.Contracts;
using Locadora.Infrastructure.Context;
using Locadora.Infrastructure.Respositories;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.Infrastructure;

public static class InfrastructureService
{
    public static IServiceCollection AddWriteInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<LocadoraWriteContext>();
        services.AddScoped<IDvdsWriteRepository, DvdWriteRepository>();
        services.AddScoped<IDirectorsWriteRepository, DirectorsWriteRepository>();

        return services;
    }
}
