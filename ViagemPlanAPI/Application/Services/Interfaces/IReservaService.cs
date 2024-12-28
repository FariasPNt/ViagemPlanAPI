using ViagemPlanAPI.Application.DTOs.ReservaDTOs;

namespace ViagemPlanAPI.Application.Services.Interfaces;

public interface IReservaService
{
    Task<IEnumerable<ReservaDTO>> GetAllReservaAsync();
    Task<ReservaDTO?> GetReservaByIdAsync(int id);
    Task<ReservaDTO> CreateReservaAsync(CreateReservaDTO createReservaDTO);
    Task<ReservaDTO?> UpdateReservaAsync(int id, UpdateReservaDto updateReservaDTO);
    Task<bool> DeleteReservaAsync(int id);
}
