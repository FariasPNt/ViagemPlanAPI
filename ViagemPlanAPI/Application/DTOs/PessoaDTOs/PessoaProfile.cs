using AutoMapper;
using ViagemPlanLibrary.Domain.Entities;

namespace ViagemPlanAPI.Application.DTOs.PessoaDTOs;

public class PessoaProfile : Profile
{
    public PessoaProfile()
    {
        CreateMap<Pessoa, PessoaDto>();
        CreateMap<CreatePessoaDto, Pessoa>();
        CreateMap<UpdatePessoaDto, Pessoa>();
    }
}
