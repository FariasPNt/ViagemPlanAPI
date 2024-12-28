using System.ComponentModel.DataAnnotations;

namespace ViagemPlanAPI.Application.DTOs.ReservaDTOs;

public class CreateReservaDTO
{
    [Required]
    public DateTime DataInicialReserva { get; set; }
    [Required]
    public DateTime DataFimReserva { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "O total de pessoas deve ser, pelo menos, 1")]
    public int TotalPessoas { get; set; }
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço da diária deve ser maior que zero")]
    public decimal PrecoDiaria { get; set; }
    [Required]
    public int PessoaId { get; set; }
}
