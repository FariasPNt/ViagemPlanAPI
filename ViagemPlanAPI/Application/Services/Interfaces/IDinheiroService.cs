using ViagemPlanLibrary.Domain.Entities;
using ViagemPlanLibrary.Domain.Interfaces;

namespace ViagemPlanAPI.Application.Services.Interfaces;

public interface IDinheiroService
{
    Dinheiro AdicionarValor(Dinheiro saldoAtual, Dinheiro valorAdicionar);
    Task<Dinheiro> AdicionarValorAsync(Dinheiro saldoAtual, Dinheiro valorAdicionar, ICotacaoRepository cotacaoRepository);
}
