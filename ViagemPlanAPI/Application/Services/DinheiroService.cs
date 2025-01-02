using System.Security.Cryptography.X509Certificates;
using ViagemPlanAPI.Application.Services.Interfaces;
using ViagemPlanLibrary.Domain.Entities;
using ViagemPlanLibrary.Domain.Interfaces;

namespace ViagemPlanAPI.Application.Services;

public class DinheiroService : IDinheiroService
{
    public Dinheiro AdicionarValor(Dinheiro saldoAtual, Dinheiro valorAdicionar)
    {
        if (!saldoAtual.Moeda.Equals(valorAdicionar.Moeda))
        {
            throw new InvalidOperationException("As moedas devem ser iguais para adicionar valores.");

        }

        var novoValor = saldoAtual.Valor + valorAdicionar.Valor;
        return new Dinheiro(novoValor, saldoAtual.Moeda);

    }

    public async Task<Dinheiro> AdicionarValorAsync(Dinheiro saldoAtual, Dinheiro valorAdicionar, ICotacaoRepository cotacaoRepository)
    {
        Dinheiro valorConvertido = valorAdicionar;

        if (!saldoAtual.Moeda.Equals(valorAdicionar.Moeda))
        {
            var taxaDeConversao = await cotacaoRepository.ObterCotacaoPara(saldoAtual.Moeda.Codigo);
            var valorConvertidoDecimal = valorAdicionar.Valor * taxaDeConversao;
            valorConvertido = new Dinheiro(valorConvertidoDecimal, saldoAtual.Moeda);
        }

        var novoValor = saldoAtual.Valor + valorConvertido.Valor;
        return new Dinheiro(novoValor, saldoAtual.Moeda);
    }
}
