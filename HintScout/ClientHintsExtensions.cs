using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HintScout;

public static class ClientHintsExtensions
{
    public static IServiceCollection AddClientHints(this IServiceCollection services, Action<ClientHintsOptions> configureOptions = null)
    {
        ClientHintsOptions options = new ClientHintsOptions();
        configureOptions?.Invoke(options);

        services.AddSingleton(options);
        services.AddHttpContextAccessor();
        services.AddScoped<IClientHintsService, ClientHintsService>();
        
        return services;
    }

    public static IApplicationBuilder UseClientHints(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ClientHintsMiddleware>();
    }
}