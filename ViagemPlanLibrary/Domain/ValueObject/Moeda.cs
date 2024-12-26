using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagemPlanLibrary.Domain.ValueObject;

public class Moeda
{
    public string Codigo { get; private set; }
    public string Simbolo { get; private set; }
    public decimal FatorConversao { get; private set; }

    public Moeda(string codigo, string simbolo, decimal fatorConversao)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("Código da moeda não pode ser nulo ou vazio");
        if (string.IsNullOrWhiteSpace(simbolo))
            throw new ArgumentException("Símbolo da moeda não pode ser nulo ou vazio");

        Codigo = codigo;
        Simbolo = simbolo;
        FatorConversao = fatorConversao;
    }

    public override bool Equals(object? obj)
    {
        return obj is Moeda moeda && Codigo == moeda.Codigo;
    }

    public override int GetHashCode()
    {
        return Codigo.GetHashCode();
    }
}
