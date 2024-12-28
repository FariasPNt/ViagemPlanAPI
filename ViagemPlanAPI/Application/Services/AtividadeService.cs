using AutoMapper;
using ViagemPlanAPI.Application.DTOs.AtividadesDTOs;
using ViagemPlanAPI.Application.Services.Interfaces;
using ViagemPlanLibrary.Domain.Entities;
using ViagemPlanLibrary.Domain.Interfaces;

namespace ViagemPlanAPI.Application.Services;

public class AtividadeService : IAtividadeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AtividadeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AtividadeDto?> GetByIdAsync(int id)
    {
        var repository = _unitOfWork.GetRepository<Atividade>();
        var atividade = await repository.GetAsync(a => a.Id == id);

        return atividade == null ? null : _mapper.Map<AtividadeDto>(atividade);
    }

    public async Task<IEnumerable<AtividadeDto>> GetAllAsync()
    {
        var repository = _unitOfWork.GetRepository<Atividade>();
        var atividades = await repository.GetAllAsync();

        return _mapper.Map<IEnumerable<AtividadeDto>>(atividades);
    }

    public async Task<AtividadeDto> CreateAsync(CreateAtividadeDto atividadeDto)
    {
        var repository = _unitOfWork.GetRepository<Atividade>();
        var atividade = _mapper.Map<Atividade>(atividadeDto);

        await repository.AddAsync(atividade);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<AtividadeDto>(atividade);
    }

    public async Task<AtividadeDto?> UpdateAsync(int id, UpdateAtividadeDto atividadeDto)
    {
        var repository = _unitOfWork.GetRepository<Atividade>();
        var atividade = await repository.GetAsync(a => a.Id == id);

        if (atividade == null)
            return null;

        _mapper.Map(atividadeDto, atividade);
        repository.Update(atividade);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<AtividadeDto>(atividade);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var repository = _unitOfWork.GetRepository<Atividade>();
        var atividade = await repository.GetAsync(a => a.Id == id);

        if (atividade == null)
            return false;

        await repository.DeleteAsync(atividade);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
