using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagemPlanLibrary.Domain.Entities;

public class AgrupamentoReservas
{
    public int Id { get; set; }
    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();



    public decimal CalcularCustoTotal()
    {
        return Reservas.Sum(reserva => reserva.CalcularCustoReserva());
    }

    public int CalcularTotalDiarias()
    {
        return Reservas.Sum(reserva => reserva.CalcularDiarias());
    }
}
