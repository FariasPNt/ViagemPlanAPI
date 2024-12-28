using ViagemPlanAPI.Application.DTOs.AtividadesDTOs;

namespace ViagemPlanAPI.Application.Services.Interfaces;

public interface IAtividadeService
{
    Task<AtividadeDto?> GetByIdAsync(int id);
    Task<IEnumerable<AtividadeDto>> GetAllAsync();
    Task<AtividadeDto> CreateAsync(CreateAtividadeDto atividadeDto);
    Task<AtividadeDto?> UpdateAsync(int id, UpdateAtividadeDto atividadeDto);
    Task<bool> DeleteAsync(int id);
}
