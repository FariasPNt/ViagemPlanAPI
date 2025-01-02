using ViagemPlanLibrary.Domain.Entities;

namespace ViagemPlanAPI.Application.Services.Interfaces;

public interface IDestinoService
{
    decimal CalcularCustoDestino(Destino destino);
    Task<IEnumerable<Destino>> BuscaDestinosPorPaisAsync(string pais);
}
