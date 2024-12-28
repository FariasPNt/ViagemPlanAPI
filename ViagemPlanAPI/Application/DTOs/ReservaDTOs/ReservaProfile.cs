using AutoMapper;
using ViagemPlanLibrary.Domain.Entities;

namespace ViagemPlanAPI.Application.DTOs.ReservaDTOs;

public class ReservaProfile : Profile
{
    public ReservaProfile() 
    {
        CreateMap<Reserva, ReservaDTO>()
            .ForMember(dest => dest.CustoTotal, opt => opt.MapFrom(src => src.CalcularCustoReserva()))
            .ForMember(dest => dest.Pessoa, opt => opt.MapFrom(scr => scr.Pessoa));
        CreateMap<CreateReservaDTO, Reserva>();
        CreateMap<UpdateReservaDto, Reserva>();
    }
}
