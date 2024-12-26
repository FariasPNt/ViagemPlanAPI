using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json.Serialization;
using ViagemPlanLibrary.Domain.Interfaces;

namespace ViagemPlanAPI.Infrastructure.Repositories;

public class ApiCotacaoRepository : ICotacaoRepository
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string _acessKey;

    public ApiCotacaoRepository(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["CurrencyLayer:BaseUrl"];
        _acessKey = configuration["CurrencyLayer:AccessKey"];
    }

    public async Task<decimal> ObterCotacaoPara(string moeda)
    {
        if (string.IsNullOrWhiteSpace(moeda))
            throw new ArgumentException("Moeda é obrigatória.");

        var url = $"{_baseUrl}?acess_key{_acessKey}&currencies={moeda}&source=BRL&format=1";

        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var cotacaoResponse = JsonConvert.DeserializeObject<CotacaoApiResponse>(content);

        if (cotacaoResponse.Quotes.TryGetValue($"BRL{moeda}", out var taxa))
        {
            return taxa;
        }

        throw new Exception($"Cotação para a moeda {moeda} não encontrada");
    }


        public class CotacaoApiResponse
    {
        public bool Sucess { get; set; }
        public Dictionary<string, decimal> Quotes { get; set; }
    }
}
