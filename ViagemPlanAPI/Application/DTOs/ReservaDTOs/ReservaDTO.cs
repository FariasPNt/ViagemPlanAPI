using ViagemPlanAPI.Application.DTOs.PessoaDTOs;

namespace ViagemPlanAPI.Application.DTOs.ReservaDTOs;

public class ReservaDTO
{
    public Guid Id { get; set; }
    public DateTime DataInicialReserva { get; set; }
    public DateTime DataFimReserva { get; set; }
    public int TotalPessoas { get; set; }
    public decimal PrecoDiaria { get; set; }
    public decimal CustoTotal { get; set; }
    public PessoaDto Pessoa { get; set; }
}
