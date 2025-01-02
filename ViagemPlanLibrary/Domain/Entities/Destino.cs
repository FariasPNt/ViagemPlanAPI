using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagemPlanLibrary.Domain.Entities;

public class Destino
{
    public int IdDestino { get; set; }
    public string Cidade { get; set; }
    public string Pais { get; set; }
    public Participantes? Participantes { get; set; }
    public Reserva? Reserva { get; set; }
    public PacoteAtividades? PacoteAtividades { get; set; }

    public decimal CalcularCustoDestino()
    {
        var custoReserva = Reserva?.CalcularCustoReserva() ?? 0;
        var custoAtividades = PacoteAtividades?.CalcularCustoTotalAtividade() ?? 0;
        return custoReserva + custoAtividades;
    }

    public override string ToString()
    {
        return $"{Cidade}, {Pais} | Custo Total: R$ {CalcularCustoDestino():F2}";
    }
}
