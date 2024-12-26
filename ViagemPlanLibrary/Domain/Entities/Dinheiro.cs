using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagemPlanLibrary.Domain.Interfaces;
using ViagemPlanLibrary.Domain.ValueObject;

namespace ViagemPlanLibrary.Domain.Entities;

public class Dinheiro
{
    public decimal Valor { get; private set; }
    public Moeda Moeda { get; private set; }
    public Dinheiro(decimal valor, Moeda moeda)
    {
        if (Valor < 0)
            throw new ArgumentException("O valor não pode ser negativo");

        Valor = valor;
        Moeda = moeda;
    }

    public override string ToString()
    {
        return $"{Moeda.Simbolo}{Valor:F2}";
    }
}
