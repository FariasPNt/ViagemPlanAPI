using ViagemPlanAPI.Application.DTOs.ReservaDTOs;
using ViagemPlanAPI.Application.Services;
using ViagemPlanAPI.Application.Services.Interfaces;
using ViagemPlanAPI.Infrastructure.Repositories;
using ViagemPlanLibrary.Domain.Interfaces;

namespace ViagemPlanAPI.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddHttpClient<ApiCotacaoRepository>();
        services.AddScoped<ICotacaoRepository, ApiCotacaoRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IReservaService, ReservaService>();
        services.AddScoped<IAgrupamentoReservaService, AgrupamentoReservaService>();
        services.AddScoped<IAtividadeService, AtividadeService>();
        services.AddAutoMapper(typeof(ReservaProfile));

        services.AddScoped<CotacaoService>();

        return services;
    }
}
