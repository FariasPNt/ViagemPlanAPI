using ViagemPlanAPI.Application.DTOs.AgrupamentoReservaDTOs;

namespace ViagemPlanAPI.Application.Services.Interfaces;

public interface IAgrupamentoReservaService
{
    Task<AgrupamentoReservaDto?> GetByIdAsync(int id);
    Task<IEnumerable<AgrupamentoReservaDto>> GetAllAsync();
    Task<AgrupamentoReservaDto> CreateAsync(CreateAgrupamentoReservaDto agrupamentoDto);
    Task<AgrupamentoReservaDto?> UpdateAsync(int id, UpdateAgrupamentoDto agrupamentoDto);
    Task<bool> DeleteAsync(int id);
    Task<decimal> CalcularCustoTotalAsync(int id);
    Task<int> CalcularTotalDiariasAsync(int id);
}
