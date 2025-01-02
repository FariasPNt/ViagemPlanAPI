using ViagemPlanAPI.Application.Services.Interfaces;
using ViagemPlanLibrary.Domain.Entities;

namespace ViagemPlanAPI.Application.Services;

public class DestinoService : IDestinoService
{
    private readonly IDestinoService _destinoService;
    
    public DestinoService(IDestinoService destinoService)
    {
        _destinoService = destinoService;
    }
    public async Task<IEnumerable<Destino>> BuscaDestinosPorPaisAsync(string pais)
    {
        if(string.IsNullOrWhiteSpace(pais))
            throw new ArgumentException("O país não pode ser nulo ou vazio", nameof(pais));
        return await _destinoService.BuscaDestinosPorPaisAsync(pais);
    }

    public decimal CalcularCustoDestino(Destino destino)
    {
        return destino.CalcularCustoDestino();
    }
}
