using AutoMapper;
using ViagemPlanLibrary.Domain.Entities;

namespace ViagemPlanAPI.Application.DTOs.PacoteAtividadesDTOs;

public class PacoteAtividadesProfile : Profile
{
    public PacoteAtividadesProfile()
    {
        CreateMap<PacoteAtividades, PacoteAtividadeDto>();
        CreateMap<CreatePacoteAtividadeDto, PacoteAtividades>();
        CreateMap<UpdatePacoteAtividadeDto, PacoteAtividades>();
    }
}
