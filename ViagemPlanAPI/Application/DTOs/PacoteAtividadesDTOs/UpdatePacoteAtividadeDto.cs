namespace ViagemPlanAPI.Application.DTOs.PacoteAtividadesDTOs;

public class UpdatePacoteAtividadeDto
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public List<int> AtividadesIds { get; set; } = new();
}
