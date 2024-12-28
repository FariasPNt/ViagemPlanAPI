using AutoMapper;
using ViagemPlanLibrary.Domain.Entities;

namespace ViagemPlanAPI.Application.DTOs.AtividadesDTOs;

public class AtividadeProfile : Profile
{
    public AtividadeProfile()
    {
        CreateMap<Atividade, AtividadeDto>();
        CreateMap<CreateAtividadeDto, Atividade>();
        CreateMap<UpdateAtividadeDto, Atividade>();
    }
}
