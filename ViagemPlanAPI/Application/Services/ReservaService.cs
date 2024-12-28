using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using ViagemPlanAPI.Application.DTOs.ReservaDTOs;
using ViagemPlanAPI.Application.Services.Interfaces;
using ViagemPlanLibrary.Domain.Entities;
using ViagemPlanLibrary.Domain.Interfaces;

namespace ViagemPlanAPI.Application.Services;

public class ReservaService : IReservaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ReservaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReservaDTO>> GetAllReservaAsync()
    {
        var reservas = await _unitOfWork.GetRepository<Reserva>().GetAllAsync();
        return _mapper.Map<IEnumerable<ReservaDTO>>(reservas);
    }
    public async Task<ReservaDTO?> GetReservaByIdAsync(int id)
    {
        var reserva = await _unitOfWork.GetRepository<Reserva>().GetAsync(r => r.ReservaId == id);
        return reserva == null ? null : _mapper.Map<ReservaDTO>(reserva);
    }
    public async Task<ReservaDTO> CreateReservaAsync(CreateReservaDTO createReservaDTO)
    {
        var reserva = _mapper.Map<Reserva>(createReservaDTO);
        var repository = _unitOfWork.GetRepository<Reserva>();

        await repository.AddAsync(reserva);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<ReservaDTO>(reserva);
    }
    public async Task<ReservaDTO?> UpdateReservaAsync(int id, UpdateReservaDto updateReservaDTO)
    {
        var repository = _unitOfWork.GetRepository<Reserva>();
        var reserva = await repository.GetAsync(r => r.ReservaId == id);

        if (reserva == null) 
            return null;

        _mapper.Map(updateReservaDTO, reserva);
        repository.Update(reserva);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<ReservaDTO>(reserva);
    }
    public async Task<bool> DeleteReservaAsync(int id)
    {
        var repository = _unitOfWork.GetRepository<Reserva>();
        var reserva = await repository.GetAsync(r => r.ReservaId == id);

        if (reserva == null)
            return false;
        await repository.DeleteAsync(reserva);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
