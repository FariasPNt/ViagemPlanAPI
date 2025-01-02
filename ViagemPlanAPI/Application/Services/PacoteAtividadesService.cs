using AutoMapper;
using ViagemPlanAPI.Application.DTOs.PacoteAtividadesDTOs;
using ViagemPlanAPI.Application.Services.Interfaces;
using ViagemPlanLibrary.Domain.Entities;
using ViagemPlanLibrary.Domain.Interfaces;

namespace ViagemPlanAPI.Application.Services;

public class PacoteAtividadesService : IPacoteAtividadesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PacoteAtividadesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PacoteAtividadeDto?> GetByIdAsync(int id)
    {
        var repository = _unitOfWork.GetRepository<PacoteAtividades>();
        var pacote = await repository.GetAsync(p => p.Id == id);
        return pacote == null ? null : _mapper.Map<PacoteAtividadeDto>(pacote);
    }
    public async Task<IEnumerable<PacoteAtividadeDto>> GetAllAsync()
    {
        var repository = _unitOfWork.GetRepository<PacoteAtividades>();
        var pacotes = await repository.GetAllAsync();
        return _mapper.Map<IEnumerable<PacoteAtividadeDto>>(pacotes);
    }
    public async Task<PacoteAtividadeDto> CreateAsync(PacoteAtividadeDto pacoteDto)
    {
        var repository = _unitOfWork.GetRepository<PacoteAtividades>();
        var pacote = _mapper.Map<PacoteAtividades>(pacoteDto);

        pacote.PrecoTotal = pacote.CalcularCustoTotalAtividade();
        await repository.AddAsync(pacote);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<PacoteAtividadeDto>(pacote);
       
    }
    public async Task<PacoteAtividadeDto?> UpdateAsync(int id, UpdatePacoteAtividadeDto pacoteDto)
    {
        var repository = _unitOfWork.GetRepository<PacoteAtividades>();
        var pacote = await repository.GetAsync(p => p.Id == id);

        if (pacote == null) 
        {
            return null;
        }
        _mapper.Map(pacoteDto, pacote);
        pacote.PrecoTotal = pacote.CalcularCustoTotalAtividade();

        repository.Update(pacote);
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<PacoteAtividadeDto>(pacote);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var repository = _unitOfWork.GetRepository<PacoteAtividades>();
        var pacote = await repository.GetAsync(p => p.Id == id);

        if (pacote == null)
            return false;

        await repository.DeleteAsync(pacote);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> AddAtividadeAsync(int pacoteId, int atividadeId)
    {
        var pacoteRepository = _unitOfWork.GetRepository<PacoteAtividades>();
        var atividadeRepository = _unitOfWork.GetRepository<Atividade>();

        var pacote = await pacoteRepository.GetAsync(p => p.Id == pacoteId);
        var atividade = await atividadeRepository.GetAsync(a => a.Id == atividadeId);

        if (pacote == null || atividade == null)
        { return false; }

        pacote.AdicionarAtividade(atividade);
        pacote.PrecoTotal = pacote.CalcularCustoTotalAtividade();

        pacoteRepository.Update(pacote);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveAtividadeAsync(int pacoteId, int atividadeId)
    {
        var pacoteRepository = _unitOfWork.GetRepository<PacoteAtividades>();
        var atividadeRepository = _unitOfWork.GetRepository<Atividade>();

        var pacote = await pacoteRepository.GetAsync(p => p.Id == pacoteId);
        var atividade = await atividadeRepository.GetAsync(a => a.Id == atividadeId);

        if (pacote == null || atividade == null)
        { 
            return false; 
        }

        pacote.RemoverAtividade(atividade);
        pacote.PrecoTotal = pacote.CalcularCustoTotalAtividade();

        pacoteRepository.Update(pacote);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }


}
