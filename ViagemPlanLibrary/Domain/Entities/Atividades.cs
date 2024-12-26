using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagemPlanLibrary.Domain.Entities;

public class Atividade
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }

    public override string ToString()
    {
        return $"{Nome} - {Descricao} (R$ {Preco:F2})";
    }
}
