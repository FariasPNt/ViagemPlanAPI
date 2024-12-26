using ViagemPlanLibrary.Domain.Entities;
using ViagemPlanLibrary.Domain.Interfaces;
using ViagemPlanLibrary.Domain.ValueObject;

namespace ViagemPlanAPI.Application.Factories;

public class DinheiroFactory
{
    private readonly ICotacaoRepository _cotacaorepository;

    public DinheiroFactory(ICotacaoRepository cotacaorepository)
    {
        _cotacaorepository = cotacaorepository;
    }

    public async Task<Dinheiro> ConverterPara(Dinheiro dinheiro, Moeda moedaDestino)
    {
        if (dinheiro.Moeda.Codigo == moedaDestino.Codigo)
        {
            return dinheiro;
        }

        var taxaDeConversao = await _cotacaorepository.ObterCotacaoPara(moedaDestino.Codigo);
        var valorConvertido = dinheiro.Valor * taxaDeConversao;

        return new Dinheiro(valorConvertido, moedaDestino);
    } 
}
