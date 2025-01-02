using ViagemPlanLibrary.Domain.Entities;

namespace ViagemPlanAPI.Application.Services.Interfaces;

public interface IViagemService
{
    decimal CalcularCustoTotalViagem(Viagem viagem);
    Task AdicionarDestinoAsync(Viagem viagem, Destino destino);
    Task RemoverDestinoAsync(Viagem viagem, Destino destino);
    Task<IEnumerable<Viagem>> ListarViagemAsync();
}
