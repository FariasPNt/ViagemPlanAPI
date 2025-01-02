using ViagemPlanAPI.Application.DTOs.PacoteAtividadesDTOs;

namespace ViagemPlanAPI.Application.Services.Interfaces;

public interface IPacoteAtividadesService
{
    Task<PacoteAtividadeDto?> GetByIdAsync(int id);
    Task<IEnumerable<PacoteAtividadeDto>> GetAllAsync();
    Task<PacoteAtividadeDto> CreateAsync(PacoteAtividadeDto pacoteDto);
    Task<PacoteAtividadeDto?> UpdateAsync(int id, UpdatePacoteAtividadeDto pacoteDto);
    Task<bool> DeleteAsync(int id);
    Task<bool> AddAtividadeAsync(int pacoteId, int atividadeId);
    Task<bool> RemoveAtividadeAsync(int pacoteId, int atividadeId);
    
}
