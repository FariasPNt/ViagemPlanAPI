using AutoMapper;
using ViagemPlanAPI.Application.DTOs.AgrupamentoReservaDTOs;
using ViagemPlanAPI.Application.Services.Interfaces;
using ViagemPlanLibrary.Domain.Entities;
using ViagemPlanLibrary.Domain.Interfaces;

namespace ViagemPlanAPI.Application.Services;

public class AgrupamentoReservaService : IAgrupamentoReservaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AgrupamentoReservaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AgrupamentoReservaDto?> GetByIdAsync(int id)
    {
        var repository = _unitOfWork.GetRepository<AgrupamentoReservas>();
        var agrupamento = await repository.GetAsync(a => a.Id == id);

        return agrupamento == null ? null : _mapper.Map<AgrupamentoReservaDto>(agrupamento);
    }
    public async Task<IEnumerable<AgrupamentoReservaDto>> GetAllAsync()
    {
        var repository = _unitOfWork.GetRepository<AgrupamentoReservas>();
        var agrupamentos = await repository.GetAllAsync();
        return _mapper.Map<IEnumerable<AgrupamentoReservaDto>>(agrupamentos);
    }
    public async Task<AgrupamentoReservaDto> CreateAsync(CreateAgrupamentoReservaDto agrupamentoDto)
    {
        var repository = _unitOfWork.GetRepository<AgrupamentoReservas>();
        var agrupamentos = _mapper.Map<AgrupamentoReservas>(agrupamentoDto);
        
        await repository.AddAsync(agrupamentos);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<AgrupamentoReservaDto>(agrupamentos);
    }
    public async Task<AgrupamentoReservaDto?> UpdateAsync(int id, UpdateAgrupamentoDto agrupamentoDto)
    {
        var repository = _unitOfWork.GetRepository<AgrupamentoReservas>();
        var agrupamento = await repository.GetAsync(a => a.Id == id);

        if (agrupamento == null)
            return null;

        _mapper.Map(agrupamentoDto, agrupamento);
        repository.Update(agrupamento);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<AgrupamentoReservaDto>(agrupamento);

    }
    public async Task<bool> DeleteAsync(int id)
    {
        var repository = _unitOfWork.GetRepository<AgrupamentoReservas>();
        var agrupamento = await repository.GetAsync(a => a.Id == id);

        if (agrupamento == null)
            return false;

        await repository.DeleteAsync(agrupamento);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<decimal> CalcularCustoTotalAsync(int id)
    {
        var repository = _unitOfWork.GetRepository<AgrupamentoReservas>();
        var agrupamento = await repository.GetAsync(a => a.Id == id);

        if (agrupamento == null)
            throw new KeyNotFoundException($"Agrupamento com ID {id} não encontrado");

        return agrupamento.CalcularTotalDiarias();
    }

    public async Task<int> CalcularTotalDiariasAsync(int id)
    {
        var repository = _unitOfWork.GetRepository<AgrupamentoReservas>();
        var agrupamento = await repository.GetAsync(a => a.Id == id);

        if (agrupamento == null)
            throw new KeyNotFoundException($"Agrupamento com ID {id} não encontrado");

        return agrupamento.CalcularTotalDiarias();
    }


    

}
