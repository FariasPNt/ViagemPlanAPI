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
        decimal custoReservas = AgrupamentoReservas?.CalcularCustoTotal() ?? 0;
        decimal custoDestino = Destinos.Sum(d => d.CalcularCustoDestino());
        return custoReservas + custoDestino;
    }

    public void AdicionarDestino(Destino destino)
    {
        if(destino == null)
            throw new ArgumentNullException(nameof(destino));
        Destinos.Add(destino);
    }

    public void RemoverDestino(Destino destino)
    {
        if(destino == null) 
            throw new ArgumentNullException(nameof(destino));
        
        Destinos.Remove(destino);
    }

    public override string ToString()
    {
        return $"{Nome} | Total de Destinos: {Destinos.Count} | Custo Total: R$ {CalcularCustoTotalViagem():F2}";
    }
}
