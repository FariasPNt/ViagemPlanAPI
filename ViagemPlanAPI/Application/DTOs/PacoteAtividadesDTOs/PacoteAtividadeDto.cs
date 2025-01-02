using ViagemPlanAPI.Application.DTOs.AtividadesDTOs;

namespace ViagemPlanAPI.Application.DTOs.PacoteAtividadesDTOs;

public class PacoteAtividadeDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public List<AtividadeDto> Atividades { get; set; } = new();
    public decimal PrecoTotal { get; set; }
}
