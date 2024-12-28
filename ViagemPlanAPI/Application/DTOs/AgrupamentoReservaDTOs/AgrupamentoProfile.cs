using AutoMapper;
using ViagemPlanLibrary.Domain.Entities;

namespace ViagemPlanAPI.Application.DTOs.AgrupamentoReservaDTOs;

public class AgrupamentoProfile : Profile
{
    public AgrupamentoProfile()
    {
        CreateMap<AgrupamentoReservas, AgrupamentoReservaDto>()
            .ForMember(dest => dest.CustoTotal, opt => opt.MapFrom(src => src.CalcularCustoTotal()))
            .ForMember(dest => dest.TotalDiarias, opt => opt.MapFrom(src => src.CalcularTotalDiarias()));
        CreateMap<CreateAgrupamentoReservaDto, AgrupamentoReservas>();
        CreateMap<UpdateAgrupamentoDto, AgrupamentoReservas>();
    }
}
