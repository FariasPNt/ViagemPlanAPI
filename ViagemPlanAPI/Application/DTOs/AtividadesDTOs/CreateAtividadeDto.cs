namespace ViagemPlanAPI.Application.DTOs.AtividadesDTOs;

public class CreateAtividadeDto
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao {  get; set; } = string.Empty;  
    public decimal Preco { get; set; }
}
