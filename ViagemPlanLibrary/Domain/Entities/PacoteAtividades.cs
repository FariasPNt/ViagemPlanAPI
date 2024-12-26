using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagemPlanLibrary.Domain.Entities;

public class PacoteAtividades
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public ICollection<Atividade> Atividades { get; set; } = new List<Atividade>();
    public decimal PrecoTotal { get; set; }

    public decimal CalcularCustoTotalAtividade()
    {
        return Atividades.Sum(a => a.Preco);
    }

    public void AdicionarAtividade(Atividade atividade)
    {
        if (atividade == null)
            throw new ArgumentNullException(nameof(atividade));
        Atividades.Add(atividade);
    }

    public void RemoverAtividade(Atividade atividade)
    {
        if (atividade == null)
            throw new ArgumentNullException(nameof(atividade));
        Atividades.Remove(atividade);
    }
    public override string ToString()
    {
        return $"{Nome} - {Descricao} | Total de Atividades: {Atividades.Count} | Preço Total: R$ {CalcularCustoTotalAtividade():F2} ";
    }
}
