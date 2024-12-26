using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagemPlanLibrary.Domain.Entities;

public class Viagem
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<Destino> Destinos { get; set; } = new List<Destino>();
    public AgrupamentoReservas? AgrupamentoReservas { get; set; }

    public decimal CalcularCustoTotalViagem()
    {
        decimal custoReservas = AgrupamentoReservas.CalcularCustoTotal();
        decimal custoAtividades = Destinos.Sum(d => d.PacoteAtividades.CalcularCustoTotalAtividade());
        return custoReservas + custoAtividades;
    }
}
