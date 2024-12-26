using ViagemPlanAPI.Application.Services;
using ViagemPlanAPI.Infrastructure.Repositories;
using ViagemPlanLibrary.Domain.Interfaces;

namespace ViagemPlanAPI.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddHttpClient<ApiCotacaoRepository>();
        services.AddScoped<ICotacaoRepository, ApiCotacaoRepository>();

        services.AddScoped<CotacaoService>();

        return services;
    }
}
