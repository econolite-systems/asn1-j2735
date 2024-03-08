using Microsoft.Extensions.DependencyInjection;

namespace Econolite.Ode.Domain.Asn1.J2735.Extensions;

public static class Defined
{
    public static IServiceCollection AddAsn1J2735Service(this IServiceCollection services)
    {
        services.AddTransient<IAsn1J2735Service, Asn1J2735Service>();

        return services;
    }
}