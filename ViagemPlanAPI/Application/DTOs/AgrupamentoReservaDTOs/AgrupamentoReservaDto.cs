using ViagemPlanAPI.Application.DTOs.ReservaDTOs;

namespace ViagemPlanAPI.Application.DTOs.AgrupamentoReservaDTOs;

public class AgrupamentoReservaDto
{
    public int Id { get; set; }
    public List<ReservaDTO> Reservas { get; set; } = new List<ReservaDTO>();
    public decimal CustoTotal { get; set; }
    public int TotalDiarias { get; set; }
}
