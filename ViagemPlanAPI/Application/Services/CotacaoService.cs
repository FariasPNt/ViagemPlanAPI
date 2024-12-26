using ViagemPlanLibrary.Domain.Interfaces;

namespace ViagemPlanAPI.Application.Services;

public class CotacaoService
{
    private readonly ICotacaoRepository _cotacaoRepository;

    public CotacaoService(ICotacaoRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }

    public async Task<decimal> ObterTaxaDeConversao(string moedaDestino)
    {
        return await _cotacaoRepository.ObterCotacaoPara(moedaDestino);
    }
}
