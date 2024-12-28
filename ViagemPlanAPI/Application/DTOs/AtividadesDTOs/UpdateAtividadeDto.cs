namespace ViagemPlanAPI.Application.DTOs.AtividadesDTOs;

public class UpdateAtividadeDto
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}
